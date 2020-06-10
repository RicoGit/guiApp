using System.Collections.Generic;
using System.Drawing;
using System;

namespace guiApp
{
    class Str3 : Polygon
    {
        protected Point left;
        protected Point right;
        protected bool filled = true;

        public Str3(Graphics g, Pen p, int height, int width)
        {
            this.g = g;
            this.p = (Pen)p.Clone();
            this.width = height;
            this.height = width;
            this.prevColor = p.Color;
        }

        override public void Draw()
        {
            if (left.IsEmpty) return;
            Console.WriteLine("draw Polygon(left " + left + ", right " + right);
            g.DrawPolygon(p, vertexList.ToArray());
            if (filled) PaintingPolygon();
        }

        // Pin left corner
        public void LeftCorner(Point point) { left = point; }

        // Pin left corner
        public void RightCorner(Point point)
        {
            this.right = point;
            this.vertexList = buildOutline(right);
            Init();
        }

        // Draw preview
        public void DrawPreview(Point right)
        {
            if (left.IsEmpty) return;

            Color prevColor = p.Color;
            p.Color = Color.DarkGray;
            g.DrawPolygon(p, buildOutline(right).ToArray());
            p.Color = prevColor;

        }

        // Builds points of figure
        protected virtual List<PointF> buildOutline(Point right)
        {
            List<PointF> vertexes = new List<PointF>(6);
            vertexes.Add(new Point(left.X, left.Y));
            vertexes.Add(new Point(right.X, left.Y));
            vertexes.Add(new Point(right.X + (right.X - left.X) / 2, left.Y - (left.Y - right.Y) / 2));
            vertexes.Add(new Point(right.X, right.Y));
            vertexes.Add(new Point(left.X, right.Y));
            vertexes.Add(new Point(left.X + (right.X - left.X) / 2, left.Y - (left.Y - right.Y) / 2));
            return vertexes;
        }

    }
}
