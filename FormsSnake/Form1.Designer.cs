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
            this.Snake0 = new System.Windows.Forms.Panel();
            this.Snake1 = new System.Windows.Forms.Panel();
            this.Snake2 = new System.Windows.Forms.Panel();
            this.SnakeGo = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Snake0
            // 
            this.Snake0.BackColor = System.Drawing.SystemColors.Info;
            this.Snake0.Location = new System.Drawing.Point(0, 0);
            this.Snake0.Name = "Snake0";
            this.Snake0.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Snake0.Size = new System.Drawing.Size(32, 32);
            this.Snake0.TabIndex = 0;
            // 
            // Snake1
            // 
            this.Snake1.BackColor = System.Drawing.SystemColors.Info;
            this.Snake1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Snake1.Location = new System.Drawing.Point(32, 0);
            this.Snake1.Name = "Snake1";
            this.Snake1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Snake1.Size = new System.Drawing.Size(32, 32);
            this.Snake1.TabIndex = 1;
            // 
            // Snake2
            // 
            this.Snake2.BackColor = System.Drawing.SystemColors.Info;
            this.Snake2.Location = new System.Drawing.Point(64, 0);
            this.Snake2.Name = "Snake2";
            this.Snake2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Snake2.Size = new System.Drawing.Size(32, 32);
            this.Snake2.TabIndex = 2;
            // 
            // SnakeGo
            // 
            this.SnakeGo.Enabled = true;
            this.SnakeGo.Interval = 200;
            this.SnakeGo.Tick += new System.EventHandler(this.SnakeGo_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 748);
            this.Controls.Add(this.Snake2);
            this.Controls.Add(this.Snake1);
            this.Controls.Add(this.Snake0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(800, 748);
            this.MinimumSize = new System.Drawing.Size(800, 748);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Snake0;
        private System.Windows.Forms.Panel Snake1;
        private System.Windows.Forms.Panel Snake2;
        private System.Windows.Forms.Timer SnakeGo;
    }
}

