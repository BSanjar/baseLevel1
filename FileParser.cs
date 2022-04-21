using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baseLevel1
{
    public class FileParser
    {
        public string parseFile(Document doc)
        {
            string text = "";
            try
            {
               
                

                //var doc = new Document(_basePathFileWord);
                DocumentBuilder builder = new DocumentBuilder(doc);

                NodeCollection paragraphs = doc.FirstSection.Body.GetChildNodes(NodeType.Paragraph, true);

                List<HeaderFooter> hfList = new List<HeaderFooter>();
                foreach (Section section in doc.Sections)
                {                   
                    HeaderFooter hf;
                    hf = section.HeadersFooters[HeaderFooterType.HeaderPrimary];
                    
                    //var tr = hf.First();


                    var t2 = section.HeadersFooters.First().ToString(SaveFormat.Text);
                    var t1 = section.HeadersFooters.Last().ToString(SaveFormat.Text);
                    var t3 = paragraphs.First().ToString(SaveFormat.Text);
                    

                    foreach (Paragraph para in doc.GetChildNodes(NodeType.Paragraph, true))
                        Console.WriteLine(para.ToString(SaveFormat.Text));
                    

                    foreach (Run run in doc.GetChildNodes(NodeType.Run, true))
                    {
                        Font font = run.Font;
                        Console.WriteLine(font.Name + "," + font.Size.ToString());
                        Console.WriteLine(run.Text);
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return text;
        }
    }
}
