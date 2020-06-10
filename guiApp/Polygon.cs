using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace guiApp
{
    public abstract class Polygon : Obj
    {

        protected Graphics g;
        protected Pen p;

        public List<PointF> vertexList;

        // width and height of canvas
        protected int height;
        protected int width;
        // list for primitive parties
        protected List<side> sides;
        protected bool isSelected = false;
        protected Color prevColor;

        // arrays of left and right boundaries of primitive section segments
        readonly List<int> Xl = new List<int>();
        readonly List<int> Xr = new List<int>();

        // structure for implementing the primitive side
        public struct side
        {
            public Point begin;
            public Point end;
            public double dXdY; // ctg of angle with axis ОХ = dx/dy
        };

        // Polygon fill
        public void PaintingPolygon()
        {

            Pen drawPen = new Pen(this.p.Color, 1);
            (float Ymin, float Ymax) = Utils.FindMaxMin(Coord.Y, vertexList);
            int begin = (int)Math.Ceiling(Ymin), end = (int)Math.Floor(Ymax);
            if (begin < 0) { begin = 0; } // corrects Ymax
            if (end > height) { end = height; } // corrects Ymin

            for (int Y = begin; Y <= end; Y++)
            {
                Xl.Clear();
                Xr.Clear();
                FindXrXl(Y);

                Xl.Sort();
                Xr.Sort();
                // take a pair of intersection points and paint over the segment between them
                for (int i = 0; i < Xl.Count(); i++) { g.DrawLine(drawPen, Xl.ElementAt(i), Y, Xr.ElementAt(i), Y); }
            }
        }

        public virtual bool Contains(int mX, int mY)
        {
            bool check = false;
            Xl.Clear();
            Xr.Clear();
            FindXrXl(mY);

            Xl.Sort();
            Xr.Sort();
            for (int i = 0; i < Xl.Count(); i++)
            {
                if (mX >= Xl[i] & mX <= Xr[i]) { check = true; break; }
            }
            return check;
        }


        // Finding the left and right borders of a polygon for a section by a given line
        public void FindXrXl(int Y)
        {
            int X;
            List<int> Xb = new List<int>(); // coordinates of the intersection of the line with the sides of the polygon
            for (int i = 0; i < sides.Count(); i++)
            {
                // check if the line crosses the side
                if ((((sides[i].begin.Y < Y) && (sides[i].end.Y >= Y)) || ((sides[i].begin.Y >= Y) && (sides[i].end.Y < Y))) && sides[i].begin.Y != sides[i].end.Y)
                {
                    X = (int)((Y - sides[i].begin.Y) * sides[i].dXdY + sides[i].begin.X); // line intersection coordinate with side
                    if (X < sides[i].begin.X && X < sides[i].end.X)
                    {
                        X = Math.Min(sides[i].begin.X, sides[i].end.X);
                    }
                    if (X > sides[i].begin.X && X > sides[i].end.X)
                    {
                        X = Math.Max(sides[i].begin.X, sides[i].end.X);
                    }
                    Xb.Add(X);
                }
            }
            Xb.Sort();
            // take a pair of intersection points and add them to the arrays of left and right borders
            for (int i = 0; i < Xb.Count() - 1; i = i + 2)
            {
                int xl = Xb.ElementAt(i) + 1;
                int xr = Xb.ElementAt(i + 1);

                Xl.Add(xl);
                Xr.Add(xr);
            }
        }

        // Fill a list of sides of a polygon using a list of vertices
        protected static List<side> PointsToSides(List<PointF> vertexList)
        {
            List<side> sides = new List<side>();
            int k;
            double dxdy;
            int n = vertexList.Count();
            Point Pi = new Point();
            Point Pk = new Point();
            for (int i = 0; i < n; i++)
            {
                if (i < n - 1)
                    k = i + 1;
                else
                    k = 0;
                Pi.X = (int)Math.Round(vertexList[i].X);
                Pi.Y = (int)Math.Round(vertexList[i].Y);
                Pk.X = (int)Math.Round(vertexList[k].X);
                Pk.Y = (int)Math.Round(vertexList[k].Y);
                if ((vertexList[k].Y - vertexList[i].Y) == 0)
                    dxdy = 0;
                else
                {
                    dxdy = (double)((vertexList[k].X - vertexList[i].X) / (vertexList[k].Y - vertexList[i].Y));
                }
                sides.Add(new side() { begin = Pi, end = Pk, dXdY = dxdy });
            }
            return sides;
        }

        // Initialixation of some inner state
        public void Init() { this.sides = PointsToSides(vertexList); }

        //
        // Draws a polygon and fill it
        //
        public abstract void Draw();

        public void Select()
        {
            this.isSelected = true;
            this.prevColor = p.Color;
            p.Color = Color.DarkGray;
            Draw();
        }

        public void UnSelect()
        {
            this.isSelected = false;
            this.p.Color = prevColor;
            Draw();
        }

        public bool IsSelected() { return this.isSelected; }

        //
        // Transmutations
        //

        double[,] P; // resultant transformation matrix (P = E x W1 x W2 x ... x Wn)
        double[][,] C0; // array of matrices of source fixed coordinates

        // Умножение матриц
        public double[,] MultMatrix(double[,] a, double[,] b)
        {
            double[,] resMatrix = new double[a.GetLength(0), b.GetLength(1)];

            for (int i = 0; i < resMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        resMatrix[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return resMatrix;
        }

        // Performing geometric transformations
        public void Transform(double[,] M1, double[,] W, double[,] M2)
        {
            double[,] Pi = MultMatrix(M1, W); // матрица элементарного преобразования (перенос в (0,0) - преобразование - перенос обратно)
            Pi = MultMatrix(Pi, M2);
            P = MultMatrix(P, Pi);
            double[,] res = new double[1, 3];
            PointF fP = new PointF();
            //for (int i = 0; i < pgnList[index].primVertexList.Count(); i++)
            for (int i = 0; i < vertexList.Count(); i++)
            {
                res = MultMatrix(C0[i], P);
                fP.X = (float)res[0, 0];
                fP.Y = (float)res[0, 1];
                vertexList[i] = fP; // todo save to new List
            }
        }

        // Initialization of the matrix of initial coordinates and the transformation matrix
        public void InitMatrix()
        {
            C0 = new double[vertexList.Count()][,];
            for (int i = 0; i < vertexList.Count(); i++)
            {
                C0[i] = new double[1, 3];
                C0[i][0, 0] = vertexList[i].X;
                C0[i][0, 1] = vertexList[i].Y;
                C0[i][0, 2] = 1;
            }
            P = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
        }

        // Calculates coordinates of figure center 
        protected PointF GetCenter()
        {
            (float Ymin, float Ymax) = Utils.FindMaxMin(Coord.Y, vertexList);
            (float Xmin, float Xmax) = Utils.FindMaxMin(Coord.X, vertexList);
            return new PointF(Xmin + (Xmax - Xmin) / 2, Ymin + (Ymax - Ymin) / 2);
        }

        // 60 degree rotation around the center of the figure
        public void Turn60(bool clockwise)
        {
            InitMatrix();
            PointF center = GetCenter();

            double cosA = 0.5;
            double sinA = 0.866025404;
            if (!clockwise) sinA = -sinA;
            // transformation matrix
            double[,] W = new double[,] { { cosA, sinA, 0 }, { -sinA, cosA, 0 }, { 0, 0, 1 } };
            // transformation matrices for transfer to the origin and vice versa
            double[,] M1 = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { -center.X, -center.Y, 1 } };
            double[,] M2 = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { center.X, center.Y, 1 } };
            Transform(M1, W, M2);
            Init();
        }

        // Vertical Mirroring
        public void Mirrow(Coord coord)
        {
            InitMatrix();
            PointF center = GetCenter();

            // transformation matrix
            double[,] W = coord is Coord.Y
                ? new double[,] { { 1, 0, 0 }, { 0, -1, 0 }, { 0, 0, 1 } }
                : new double[,] { { -1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            // transformation matrices for transfer to the origin and vice versa
            double[,] M1 = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { -center.X, -center.Y, 1 } };
            double[,] M2 = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { center.X, center.Y, 1 } };
            Transform(M1, W, M2);
            Init();
        }

        // Y axis scaling
        public void Scale(bool increase)
        {
            InitMatrix();
            PointF center = GetCenter();

            float scale = increase ? 1.5f : 0.5f;
            // transformation matrix
            double[,] W = new double[,] { { 1, 0, 0 }, { 0, scale, 0 }, { 0, 0, 1 } };
            // transformation matrices for transfer to the origin and vice versa
            double[,] M1 = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { -center.X, -center.Y, 1 } };
            double[,] M2 = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { center.X, center.Y, 1 } };
            Transform(M1, W, M2);
            Init();
        }

        // Moves according to direction
        public void Move(Direction direction)
        {
            InitMatrix();
            PointF center = GetCenter();

            // transformation matrix
            double[,] W = new double[,] { { } };
            switch (direction)
            {
                case Direction.Left:
                    W = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { -5, 0, 1 } };
                    break;
                case Direction.Right:
                    W = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 5, 0, 1 } };
                    break;
                case Direction.Up:
                    W = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, -5, 1 } };
                    break;
                case Direction.Down:
                    W = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 5, 1 } };
                    break;
            }

            // transformation matrices for transfer to the origin and vice versa
            double[,] M1 = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { -center.X, -center.Y, 1 } };
            double[,] M2 = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { center.X, center.Y, 1 } };
            Transform(M1, W, M2);
            Init();
        }
    }
}
