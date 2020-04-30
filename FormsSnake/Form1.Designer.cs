namespace FormsSnake
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
            this.components = new System.ComponentModel.Container();
            this.snake0 = new System.Windows.Forms.Panel();
            this.snake1 = new System.Windows.Forms.Panel();
            this.snake2 = new System.Windows.Forms.Panel();
            this.SnakeGo = new System.Windows.Forms.Timer(this.components);
            this.Apple = new System.Windows.Forms.Panel();
            this.Count = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // snake0
            // 
            this.snake0.BackColor = System.Drawing.SystemColors.Info;
            this.snake0.Location = new System.Drawing.Point(663, 208);
            this.snake0.Name = "snake0";
            this.snake0.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.snake0.Size = new System.Drawing.Size(32, 32);
            this.snake0.TabIndex = 0;
            // 
            // snake1
            // 
            this.snake1.BackColor = System.Drawing.SystemColors.Info;
            this.snake1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.snake1.Location = new System.Drawing.Point(701, 208);
            this.snake1.Name = "snake1";
            this.snake1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.snake1.Size = new System.Drawing.Size(32, 32);
            this.snake1.TabIndex = 1;
            // 
            // snake2
            // 
            this.snake2.BackColor = System.Drawing.SystemColors.Info;
            this.snake2.Location = new System.Drawing.Point(739, 208);
            this.snake2.Name = "snake2";
            this.snake2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.snake2.Size = new System.Drawing.Size(32, 32);
            this.snake2.TabIndex = 2;
            // 
            // SnakeGo
            // 
            this.SnakeGo.Enabled = true;
            this.SnakeGo.Tick += new System.EventHandler(this.SnakeGo_Tick);
            // 
            // Apple
            // 
            this.Apple.BackColor = System.Drawing.SystemColors.Highlight;
            this.Apple.Location = new System.Drawing.Point(69, 208);
            this.Apple.MaximumSize = new System.Drawing.Size(32, 32);
            this.Apple.MinimumSize = new System.Drawing.Size(32, 32);
            this.Apple.Name = "Apple";
            this.Apple.Size = new System.Drawing.Size(32, 32);
            this.Apple.TabIndex = 3;
            // 
            // Count
            // 
            this.Count.BackColor = System.Drawing.Color.Transparent;
            this.Count.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Count.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold);
            this.Count.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Count.Location = new System.Drawing.Point(757, 9);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(31, 36);
            this.Count.TabIndex = 2;
            this.Count.Text = "0";
            this.Count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 748);
            this.Controls.Add(this.Apple);
            this.Controls.Add(this.snake2);
            this.Controls.Add(this.snake1);
            this.Controls.Add(this.snake0);
            this.Controls.Add(this.Count);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(800, 748);
            this.MinimumSize = new System.Drawing.Size(800, 748);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel snake0;
        private System.Windows.Forms.Panel snake1;
        private System.Windows.Forms.Panel snake2;
        private System.Windows.Forms.Timer SnakeGo;
        private System.Windows.Forms.Panel Apple;
        private System.Windows.Forms.Label Count;
    }
}

