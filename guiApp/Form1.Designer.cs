namespace guiApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectBtn = new System.Windows.Forms.RadioButton();
            this.UGL_BTN = new System.Windows.Forms.RadioButton();
            this.STR_BTN = new System.Windows.Forms.RadioButton();
            this.lineSegment = new System.Windows.Forms.RadioButton();
            this.BZ_BTN = new System.Windows.Forms.RadioButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.clearAllBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mirrorCenterX = new System.Windows.Forms.Button();
            this.mirrorCenterY = new System.Windows.Forms.Button();
            this.decreaseY = new System.Windows.Forms.Button();
            this.moveDown = new System.Windows.Forms.Button();
            this.moveUp = new System.Windows.Forms.Button();
            this.moveRight = new System.Windows.Forms.Button();
            this.moveLeft = new System.Windows.Forms.Button();
            this.increaseY = new System.Windows.Forms.Button();
            this.turn60 = new System.Windows.Forms.Button();
            this.turn60cw = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.width = new System.Windows.Forms.ComboBox();
            this.color = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectBtn);
            this.groupBox1.Controls.Add(this.UGL_BTN);
            this.groupBox1.Controls.Add(this.STR_BTN);
            this.groupBox1.Controls.Add(this.lineSegment);
            this.groupBox1.Controls.Add(this.BZ_BTN);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Примитивы";
            // 
            // selectBtn
            // 
            this.selectBtn.AutoSize = true;
            this.selectBtn.Location = new System.Drawing.Point(6, 131);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(147, 21);
            this.selectBtn.TabIndex = 4;
            this.selectBtn.Text = "Выделить (Select)";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.CheckedChanged += new System.EventHandler(this.Select_Click);
            // 
            // UGL_BTN
            // 
            this.UGL_BTN.AutoSize = true;
            this.UGL_BTN.Location = new System.Drawing.Point(6, 77);
            this.UGL_BTN.Name = "UGL_BTN";
            this.UGL_BTN.Size = new System.Drawing.Size(102, 21);
            this.UGL_BTN.TabIndex = 2;
            this.UGL_BTN.Text = "Угол (Ugl3)";
            this.UGL_BTN.UseVisualStyleBackColor = true;
            this.UGL_BTN.CheckedChanged += new System.EventHandler(this.UGL_BTN_CheckedChanged);
            // 
            // STR_BTN
            // 
            this.STR_BTN.AutoSize = true;
            this.STR_BTN.Location = new System.Drawing.Point(6, 104);
            this.STR_BTN.Name = "STR_BTN";
            this.STR_BTN.Size = new System.Drawing.Size(132, 21);
            this.STR_BTN.TabIndex = 3;
            this.STR_BTN.Text = "Стрелка3 (Str3)";
            this.STR_BTN.UseVisualStyleBackColor = true;
            this.STR_BTN.CheckedChanged += new System.EventHandler(this.STR_BTN_CheckedChanged);
            // 
            // lineSegment
            // 
            this.lineSegment.AutoSize = true;
            this.lineSegment.Checked = true;
            this.lineSegment.Location = new System.Drawing.Point(6, 23);
            this.lineSegment.Name = "lineSegment";
            this.lineSegment.Size = new System.Drawing.Size(124, 21);
            this.lineSegment.TabIndex = 1;
            this.lineSegment.TabStop = true;
            this.lineSegment.Text = "Прямая линия";
            this.lineSegment.UseVisualStyleBackColor = true;
            this.lineSegment.CheckedChanged += new System.EventHandler(this.Line_CheckedChanged);
            // 
            // BZ_BTN
            // 
            this.BZ_BTN.AutoSize = true;
            this.BZ_BTN.Location = new System.Drawing.Point(6, 50);
            this.BZ_BTN.Name = "BZ_BTN";
            this.BZ_BTN.Size = new System.Drawing.Size(152, 21);
            this.BZ_BTN.TabIndex = 1;
            this.BZ_BTN.Text = "Кривая Безье (BZ)";
            this.BZ_BTN.UseVisualStyleBackColor = true;
            this.BZ_BTN.CheckedChanged += new System.EventHandler(this.BZ_BTN_CheckedChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox.Location = new System.Drawing.Point(218, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(570, 475);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseUp);
            // 
            // clearAllBtn
            // 
            this.clearAllBtn.Location = new System.Drawing.Point(12, 444);
            this.clearAllBtn.Name = "clearAllBtn";
            this.clearAllBtn.Size = new System.Drawing.Size(200, 46);
            this.clearAllBtn.TabIndex = 2;
            this.clearAllBtn.Text = "Очистить поле";
            this.clearAllBtn.UseVisualStyleBackColor = true;
            this.clearAllBtn.Click += new System.EventHandler(this.ClearAllBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mirrorCenterX);
            this.groupBox2.Controls.Add(this.mirrorCenterY);
            this.groupBox2.Controls.Add(this.decreaseY);
            this.groupBox2.Controls.Add(this.moveDown);
            this.groupBox2.Controls.Add(this.moveUp);
            this.groupBox2.Controls.Add(this.moveRight);
            this.groupBox2.Controls.Add(this.moveLeft);
            this.groupBox2.Controls.Add(this.increaseY);
            this.groupBox2.Controls.Add(this.turn60);
            this.groupBox2.Controls.Add(this.turn60cw);
            this.groupBox2.Controls.Add(this.delete);
            this.groupBox2.Controls.Add(this.width);
            this.groupBox2.Controls.Add(this.color);
            this.groupBox2.Location = new System.Drawing.Point(12, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 262);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Инструменты";
            // 
            // mirrorCenterX
            // 
            this.mirrorCenterX.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mirrorCenterX.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mirrorCenterX.BackgroundImage")));
            this.mirrorCenterX.Location = new System.Drawing.Point(103, 225);
            this.mirrorCenterX.Name = "mirrorCenterX";
            this.mirrorCenterX.Size = new System.Drawing.Size(91, 30);
            this.mirrorCenterX.TabIndex = 10;
            this.mirrorCenterX.Text = "⇄";
            this.mirrorCenterX.UseVisualStyleBackColor = true;
            this.mirrorCenterX.Click += new System.EventHandler(this.MirrorCenterX_Click);
            // 
            // MirrorCenterY
            // 
            this.mirrorCenterY.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mirrorCenterY.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MirrorCenterY.BackgroundImage")));
            this.mirrorCenterY.Location = new System.Drawing.Point(6, 225);
            this.mirrorCenterY.Name = "MirrorCenterY";
            this.mirrorCenterY.Size = new System.Drawing.Size(91, 30);
            this.mirrorCenterY.TabIndex = 10;
            this.mirrorCenterY.Text = "⇅";
            this.mirrorCenterY.UseVisualStyleBackColor = true;
            this.mirrorCenterY.Click += new System.EventHandler(this.MirrorCenterY_Click);
            // 
            // decreaseY
            // 
            this.decreaseY.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.decreaseY.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("decreaseY.BackgroundImage")));
            this.decreaseY.Location = new System.Drawing.Point(103, 189);
            this.decreaseY.Name = "decreaseY";
            this.decreaseY.Size = new System.Drawing.Size(91, 30);
            this.decreaseY.TabIndex = 10;
            this.decreaseY.Text = "- (Y)";
            this.decreaseY.UseVisualStyleBackColor = true;
            this.decreaseY.Click += new System.EventHandler(this.DecreaseY_Click);
            // 
            // moveDown
            // 
            this.moveDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.moveDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveDown.BackgroundImage")));
            this.moveDown.Location = new System.Drawing.Point(150, 153);
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(42, 30);
            this.moveDown.TabIndex = 10;
            this.moveDown.Text = "↓";
            this.moveDown.UseVisualStyleBackColor = true;
            this.moveDown.Click += new System.EventHandler(this.MoveDown_Click);
            // 
            // moveUp
            // 
            this.moveUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.moveUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveUp.BackgroundImage")));
            this.moveUp.Location = new System.Drawing.Point(102, 153);
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(42, 30);
            this.moveUp.TabIndex = 10;
            this.moveUp.Text = "↑";
            this.moveUp.UseVisualStyleBackColor = true;
            this.moveUp.Click += new System.EventHandler(this.MoveUp_Click);
            // 
            // moveRight
            // 
            this.moveRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.moveRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveRight.BackgroundImage")));
            this.moveRight.Location = new System.Drawing.Point(54, 153);
            this.moveRight.Name = "moveRight";
            this.moveRight.Size = new System.Drawing.Size(42, 30);
            this.moveRight.TabIndex = 10;
            this.moveRight.Text = "→";
            this.moveRight.UseVisualStyleBackColor = true;
            this.moveRight.Click += new System.EventHandler(this.MoveRight_Click);
            // 
            // moveLeft
            // 
            this.moveLeft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.moveLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveLeft.BackgroundImage")));
            this.moveLeft.Location = new System.Drawing.Point(6, 153);
            this.moveLeft.Name = "moveLeft";
            this.moveLeft.Size = new System.Drawing.Size(42, 30);
            this.moveLeft.TabIndex = 10;
            this.moveLeft.Text = "←";
            this.moveLeft.UseVisualStyleBackColor = true;
            this.moveLeft.Click += new System.EventHandler(this.MoveLeft_Click);
            // 
            // increaseY
            // 
            this.increaseY.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.increaseY.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("increaseY.BackgroundImage")));
            this.increaseY.Location = new System.Drawing.Point(6, 189);
            this.increaseY.Name = "increaseY";
            this.increaseY.Size = new System.Drawing.Size(91, 30);
            this.increaseY.TabIndex = 10;
            this.increaseY.Text = "+ (Y)";
            this.increaseY.UseVisualStyleBackColor = true;
            this.increaseY.Click += new System.EventHandler(this.IncreaseY_Click);
            // 
            // turn60
            // 
            this.turn60.Location = new System.Drawing.Point(103, 117);
            this.turn60.Name = "turn60";
            this.turn60.Size = new System.Drawing.Size(91, 30);
            this.turn60.TabIndex = 10;
            this.turn60.Text = "↺ 60°";
            this.turn60.UseVisualStyleBackColor = true;
            this.turn60.Click += new System.EventHandler(this.Turn60_Click);
            // 
            // turn60cw
            // 
            this.turn60cw.Location = new System.Drawing.Point(6, 117);
            this.turn60cw.Name = "turn60cw";
            this.turn60cw.Size = new System.Drawing.Size(91, 30);
            this.turn60cw.TabIndex = 10;
            this.turn60cw.Text = "↻ 60°";
            this.turn60cw.UseVisualStyleBackColor = true;
            this.turn60cw.Click += new System.EventHandler(this.Turn60cw_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(6, 81);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(188, 30);
            this.delete.TabIndex = 10;
            this.delete.Text = "Удалить";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // width
            // 
            this.width.FormattingEnabled = true;
            this.width.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8"});
            this.width.Location = new System.Drawing.Point(6, 51);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(188, 24);
            this.width.TabIndex = 13;
            this.width.Text = "Толщина линии";
            this.width.SelectedIndexChanged += new System.EventHandler(this.Width_SelectedIndexChanged);
            // 
            // color
            // 
            this.color.FormattingEnabled = true;
            this.color.Items.AddRange(new object[] {
            "Черный",
            "Красный",
            "Синий",
            "Зеленый"});
            this.color.Location = new System.Drawing.Point(6, 21);
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(188, 24);
            this.color.TabIndex = 12;
            this.color.Text = "Цвет";
            this.color.SelectedIndexChanged += new System.EventHandler(this.Color_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 499);
            this.Controls.Add(this.clearAllBtn);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton UGL_BTN;
        private System.Windows.Forms.RadioButton STR_BTN;
        private System.Windows.Forms.RadioButton BZ_BTN;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button clearAllBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox color;
        private System.Windows.Forms.ComboBox width;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.RadioButton selectBtn;
        private System.Windows.Forms.Button turn60cw;
        private System.Windows.Forms.Button increaseY;
        private System.Windows.Forms.Button mirrorCenterY;
        private System.Windows.Forms.Button decreaseY;
        private System.Windows.Forms.Button mirrorCenterX;
        private System.Windows.Forms.Button turn60;
        private System.Windows.Forms.Button moveRight;
        private System.Windows.Forms.Button moveLeft;
        private System.Windows.Forms.Button moveDown;
        private System.Windows.Forms.Button moveUp;
        private System.Windows.Forms.RadioButton lineSegment;
    }
}

