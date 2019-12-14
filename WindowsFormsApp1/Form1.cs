using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = NamePairs.FullName;
            button1.Text = NamePairs.Add;
            button2.Text = NamePairs.SavingFile;
            button3.Text = NamePairs.Deleting;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text
            };
            users.Add(u);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "Comma Separated Values (*.csv)|*.csv";
            sfd.DefaultExt = "csv";
            sfd.AddExtension = true;

            if (sfd.ShowDialog() != DialogResult.OK) return;
            else
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8)) 
                {
                    foreach (var név in users)
                    {
                        sw.WriteLine(név.ID + ";" + név.FullName);
                    }
                } 
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            users.Remove((User)listBox1.SelectedItem);
        }
    }
}
