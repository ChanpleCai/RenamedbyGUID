using System;
using System.IO;
using System.Windows.Forms;

namespace RenamedbyGUID
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //目标文件夹
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                Description = "请选择目标文件夹"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in new DirectoryInfo(dialog.SelectedPath).GetFiles())
                {
                    try
                    {
                        File.Move(item.FullName, Path.Combine(Path.GetDirectoryName(item.FullName), Guid.NewGuid().ToString() + Path.GetExtension(item.Name).ToString()));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                MessageBox.Show("Done!");
            }
        }
    }
}
