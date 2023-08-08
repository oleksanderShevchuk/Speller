using System.Collections;

namespace Speller.Hashtable
{
    public class Hashtable<T>
    {
        private Item<T>[] items;
        public int Size
        {
            get
            {
                int totalSize = 0;
                foreach (var item in items)
                {
                    totalSize += item.Nodes.Count;
                }
                return totalSize;
            }
        }
        public Hashtable(int size) 
        {
            items = new Item<T>[size];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item<T>(i);
            }
        }
        public void Add(T item)
        {
            var key = GetHash(item);
            items[key].Nodes.Add(item);
        }
        public bool Search(T item)
        {
            var key = GetHash(item);
            return items[key].Nodes.Contains(item);
        }
        private int GetHash(T item)
        {
            int hash = item.GetHashCode() % items.Length;
            if (hash < 0)
            {
                hash += items.Length;
            }
            return hash;
        }
        public void Unload()
        {
            foreach (var item in items)
            {
                item.Nodes.Clear();
            }
        }
    }
}
