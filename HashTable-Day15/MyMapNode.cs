using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable_Day15
{
    public class KeyValue<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }

        public int freq { get; set; }
    }
    public class MyMapNode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        /// <summary>
        /// Gets the index position from haschcode.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        protected int GetArrayPosition(K key)
        {
            int hash = key.GetHashCode();
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        /// <summary>
        /// Gets the specified key from a linked list.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                    return item.Value;
            }

            return default(V);
        }
        /// <summary>
        /// Adds the specified key and value in the linked list at the specified index.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>()
            { Key = key, Value = value };
            linkedList.AddLast(item);
            Console.WriteLine(item.Key + " " + item.Value);

        }
        /// <summary>
        /// Removes the specified key from the linked list.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
        /// <summary>
        /// Creates a new linked list on the given index
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        public LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        /// <summary>
        /// Displays the key and value inside the linked list
        /// </summary>
        public void Display()
        {
            foreach (var linkedList in items)
            {
                if (linkedList != null)
                    foreach (var element in linkedList)
                    {
                        string res = element.ToString();
                        if (res != null)
                            Console.WriteLine(element.Key + " " + element.Value);
                    }
            }
        }
        /// <summary>
        /// Gets the freqency of each word in the sentence.
        /// </summary>
        /// <param name="value">The value.</param>
        public int GetFreq(V value)
        {
            int freq = 0;
            foreach (LinkedList<KeyValue<K, V>> list in items)
            {
                if (list == null)
                    continue;
                foreach (KeyValue<K, V> obj in list)
                {
                    if (obj.Equals(null))
                        continue;
                    if (obj.Value.Equals(value))
                        freq++;
                }
            }
            Console.WriteLine("Frequency of {0} is {1}", value, freq);
            return freq;
        }
        /// <summary>
        /// Displays the frequency words in large paragraphs.
        /// </summary>
        public void DisplayFrequency()
        {
            foreach (LinkedList<KeyValue<K, V>> list in items)
            {
                if (list == null)
                    continue;
                foreach (KeyValue<K, V> obj in list)
                {
                    if (obj.Equals(null))
                        continue;
                    else
                        obj.freq = GetFreq(obj.Value);
                }
            }
        }
    }
}
