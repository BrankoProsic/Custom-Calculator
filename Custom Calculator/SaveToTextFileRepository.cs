
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace Custom_Calculator
{
    public class SaveToTextFileRepository : IRepository
    {
        public void SaveHistory(string text) // zavrsi ovaj deo ako nemas nesto drugo zanimljivo trenutno
        {
            string putanja = ConfigurationManager.AppSettings.Get("PutanjaZaCuvanjeFajla");
            string ime = ConfigurationManager.AppSettings.Get("ImeFajla");
            string tacnaLokacija = $"{putanja}{ime}";

            SaveFileDialog saveText = new SaveFileDialog();
            saveText.Title = "Save file as";
            saveText.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            saveText.FileName = ime;
            saveText.FilterIndex = 1;
            saveText.RestoreDirectory = true;
            saveText.OverwritePrompt = false;
            
            if (!File.Exists(saveText.FileName))
            {
                if (saveText.ShowDialog() == DialogResult.OK)
                {
                    TextWriter writer = new StreamWriter(saveText.FileName);
                    writer.Write(text);
                    writer.Close();
                }
            }
            else 
            {
                if (File.Exists(tacnaLokacija))
                {
                    File.AppendAllLines(tacnaLokacija, text);
                }
                //{
                //    StreamWriter sw = new StreamWriter(putanja);
                //    File.AppendAllLines(putanja, text);
                //    //File.AppendAllLines(putanja, text);
                //    //saveText.FileName = putanja;
                //}
            }

            //string filePath =
            //    @"C:\Users\brank\Desktop\PROJECTS\APLIKACIJE\CALCULATORS\Calculator WF\Custom Calculator\history.txt";

            //if (!File.Exists(filePath))
            //{

            //    File.Create(filePath);
            //    TextWriter calculatorHistory = new StreamWriter(filePath);
            //    File.WriteAllText(filePath, text);
            //    calculatorHistory.Close();
            //}
            //else if (File.Exists(filePath))
            //{
            //    File.AppendAllText(filePath, text);
            //}
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
