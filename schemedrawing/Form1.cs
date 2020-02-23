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
    public partial class Form1 : Form
    {
        C obj = new C();
        public double radius1=200;
        public double radius2=400;
        
        //public int n = 100;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
            base.OnPaint(e);
            Graphics g = e.Graphics;
            SolidBrush b = new SolidBrush(Color.Red);
            var center = new Point(panel1.Width / 2, panel1.Height / 2);
            var p1 = new Pen(Color.Black, 2);
            var p2 = new Pen(Color.Blue, 2);
            var p3 = new Pen(Color.Red, 1);

          

          //  x[0] = center.X - (float)obj.X(radius1, radius2)[0];
           // y[0] = center.Y - (float)radius2;

            //spheres
            g.DrawEllipse(p1, center.X-(float)radius1, center.Y-(float)radius1, (float)(2*radius1), (float)(2 * radius1));
            g.DrawEllipse(p1, center.X - (float)radius2, center.Y - (float)radius2, (float)(2 * radius2), (float)(2 * radius2));
            g.DrawLine(p3, center.X, center.Y, center.X-(float)obj.StepX(radius1,radius2)[0], center.Y - (float)radius2);
           
            
            for (int i = 1; i < obj.n; i++)
            {
               
                 g.FillRectangle(b, (float)obj.X(center.X,radius1,radius2)[i],(float)obj.Y(center.X,center.Y,radius1,radius2)[i], 2, 2);
                 g.DrawLine(p3, center.X-(float)obj.StepX(radius1,radius2)[i], center.Y, (float)obj.EndX(center.X, obj.StepX(radius1, radius2)[i], obj.Theta()[obj.n-i], radius2),center.Y+(float)obj.EndY(center.X,center.Y, obj.StepX(radius1, radius2)[i], obj.Theta()[obj.n-i],radius2));
                g.DrawEllipse(p2, center.X - (float)(radius1+ obj.StepX(radius1, radius2)[i] ), center.Y - (float)(radius1 + obj.StepX(radius1, radius2)[i]), (float)(2 * (radius1+ obj.StepX(radius1, radius2)[i] )), (float)(2 * (radius1 + obj.StepX(radius1, radius2)[i])));
                
                //Console.WriteLine("x'={0} \n y'={1} \n theta={2}", obj.EndX(center.X, x[i], obj.Theta()[obj.n - 1 - i], radius2),center.Y- obj.EndY(center.X, center.Y, x[i], obj.Theta()[obj.n - 1 - i], radius2),obj.Theta()[obj.n-i]);
            }
           // Console.WriteLine("center:{0}-{1}, x:{2} -{3}", center.X, center.Y, centerX, centerY);

        }
    }
}
