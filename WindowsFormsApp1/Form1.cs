using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            label1.Text = NamePairs.LastName;
            label2.Text = NamePairs.FirstName;
            button1.Text = NamePairs.Add;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FirstName = label2.Text,
                LastName = label1.Text
            };
            users.Add(u);
        }
    }
}
