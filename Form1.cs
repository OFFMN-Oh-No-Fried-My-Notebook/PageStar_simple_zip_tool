using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tiny_ziptool_smaller
{
    public partial class Form1 : Form
    {
        private bool isDragging = false; // 标记是否正在拖动
        private Point dragStartPosition; // 记录拖动起始位置
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPosition = e.Location; // 保存起始位置（相对于客户区）
            }
        }

        // 鼠标移动时更新窗口位置
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // 计算新位置（屏幕坐标）
                Point screenPosition = this.PointToScreen(
                    new Point(e.X, e.Y)
                );

                // 计算窗口新位置（减去初始偏移）
                this.Location = new Point(
                    screenPosition.X - dragStartPosition.X,
                    screenPosition.Y - dragStartPosition.Y
                );
            }
        }

        // 鼠标释放时停止拖动
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            taker takerForm = new taker();
            takerForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            about aboutForm = new about();
            aboutForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            maker makerForm = new maker();
            makerForm.ShowDialog();
        }
    }
}
