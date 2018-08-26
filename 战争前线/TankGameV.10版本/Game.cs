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
    public partial class Game : Form
    {
        #region 游戏初始化
        public Game()
        {
            InitializeComponent();//初始化组件
            InitialGame();//初始化游戏
        }

        public void InitialGame()
        {
            SingleObject.GetSingle().AddGameObject(new PlayerTank(0,0 , 10, 10, Direction.Down));
            SetEnemyTanks();

        }

        public int[,] WMap = new int[720, 600]; //砖块地图
        public int[,] TMap = new int[720, 600]; //坦克地图
        Random r = new Random();

        public void SetEnemyTanks()//初始化电脑坦克和墙
        {
            for (int x = 1; x < 13; x += 2)
                for (int y = 0; y < 11; y += 2)
                {
                    WMap[x, y] = r.Next(0, 100);
                    if (WMap[x, y] <40)
                        SingleObject.GetSingle().AddGameObject(new Wall(x * 60, y * 60,60,60));
                    if (WMap[x, y] >86)
                        SingleObject.GetSingle().AddGameObject(new EnemyTank(x*60, y*60, r.Next(0, 3), Direction.Down));
                }
        }


        private void Form1_Paint(object sender, PaintEventArgs e)//执行draw所需要的资源
        {
            SingleObject.GetSingle().Draw(e.Graphics);
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)//键盘触发
        {
            Program.PT.KeyDown(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();//对窗体进行更新
            SingleObject.GetSingle().PZJC();//调用碰撞检测方法
            if (Program.t == 1)
            {
                this.Hide();
                Program.t = 2;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //让控件不闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
        }
    }
    #endregion
}
