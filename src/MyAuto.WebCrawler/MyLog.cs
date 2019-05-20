using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.WebCrawler
{
    public static class MyLog
    {
        private static readonly object logLocker = new object();
        public static void WriteLog(string msg)
        {
            string logpath = ConfigurationManager.AppSettings["LogPath"];
            string LogAddress = logpath + '\\' +
                        DateTime.Now.Month + '-' +
                        DateTime.Now.Day + "_Log.log";
            //把异常信息输出到文件 
            StreamWriter fs = new StreamWriter(LogAddress, true);
            fs.WriteLine(msg);
            fs.Close();
        }
        public static void WriteLog(string msg, string msg2)
        {
            lock (logLocker)
            {
                string logpath = ConfigurationManager.AppSettings["LogPath"];
                string LogAddress = logpath + '\\' + msg2 + '-' +
                            DateTime.Now.Month + '-' +
                            DateTime.Now.Day + "_Log.log";
                //把异常信息输出到文件 
                StreamWriter fs = new StreamWriter(LogAddress, true);
                fs.WriteLine(msg);
                fs.Close();
            }
        }
        public static void WriteLog(string msg, ErrorState errorState)
        {
            lock (logLocker)
            {
                string logpath = ConfigurationManager.AppSettings["LogPath"];
                string LogAddress = "Log.log";
                switch (errorState)
                {
                    case ErrorState.Error: LogAddress = logpath + '\\' + "Error" + "_Log.log"; break;
                    case ErrorState.CopyError: LogAddress = logpath + '\\' + "CopyError" + "_Log.log"; break;
                    case ErrorState.ConvertError: LogAddress = logpath + '\\' + "ConvertError" + "_Log.log"; break;
                    case ErrorState.OrdinaryError: LogAddress = logpath + '\\' + "OrdinaryError" + "_Log.log"; break;
                    case ErrorState.FindError: LogAddress = logpath + '\\' + "FindError" + "_Log.log"; break;

                    default:
                        LogAddress = logpath + '\\' +
                            DateTime.Now.Month + '-' +
                            DateTime.Now.Day + "_Log.log";
                        break;
                }
                //把异常信息输出到文件 
                StreamWriter fs = new StreamWriter(LogAddress, true);
                fs.WriteLine(msg);
                fs.Close();
            }
        }
        /// <summary>
        /// 错误类型
        /// </summary>
        public enum ErrorState
        {
            Error = 0,
            CopyError = 1,
            ConvertError = 2,
            OrdinaryError = 3,
            FindError = 4,
        };



    }
}
