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
    public partial class DeleteUser : Form
    {
        public DeleteUser()
        {
            InitializeComponent();
        }

        private void DeleteUser_Load(object sender, EventArgs e)
        {
            DialogResult result = System.Windows.Forms.DialogResult.No;
            DirectoryInfo dInfo = new DirectoryInfo("profiles");
            FileInfo[] fInfos = dInfo.GetFiles();
            foreach (FileInfo finfo in fInfos)
            {
                string []str=finfo.Name.ToString().Split('.');
                listBox_UserName.Items.Add(str[0]);
            }
            
            
            
        }

        private void button_DeleteUser_Click(object sender, EventArgs e)
        {
            bool flag = false;
            DialogResult result = System.Windows.Forms.DialogResult.No;
            DirectoryInfo dInfo = new DirectoryInfo("profiles");
            FileInfo[] fInfos = dInfo.GetFiles();
            foreach (FileInfo finfo in fInfos)
            {
                if (finfo.Name.Equals(listBox_UserName.SelectedItem.ToString() + ".emu"))
                {

                    result = MessageBox.Show("Do you want to delete user profile?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (result.ToString().Equals("Yes"))
                    {
                        finfo.Delete();
                        flag = true;
                    }
                }
            }
            if (flag)
            {
                listBox_UserName.Items.Clear();
                 result = System.Windows.Forms.DialogResult.No;
                 dInfo = new DirectoryInfo("profiles");
                 fInfos = dInfo.GetFiles();
                foreach (FileInfo finfo in fInfos)
                {
                    string[] str = finfo.Name.ToString().Split('.');
                    listBox_UserName.Items.Add(str[0]);
                }
            }
        }
    }
}
