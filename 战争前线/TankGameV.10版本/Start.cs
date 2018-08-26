using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TankSound;

namespace TankGameV._10版本
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game use = new Game();
            this.Hide();
            use.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W:上移\nS: 下移\nA: 左移\nD: 右移\nK: 射击\n\n由郑宇飞帆小组开发");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"D:\得分查询.txt");
        }
    }
}
