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
            using (StreamReader reader = new StreamReader("..\\..\\TextFile.txt"))
            {
                try
                {
                    string line = reader.ReadToEnd();
                    string[] fileText = line.Split(new string[] { ". " }, StringSplitOptions.RemoveEmptyEntries);

                    List<string> text = new List<string>();

                    foreach (string е in fileText)
                    {
                        text.Add(е);
                    }

                    Console.WriteLine(String.Join(" . ", text));
                }
                catch (FileNotFoundException)
                {
                    throw new FileNotFoundException("file doesn't exist");
                }
            }

            List<int> integers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            for (int i = 0; i < integers.Count; i++)
            {
                if (integers[i] % 2 == 0)
                {
                    integers.RemoveAt(i);
                }
            }

            Console.WriteLine(String.Join(" , ", integers));

            List<int> numbers = new List<int> { 1, 1, 3, 2, 5, 5, 7, 2 };

            List<int> newNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                newNumbers.Add(numbers[i]);

                for (int j = 0; j < newNumbers.Count - 1; j++)
                {
                    if (newNumbers[j] == numbers[i])
                    {
                        newNumbers.RemoveAt(newNumbers.Count - 1);
                    }
                }
            }

            Console.WriteLine(String.Join(" , ", newNumbers));
        }
    }
}
