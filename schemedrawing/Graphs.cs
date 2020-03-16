using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schemedrawing
{
    public partial class Graphs : Form
    {
        public Graphs()
        {
            InitializeComponent();
           // chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            double x = 0.001;
            const int N = 1000;
          /*  for (int i = 1; i < N; i++)
            {
                double y = x*x;
                chart1.Series[0].Points.AddXY(x, y);
                x = x + 0.001;
            }*/
            
            chart1.Series[0].Points.AddXY(0.00001,0.70);
            /*
            chart1.Series[0].Points.AddXY(0.1, 0.70);
            chart1.Series[0].Points.AddXY(0.2, 0.69);
            chart1.Series[0].Points.AddXY(0.25, 0.68);
            chart1.Series[0].Points.AddXY(0.3, 0.65);
            chart1.Series[0].Points.AddXY(0.33, 0.64);
            chart1.Series[0].Points.AddXY(0.34, 0.63);
            chart1.Series[0].Points.AddXY(0.35, 0.62);
            chart1.Series[0].Points.AddXY(0.38, 0.61);
            chart1.Series[0].Points.AddXY(0.4, 0.6);
            chart1.Series[0].Points.AddXY(0.5, 0.55);
            chart1.Series[0].Points.AddXY(1, 0.25);
            chart1.Series[0].Points.AddXY(1.5, 0.05);
            */
            chart1.Series[0].Points.AddXY(0, 0.72);
            chart1.Series[0].Points.AddXY(0.5, 0.58);
            chart1.Series[0].Points.AddXY(1, 0.27);
            chart1.Series[0].Points.AddXY(1.5, 0.05);
            chart1.Series[0].Points.AddXY(2, 0.01);



            /*   chart2.Series[0].Points.AddXY(0, 0.66);
               chart2.Series[0].Points.AddXY(0.05, 0.65);
               chart2.Series[0].Points.AddXY(0.1, 0.64);
               chart2.Series[0].Points.AddXY(0.15, 0.63);
               chart2.Series[0].Points.AddXY(0.2, 0.62);
               chart2.Series[0].Points.AddXY(0.25, 0.61);
               chart2.Series[0].Points.AddXY(0.4, 0.6);
               chart2.Series[0].Points.AddXY(0.5, 0.55);
               chart2.Series[0].Points.AddXY(0.75, 0.45);
               chart2.Series[0].Points.AddXY(1, 0.35);
               chart2.Series[0].Points.AddXY(1.5, 0.22);
               */
        }

        private void Graphs_Load(object sender, EventArgs e)
        {

        }
    }
}
