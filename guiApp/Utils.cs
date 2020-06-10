using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace guiApp
{
    public class Utils
    {

        // Нахождение Xmax, Ymax, Xmin и Ymin (крайные правую, левую, верхнюю и нижнюю вершины многоугольника)
        public static (float, float) FindMaxMin(Coord coord, List<PointF> vertexList)
        {
            List<PointF> vertexsSort = new List<PointF>();
            vertexsSort.AddRange(vertexList);
            float min = 0, max = 0;
            switch (coord)
            {
                case Coord.X:
                    vertexsSort.Sort(CompareX); // сортировка списка sidesSort по возрастанию vertexList[i].X
                    max = vertexsSort[vertexsSort.Count() - 1].X;
                    min = vertexsSort[0].X;
                    return (min, max); // Xmin, Xmax
                case Coord.Y:
                    vertexsSort.Sort(CompareY); // сортировка списка sidesSort по возрастанию vertexList[i].Y
                    max = vertexsSort[vertexsSort.Count() - 1].Y;
                    min = vertexsSort[0].Y;
                    return (min, max); // Ymin, Ymax
            }
            throw new Exception("shouldn't be there");
        }

        public static int CompareX(PointF o1, PointF o2)
        {
            if (o1.X > o2.X) { return 1; }
            else if (o1.X < o2.X) { return -1; }
            return 0;
        }

        public static int CompareY(PointF o1, PointF o2)
        {
            if (o1.Y > o2.Y) { return 1; }
            else if (o1.Y < o2.Y) { return -1; }
            return 0;
        }

    }
}
