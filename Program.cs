using Aspose.Words;
using System;
using System.IO;

namespace baseLevel1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input doc file name: ");
            //string fileName = Console.ReadLine();
            string fileName = "doc1";
            string dir = Directory.GetCurrentDirectory();

            Document doc;
            using (Stream stream = File.OpenRead(dir + "\\" + fileName + ".docx"))
            {
                doc = new Document(stream);
            }
            string text1 = doc.GetText();
            FileParser fp = new FileParser();
            string text = fp.parseFile(doc);
        }


    }
}
