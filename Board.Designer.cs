namespace DominoGame
{
    partial class Board
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Board));
            this.bazar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.field = new System.Windows.Forms.Label();
            this.bazarC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bazar
            // 
            this.bazar.BackColor = System.Drawing.Color.Transparent;
            this.bazar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bazar.BackgroundImage")));
            this.bazar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bazar.FlatAppearance.BorderSize = 0;
            this.bazar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bazar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bazar.Location = new System.Drawing.Point(255, 536);
            this.bazar.Name = "bazar";
            this.bazar.Size = new System.Drawing.Size(137, 54);
            this.bazar.TabIndex = 0;
            this.bazar.UseVisualStyleBackColor = false;
            this.bazar.Click += new System.EventHandler(this.bazar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(27, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "PC\'s hand";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(27, 578);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Your hand";
            // 
            // field
            // 
            this.field.AutoSize = true;
            this.field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.field.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.field.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.field.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.field.Location = new System.Drawing.Point(34, 231);
            this.field.MinimumSize = new System.Drawing.Size(575, 290);
            this.field.Name = "field";
            this.field.Size = new System.Drawing.Size(575, 290);
            this.field.TabIndex = 7;
            this.field.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bazarC
            // 
            this.bazarC.AutoSize = true;
            this.bazarC.BackColor = System.Drawing.Color.Transparent;
            this.bazarC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.bazarC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bazarC.Location = new System.Drawing.Point(409, 551);
            this.bazarC.Name = "bazarC";
            this.bazarC.Size = new System.Drawing.Size(0, 24);
            this.bazarC.TabIndex = 8;
            this.bazarC.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.5F);
            this.label3.Location = new System.Drawing.Point(29, 226);
            this.label3.MinimumSize = new System.Drawing.Size(548, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(587, 300);
            this.label3.TabIndex = 9;
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(648, 747);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bazarC);
            this.Controls.Add(this.field);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bazar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Board";
            this.Text = "Board";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bazar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label field;
        private System.Windows.Forms.Label bazarC;
        private System.Windows.Forms.Label label3;
    }
}