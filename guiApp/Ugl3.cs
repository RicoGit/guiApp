using System;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace guiApp
{
    class Ugl3 : Str3
    {

        public Ugl3(Graphics g, Pen p, int height, int width) : base(g, p, height, width) { }

        override public void Draw()
        {
            if (left.IsEmpty) return;
            Console.WriteLine("draw Angle(left " + left + ", right " + right);
            g.DrawPolygon(p, vertexList.ToArray());
            if (filled) PaintingPolygon();
        }

        // Builds points of figure
        override protected List<PointF> buildOutline(Point right)
        {
            List<PointF> vertexes = new List<PointF>(4);
            vertexes.Add(new Point(left.X, left.Y));
            vertexes.Add(new Point(right.X, left.Y));
            vertexes.Add(new Point(left.X + (right.X - left.X) / 3, left.Y - (left.Y - right.Y) / 3));
            vertexes.Add(new Point(left.X, right.Y));
            return vertexes;
        }

    }
}
