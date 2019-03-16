using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListHome
{
    class ArrayListHome
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader reader = new StreamReader("..\\..\\TextFile.txt"))
                {
                    List<string> text = new List<string>();

                    string currentLine;
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        text.Add(currentLine);
                    }

                    Console.WriteLine(string.Join(" ", text));
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ошибка при чтении файла");
            }

            List<int> integers = new List<int> { 1, 2, 3, 4, 4, 6, 7, 8, 5, 10 };

            for (int i = 0; i < integers.Count; i++)
            {
                if (integers[i] % 2 == 0)
                {
                    integers.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine(string.Join(" , ", integers));

            List<int> numbers = new List<int> { 1, 1, 3, 2, 5, 5, 7, 2, 6, 6, 1 };

            List<int> newNumbers = new List<int>();

            foreach (int е in numbers)
            {
                if (!newNumbers.Contains(е))
                {
                    newNumbers.Add(е);
                }
            }

            Console.WriteLine(string.Join(" , ", newNumbers));
        }
    }
}

