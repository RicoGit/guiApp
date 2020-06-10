using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace guiApp
{

    public enum Direction { Left, Right, Up, Down }
    interface Obj
    {
        void Draw();
        void Select();
        void UnSelect();
        bool IsSelected();
        void Turn60(bool clockwise);
        void Mirrow(Coord coord);
        void Scale(bool increase);
        void Move(Direction direction);
        bool Contains(int x, int y);
    }
}
