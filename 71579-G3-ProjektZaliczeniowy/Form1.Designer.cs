namespace _71579_G3_ProjektZaliczeniowy
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblGracz = new System.Windows.Forms.Label();
            this.lblKomp = new System.Windows.Forms.Label();
            this.btnResetuj = new System.Windows.Forms.Button();
            this.btnZamknij = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGracz
            // 
            this.lblGracz.AutoSize = true;
            this.lblGracz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblGracz.ForeColor = System.Drawing.Color.Red;
            this.lblGracz.Location = new System.Drawing.Point(437, 34);
            this.lblGracz.Name = "lblGracz";
            this.lblGracz.Size = new System.Drawing.Size(90, 16);
            this.lblGracz.TabIndex = 0;
            this.lblGracz.Text = "PlayerWins;";
            // 
            // lblKomp
            // 
            this.lblKomp.AutoSize = true;
            this.lblKomp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKomp.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblKomp.Location = new System.Drawing.Point(437, 69);
            this.lblKomp.Name = "lblKomp";
            this.lblKomp.Size = new System.Drawing.Size(72, 16);
            this.lblKomp.TabIndex = 1;
            this.lblKomp.Text = "CpuWins;";
            // 
            // btnResetuj
            // 
            this.btnResetuj.Location = new System.Drawing.Point(452, 183);
            this.btnResetuj.Name = "btnResetuj";
            this.btnResetuj.Size = new System.Drawing.Size(75, 23);
            this.btnResetuj.TabIndex = 2;
            this.btnResetuj.Text = "RESET";
            this.btnResetuj.UseVisualStyleBackColor = true;
            this.btnResetuj.Click += new System.EventHandler(this.Resetuj_Click);
            // 
            // btnZamknij
            // 
            this.btnZamknij.Location = new System.Drawing.Point(452, 245);
            this.btnZamknij.Name = "btnZamknij";
            this.btnZamknij.Size = new System.Drawing.Size(75, 23);
            this.btnZamknij.TabIndex = 3;
            this.btnZamknij.Text = "EXIT";
            this.btnZamknij.UseVisualStyleBackColor = true;
            this.btnZamknij.Click += new System.EventHandler(this.Zamknij_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 401);
            this.Controls.Add(this.btnZamknij);
            this.Controls.Add(this.btnResetuj);
            this.Controls.Add(this.lblKomp);
            this.Controls.Add(this.lblGracz);
            this.Name = "Form1";
            this.Text = "TicTacToe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGracz;
        private System.Windows.Forms.Label lblKomp;
        private System.Windows.Forms.Button btnResetuj;
        private System.Windows.Forms.Button btnZamknij;
    }
}

