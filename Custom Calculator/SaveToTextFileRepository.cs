﻿
using System.IO;

namespace Custom_Calculator
{
    public class SaveToTextFileRepository : IRepository
    {
        

        public void SaveHistory(string text) // zavrsi ovaj deo ako nemas nesto drugo zanimljivo trenutno
        {
            string filePath =
                @"C:\Users\brank\Desktop\PROJECTS\APLIKACIJE\CALCULATORS\Calculator WF\Custom Calculator\history.txt";

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
                TextWriter calculatorHistory = new StreamWriter(filePath);
                File.WriteAllText(filePath, text);
                calculatorHistory.Close();
                
            }
            else if (File.Exists(filePath))
            {
                File.AppendAllText(filePath, text);
            }
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
