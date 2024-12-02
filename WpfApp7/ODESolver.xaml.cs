using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for ODESolver.xaml
    /// </summary>
    public partial class ODESolver : Window
    {
        
        public ODESolver()
        {
            InitializeComponent();
        }

        public delegate double Function(double[] x, double t);
        /// <summary>
        /// 四阶龙格库塔 法解微分方程
        /// </summary>
        /// <param name="f">函数各阶微分方程数组 <br/>
        ///              例1：<br/>
        ///                关于位移关于时间的1阶导函数-即速度关于时间函数  
        ///                f1(xx,t)=> xx[1]， 
        ///                2阶导函数-即加速度关于时间函数 f2(xx,t)=> a）<br/>
        ///              例2：单摆运动 其中g为重力加速度，b为阻尼系数, L为摆长， m为质量 <br/>
        ///                f1(xx,t)=> xx[1]   <br/>
        ///                f2(xx,t)=> -g * Math.Sin( xx[0] ) / L - b * xx[1] / m ; <br/>
        ///                返回的值 xx[0] 表示转动角度， xx[1]表 转动的角速度
        /// </param>
        /// <param name="x0">初始数组（个数等于阶次）</param>
        /// <param name="t0">初时时间，通常初始为0</param>
        /// <param name="dt">计算时间步长</param>
        /// <returns>
        ///     返回各函数各阶导函数的函数值xx，其中xx[0]就是关于时刻t0时的位移 xx[1]就是t0时刻的速度 <br/>
        ///     累计 t0 += dt ， 再把返回值存入xx数组变量，再次作为参数x0传入这个函数，迭代计算，<br/>
        ///     就可以计算其他时间时刻的位移和速度
        /// </returns>
        public static double[] RungeKutta4(Function[] f, double[] x0, double t0, double dt)
        {
            int n = x0.Length;
            double[] k1 = new double[n];
            double[] k2 = new double[n];
            double[] k3 = new double[n];
            double[] k4 = new double[n];

            double t = t0;
            double[] x1 = new double[n];
            double[] x = x0;

            for (int i=0; i<n; i++)
            {
                k1[i] = dt * f[i](x, t);
            }

            for (int i=0; i< n; i++)
            {
                x1[i] = x[i] + k1[i] / 2;
            }

            for (int i = 0; i < n; i++)
            {
                k2[i] = dt * f[i](x1, t + dt / 2);
            }

            for (int i=0; i< n; i++)
            {
                x1[i] = x[i] + k2[i] / 2;
            }

            for (int i = 0; i < n; i++)
            {
                k3[i] = dt * f[i] (x1, t + dt / 2);
            }

            for (int i =0; i<n; i++)
            {
                x1[i] = x[i] + k3[i];
            }

            for (int i=0; i<n; i++)
            {
                k4[i] = dt * f[i](x1, t + dt);
            }

            for (int i=0; i< n; i++)
            {
                x[i] += (k1[i] + 2 * k2[i] + 2 * k3[i] + k4[i]) / 6;
            }

            return x;
        }
    }
}
