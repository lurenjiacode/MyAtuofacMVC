using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.Tokenattributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.LuceneNet
{
    public class LuceneHelper
    {
        public static string GetKeyWordSplid(string keywords)
        {
            StringBuilder sb = new StringBuilder();
            //Analyzer analyzer = new PanGuAnalyzer();
            Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);


            TokenStream stream = analyzer.TokenStream(keywords, new StringReader(keywords));
            ITermAttribute ita = null;
            bool hasNext = stream.IncrementToken();
            while (hasNext)
            {
                ita = stream.GetAttribute<ITermAttribute>();
                sb.Append(ita.Term + " ");
                hasNext = stream.IncrementToken();
            }
            return sb.ToString();
        }


    }
}
