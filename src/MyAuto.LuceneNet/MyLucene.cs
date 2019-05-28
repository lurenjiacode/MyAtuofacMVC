using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.LuceneNet
{
    public class MyLucene
    {

        public void myindexer()
        {
            #region //盘古分词
            //Segment.Init();
            //string str = "盘古分词demo2";
            //Segment segment = new Segment();
            //ICollection<WordInfo> words = segment.DoSegment(str);
            #endregion


            Stopwatch sw = new Stopwatch();
            sw.Start();
            IndexWriter writer = null;
            Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            //Analyzer pganalyzer = new PanGuAnalyzer();
            Lucene.Net.Store.Directory dir = FSDirectory.Open(new System.IO.DirectoryInfo("F:\\doc"));
            try
            {
                ////IndexReader:对索引进行读取的类。
                //该语句的作用：判断索引库文件夹是否存在以及索引特征文件是否存在。
                bool isCreate = !IndexReader.IndexExists(dir);
                writer = new IndexWriter(dir, analyzer, isCreate, IndexWriter.MaxFieldLength.UNLIMITED);
                //添加索引
                {
                    Document doc = new Document();
                    //string path = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "F:\\doc\\红楼梦.txt";
                    string path = "F:\\doc\\红楼梦.txt";
                    string text = System.IO.File.ReadAllText(path, Encoding.Default);
                    //Field.Store.YES:表示是否存储原值。只有当Field.Store.YES在后面才能用doc.Get("number")取出值来.Field.Index. NOT_ANALYZED:不进行分词保存
                    doc.Add(new Field("number", 1.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                    // Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS:不仅保存分词还保存分词的距离。
                    doc.Add(new Field("body", text, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS));
                    writer.AddDocument(doc);
                }
                writer.Optimize();
                sw.Stop();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (writer != null)
                    writer.Dispose();
                if (dir != null)
                    dir.Dispose();
            }

        }

        public void mychaxun()
        {

            //if (string.IsNullOrEmpty(this.txtSearch.Text))
            //    MessageBox.Show("请输入搜索的文本");

            string selname = "贾宝玉";

            StringBuilder sb = new StringBuilder();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //索引库目录
            Lucene.Net.Store.Directory dir = FSDirectory.Open(new System.IO.DirectoryInfo("F:\\doc"), new NoLockFactory());
            IndexReader reader = IndexReader.Open(dir, true);
            IndexSearcher search = null;
            try
            {
                search = new IndexSearcher(reader);
                QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "body", new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30));
                Query query = parser.Parse(LuceneHelper.GetKeyWordSplid(selname));
                //执行搜索，获取查询结果集对象  
                TopDocs ts = search.Search(query, null, 1000);
                ///获取命中的文档信息对象  
                ScoreDoc[] docs = ts.ScoreDocs;
                sw.Stop();
                //this.listBox.Items.Clear();
                for (int i = 0; i < docs.Length; i++)
                {
                    int docId = docs[i].Doc;
                    Document doc = search.Doc(docId);
                    //this.listBox.Items.Add(doc.Get("number") + "\r\n");
                    //this.listBox.Items.Add(doc.Get("body") + "\r\n");
                    //this.listBox.Items.Add("------------------------\r\n");
                    string a = doc.Get("number") + "\r\n";
                    string b = doc.Get("body") + "\r\n";

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (search != null)
                    search.Dispose();
                if (dir != null)
                    dir.Dispose();
            }
            //this.label.Text = "搜索用时:";
            //this.timeBox.Text = sw.ElapsedMilliseconds + "毫秒";

        }

    }
}
