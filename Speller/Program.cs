using System;

namespace Speller
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionaryPath = "C:\\Users\\oleks\\source\\repos\\Speller\\Speller\\dictionaries\\large.txt";
            var speller = new Speller();
            bool IsLoad = speller.Load(dictionaryPath);
            if (!IsLoad)
            {
                Console.WriteLine("Could not load" + dictionaryPath);
                return;
            }
            var words = new List<string>();
            string smallPath = "C:\\Users\\oleks\\source\\repos\\Speller\\Speller\\dictionaries\\small.txt";
            using (var reader = new StreamReader(smallPath))
            {
                string word = null;
                while ((word = reader.ReadLine()) != null)
                {
                    words.Add(word);
                }
            }
            Console.WriteLine("\nMISSPELLED WORDS\n");
            foreach (var word in words)
            {
                if (!speller.Check(word)) 
                {
                    Console.WriteLine(word);
                }
            }
            speller.Unload();
        }
    }
}