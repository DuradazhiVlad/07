using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _07
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
            //Відображаємо диски
            string[] drives = Directory.GetLogicalDrives();
            foreach (string drive in drives)
            {
                TreeNode driveNode = new TreeNode(drive);
                treeView1.Nodes.Add(driveNode);


                // Додавання дочірніх вузлів для кожного диску
                string[] directories = Directory.GetDirectories(drive);
                foreach (string directory in directories)
                {
                    driveNode.Nodes.Add(new TreeNode(Path.GetFileName(directory)));
                }


            }
            //recurs_list(treeView1.Nodes);

        }

        //public void recurs_list(TreeNodeCollection nodes)
        //{
        //    foreach (TreeNode i in nodes)
        //    {
        //        if (i.Parent == null) // додавати тільки верхні вузли
        //        {
        //            listBox1.Items.Add(i.Text);
        //        }

        //        if (i.Nodes.Count > 0)
        //        {
        //            recurs_list(i.Nodes);
        //        }
        //    }
        //}


       

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //Якщо це папка, відображаємо її файли в ListBox
            if(Directory.Exists(e.Node.FullPath))
            {
                listBox1.Items.Clear();
                string[] files=Directory.GetFiles(e.Node.FullPath);                
                foreach (string file in files)
                {
                    listBox1.Items.Add(Path.GetFileName(file));                    
                }
                

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filePath = Path.Combine(treeView1.SelectedNode.FullPath);            
            toolStripTextBox1.Text = filePath;
            Clipboard.SetText(filePath);
        }

        
    }


    
}
