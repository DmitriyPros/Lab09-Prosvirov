import 'package:audioplayers/audioplayers.dart';
import 'package:flutter/foundation.dart';

/// Owns the music and effects for one game screen.
class SoundService {
  SoundService({
    AudioPlayer Function()? createPlayer,
  }) : _createPlayer =
           createPlayer ?? AudioPlayer.new;

  final AudioPlayer Function() _createPlayer;
  AudioPlayer? _background;
  AudioPlayer? _effect;
  Future<void> _pending = Future.value();
  Future<void>? _disposing;
  bool _ready = false;
  bool _closed = false;
  bool _isMuted = true;
  String? _lastError;

  bool get isMuted => _isMuted;
  String? get lastError => _lastError;

  // Serial execution prevents overlapping init, mute, play and dispose calls.
  // An audio error is reported, but never breaks the game or the next command.
  Future<void> _run(
    Future<void> Function() action,
  ) {
    if (_closed) return Future.value();
    _pending = _pending.then((_) async {
      if (_closed) return;
      try {
        _lastError = null;
        await action();
      } catch (error, stack) {
        _lastError = error.toString();
        debugPrint('Audio error: $error\n$stack');
      }
    });
    return _pending;
  }

  Future<void> _prepare() async {
    if (_ready || _closed) return;
    final music = _background ??= _createPlayer();
    final effect = _effect ??= _createPlayer();

    await music.setAudioContext(
      AudioContext(
        android: const AudioContextAndroid(
          usageType: AndroidUsageType.game,
          contentType: AndroidContentType.music,
          audioFocus: AndroidAudioFocus.gain,
        ),
      ),
    );

    await effect.setAudioContext(
      AudioContext(
        android: const AudioContextAndroid(
          usageType: AndroidUsageType.game,
          contentType:
              AndroidContentType.sonification,
          audioFocus: AndroidAudioFocus.none,
        ),
      ),
    );

    await music.setReleaseMode(ReleaseMode.loop);
    await music.setVolume(0.35);
    await effect.setReleaseMode(ReleaseMode.stop);
    await music.setSource(
      AssetSource('sounds/background.mp3'),
    );
    _ready = true;
  }

  // Preparation only. Playback starts after the user presses the sound button.
  Future<void> init() => _run(_prepare);

  Future<void> setMuted(bool value) {
    if (value) _isMuted = true;
    return _run(() async {
      if (value) {
        _isMuted = true;
        await _background?.pause();
        await _effect?.stop();
      } else {
        await _prepare();
        if (_closed) return;
        await _background!.resume();
        _isMuted = false;
      }
    });
  }

  Future<void> _play(
    String file,
    double volume,
  ) => _run(() async {
    if (_isMuted) return;
    await _prepare();
    if (_closed || _isMuted) return;
    await _effect!.stop();
    await _effect!.play(
      AssetSource('sounds/$file'),
      volume: volume,
    );
  });

  Future<void> playClick() =>
      _play('click.mp3', 0.6);
  Future<void> playWin() => _play('win.mp3', 1);
  Future<void> playLose() =>
      _play('lose.mp3', 0.7);
  Future<void> playJackpot() =>
      _play('jackpot.mp3', 1);

  Future<void> dispose() {
    _closed = true;
    return _disposing ??= _disposePlayers();
  }

  Future<void> _disposePlayers() async {
    await _pending;
    for (final player in [_background, _effect]) {
      try {
        await player?.dispose();
      } catch (error) {
        debugPrint('Audio dispose error: $error');
      }
    }
    _ready = false;
  }
}
