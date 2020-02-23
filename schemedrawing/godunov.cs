using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schemedrawing
{
    class godunov
    {
        C objC = new C();
        Form1 objF = new Form1();
        //вспомогательные константы
        const double
           EPS = 10e-6,
           MAX_ITER = 20,
           CFL = 0.4,
           gamma = 1.4;

        
        int main() {

            // выделение памяти под массивы

            double[,]
                r = new double[2 * objC.n, 2 * objC.n], // плотность
                p = new double[2 * objC.n, 2 * objC.n], // давление
                u = new double[2 * objC.n, 2 * objC.n], //скорость по х
                v = new double[2 * objC.n, 2 * objC.n], // скорость по r
                ru = new double[2 * objC.n, 2 * objC.n],// импульс
                rv = new double[2 * objC.n, 2 * objC.n], // тоже импульс, но вдоль r
                re = new double[2 * objC.n, 2 * objC.n], // 
                fr = new double[2 * objC.n - 2, 2 * objC.n - 2], //
                fru = new double[2 * objC.n - 2, 2 * objC.n - 2], //
                fre = new double[2 * objC.n - 2, 2 * objC.n - 2],
                a = new double[2 * objC.n, 2 * objC.n],
                r_left = new double[2 * objC.n, 2 * objC.n],
                r_right = new double[2 * objC.n, 2 * objC.n],
                D_left = new double[2 * objC.n, 2 * objC.n],
                D_right = new double[2 * objC.n, 2 * objC.n],
                P_big = new double[2 * objC.n, 2 * objC.n],
                R_big = new double[2 * objC.n, 2 * objC.n],
                W_big = new double[2 * objC.n, 2 * objC.n],
                w_s = new double[2 * objC.n, 2 * objC.n]; 



            // определение шага вдоль сетки
            double[,] l = new double[objC.n, objC.n];


            /*  for (int i = 1; i < objC.n; i++)
               l[i, objC.n-1] = objC.X(637, 200, 400)[i] * objC.X(637, 200, 400)[i] + objC.Y(637, 417, 200, 400)[i]; 
              l[0,objC.n-1]=637*637+()
             // for(int j=0;j<objC.n;j++)
                 // l*/

            l[objC.n - 1,0] = 400;
            for(int i = 0; i < objC.n; i++)
            {
                l[i, 0] = objC.StepX(200, 400)[i];
                l[i,objC.n-1]= objC.StepX(200, 400)[i];
            }

            for(int i = 1; i < objC.n-1; i++)
            {
                for(int j = 0; j < objC.n; j++)
                {
                    l[i, j] = Math.Pow(l[i, 0], 1 - j / objC.n) * Math.Pow(l[i, objC.n - 1], j / objC.n);
                }
            }
            // расчет больших величин на границе ячеек по углу : n-1/2, m-1/2; n+1/2, m-1/2
         
            for(int i = 0; i < objC.n; i += 2)
            {
                for(int j = 0; j < objC.n; j += 2)
                {
                    w_s[i, j] = u[i, j] * Math.Sin(objC.Theta()[i / 2]) + v[i, j] * Math.Sin(objC.Theta()[j / 2]);

                }
            }

            

            for (int i = 0; i < objC.n - 2; i += 2)
            {
                for (int j = 0; j < objC.n; j += 2)
                {
                    a[i + 1, j] = Math.Sqrt(gamma * ((p[i, j] + p[i + 2, j]) / 2) * ((r[i, j] + r[i + 2, j]) / 2));
                    p[i + 1, j] = (p[i, j] + p[i + 2, j]) / 2 + a[i + 1, j] * (w_s[i, j] - w_s[i + 2, j]) / 2;
                    w_s[i + 1, j] = (w_s[i, j] + w_s[i + 2, j]) / 2 + (p[i, j] - p[i + 1, j]) / (2 * a[i + 1, j]);
                    r_left[i + 1, j] = ((gamma + 1) * p[i + 1, j] + (gamma - 1) * p[i, j]) * r[i, j] / ((gamma - 1) * p[i + 1, j] + (gamma + 1) * p[i, j]);
                    r_right[i + 1, j] = ((gamma + 1) * p[i + 1, j] + (gamma - 1) * p[i + 2, j]) * r[i, j] / ((gamma - 1) * p[i + 1, j] + (gamma + 1) * p[i + 2, j]);
                    D_left[i + 1, j] = w_s[i, j] - a[i + 1, j] / r[i, j];
                    D_right[i + 1, j] = w_s[i+2, j] - a[i + 1, j] / r[i+2, j];

                    // выбор больших величин из 4 случаев

                    if (D_left[i + 1, j] * D_right[i + 1, j] < 0 && w_s[i+1,j]<0)
                    {
                        P_big[i + 1, j] = p[i + 1, j];
                        R_big[i + 1, j] = r_right[i + 1, j];
                        W_big=

                    }

                    if(D_left[i + 1, j] * D_right[i + 1, j] < 0 && w_s[i + 1, j] > 0)
                    {

                    }

                    if(D_left[i + 1, j] >0 && D_right[i + 1, j] > 0)
                    {

                    }
                   
                    if (D_left[i + 1, j] < 0 && D_right[i + 1, j] < 0)
                    {

                    }


                }

            }
           






            return 0;
        
        }

       
       
    }
}
