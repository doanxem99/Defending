namespace nonamegame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SCORE_label = new System.Windows.Forms.Label();
            this.TANK_picturebox = new System.Windows.Forms.PictureBox();
            this.BACKGROUND_picturebox = new System.Windows.Forms.PictureBox();
            this.POSITION_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TANK_picturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BACKGROUND_picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // SCORE_label
            // 
            this.SCORE_label.AutoSize = true;
            this.SCORE_label.BackColor = System.Drawing.SystemColors.Menu;
            this.SCORE_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SCORE_label.Location = new System.Drawing.Point(0, 0);
            this.SCORE_label.Name = "SCORE_label";
            this.SCORE_label.Size = new System.Drawing.Size(178, 36);
            this.SCORE_label.TabIndex = 2;
            this.SCORE_label.Text = "SCORE : 0    ";
            // 
            // TANK_picturebox
            // 
            this.TANK_picturebox.BackColor = System.Drawing.Color.Cyan;
            this.TANK_picturebox.Image = global::nonamegame.Properties.Resources.TANK;
            this.TANK_picturebox.Location = new System.Drawing.Point(450, 250);
            this.TANK_picturebox.Name = "TANK_picturebox";
            this.TANK_picturebox.Size = new System.Drawing.Size(50, 50);
            this.TANK_picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.TANK_picturebox.TabIndex = 0;
            this.TANK_picturebox.TabStop = false;
            // 
            // BACKGROUND_picturebox
            // 
            this.BACKGROUND_picturebox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BACKGROUND_picturebox.Location = new System.Drawing.Point(0, 0);
            this.BACKGROUND_picturebox.Name = "BACKGROUND_picturebox";
            this.BACKGROUND_picturebox.Size = new System.Drawing.Size(930, 710);
            this.BACKGROUND_picturebox.TabIndex = 1;
            this.BACKGROUND_picturebox.TabStop = false;
            this.BACKGROUND_picturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.BACKGROUND_picturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // POSITION_label
            // 
            this.POSITION_label.AutoSize = true;
            this.POSITION_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POSITION_label.Location = new System.Drawing.Point(840, 685);
            this.POSITION_label.Name = "POSITION_label";
            this.POSITION_label.Size = new System.Drawing.Size(90, 25);
            this.POSITION_label.TabIndex = 3;
            this.POSITION_label.Text = "000:000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 711);
            this.Controls.Add(this.POSITION_label);
            this.Controls.Add(this.SCORE_label);
            this.Controls.Add(this.TANK_picturebox);
            this.Controls.Add(this.BACKGROUND_picturebox);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.TANK_picturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BACKGROUND_picturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox TANK_picturebox;
        private System.Windows.Forms.PictureBox BACKGROUND_picturebox;
        private System.Windows.Forms.Label SCORE_label;
        private System.Windows.Forms.Label POSITION_label;
    }
}

