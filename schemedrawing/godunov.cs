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
        //Form1 objF = new Form1();
        //вспомогательные константы
        const double
           EPS = 10e-6,
           MAX_ITER = 20,
           CFL = 0.4,
           gamma = 1.4;

        
       public int main() {

            // выделение памяти под массивы

            double[,]
                r = new double[2 * objC.n, 2 * objC.n], // плотность
                p = new double[2 * objC.n, 2 * objC.n], // давление
                e = new double[2 * objC.n, 2 * objC.n],
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
                U_big = new double[2 * objC.n, 2 * objC.n],
                V_big = new double[2 * objC.n, 2 * objC.n],
                E_big = new double[2 * objC.n, 2 * objC.n],
                w_s = new double[2 * objC.n, 2 * objC.n],
                w_ss = new double[2 * objC.n, 2 * objC.n],
                w = new double[2 * objC.n, 2 * objC.n],
                sin_phi = new double[2 * objC.n, 2 * objC.n],
                cos_phi = new double[2 * objC.n, 2 * objC.n],
                z = new double[2 * objC.n, 2 * objC.n];



            // определение шага вдоль сетки
            double[,] l = new double[2*objC.n, 2*objC.n];


            /*  for (int i = 1; i < objC.n; i++)
               l[i, objC.n-1] = objC.X(637, 200, 400)[i] * objC.X(637, 200, 400)[i] + objC.Y(637, 417, 200, 400)[i]; 
              l[0,objC.n-1]=637*637+()
             // for(int j=0;j<objC.n;j++)
                 // l*/

            l[objC.n - 1,0] = 1;
            for(int i = 0; i < objC.n; i++)
            {
                l[i, 0] = objC.StepX(1, 2.25)[i];
                l[i,objC.n-1]= objC.StepX(1, 2.25)[i];
            }

            for(int i = 1; i < objC.n; i++)
            {
                for(int j = 0; j < objC.n; j++)
                {
                    l[i, j] = Math.Pow(l[i, 0], 1 - j / objC.n) * Math.Pow(l[i, objC.n - 1], j / objC.n);
                   
                }
            }

            //  начальные условия

            double u_inf=4/Math.Sqrt(21),
                v_inf=0, 
                r_inf=1,
                e_inf=1 / (1.4 * 0.4 * 2.1);

            for(int i = 0; i < 2 * objC.n; i += 2)
            {
                for (int j = 0; j < 2 * objC.n; j += 2)
                {
                    r[i, j] = r_inf ;
                    e[i, j] = e_inf ;
                    p[i, j] = (gamma - 1) * r_inf * e_inf;
                    u[i, j] = u_inf;
                }
            }

            
            
        
            // расчет больших величин на границе ячеек по углу : n-1/2, m-1/2; n+1/2, m-1/2
         
            // проекция векторов скоростей в этиях ячейках на нормаль к границе
            for(int i = 1; i < 2*objC.n; i += 2)
            {
                for(int j = 1; j < 2*objC.n; j += 2)
                {
                    w_s[i, j] = u[i, j] * Math.Sin(objC.Theta()[(i-1) / 2]) + v[i, j] * Math.Sin(objC.Theta()[(j-1) / 2]);
                  
                }
            }

            

            for (int i = 1; i < 2*objC.n - 2; i += 2)
            {
                for (int j = 1; j < 2*objC.n; j += 2)
                {
                    a[i+1, j] = Math.Sqrt(gamma * ((p[i, j] + p[i + 2, j]) / 2) * ((r[i, j] + r[i + 2, j]) / 2));
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
                        W_big[i + 1, j] = w[i + 1, j];
                        U_big[i + 1, j] = w_s[i + 1, j] * Math.Sin(objC.Theta()[i / 2]) + (u[i+2,j] * Math.Cos(objC.Theta()[i / 2]) -v[i+2,j] * Math.Sin(objC.Theta()[i / 2])) *Math.Cos(objC.Theta()[i/2]);
                        V_big[i+1,j]= w_s[i + 1, j] * Math.Cos(objC.Theta()[i / 2]) - (u[i + 2, j] * Math.Cos(objC.Theta()[i / 2]) - v[i + 2, j] * Math.Cos(objC.Theta()[i / 2])) * Math.Sin(objC.Theta()[i / 2]);
                    }

                    if(D_left[i + 1, j] * D_right[i + 1, j] < 0 && w_s[i + 1, j] > 0)
                    {
                        P_big[i + 1, j] = p[i + 1, j];
                        R_big[i + 1, j] = r_left[i + 1, j];
                        W_big[i + 1, j] = w[i + 1, j];
                        U_big[i + 1, j] = w_s[i + 1, j] * Math.Sin(objC.Theta()[i / 2]) + (u[i , j] * Math.Cos(objC.Theta()[i / 2]) - v[i , j] * Math.Sin(objC.Theta()[i / 2])) * Math.Cos(objC.Theta()[i / 2]);
                        V_big[i + 1, j] = w_s[i + 1, j] * Math.Cos(objC.Theta()[i / 2]) - (u[i , j] * Math.Cos(objC.Theta()[i / 2]) - v[i , j] * Math.Cos(objC.Theta()[i / 2])) * Math.Sin(objC.Theta()[i / 2]);
  
                    }

                    if(D_left[i + 1, j] >0 && D_right[i + 1, j] > 0)
                    {
                        P_big[i + 1, j] = p[i , j];
                        R_big[i + 1, j] = r[i, j];
                        U_big[i + 1, j] = u[i, j];
                        V_big[i + 1, j] = v[i, j];
                        W_big[i + 1, j] = w[i, j];


                    }
                   
                    if (D_left[i + 1, j] < 0 && D_right[i + 1, j] < 0)
                    {
                        P_big[i + 1, j] = p[i+2, j];
                        R_big[i + 1, j] = r[i+2, j];
                        U_big[i + 1, j] = u[i+2, j];
                        V_big[i + 1, j] = v[i+2, j];
                        W_big[i + 1, j] = w[i+2, j];
                    }
                    E_big[i + 1, j] = P_big[i + 1, j] / ((gamma - 1) * R_big[i + 1, j]);

                }

            }
           
            // расчет больших величин для ячеек, соседних по радиусу

            for (int i = 1; i < 2 * objC.n-2; i += 2)
            {
                for (int j = 1; j < 2 * objC.n-2; j += 2)

                {
                    sin_phi[i, j + 1] = l[i + 1, j + 1] * Math.Sin(objC.Theta()[i / 2]);

                   // z[i, j + 1] = Math.Sqrt( Math.Pow( (l[i+1,j+1] *Math.Sin(objC.Theta()[i/2]) - l[i - 1, j + 1] * Math.Sin(objC.Theta()[i / 2]),2.0 ))) ;
                  //  w_s[i, j] = -u[i, j] * Math.Sin() + v[i, j] * Math.Sin(objC.Theta()[j / 2]);

                }
            }


           // Console.WriteLine("")





            return 0;
        
        }

       
       
    }
}
