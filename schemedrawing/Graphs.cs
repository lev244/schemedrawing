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
            
            chart1.Series[1].Points.AddXY(0.00001,0.72);
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
            //chart1.Series[0].Points.AddXY(0, 0.72);
            chart1.Series[1].Points.AddXY(0.5, 0.58);
            chart1.Series[1].Points.AddXY(1, 0.27);
            chart1.Series[1].Points.AddXY(1.5, 0.05);
            chart1.Series[1].Points.AddXY(2, 0.01);
            
           // chart1.Series[2].Points.AddXY(1.5, 0.05);




            chart1.Series[0].Points.AddXY(0, 0.74);
            chart1.Series[0].Points.AddXY(0.22, 0.68);
            chart1.Series[0].Points.AddXY(0.45, 0.56);
           // chart1.Series[1].Points.AddXY(0.5, 0.55);
            //chart1.Series[1].Points.AddXY(0.55, 0.53);
           // chart1.Series[1].Points.AddXY(0.6, 0.50);
           // chart1.Series[1].Points.AddXY(0.65, 0.45);
            chart1.Series[0].Points.AddXY(0.75, 0.40);
            chart1.Series[0].Points.AddXY(0.8, 0.35);
            chart1.Series[0].Points.AddXY(0.85, 0.32);
            chart1.Series[0].Points.AddXY(0.9, 0.28);
            chart1.Series[0].Points.AddXY(0.95, 0.25);
            chart1.Series[0].Points.AddXY(1, 0.22);
            chart1.Series[0].Points.AddXY(1.05, 0.2);
            chart1.Series[0].Points.AddXY(1.3, 0.1);
            chart1.Series[0].Points.AddXY(1.5, 0.05);
            chart1.Series[0].Points.AddXY(2, 0.005);


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

            chart2.Series[1].Points.AddXY(0, 0.72);
            chart2.Series[1].Points.AddXY(0.33, 0.6);
            chart2.Series[1].Points.AddXY(0.95, 0.2);
            chart2.Series[1].Points.AddXY(1.45, 0.09);
            chart2.Series[1].Points.AddXY(1.8, 0.05);
            chart2.Series[1].Points.AddXY(2, 0.01);
            //chart2.Series[1].Points.AddXY(2, 1.0);
            chart2.Series[0].Points.AddXY(0, 0.71);
            chart2.Series[0].Points.AddXY(0.24, 0.60);
            chart2.Series[0].Points.AddXY(0.32, 0.55);
            chart2.Series[0].Points.AddXY(0.41, 0.50);
            // chart3.Series[1].Points.AddXY(0.8, 0.20);
            chart2.Series[0].Points.AddXY(0.9, 0.2);
            chart2.Series[0].Points.AddXY(1.5, 0.05);

            chart2.Series[0].Points.AddXY(2, 0.01);


            chart3.Series[0].Points.AddXY(0, 0.72);
            chart3.Series[0].Points.AddXY(0.33, 0.55);
            chart3.Series[0].Points.AddXY(0.7, 0.25);
            chart3.Series[0].Points.AddXY(1.3, 0.05);
            chart3.Series[0].Points.AddXY(1.8, 0.02);
            chart3.Series[0].Points.AddXY(2, 0.01);
            chart3.Series[1].Points.AddXY(0, 0.73);
            chart3.Series[1].Points.AddXY(0.28, 0.63);
            chart3.Series[1].Points.AddXY(0.35, 0.59);
            chart3.Series[1].Points.AddXY(0.4, 0.55);
           // chart3.Series[1].Points.AddXY(0.8, 0.20);
            chart3.Series[1].Points.AddXY(0.9, 0.2);
            chart3.Series[1].Points.AddXY(1.5, 0.05);
            chart3.Series[1].Points.AddXY(1.544, 0.0467);
            chart3.Series[1].Points.AddXY(2, 0.01);





        }

        private void Graphs_Load(object sender, EventArgs e)
        {

        }
    }
}
