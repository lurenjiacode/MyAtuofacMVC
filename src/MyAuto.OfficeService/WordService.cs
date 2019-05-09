using Aspose.Words;
using Aspose.Words.Saving;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using System.Xml;

namespace MyAuto.OfficeService
{
    public class WordService
    {

        public string TiquWord(string sourceWordName)
        {
            string a = String.Empty;
            //Stream stream = new FileStream("aaa");
            //Document doc = new Document(sourceWordName);


            //FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            //byte[] buffer = stream2byte(fs);
            //Stream stream = new MemoryStream(buffer);
            //stream.Seek(0, SeekOrigin.Begin);
            //StreamReader sr = new StreamReader(stream);
            //string line;
            //while ((line = sr.ReadLine()) != null)//读取每一行数据
            //{
            //    Console.WriteLine(line.ToString());
            //}
            

            ////doc.Save(stream,new SaveFormat() saveFormat);
            //doc.Save(stream, SaveFormat.Text);
            //{
            //    StreamReader reader = new StreamReader("temp.doc", Encoding.GetEncoding("gb2312"));
            //    string text = reader.ReadToEnd();
            //    Aspose.Words.Document doc2 = new Aspose.Words.Document();
            //    Aspose.Words.DocumentBuilder builder = new DocumentBuilder(doc);
            //    builder.Write(text);
            //    doc.Save("temp.pdf", SaveFormat.Pdf);
            //    reader.Close();
            //}
            return a;
        }


        /// <summary>
        /// docx
        /// </summary>
        /// <param name="sourceWordName">docx文件目录</param>
        public void Tiqu2(string sourceWordName)
        {
            const string wordmlNamespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

            StringBuilder textBuilder = new StringBuilder();
            using (WordprocessingDocument wdDoc = WordprocessingDocument.Open(sourceWordName, false))
            {
                // Manage namespaces to perform XPath queries.  
                NameTable nt = new NameTable();
                XmlNamespaceManager nsManager = new XmlNamespaceManager(nt);
                nsManager.AddNamespace("w", wordmlNamespace);

                // Get the document part from the package.  
                // Load the XML in the document part into an XmlDocument instance.  
                XmlDocument xdoc = new XmlDocument(nt);
                xdoc.Load(wdDoc.MainDocumentPart.GetStream());

                XmlNodeList paragraphNodes = xdoc.SelectNodes("//w:p", nsManager);
                foreach (XmlNode paragraphNode in paragraphNodes)
                {
                    XmlNodeList textNodes = paragraphNode.SelectNodes(".//w:t", nsManager);
                    foreach (System.Xml.XmlNode textNode in textNodes)
                    {
                        textBuilder.Append(textNode.InnerText);
                    }
                    textBuilder.Append(Environment.NewLine);
                }
            }
            var result = textBuilder.ToString();
        }
    }
}
