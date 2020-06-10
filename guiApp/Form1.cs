using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace guiApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = pictureBox.CreateGraphics(); // graphic initialization
        }

        // Graphics

        private Graphics g;
        private Pen p = new Pen(Color.Black, 1);

        // Algorithms

        private List<Obj> objects = new List<Obj>();
        private Line line;
        private Bezie bezie;
        private Str3 star;
        private Ugl3 ugl;

        // UI 

        private bool pull = false;

        enum Mode
        {
            Ln, Bz, Ugl3, Str3, // primitives 
            Sel                 // actions
        }

        Mode mode = Mode.Ln; // set default mode

        // Clear scene
        private void ClearAll() { g.Clear(Color.White); }

        // Draw schene
        private void DrawAll() { ClearAll(); objects.ForEach(o => o.Draw()); }

        // Unselect all objects
        void UnselectAll() { objects.ForEach(o => o.UnSelect()); }

        //
        // Trasformations
        //

        // Returns index of selected object
        public int SelectObj(int mX, int mY) { return objects.FindIndex(o => o.Contains(mX, mY)); }

        //
        // User actions
        //

        private void Line_CheckedChanged(object sender, EventArgs e) { mode = Mode.Ln; }
        private void BZ_BTN_CheckedChanged(object sender, EventArgs e) { mode = Mode.Bz; }
        private void UGL_BTN_CheckedChanged(object sender, EventArgs e) { mode = Mode.Ugl3; }
        private void STR_BTN_CheckedChanged(object sender, EventArgs e) { mode = Mode.Str3; }

        // Clears canvas
        private void ClearAllBtn_Click(object sender, EventArgs e) { ClearAll(); objects = new List<Obj>(); }

        // MouseDone handler
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            pull = true;
            switch (mode)
            {
                case Mode.Ln:
                    if (e.Button == MouseButtons.Right) { UnselectAll(); }
                    else
                    {
                        if (line == null) line = new Line(g, p);
                        if (line.AddPoint(point))
                        {
                            line.Draw();
                            objects.Add(line);
                            line = null;
                        }
                    }
                    break;
                case Mode.Bz:
                    if (e.Button == MouseButtons.Right)
                    {
                        if (bezie == null) return;
                        objects.Add(bezie);
                        DrawAll();
                        bezie = null;
                        UnselectAll();
                    }
                    else
                    {
                        if (bezie == null) bezie = new Bezie(g, p);
                        bezie.AddPoint(point);
                    }
                    break;
                case Mode.Ugl3:
                    if (e.Button == MouseButtons.Right) { UnselectAll(); }
                    else
                    {
                        ugl = new Ugl3(g, p, pictureBox.Height, pictureBox.Width);
                        ugl.LeftCorner(point);
                    }
                    break;
                case Mode.Str3:
                    if (e.Button == MouseButtons.Right) { UnselectAll(); }
                    else
                    {
                        star = new Str3(g, p, pictureBox.Height, pictureBox.Width);
                        star.LeftCorner(point);
                    }
                    break;
                case Mode.Sel:
                    if (e.Button == MouseButtons.Right) { UnselectAll(); }
                    else
                    {
                        int idx = SelectObj(e.X, e.Y);
                        if (idx == -1) return;
                        Obj obj = objects[idx];
                        obj.Select();

                    }
                    break;
            }
        }

        // Mouse move handler
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            Point point = new Point(e.X, e.Y);
            switch (mode)
            {
                case Mode.Ln:
                    break;
                case Mode.Bz:
                    break;
                case Mode.Ugl3:
                    if (!pull) return;
                    DrawAll();
                    ugl.DrawPreview(point);
                    break;
                case Mode.Str3:
                    if (!pull) return;
                    DrawAll();
                    star.DrawPreview(point);
                    break;
            }
        }

        // Mouse up handler
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            pull = false;
            switch (mode)
            {
                case Mode.Ln:
                    break;
                case Mode.Bz:
                    break;
                case Mode.Ugl3:
                    if (e.Button == MouseButtons.Right) return;
                    ugl.RightCorner(point);
                    objects.Add(ugl);
                    DrawAll();
                    break;
                case Mode.Str3:
                    if (e.Button == MouseButtons.Right) return;
                    star.RightCorner(point);
                    objects.Add(star);
                    DrawAll();
                    break;
            }
        }

        // Color changing
        private void Color_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (color.SelectedIndex) // выбор цвета 
            {
                case 0: p.Color = Color.Black; break;
                case 1: p.Color = Color.Red; break;
                case 2: p.Color = Color.Blue; break;
                case 3: p.Color = Color.Green; break;
            }
        }

        // Pen width changing
        private void Width_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (width.SelectedIndex) // выбор толщины линии 
            {
                case 0: p.Width = 1; break;
                case 1: p.Width = 2; break;
                case 2: p.Width = 4; break;
                case 3: p.Width = 8; break;
            }
        }

        // Select btn handler
        private void Select_Click(object sender, EventArgs e) { this.mode = Mode.Sel; }

        // Remove selected bnt handler
        private void Delete_Click(object sender, EventArgs e) { objects.RemoveAll(o => o.IsSelected()); DrawAll(); }

        // Rotate 60° btn handler
        private void Turn60_Click(object sender, EventArgs e) { objects.FindAll(o => o.IsSelected()).ForEach(o => o.Turn60(false)); DrawAll(); }

        private void Turn60cw_Click(object sender, EventArgs e) { objects.FindAll(o => o.IsSelected()).ForEach(o => o.Turn60(true)); DrawAll(); }

        // Scale up by Y btn handler
        private void IncreaseY_Click(object sender, EventArgs e) { objects.FindAll(o => o.IsSelected()).ForEach(o => o.Scale(true)); DrawAll(); }
        // Scale down by Y btn handler
        private void DecreaseY_Click(object sender, EventArgs e) { objects.FindAll(o => o.IsSelected()).ForEach(o => o.Scale(false)); DrawAll(); }

        // Mirror view by Y btn handler
        private void MirrorCenterY_Click(object sender, EventArgs e) { objects.FindAll(o => o.IsSelected()).ForEach(o => o.Mirrow(Coord.Y)); DrawAll(); }

        // Mirror view by X btn handler
        private void MirrorCenterX_Click(object sender, EventArgs e) { objects.FindAll(o => o.IsSelected()).ForEach(o => o.Mirrow(Coord.X)); DrawAll(); }

        private void MoveLeft_Click(object sender, EventArgs e) { objects.FindAll(o => o.IsSelected()).ForEach(o => o.Move(Direction.Left)); DrawAll(); }
        private void MoveRight_Click(object sender, EventArgs e) { objects.FindAll(o => o.IsSelected()).ForEach(o => o.Move(Direction.Right)); DrawAll(); }
        private void MoveUp_Click(object sender, EventArgs e) { objects.FindAll(o => o.IsSelected()).ForEach(o => o.Move(Direction.Up)); DrawAll(); }
        private void MoveDown_Click(object sender, EventArgs e) { objects.FindAll(o => o.IsSelected()).ForEach(o => o.Move(Direction.Down)); DrawAll(); }

    }
}
