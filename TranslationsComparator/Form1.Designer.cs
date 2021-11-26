
namespace TranslationsComparator
{
    partial class MainForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.labelMissingEntries = new System.Windows.Forms.Label();
            this.labelDoubledEntries = new System.Windows.Forms.Label();
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
            this.btnSelectFiles.Size = new System.Drawing.Size(297, 45);
            this.btnSelectFiles.TabIndex = 0;
            this.btnSelectFiles.Text = "Kliknij aby wybrać pliki";
            this.btnSelectFiles.UseVisualStyleBackColor = true;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "Wybierz dokładnie dwa pliki translacyjne\r\naby dokonać ich porównania.\r\nObecnie us" +
    "tawiony znak porównania to \'=\'\r\n";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // labelMissingEntries
            // 
            this.labelMissingEntries.AutoSize = true;
            this.labelMissingEntries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMissingEntries.Location = new System.Drawing.Point(12, 118);
            this.labelMissingEntries.Name = "labelMissingEntries";
            this.labelMissingEntries.Size = new System.Drawing.Size(129, 20);
            this.labelMissingEntries.TabIndex = 3;
            this.labelMissingEntries.Text = "Brakujące klucze";
            this.labelMissingEntries.Visible = false;
            this.labelMissingEntries.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // labelDoubledEntries
            // 
            this.labelDoubledEntries.AutoSize = true;
            this.labelDoubledEntries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDoubledEntries.Location = new System.Drawing.Point(15, 142);
            this.labelDoubledEntries.Name = "labelDoubledEntries";
            this.labelDoubledEntries.Size = new System.Drawing.Size(129, 20);
            this.labelDoubledEntries.TabIndex = 9;
            this.labelDoubledEntries.Text = "Identyczne wpisy";
            this.labelDoubledEntries.Visible = false;
            this.labelDoubledEntries.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 161);
            this.Controls.Add(this.labelDoubledEntries);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelMissingEntries);
            this.Controls.Add(this.btnSelectFiles);
            this.HelpButton = true;
            this.Name = "MainForm";
            this.Text = "Translation Comparator - demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dialogSelectFiles;
        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelMissingEntries;
        private System.Windows.Forms.Label labelDoubledEntries;
    }
}

