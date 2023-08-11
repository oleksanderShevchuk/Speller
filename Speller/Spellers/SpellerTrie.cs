using Speller.Hashtable;
using Speller.Trie;

namespace Speller
{
    public class SpellerTrie
    {
        private Trie<string> Trie { get; set; }
        public SpellerTrie() 
        {
            Trie = new Trie<string>();
        }    
        public bool Load(string dictionary)
        {
            using (var reader = new StreamReader(dictionary))
            {
                string word = null;
                while ((word = reader.ReadLine()) != null)
                {
                    Trie.Add(word, word.Length.ToString());
                }
            }
            return true;
        }
        public bool Check(string words)
        {
            return Trie.TrySearch(words, out var value);
        }
        public void Unload()
        {
            Trie.Unload();
        }
    }
}
