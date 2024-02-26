using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using static System.Windows.Forms.LinkLabel;
using System.Collections;
using System.Globalization;

namespace Lab11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = "E:/PSU_lab/6_semester/RV/someone/IterationTimes.txt";
            List<string> fileContent = new List<string>();
            List<double> iterationTimes = new List<double>();
            if (File.Exists(fileName)) 
            {
                fileContent.AddRange(File.ReadAllText(fileName).Split(' '));
                foreach (string str in fileContent)
                {
                    double num;
                    if(double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out num))
                    {
                        iterationTimes.Add(num);
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
            ChartArea сhartArea = chart1.ChartAreas["ChartArea1"];
            сhartArea.AxisX.Title = "Номер итерации";
            сhartArea.AxisY.Title = "Время (сек)";
            сhartArea.AxisX.Interval = 1;
            сhartArea.AxisY.Interval = 0.1;
            Series series = chart1.Series.Add("Время итераций");
            for (int i = 0; i < iterationTimes.Count; i++)
            {
                series.Points.AddXY(i + 1, iterationTimes[i]);
            }
        }
    }
}
