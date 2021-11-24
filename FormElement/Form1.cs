using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormElement
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        PictureBox pb;
        CheckBox cbA, cbB, cbC, cbD;
        RadioButton rb, rb2;
        TextBox tbx;
        Button mb;
        bool t = true;
        public Form1()
        {
            this.Height = 500;
            this.Width = 800;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp"));
            tn.Nodes.Add(new TreeNode("label"));
            tn.Nodes.Add(new TreeNode("PictureBox"));
            tn.Nodes.Add(new TreeNode("CheckBox"));
            tn.Nodes.Add(new TreeNode("Radiobutton"));
            tn.Nodes.Add(new TreeNode("TextBox"));
            tn.Nodes.Add(new TreeNode("TabControl"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
            //nupp
            btn = new Button();
            btn.Text = "vajuta siia";
            btn.Location = new Point(150, 30);
            btn.Height = 30;
            btn.Width = 100;
            btn.Click += Btn_Click;
            //label
            lbl = new Label();
            lbl.Text = "Elamentide loomine c# abil";
            lbl.Size = new Size(60,30);
            lbl.Location = new Point(150, 0);
            lbl.MouseHover += Lbl_MouseHover;
            lbl.MouseLeave += Lbl_MouseLeave;
            //imageBox
            pb = new PictureBox();
            pb.Size = new Size(100, 100);
            pb.Location = new Point(150, 70);
            pb.ImageLocation = ("../../image/index.jpg");
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            pb.MouseDoubleClick += Pb_MouseDoubleClick;
            //checkBox
            cbA = new CheckBox();
            cbB = new CheckBox();
            cbC = new CheckBox();
            cbD = new CheckBox();
            
            cbA.Location = new Point(600, 70);
            cbA.Text = "Font(label)";
            cbB.Text = "Border(PictureBox)";
            cbB.Location = new Point(600, 50);
            cbB.Size = new Size(cbB.Text.Length * 8, 20);
            cbC.Location = new Point(600, 30);
            cbC.Text = "Background color";
            cbD.Location = new Point(600, 90);
            cbD.Text = "Size";
            cbA.MouseClick += CbA_MouseClick;
            cbB.MouseClick += CbB_MouseClick;
            cbC.MouseClick += CbC_MouseClick;
            cbD.MouseClick += CbD_MouseClick;
            //radiobutton
            rb = new RadioButton();
            rb2 = new RadioButton();
            rb.Location = new Point(500, 70);
            rb2.Location = new Point(500, 40);
            rb.Text = "Youtube";
            rb2.Text = "Moodle";
            rb.MouseClick += Rb_MouseClick;
            rb2.MouseClick += Rb2_MouseClick;
            //messageBox
            mb = new Button();
            mb.Location = new Point(300, 70);
            mb.Click += Mb_Click;



            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
            
        }

        private void Mb_Click(object sender, EventArgs e)
        {
            var answer=MessageBox.Show(
            "Вы хотите перейти на сайт",
            "Сообщение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            if(answer==DialogResult.No)
            {
                var answers = MessageBox.Show(
                "Ты меня растраиваешь",
                "Сообщение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void Rb2_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://moodle.edu.ee/");
        }
        private void Rb_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/");
        }

        private void CbD_MouseClick(object sender, MouseEventArgs e)
        {
            if (t)
            {
                this.Size = new Size(1000, 1000);
                cbD.Text = "Teeme väiksem";
                t = false;
            }
            else
            {
                this.Size = new Size(800, 500);
                cbD.Text = "Suurendame";
                t = true;
            }
        }

        private void CbC_MouseClick(object sender, MouseEventArgs e)
        {
            if (t)
            {
                lbl.Font = new Font("Times New Roman",7,FontStyle.Bold);
                cbC.Text = "Times New Roman";
                t = false;
            }
            else
            {
                lbl.Font = new Font("Arial",7, FontStyle.Bold);
                cbC.Text = "Arial";
                t = true;
            }
        }

        private void CbB_MouseClick(object sender, MouseEventArgs e)
        {
            if (t)
            {
                pb.BorderStyle = BorderStyle.Fixed3D;
                cbB.Text = "Fixed3D";
                t = false;
            }
            else
            {
                pb.BorderStyle = BorderStyle.None;
                cbB.Text = "None";
                t = true;
            }
            
        }

        private void CbA_MouseClick(object sender, MouseEventArgs e)
        {
            if (t)
            {
                BackColor = Color.Red;
                cbA.Text = "Red";
                t = false;
            }
            else
            {
                BackColor = Color.Blue;
                cbA.Text = "Blue";
                t = true;
            }
        }

        private void Pb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("images.jpg");
            list.Add("index.jpg");
            list.Add("index2.jpg");
            
            Random rnd = new Random();

            int num = rnd.Next(3);

            pb.ImageLocation = ($"../../image/{list[num]}");
        }

        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            lbl.BackColor = Color.Transparent;
        }

        private void Lbl_MouseHover(object sender, EventArgs e)
        {
            lbl.BackColor = Color.FromArgb(76,0,153);
        }

        
        private void Btn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://kabilov20.thkit.ee");
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text=="Nupp")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "label")
            {
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "PictureBox")
            {
                this.Controls.Add(pb);
            }
            else if (e.Node.Text == "CheckBox")
            {
                this.Controls.Add(cbA);
                this.Controls.Add(cbB);
                this.Controls.Add(cbC);
                this.Controls.Add(cbD);
            }
            else if (e.Node.Text == "Radiobutton")
            {
                this.Controls.Add(rb);
                this.Controls.Add(rb2);
            }
            else if (e.Node.Text == "MessageBox")
            {
                this.Controls.Add(mb);
               
            }
        }
    }
}
