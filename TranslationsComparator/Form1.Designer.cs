
namespace TranslationsComparator
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
            this.dialogSelectFiles = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.lblTranslationsComparator = new System.Windows.Forms.Label();
            this.lstMismatches = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstDoubled = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dialogSelectFiles
            // 
            this.dialogSelectFiles.FileName = "openFileDialog1";
            this.dialogSelectFiles.Title = "Wybierz pliki";
            this.dialogSelectFiles.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSelectFiles.Location = new System.Drawing.Point(12, 66);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(297, 120);
            this.btnSelectFiles.TabIndex = 0;
            this.btnSelectFiles.Text = "Kliknij aby wybrać pliki";
            this.btnSelectFiles.UseVisualStyleBackColor = true;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // lblTranslationsComparator
            // 
            this.lblTranslationsComparator.AutoSize = true;
            this.lblTranslationsComparator.Location = new System.Drawing.Point(500, 80);
            this.lblTranslationsComparator.Name = "lblTranslationsComparator";
            this.lblTranslationsComparator.Size = new System.Drawing.Size(0, 13);
            this.lblTranslationsComparator.TabIndex = 1;
            this.lblTranslationsComparator.Click += new System.EventHandler(this.label1_Click);
            // 
            // lstMismatches
            // 
            this.lstMismatches.FormattingEnabled = true;
            this.lstMismatches.Location = new System.Drawing.Point(12, 234);
            this.lstMismatches.Name = "lstMismatches";
            this.lstMismatches.Size = new System.Drawing.Size(297, 121);
            this.lstMismatches.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(16, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Brakujące klucze";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lstDoubled
            // 
            this.lstDoubled.FormattingEnabled = true;
            this.lstDoubled.Location = new System.Drawing.Point(12, 402);
            this.lstDoubled.Name = "lstDoubled";
            this.lstDoubled.Size = new System.Drawing.Size(297, 147);
            this.lstDoubled.TabIndex = 4;
            this.lstDoubled.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(18, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Powtarzające się wpisy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "Wybierz przynajmniej dwa pliki translacyjne\r\naby dokonać ich porównania.\r\nObecnie" +
    " ustawiony znak porównania to \'=\'\r\n";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 619);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstDoubled);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstMismatches);
            this.Controls.Add(this.lblTranslationsComparator);
            this.Controls.Add(this.btnSelectFiles);
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dialogSelectFiles;
        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.Label lblTranslationsComparator;
        private System.Windows.Forms.ListBox lstMismatches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstDoubled;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

