
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace Custom_Calculator
{
    public class SaveToTextFileRepository : IRepository
    {
        public void SaveHistory(string text) // zavrsi ovu metodu
        {
            string putanja = ConfigurationManager.AppSettings.Get("PutanjaZaCuvanjeFajla");

            SaveFileDialog saveText = new SaveFileDialog();
            saveText.Title = "Save file as";
            saveText.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            try
            {
                if (File.Exists(putanja))
                {
                    File.AppendAllText(putanja, text);
                }

                else
                {
                    if (saveText.ShowDialog() == DialogResult.OK)
                    {
                        TextWriter writer = new StreamWriter(saveText.FileName);
                        writer.Write(text);
                        writer.Close();
                        AddOrUpdateAppSettings("PutanjaZaCuvanjeFajla", saveText.FileName);
                    }
                }
            }
            catch { }

        }

        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

    }
}
