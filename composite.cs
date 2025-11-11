using System;
using System.Collections.Generic;

public abstract class FileSystemComponent
{
    protected string _name;

    public FileSystemComponent(string name)
    {
        _name = name;
    }

    public abstract void Display(int depth);

    public virtual void Add(FileSystemComponent component)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(FileSystemComponent component)
    {
        throw new NotImplementedException();
    }

    public virtual FileSystemComponent GetChild(int index)
    {
        throw new NotImplementedException();
    }
}

public class File : FileSystemComponent
{
    public File(string name) : base(name) { }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + " Файл: " + _name);
    }
}

public class Directory : FileSystemComponent
{
    private List<FileSystemComponent> _children = new List<FileSystemComponent>();

    public Directory(string name) : base(name) { }

    public override void Add(FileSystemComponent component)
    {
        _children.Add(component);
    }

    public override void Remove(FileSystemComponent component)
    {
        _children.Remove(component);
    }

    public override FileSystemComponent GetChild(int index)
    {
        return _children[index];
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + " Папка: " + _name);
        foreach (var component in _children)
        {
            component.Display(depth + 2);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(" Система файлов ");

        Console.Write("Введите название корневой папки: ");
        string rootName = Console.ReadLine();
        Directory root = new Directory(rootName);

        Console.Write("Введите имя первого файла: ");
        string file1Name = Console.ReadLine();
        File file1 = new File(file1Name);

        Console.Write("Введите имя второго файла: ");
        string file2Name = Console.ReadLine();
        File file2 = new File(file2Name);

        Console.Write("Введите название вложенной папки: ");
        string subDirName = Console.ReadLine();
        Directory subDir = new Directory(subDirName);

        Console.Write("Введите имя файла внутри вложенной папки: ");
        string subFileName = Console.ReadLine();
        File subFile1 = new File(subFileName);

        root.Add(file1);
        root.Add(file2);
        subDir.Add(subFile1);
        root.Add(subDir);

        Console.WriteLine("\nСтруктура файловой системы:");
        root.Display(1);

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
