using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schemedrawing
{
    
    class C
    {
        public  int n = 10;
        public double[] StepX(double radius1,double radius2)
        {

            double[] x = new double[n];
            double step = (radius2 - radius1) / (double) n;

            for (int i = 0; i <n; i++)
            {
                x[i] = i * step;
               
            }


            return x;
        }

        public double[] Theta()
        {
            double[] theta = new double[n];
            double step = (double)90 / (double)(n);

            for (int i = 0; i < n; i++)
            {
                theta[i] = i * step;
               
            }


            return theta;
        }

        public double EndX(double center,double xi, double theta, double r) 
        {
            return (center *( Math.Tan(theta * (Math.PI / 180)) * Math.Tan(theta * (Math.PI / 180)) +1) -Math.Sqrt((r*r-xi*xi)* Math.Tan(theta * (Math.PI / 180)) * Math.Tan(theta * (Math.PI / 180)) +r*r) +xi* Math.Tan(theta * (Math.PI / 180)) * Math.Tan(theta * (Math.PI / 180)))/(Math.Tan(theta * (Math.PI / 180)) * Math.Tan(theta * (Math.PI / 180)) +1);
        }

        public double EndY(double centerX,double centerY, double xi, double theta, double r)
        {
            return ((EndX(centerX, xi, theta, r)  -centerX - xi) * Math.Tan(theta * (Math.PI / 180)));
        }
       
       public double[] X(double centerX, double radius1, double radius2)
        {
            double[] x = new double[n];
            for(int i=1;i<n;i++)
                x[i] = EndX(centerX, StepX(radius1, radius2)[i], Theta()[n - i], radius2);
            return x;
        }

        public double[] Y(double centerX, double centerY, double radius1, double radius2)
        {
            double[] y = new double[n];
            for(int i = 1; i < n; i++)
                y[i]= centerY + EndY(centerX, centerY, StepX(radius1, radius2)[i], Theta()[n - i], radius2);

            return y;
        }


    }
}
