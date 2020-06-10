using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace guiApp
{
    class Line : Polygon
    {

        public Line(Graphics g, Pen p) { this.g = g; this.p = (Pen)p.Clone(); this.vertexList = new List<PointF>(2); }

        public bool AddPoint(Point point)
        {
            if (vertexList.Count >= 2) return true;
            vertexList.Add(point);
            g.DrawEllipse(p, point.X - 2, point.Y - 2, 4, 4);
            return vertexList.Count == 2 ? true : false;
        }

        public override void Draw()
        {
            if (vertexList.Count == 0) return;
            Console.WriteLine("draw Line(first " + vertexList.First() + ", last " + vertexList.Last());
            DrawLine(true, 0, 0);
        }

        public override bool Contains(int x, int y) { return DrawLine(false, x, y); }

        // Draw or check whether the point lie on the line (yes, bad design)
        public bool DrawLine(bool draw, int curX, int curY)
        {
            int x1 = (int)vertexList.First().X;
            int y1 = (int)vertexList.First().Y;
            int x2 = (int)vertexList.Last().X;
            int y2 = (int)vertexList.Last().Y;

            int x, y, dx, dy, Sx = 0, Sy = 0; int F = 0, Fx = 0, dFx = 0, Fy = 0, dFy = 0; dx = x2 - x1; dy = y2 - y1;
            Sx = Math.Sign(dx); Sy = Math.Sign(dy);
            if (Sx > 0) dFx = dy; else dFx = -dy; if (Sy > 0) dFy = dx; else dFy = -dx;
            x = x1; y = y1; F = 0;
            if (Math.Abs(dx) >= Math.Abs(dy)) // angle <= 45 
            {
                do
                {
                    if (draw) { Draw(x, y); }
                    else
                    {
                        int dx1 = Math.Abs(curX - x);
                        int dy1 = Math.Abs(curY - y);

                        if (dx1 <= 10 && dy1 <= 10) { return true; }
                    }

                    if (x == x2) break;
                    Fx = F + dFx; F = Fx - dFy; x = x + Sx;
                    if (Math.Abs(Fx) < Math.Abs(F)) F = Fx; else y = y + Sy;
                } while (true);
            }
            else // angle > 45 
            {
                do
                {
                    if (draw) { Draw(x, y); }
                    else
                    {
                        int dx1 = Math.Abs(curX - x);
                        int dy1 = Math.Abs(curY - y);

                        if (dx1 <= 10 && dy1 <= 10) { return true; }
                    }
                    if (y == y2) break;
                    Fy = F - dFy; F = Fy + dFx; y = y + Sy;
                    if (Math.Abs(Fy) < Math.Abs(F)) F = Fy; else x = x + Sx;
                } while (true);
            }
            return false;
        }

        // Draw point (square)
        public void Draw(int x, int y) { g.DrawRectangle(p, x, y, p.Width, p.Width); }

    }
}
