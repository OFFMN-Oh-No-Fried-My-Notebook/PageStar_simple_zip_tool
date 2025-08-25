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
    public partial class maker : Form
    {
        private string selectedFilePath = string.Empty;
        private string makerzipFilepatch = string.Empty;
        private const string title = "打包";
        public maker()
        {
            InitializeComponent();
        }

        private void maker_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                makerzipFilepatch = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = saveFileDialog1.FileName;
                selectedFilePath = saveFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(makerzipFilepatch))
                {
                    MessageBox.Show("请先选择路径！");

                }
                else
                {
                    this.Text = $"{title} - 打包中...";
                    ZipFile.CreateFromDirectory(makerzipFilepatch, selectedFilePath);
                    MessageBox.Show("打包成功，项目已打包到：" + selectedFilePath);
                }
            }
            catch (Exception ex)
            {
                this.Text = $"{title} - 打包失败";
                MessageBox.Show("打包失败,错误代码: " + ex.Message);
            }
        }
    }
}
