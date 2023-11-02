using System;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

class Program
{
    static string filePath;
    static Figure figure;

    static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к файлу:");
        filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        LoadFile();

        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.F1)
                SaveFile();
        } while (key.Key != ConsoleKey.Escape);
    }

    static void LoadFile()
    {
        string extension = Path.GetExtension(filePath);

        switch (extension)
        {
            case ".txt":
                LoadTextFile();
                break;
            case ".json":
                LoadJsonFile();
                break;
            case ".xml":
                LoadXmlFile();
                break;
            default:
                Console.WriteLine("Неподдерживаемый формат файла.");
                break;
        }
    }

    static void LoadTextFile()
    {
        string[] lines = File.ReadAllLines(filePath);
        if (lines.Length >= 3)
        {
            figure = new Figure
            {
                Name = lines[0],
                Width = int.Parse(lines[1]),
                Height = int.Parse(lines[2])
            };
        }
        else
        {
            Console.WriteLine("Некорректный формат файла.");
        }
    }

    static void LoadJsonFile()
    {
        string json = File.ReadAllText(filePath);
        figure = JsonConvert.DeserializeObject<Figure>(json);
    }

    static void LoadXmlFile()
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Figure));
            figure = (Figure)serializer.Deserialize(reader);
        }
    }

    static void SaveFile()
    {
        string extension = Path.GetExtension(filePath);

        switch (extension)
        {
            case ".txt":
                SaveTextFile();
                break;
            case ".json":
                SaveJsonFile();
                break;
            case ".xml":
                SaveXmlFile();
                break;
            default:
                Console.WriteLine("Неподдерживаемый формат файла для сохранения.");
                break;
        }
    }

    static void SaveTextFile()
    {
        string text = $"{figure.Name}\n{figure.Width}\n{figure.Height}";
        File.WriteAllText(filePath, text);
    }

    static void SaveJsonFile()
    {
        string json = JsonConvert.SerializeObject(figure);
        File.WriteAllText(filePath, json);
    }

    static void SaveXmlFile()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Figure));
            serializer.Serialize(writer, figure);
        }
    }
}

class Figure
{
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
}