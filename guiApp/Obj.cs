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
        // Draws this object
        void Draw();
        // Makes this object selected
        void Select();
        // Unselects this object
        void UnSelect();
        // Checks whether this object selected or not
        bool IsSelected();
        // Rotates around its axis clockwise or not
        void Turn60(bool clockwise);
        // Object mirroring
        void Mirrow(Coord coord);
        // Scale by axis Y
        void Scale(bool increase);
        // Moves object to corresponded direction
        void Move(Direction direction);
        // Chekcs whether point contains inside object or not
        bool Contains(int x, int y);
    }
}
