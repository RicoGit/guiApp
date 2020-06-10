using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace guiApp
{
    class Bezie : Polygon
    {
        private const int MaxNumOfPoints = 20; // max number of points
        private double[] factorialMas = FillFactorialMas(MaxNumOfPoints);  // array of factorials

        public Bezie(Graphics g, Pen p) { this.g = g; this.p = (Pen)p.Clone(); this.vertexList = new List<PointF>(MaxNumOfPoints); }

        public void AddPoint(Point point)
        {
            if (vertexList.Count >= MaxNumOfPoints) return;
            vertexList.Add(point);
            g.DrawEllipse(p, point.X - 2, point.Y - 2, 5, 5);
        }

        public override void Draw() { DrawBezie(true, 0, 0); }

        public override bool Contains(int x, int y) { return DrawBezie(false, x, y); }

        // Draw or check whether the point lie on the line (yes, bad design)
        bool DrawBezie(bool draw, int x, int y)
        {
            if (vertexList.Count == 0) return false;
            Console.WriteLine("draw Bezie(first " + vertexList.First() + ", last " + vertexList.Last());

            int pointsNum = vertexList.Count - 1;
            double dt = 0.01; // прирост (шаг табуляции)
            double t = dt;
            //координаты предыдущей точки
            double xPred = vertexList[0].X;
            double yPred = vertexList[0].Y;
            double xt, yt; // координаты текущей точки 
            double J; // полином Берштейна
            int i;

            while (t < (1 + dt / 2))
            {
                xt = 0;
                yt = 0;
                i = 0;
                while (i <= pointsNum)
                {
                    J = Math.Pow(t, i)
                        * Math.Pow((1 - t), (pointsNum - i))
                        * factorialMas[pointsNum] / (factorialMas[i] * factorialMas[pointsNum - i]);
                    xt += vertexList[i].X * J;
                    yt += vertexList[i].Y * J;
                    i++;
                }

                int x1 = (int)Math.Round(xPred);
                int y1 = (int)Math.Round(yPred);
                int x2 = (int)Math.Round(xt);
                int y2 = (int)Math.Round(yt);

                int treshold = 5;
                if (draw) { g.DrawLine(p, x1, y1, x2, y2); }
                else
                {
                    int dx1 = Math.Abs(x - x1);
                    int dx2 = Math.Abs(x - x2);

                    int dy1 = Math.Abs(y - y1);
                    int dy2 = Math.Abs(y - y2);
                    if ((dx1 <= treshold && dy1 <= treshold) || (dx2 <= treshold && dy2 <= treshold)) { return true; }
                }

                t += dt;
                xPred = xt;
                yPred = yt;
            }
            return false;
        }

        // Fills array of factorials (is nessesary for Bezie visualization)
        static double[] FillFactorialMas(int size)
        {
            double[] result = new double[size + 1]; // массив значений факториалов чисел от 0 до size
            result[0] = 1;
            for (int l = 1; l <= size; l++)
            {
                result[l] = l * result[l - 1];
            }
            return result;
        }
    }
}
