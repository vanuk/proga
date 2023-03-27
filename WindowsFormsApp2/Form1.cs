using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading;
using System.Diagnostics;

namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static async Task<string> TranslateText(string text, string targetLanguage)
        {
            string endpoint = $"https://api.mymemory.translated.net/get?q={text}&langpair=uk|{targetLanguage}";
            var client = new HttpClient();
            var response = await client.GetAsync(endpoint);
            var json = await response.Content.ReadAsStringAsync();
            var translation = Newtonsoft.Json.JsonConvert.DeserializeObject<Translation>(json);
            return translation.responseData.translatedText;
        }
        private  void textBox1_TextChanged(object sender, EventArgs e)
        {


        }
        private async void button1_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "MyTest1.txt");

            string targetLanguage = "en";
            string v = await TranslateText(textBox1.Text, targetLanguage);
            string name = await TranslateText(textBox2.Text, targetLanguage);
            string nameD = await TranslateText(textBox3.Text, targetLanguage);
            string year = await TranslateText(textBox4.Text, targetLanguage);
            string year1 = year.Substring(year.Length - 2);
            string email = "";

            // Check if the file already exists and create it if it doesn't
            if (!File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {

                    AddText(fs, "Дані студента: " + textBox1.Text.Substring(0, 1).ToUpper() + textBox1.Text.Substring(1) + " " + textBox2.Text.Substring(0, 1).ToUpper() + textBox2.Text.Substring(1) + " " + textBox3.Text.Substring(0, 1).ToUpper() + textBox3.Text.Substring(1) + "\n");
                    AddText(fs, "Рік вступу: " + textBox4.Text + "\n");

                    if (checkBox1.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox1.Tag + year1 + "@nuwm.edu.ua";
                        AddText(fs, "В якому інституті навчається: " + checkBox1.Text + "\n");
                    }
                    else if (checkBox2.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox2.Tag + year1 + "@nuwm.edu.ua";
                        AddText(fs, "В якому інституті навчається: " + checkBox2.Text + "\n");
                    }
                    else if (checkBox3.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox3.Tag + year1 + "@nuwm.edu.ua";
                        AddText(fs, "В якому інституті навчається: " + checkBox3.Text + "\n");
                    }
                    else if (checkBox4.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox4.Tag + year1 + "@nuwm.edu.ua";
                        AddText(fs, "В якому інституті навчається: " + checkBox4.Text + "\n");
                    }
                    else if (checkBox5.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox5.Tag + year1 + "@nuwm.edu.ua";
                        AddText(fs, "В якому інституті навчається: " + checkBox5.Text + "\n");
                    }
                    else if (checkBox6.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox6.Tag + year1 + "@nuwm.edu.ua";
                        AddText(fs, "В якому інституті навчається: " + checkBox6.Text + "\n");
                    }
                    else if (checkBox7.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox7.Tag + year1 + "@nuwm.edu.ua";
                        AddText(fs, "В якому інституті навчається: " + checkBox7.Text + "\n");
                    }
                    else if (checkBox8.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox8.Tag + year1 + "@nuwm.edu.ua";
                        AddText(fs, "В якому інституті навчається: " + checkBox8.Text + "\n");

                    }
                    AddText(fs, "Електрона почта вступника: " + email + "\n");
                    AddText(fs, "Пароль до почти вступника: " + name + "_" + year + "\n");
                }
            }
            else // If the file already exists, append the new student's data to it
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine();
                    sw.WriteLine("Дані студента: " + textBox1.Text.Substring(0, 1).ToUpper() + textBox1.Text.Substring(1) + " " + textBox2.Text.Substring(0, 1).ToUpper() + textBox2.Text.Substring(1) + " " + textBox3.Text.Substring(0, 1).ToUpper() + textBox3.Text.Substring(1));
                    sw.WriteLine("Рік вступу: " + textBox4.Text);

                    if (checkBox1.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox1.Tag + year1 + "@nuwm.edu.ua";
                        sw.WriteLine("В якому інституті навчається: " + checkBox1.Text);
                    }
                    else if (checkBox2.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox2.Tag + year1 + "@nuwm.edu.ua";
                        sw.WriteLine("В якому інституті навчається: " + checkBox2.Text);
                    }
                    else if (checkBox3.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox3.Tag + year1 + "@nuwm.edu.ua";
                        sw.WriteLine("В якому інституті навчається: " + checkBox3.Text);
                    }
                    else if (checkBox4.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox4.Tag + year1 + "@nuwm.edu.ua";
                        sw.WriteLine("В якому інституті навчається: " + checkBox4.Text);
                    }
                    else if (checkBox5.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox5.Tag + year1 + "@nuwm.edu.ua";
                        sw.WriteLine("В якому інституті навчається: " + checkBox5.Text);
                    }
                    else if (checkBox6.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox6.Tag + year1 + "@nuwm.edu.ua";
                        sw.WriteLine("В якому інституті навчається: " + checkBox6.Text);
                    }
                    else if (checkBox7.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox7.Tag + year1 + "@nuwm.edu.ua";
                        sw.WriteLine("В якому інституті навчається: " + checkBox7.Text);
                    }
                    else if (checkBox8.Checked == true)
                    {
                        email = v.ToLower() + "." + name.Substring(0, 1).ToLower() + "_" + checkBox8.Tag + year1 + "@nuwm.edu.ua";
                        sw.WriteLine("В якому інституті навчається: " + checkBox8.Text);
                       
                    }
                    sw.WriteLine("Електрона почта вступника: " + email);
                    sw.WriteLine("Пароль до почти вступника: " + name + "_" + year);
                }
            }
             MessageBox.Show("Дані успішно записані в файл!");
            // Open the file in a text editor
            foreach (var process in Process.GetProcessesByName("notepad"))
            {
                process.Kill();
            }
            Process notepadProcess = Process.Start("notepad.exe", path);
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
      
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        class Translation
        {
            public ResponseData responseData { get; set; }
        }

        class ResponseData
        {
            public string translatedText { get; set; }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
