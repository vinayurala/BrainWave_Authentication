using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ScreenLock
{
    public partial class DeleteUserForm : Form
    {
        public DeleteUserForm()
        {
            InitializeComponent();
        }

        private void DeleteUserForm_Load(object sender, EventArgs e)
        {
            userNameListComboBox.SelectedIndex = 0;
            string[] userList = Directory.GetDirectories(Environment.CurrentDirectory);
            userNameListComboBox.Items.AddRange(userList);
        }

        private void formCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            if (userNameListComboBox.SelectedIndex == 0)
            {
                MessageBox.Show("Select an user to delete!!");
                return;
            }
            else
            {
                //string path = Environment.CurrentDirectory + "\\" + userNameListComboBox.SelectedText;
                ////Directory.Delete(path, true);
                //DirectoryInfo dInfo = new DirectoryInfo(path);
                //dInfo.Delete();
                //MessageBox.Show("User" + userNameListComboBox.SelectedText + " Deleted!");
            }
        }

    }
}
