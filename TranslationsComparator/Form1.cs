using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranslationsComparator;
using Microsoft.VisualBasic;

namespace TranslationsComparator
{
    public partial class MainForm : Form
    {
        private TranslationComparator _translationComparator;
        private Dictionary<Translation, string> _translationMismatches;
        private List<Translation> _translationsDoubled;
        private List<string> _translationFiles;
        private int _missingTranslationsY;
        private int _missingTranslationHeight;
        private int _doubledTranslationsY;
        private int _doubledTranslationsHeight;
        private Panel _missingEntriesPanel;
        private Panel _doubledEntriesPanel;

        public MainForm()
        {
            InitializeComponent();
            this._missingEntriesPanel = new Panel();
            this._doubledEntriesPanel = new Panel();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TXT files|*.txt";
            openFileDialog.Multiselect = true;

            this._translationFiles = new List<string> { };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    _translationFiles.Add(filePath);
                }
                AnalyzeFiles();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lstMismatches_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvMismatches_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDoubledEntryies_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void missingEntriesPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button_Edit_Entry_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button);
            Translation entry = new Translation(button.Name);
            
            string fileName = entry.GetValue();
            string fullFilePath = GetFileByName(fileName);
            string newKey = entry.GetKey();
            string newValue = newKey;
            string textFile = File.ReadAllText(@fullFilePath, Encoding.UTF8);
            string newLinePrefix = "";            
            MessageBox.Show("Youre going to change value of " + newKey + " in " + fullFilePath);
            TranslationFile translationFile = new TranslationFile(fullFilePath);            
            Translation translationToChange = translationFile.GetTranslationByKey(newKey);
            newValue = Microsoft.VisualBasic.Interaction.InputBox("Podaj nowe tłumaczenie dla klucza:" + Environment.NewLine + newKey + " (w pliku " + fileName + ")", "Zmień tłumaczenie", newKey, 150, 350);
            translationFile.ChangeValue(translationToChange,newValue);
            /*if ((!textFile.EndsWith(Environment.NewLine)) && (!textFile.EndsWith("\n")))
            {
                newLinePrefix = Environment.NewLine;
            }*/
            
            
            AnalyzeFiles();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button);
            Translation entry = new Translation(button.Name);

            string fileName = entry.GetValue();
            string fullFilePath = GetFileByName(fileName);
            string newKey = entry.GetKey();
            string newValue = newKey;
            string textFile = File.ReadAllText(@fullFilePath, Encoding.UTF8);
            string newLinePrefix = "";

            if ((!textFile.EndsWith(Environment.NewLine)) && (!textFile.EndsWith("\n")))
            {
                newLinePrefix = Environment.NewLine;
            }
            newValue = Microsoft.VisualBasic.Interaction.InputBox("Podaj wartość dla klucza:"+Environment.NewLine+newKey+" (w pliku "+fileName+")", "Dodaj tłumaczenie", newKey, 150, 350);
            File.AppendAllText(fullFilePath, newLinePrefix + newKey+"="+newValue + Environment.NewLine);
            AnalyzeFiles();
        }

        public string GetFileByName(string fileName)
        {
            foreach (string file in this._translationFiles)
            {
                if (fileName == Path.GetFileName(file)) {
                    return file;
                }
            }
            return "Nie znaleziono pliku o nazwie ("+fileName+")!";
        }

        public void ListMissingEntries()
        {
            
            int counter = 0;
            int missingEntriesPanelHeight = this._translationMismatches.Count * 27;
            if (missingEntriesPanelHeight > 200) {
                missingEntriesPanelHeight = 200;
            }
            this._doubledTranslationsY = 180 + missingEntriesPanelHeight;
            this.labelDoubledEntries.Location = new Point(15, this._doubledTranslationsY - 22);
            this.Size = new Size(this.Size.Width, this.Size.Height + missingEntriesPanelHeight);
            
            
            this._missingEntriesPanel.Controls.Clear();
            this._missingEntriesPanel.Visible = false;
            this._missingEntriesPanel.Location = new Point(15, 150);
            this._missingEntriesPanel.Size = new Size(300, missingEntriesPanelHeight);
            
            this._missingEntriesPanel.BackColor = Color.AliceBlue;
            this._missingEntriesPanel.BorderStyle = BorderStyle.FixedSingle;
            
            this._missingEntriesPanel.AutoScroll = true;
            this.Controls.Add(this._missingEntriesPanel);

            foreach (KeyValuePair<Translation, string> mismatch in this._translationMismatches)
            {

                Button button = new Button();
                counter = this._missingEntriesPanel.Controls.OfType<Button>().ToList().Count;
                button.Location = new Point(5, 22 * counter);
                button.Size = new Size(50, 20);
                button.Name = mismatch.Key.GetKey() + "=" + mismatch.Value;
                button.Text = "dodaj";
                button.Click += new System.EventHandler(this.Button_Click);
                this._missingEntriesPanel.Controls.Add(button);

                counter = this._missingEntriesPanel.Controls.OfType<Label>().ToList().Count;

                Label label = new Label();
                label.Location = new Point(65, 22 * counter + 2);
                label.Size = new Size(180, 20);
                label.Name = mismatch.Key.GetKey();
                label.Text = mismatch.Key.GetKey();
                this._missingEntriesPanel.Controls.Add(label);
            }
            this._missingEntriesPanel.Visible = true;
        }

        public void ListDoubledEntries()
        {
            int counter = 0;
            int doubledEntriesPanelHeight = this._translationsDoubled.Count * 27;
            if (doubledEntriesPanelHeight > 200)
            {
                doubledEntriesPanelHeight = 200;
            }
            this.Size = new Size(this.Size.Width, this.Size.Height + doubledEntriesPanelHeight);

            this._doubledEntriesPanel.Controls.Clear();
            this._doubledEntriesPanel.Location = new Point(15, this._doubledTranslationsY);
            this._doubledEntriesPanel.Size = new Size(300, doubledEntriesPanelHeight);
            this._doubledEntriesPanel.Visible = true;
            this._doubledEntriesPanel.BackColor = Color.WhiteSmoke;
            this._doubledEntriesPanel.Controls.Clear();
            this._doubledEntriesPanel.AutoScroll = true;
            this._doubledEntriesPanel.BackColor = Color.AntiqueWhite;
            this._doubledEntriesPanel.BorderStyle = BorderStyle.FixedSingle;
            this._doubledEntriesPanel.Show();
            this.Controls.Add(this._doubledEntriesPanel);

            foreach (Translation translationDouble in this._translationsDoubled)
            {
                int filesCounter = 0;
                foreach (string translationFile in this._translationFiles)
                {                    
                    Button button = new Button();
                    string fileName = Path.GetFileName(translationFile);
                    counter = this._doubledEntriesPanel.Controls.OfType<Button>().ToList().Count/2;
                    button.Location = new Point(5+filesCounter*45, 22 * counter);
                    button.Size = new Size(40, 20);
                    button.Name = translationDouble.GetKey() + "=" + fileName;
                    button.Text = fileName;
                    //MessageBox.Show("Youre going to change value of " + button.Name + " in " + fileName);
                    button.Click += new System.EventHandler(this.Button_Edit_Entry_Click);
                    this._doubledEntriesPanel.Controls.Add(button);
                    filesCounter++;
                }
                counter = this._doubledEntriesPanel.Controls.OfType<Label>().ToList().Count;

                Label label = new Label();
                label.Location = new Point(100, 22 * counter + 2);
                label.Size = new Size(180, 20);
                label.Name = translationDouble.GetKey();
                label.Text = translationDouble.GetKey();
                this._doubledEntriesPanel.Controls.Add(label);
            }
        }

        public void AnalyzeFiles() {
            
            this.Size = new Size(346,260);
            labelMissingEntries.Visible = false;
            this._translationComparator = new TranslationComparator(_translationFiles);
            this._translationComparator.CompareTranslationFiles();

            this._translationMismatches = this._translationComparator.GetMismatches();
            this._translationsDoubled = this._translationComparator.GetDoubles();

            string resultMessage = "";
            bool resultsFound = false;

            if (this._translationMismatches.Count > 0)
            {
                labelMissingEntries.Visible = true;
                resultsFound = true;
                
                labelMissingEntries.Text = "Brakujące klucze (" + this._translationMismatches.Count + ")";
                
            }
            ListMissingEntries();
            ListDoubledEntries();
            if (this._translationsDoubled.Count > 0)
            {   
                //lstDoubled.Visible = true;
                labelDoubledEntries.Visible = true;
                resultsFound = true;
                labelDoubledEntries.Visible = true;
                labelDoubledEntries.Text = "Identyczne wpisy (" + this._translationsDoubled.Count + ")";
            }            
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
