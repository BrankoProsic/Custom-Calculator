using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Calculator
{
    public class Repository : IRepository
    {
        public string directory = @"C:\Users\brank\Desktop\PROJECTS\APLIKACIJE\CALCULATORS\Calculator WF\Custom Calculator";
        public string displayHistory = "history.txt";
        public string path;
        //C:\Users\brank\Desktop\PROJECTS\APLIKACIJE\CALCULATORS\Calculator WF\Custom Calculator

        //public string ClearHistory()
        //{
        //    throw new NotImplementedException();
        //}

        public void SaveHistory(/*string text*/)
        {
            TextWriter txt = new StreamWriter("C:\\Users\\brank\\Desktop\\PROJECTS\\APLIKACIJE\\CALCULATORS\\Calculator WF\\Custom Calculator");
            txt.Write("");
            txt.Close();

            //return "";
        }

        //private void CheckFile()
        //{
        //    string path = $"{directory}{displayHistory}";

        //    if (!File.Exists(path))
        //    {
        //        //Create the directory
        //        if (!Directory.Exists(path))
        //            Directory.CreateDirectory(directory);

        //        //Create the empty file
        //        FileStream fs = File.Create(path);
        //    }
        //}
    }
}
