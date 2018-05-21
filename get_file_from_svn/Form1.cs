using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace get_file_from_svn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var svn = txtSvn.Text;
            var lines = svn.Split('\n');
            var files = new List<string>();
            foreach(var line in lines)
            {
                string linetext = line.Trim();

                {
                    string tag = "Modified : ";
                    if (linetext.StartsWith(tag))
                    {
                        string txt = linetext.Substring(tag.Length);
                        txt = txt.Trim() + "\n";
                        if (!files.Contains(txt))
                        {
                            files.Add(txt);
                        }
                    }
                }

                {
                    string tag = "Added : ";
                    if (linetext.StartsWith(tag))
                    {
                        string txt = linetext.Substring(tag.Length);
                        txt = txt.Trim() + "\n";
                        if (!files.Contains(txt))
                        {
                            files.Add(txt);
                        }
                    }
                }
            }

            files.Sort();

            txtFile.Text = string.Concat(files);
        }

        private void txtFile_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (e.Control)
                    {
                        txtFile.SelectAll();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
