using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Wprowadź ścieżkę do pliku lub katalogu:");
        string path = Console.ReadLine();

        if (File.Exists(path))
        {
            // Jeżeli to plik, wyświetl zawartość
            string content = File.ReadAllText(path);
            Console.WriteLine("Zawartość pliku:");
            Console.WriteLine(content);
        }
        else if (Directory.Exists(path))
        {
            // Jeżeli to katalog, wyświetl zawartość jako lista
            string[] files = Directory.GetFiles(path);
            string[] directories = Directory.GetDirectories(path);

            Console.WriteLine("Zawartość katalogu:");

            Console.WriteLine("Pliki:");
            foreach (var file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }

            Console.WriteLine("Katalogi:");
            foreach (var directory in directories)
            {
                Console.WriteLine(Path.GetFileName(directory));
            }
        }
        else
        {
            // Jeżeli to nowy plik, pobierz wieloliniowy tekst
            Console.WriteLine("Podany plik nie istnieje. Wprowadź tekst. Zakończ wpisując 'END;;':");

            using (StreamWriter writer = File.CreateText(path))
            {
                string line;
                while ((line = Console.ReadLine()) != "END;;")
                {
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Plik został utworzony i zapisany.");
        }
    }
}