/*Console.Write("Введите слово: ");
string word = Console.ReadLine();

Console.WriteLine($"Длина: {word.Length}");
Console.WriteLine($"Первый символ: {word[0]}");
Console.WriteLine($"Последний символ: {word[word.Length - 1]}");

//Задание 1
Console.Write("Введите слово: ");
String word1 = Console.ReadLine();
String word2 = word1.ToLower();

int c  = 0;
foreach (char s in word2)
{
    if (s == 'а')
    {
        c += 1;
    }
}
Console.WriteLine($"Букв 'а'/'А' в слове {word1}: {c}.");

//Задание 2
Console.Write("Имя файла: ");
string fileName = Console.ReadLine();

string normalizedName = fileName.ToLower();

if (normalizedName.EndsWith(".cs"))
{
    Console.WriteLine("Это файл C#");
}
else if (normalizedName.EndsWith(".png") || normalizedName.EndsWith(".jpg"))
{
    Console.WriteLine("Это изображение");
}
else
{
    Console.WriteLine("Неизвестный тип");
}

if (normalizedName.StartsWith("lab"))
{
    Console.WriteLine("Это лабораторная работа");
}

if (normalizedName.Contains("test"))
{
    Console.WriteLine("Тестовый файл");
}

//Задание 3
Console.Write("Введите фразу: ");
string fraza = Console.ReadLine();

Console.WriteLine(fraza.ToUpper());
Console.WriteLine(fraza.Replace(" ", "_"));
string lowfraza = fraza.ToLower();
if (lowfraza.Contains("стоп"))
{
    Console.WriteLine("Стоп-слово найдено!");
} 

//Задание 4
Console.Write("Введите дату в формате хххх-хх-хх: ");
string data = Console.ReadLine();

string data1 = data.Substring(0, 4); 

string data2 = data.Substring(5, 2);

string data3 = data.Substring(8, 2);

string newdata = data3 + "." + data2 + "." + data1;

Console.WriteLine(newdata);


Console.Write("Введите номер телефона в формате xxxxxxxxxxx: ");
string number = Console.ReadLine();

string num1 = number.Substring(1, 3);

string num2 = number.Substring(4, 3);

string num3 = number.Substring(7, 2);

string num4 = number.Substring(9, 2);

Console.WriteLine($"+7({num1}) {num2}-{num3}-{num4}"); 

//Задание 5. Анализ текста
Console.Write("Введите строку: ");
string f = Console.ReadLine();

Console.WriteLine(f.Length);

int c  = 0;
foreach (char s in f)
{
    if (s == ' ')
    {
        c += 1;
    }
}
Console.WriteLine(c);

string a = "аеёиоуыэюя";
int count  = 0;
foreach (char s in f)
{
    if (a.Contains(s))
    {
        count += 1;
    }
}
Console.WriteLine(count); 

//Задание 6
Console.Write("Введите слово: ");
string word = Console.ReadLine();

string reversed = "";

for (int i = word.Length - 1; i >= 0; i--)
{
    reversed += word[i];
}
Console.WriteLine(reversed);

if (reversed.ToLower() == word.ToLower())
{
    Console.WriteLine("Слово является палиндромом");
} else
{
    Console.WriteLine("Слово не является палиндромом");
} 

//Итоговая задача. «Проверка email»
using System.Drawing;

Console.Write("Введите адрес электронной почты: ");
string post = Console.ReadLine();

int c1 = 0;
if (post.Length >= 5)
{
    c1 += 1;
}

int c2 = 0;
int ca = 0;
foreach (char s in post)
{
    if (s == '@')
    {
        ca += 1;
    }
}
if (ca == 1)
{
    c2 += 1;
}

int c3 = 0;
if (post.EndsWith('@') || post.StartsWith('@'))
{
    c3 = 0;
}
else
{
    c3 += 1;
}

int c4 = 0;
foreach (char g in post)
{
    if (g == ' ')
    {
        c4 += 1;
    }
}

int c5 = 0;
if (post.EndsWith(".ru") || post.EndsWith(".com"))
{
    c5 += 1;
}

if (c1 > 0 && c2 > 0 && c3 > 0 && c4 == 0 && c5 > 0)
{
    Console.WriteLine("Адрес корректен");
    Console.WriteLine(post.ToLower());
}

if (c1 == 0)
{
    Console.WriteLine("Адрес некорректен");
    Console.WriteLine("Длина адреса меньше 5 символов");
}
else if (c2 == 0)
{
    Console.WriteLine("Адрес некорректен");
    Console.WriteLine("В адресе несколько символов '@'");
}
else if (c3 == 0)
{
    Console.WriteLine("Адрес некорректен");
    Console.WriteLine("Адрес начинается или заканчивается на '@'");
}
else if (c4 > 0)
{
    Console.WriteLine("Адрес некорректен");
    Console.WriteLine("В адресе есть пробелы");
}
else if (c5 == 0)
{
    Console.WriteLine("Адрес некорректен");
    Console.WriteLine("Адрес не заканчивается на '.ru' или '.com'");
} 

//Дополнительное задание 
using System.Text;

Console.WriteLine("Введите строку: ");
string fr = Console.ReadLine();
var sb = new StringBuilder();
string a = "аеёиоуыэюя";
foreach (char s in fr)
{
    if (!a.Contains(s))
    {
        sb.Append(s);
    }
}
Console.WriteLine(sb.ToString()); */
