using System;

namespace HashTable_Day15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------Welcome to Hash Table Prolem---------------");
            MyMapNode<string, string> mapNode = new MyMapNode<string, string>(5);
            Console.WriteLine("Adding KeyValue pair");
            mapNode.Add("0", "Paranoids");
            mapNode.Add("1", "are");
            mapNode.Add("2", "not");
            mapNode.Add("3", "paranoid");
            mapNode.Add("4", "beacuse");
            mapNode.Add("5", "they");
            mapNode.Add("6", "are");
            mapNode.Add("7", "paranoid");
            mapNode.Add("8", "but");
            mapNode.Add("9", "because");
            mapNode.Add("10", "they");
            mapNode.Add("12", "putting");
            mapNode.Add("13", "themselves");
            mapNode.Add("14", "deliberately");
            mapNode.Add("15", "into");
            mapNode.Add("16", "paranoid");
            mapNode.Add("17", "avoidable");
            mapNode.Add("18", "situations");
            mapNode.GetFreq("paranoid");
            mapNode.DisplayFrequency();
            mapNode.RemoveValue("avoidable");
            mapNode.GetFreq("avoidable");
        }
    }
}
