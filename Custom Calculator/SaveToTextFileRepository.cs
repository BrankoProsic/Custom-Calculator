
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
            catch (FileNotFoundException e) // tries to access a file in the program that either doesn't exist or has been deleted
            {
                MessageBox.Show(e.Message);
            }
            catch (ArgumentNullException e) // occurs when an invalid argument is passed to a method in C#
            {
                MessageBox.Show(e.Message);
            }
            catch (ConfigurationErrorsException e) // application attempts to read or write data to the configuration file but is unsuccessful
            {
                MessageBox.Show(e.Message);
            }
            catch (IOException e) //not able to perform an input/output action (such as reading or copying data)
            {
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public static void AddOrUpdateAppSettings(string key, string value) //metod - referentni parametri iz kofiguracionog fajla
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings; //odvojen/podeljen "settings" na if - else
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
                //Console.WriteLine("Error writing app settings");
                MessageBox.Show("Error writing app settings");
            }
        }

    }
}
