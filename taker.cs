using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace Tiny_ziptool_smaller
{
    public partial class taker : Form
    {
        private const string title = "解压";
        private string selectedFilePath = string.Empty;
        private string unzipFilepatch = string.Empty;
        public taker()
        {
            InitializeComponent();
        }

        private void taker_Load(object sender, EventArgs e)
        {
            this.Text = title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                selectedFilePath = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedFilePath))
                {
                    MessageBox.Show("请选择要解压的zip文件。");
                }
                else
                {
                    this.Text = $"{title} - 解压中...";
                    ZipFile.ExtractToDirectory(selectedFilePath, unzipFilepatch);
                    MessageBox.Show("解压成功，项目已解压到：" + unzipFilepatch);
                }
            }
            catch (Exception ex)
            {
                this.Text = $"{title} - 解压失败";
                MessageBox.Show("解压失败，错误代码: " + ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
                unzipFilepatch = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
