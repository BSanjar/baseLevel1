using baseLevel1.models;
using System;

namespace baseLevel1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input doc file name: ");
            string fileName = Console.ReadLine();
            //string fileName = "doc1";

            FileParser fp = new FileParser();

            Console.WriteLine("");
            Console.WriteLine("parsing file... ");
            MethodResult mr = fp.parseFile(fileName);
            Console.WriteLine(mr.message);
            if (mr.code == 0)
            {
                Console.WriteLine("input text language (example: en): ");
                string fromText = Console.ReadLine();
                Console.WriteLine("input translate language (example: ru): ");
                string toText = Console.ReadLine();

                Console.WriteLine("");
                Console.WriteLine("translating text... ");

                Translator translator = new Translator();
                //временно, пока не будет подписки
                mr.text = mr.text.Replace("Created with an evaluation copy of Aspose.Words. To discover the full versions of our APIs please visit: https://products.aspose.com/words/\r\n\n", "");

                MethodResult result = translator.translateText(mr.text, fromText, toText);
                Console.WriteLine("result: ");
                if (result.code == 0)
                {
                    Console.WriteLine(result.text);
                }
                else
                {
                    Console.WriteLine("can`t translate text, error: " + result.message);
                }
            }
            Console.ReadLine();
        }
    }
}
