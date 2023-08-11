using Speller.Spellers;

namespace Speller
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Dictionaries
            var dictionaryPath = "C:\\Users\\oleks\\source\\repos\\Speller\\Speller\\Dictionaries\\large.txt";
            string smallPath = "C:\\Users\\oleks\\source\\repos\\Speller\\Speller\\Dictionaries\\small.txt";
            #endregion

            #region Speller with HashTable
            var spellerHashTable = new SpellerHashTable();
            bool IsLoad = spellerHashTable.Load(dictionaryPath);
            if (!IsLoad)
            {
                Console.WriteLine("Could not load" + dictionaryPath);
                return;
            }
            var words = new List<string>();

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
                if (!spellerHashTable.Check(word))
                {
                    Console.WriteLine(word);
                }
            }
            spellerHashTable.Unload();
            #endregion

            #region Speller with Trie
            var spellerTrie = new SpellerTrie();
            IsLoad = spellerTrie.Load(dictionaryPath);
            if (!IsLoad)
            {
                Console.WriteLine("Could not load" + dictionaryPath);
                return;
            }
            words = new List<string>();

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
                if (!spellerTrie.Check(word))
                {
                    Console.WriteLine(word);
                }
            }
            spellerTrie.Unload();
            #endregion

        }
    }
}