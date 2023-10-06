﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.IO;

namespace Custom_Calculator
{
    //Interface
    public partial class Form1 : Form
    {   
        private string connStr = ConfigurationManager.ConnectionStrings["CustomCalculatorString"].ConnectionString;

        //public IRepository repo = new Repository();

        //Fields
        Double result = 0;
        string operation = string.Empty;
        string fstNum, secNum;
        bool enterValue = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void BtnMathOperation_Click(object sender, EventArgs e)
        {
            if (result != 0)BtnEquals.PerformClick();
            else result = Double.Parse(TxtDisplay1.Text);

            Button button = (Button)sender;
            operation = button.Text;
            enterValue = true;

            if (TxtDisplay1.Text != "0")
            {
                TxtDisplay2.Text = fstNum = $"{result}{operation}";
                TxtDisplay1.Text = string.Empty;
            }
        }
        private void BtnEquals_Click(object sender, EventArgs e)
        {
            secNum = TxtDisplay1.Text;
            TxtDisplay2.Text = $"{TxtDisplay2.Text}{TxtDisplay1.Text}";
            // uklonio sam znak = pred kraj navoda : TxtDisplay2.Text = $"{TxtDisplay2.Text}{TxtDisplay1.Text}=";
            if (TxtDisplay1.Text != string.Empty)
            {
                if (TxtDisplay1.Text == "0") TxtDisplay2.Text = string.Empty;

                switch(operation)
                {
                    case "+":
                        TxtDisplay1.Text = (result + Double.Parse(TxtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum} = {TxtDisplay1.Text}\n");
                        break;
                    case "-":
                        TxtDisplay1.Text = (result - Double.Parse(TxtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum} = {TxtDisplay1.Text}\n");
                        break;
                    case "x":
                        TxtDisplay1.Text = (result * Double.Parse(TxtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum} = {TxtDisplay1.Text}\n");
                        break;
                    case "÷":
                        TxtDisplay1.Text = (result / Double.Parse(TxtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum} = {TxtDisplay1.Text}\n");
                        break;
                    default: TxtDisplay2.Text = $"{TxtDisplay1.Text}=";
                        break;
                }
                result = Double.Parse(TxtDisplay1.Text);
                operation = string.Empty;
            }
        }
        private void BtnHistory_Click(object sender, EventArgs e)
        {
            PnlHistory.Height = (PnlHistory.Height == 5) ? PnlHistory.Height = 355 : 5;
        }
        public void BtnClearHistory_Click(object sender, EventArgs e)
        {
            //repo.SaveHistory(/*RtBoxDisplayHistory.Text*/);
            //SqlConnection conn = new SqlConnection(connStr);
            //conn.Open();
            //string sqlTxt = "SELECT ProductID, Title, Cost, SalePrice, Quantity FROM Inventory";
            //SqlCommand cmd = new SqlCommand(sqlTxt, conn);

            //RtBoxDisplayHistory.SaveFile(path);
            if (RtBoxDisplayHistory.Text != string.Empty)
            {
                string filePath = 
                    @"C:\Users\brank\Desktop\PROJECTS\APLIKACIJE\CALCULATORS\Calculator WF\Custom Calculator\history.txt";
                File.AppendAllLines(filePath, RtBoxDisplayHistory.Lines);
            }
            if (RtBoxDisplayHistory.Text != string.Empty)
            {
                SqlConnection conn = new SqlConnection(connStr); 
                conn.Open();

                string sqlTxt = "INSERT INTO History(Logs) VALUES ('" + RtBoxDisplayHistory.Text + "')";
                SqlCommand cmdInsert = new SqlCommand(sqlTxt, conn);

                cmdInsert.ExecuteNonQuery();
                conn.Close();
            }

            if (RtBoxDisplayHistory.Text == string.Empty)
                RtBoxDisplayHistory.Text = "There is no history";
            RtBoxDisplayHistory.Clear();
        }
        private void BtnBackSpace_Click(object sender, EventArgs e)
        {
            if (TxtDisplay1.Text.Length > 0)
                TxtDisplay1.Text = TxtDisplay1.Text.Remove(TxtDisplay1.Text.Length -1, 1);
            if (TxtDisplay1.Text == string.Empty) TxtDisplay1.Text = "0";
        }
        private void BtnC_Click(object sender, EventArgs e)
        {
            TxtDisplay1.Text = "0";
            TxtDisplay2.Text = string.Empty;
            result = 0;
        }
        private void BtnCE_Click(object sender, EventArgs e)
        {
            TxtDisplay1.Text = "0";
        }

        private void BtnOperations_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            switch (operation)
            {
                case "√x":
                    TxtDisplay2.Text = $"√({TxtDisplay1.Text})";
                    TxtDisplay1.Text = Convert.ToString(Math.Sqrt(Double.Parse(TxtDisplay1.Text)));
                    break;
                case "^2":
                    TxtDisplay2.Text = $"^2({TxtDisplay1.Text})";
                    TxtDisplay1.Text = Convert.ToString(Convert.ToDouble(TxtDisplay1.Text) * Convert.ToDouble(TxtDisplay1.Text));
                    break;
                case "1/x":
                    TxtDisplay2.Text = $"1/({TxtDisplay1.Text})";
                    TxtDisplay1.Text = Convert.ToString(1.0 / Convert.ToDouble(TxtDisplay1.Text));
                    break;
                case "%":
                    TxtDisplay2.Text = $"%({TxtDisplay1.Text})";
                    TxtDisplay1.Text = Convert.ToString(Convert.ToDouble(TxtDisplay1.Text) / Convert.ToDouble(100));
                    break;
                case "±":
                    TxtDisplay1.Text = Convert.ToString(-1 * Convert.ToDouble(TxtDisplay1.Text));
                    break;
                default:
                    break;
            }
            RtBoxDisplayHistory.AppendText($"{TxtDisplay2.Text} = {TxtDisplay1.Text}\n");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnNum_Click(object sender, EventArgs e)
        {
            if (TxtDisplay1.Text == "0" || enterValue) TxtDisplay1.Text = string.Empty;

            enterValue = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if(!TxtDisplay1.Text.Contains("."))
                    TxtDisplay1.Text = TxtDisplay1.Text + button.Text;
            }
            else TxtDisplay1.Text = TxtDisplay1.Text + button.Text;
        }
    }
}
