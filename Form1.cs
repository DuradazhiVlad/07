using System.Windows.Forms;

namespace _07
{
    public partial class Form1 : Form
    {
        public string opendFile = "";
        public Form1()
        {
            InitializeComponent();
            textBox1.MouseClick += new MouseEventHandler(textBox1_MouseClick);
        }
        public void seveFilesAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                opendFile = sfd.FileName;
                seveFile(sfd.FileName);
            }
        }

        private void seveFile(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.Write(textBox1.Text);
            writer.Close();
        }

        private void seveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (opendFile == "")
            {
                seveFilesAs();
            }
            else seveFile(opendFile);
        }

        private void seveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            seveFilesAs();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt";
            openFileDialog.FilterIndex = 2;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                opendFile = openFileDialog.FileName;
                StreamReader rider = new StreamReader(openFileDialog.FileName);                
                textBox1.Text = rider.ReadToEnd();
                rider.Close();
            }
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = textBox1.Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {

                textBox1.Font = fontDialog.Font;

            }
        }

        private void колірШрифтуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = textBox1.ForeColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {

                textBox1.ForeColor = cd.Color;

            }
        }

        private void колірФонуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ColorDialog cd = new ColorDialog();
            cd.Color = textBox1.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {

                textBox1.BackColor = cd.Color;

            }
        }

        private void новийДокументToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void копіюватиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            textBox1.Copy();
        }

        private void вставитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cursorPosition = textBox1.SelectionStart;
            textBox1.Text = textBox1.Text.Insert(cursorPosition, Clipboard.GetText());
            textBox1.SelectionStart = cursorPosition + Clipboard.GetText().Length;            
        }

        private void вирізатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void відмінитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(textBox1, e.Location);
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(textBox1, e.Location);
            }
        }

        private void перейтиДо2ЗавданняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}