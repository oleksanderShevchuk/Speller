using Speller.Hashtable;
using System.Collections;

namespace Speller.Spellers
{
    public class SpellerHashTable
    {
        public const int SIZE_TABLE = 100;
        private Hashtable<string> HashTable { get; set; }
        public SpellerHashTable()
        {
            HashTable = new Hashtable<string>(SIZE_TABLE);
        }
        public bool Load(string dictionary)
        {
            using (var reader = new StreamReader(dictionary))
            {
                string word = null;
                while ((word = reader.ReadLine()) != null)
                {
                    HashTable.Add(word);
                }
            }
            return true;
        }
        public bool Check(string words)
        {
            return HashTable.Search(words);
        }
        public void Unload()
        {
            HashTable.Unload();
        }
    }
}
