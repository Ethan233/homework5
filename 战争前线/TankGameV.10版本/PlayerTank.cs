using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TankGameV._10版本.Properties;
namespace TankGameV._10版本
{
    class PlayerTank : TankFather

    {
        //玩家对象资源
        private static Image[] imgs = 
            {Resources.p1tankU,
             Resources.p1tankD,
             Resources.p1tankL,
             Resources.p1tankR};

        public PlayerTank(int x, int y, int speed, int life, Direction dir)
            : base(x, y, imgs, speed, life, dir)
        {

        }

        #region 按键触发
        public void KeyDown(KeyEventArgs e)
        {
            int p = 0;
            switch (e.KeyCode)
            {
                case Keys.W:
                    this.Dir = Direction.Up;
                    for (int i = 0; i < Program.listEnemyTank.Count; i++)
                    {
                        if (Program.listEnemyTank[i].GetRectangle().IntersectsWith(Program.PT.GetRectangle()))
                            p = 1;
                    }
                    for (int j = 0; j< Program.listWall.Count; j++)
                    {
                        if (Program.listWall[j].GetRectangle().IntersectsWith(Program.PT.GetRectangle()))
                        {
                            p = 1;
                            this.Y += this.Speed;
                        }
                    }
                    if (p == 0)
                        base.Move();
                    p = 0;
                    break;
                case Keys.S:
                    this.Dir = Direction.Down;
                    for (int i = 0; i < Program.listEnemyTank.Count; i++)
                    {
                        if (Program.listEnemyTank[i].GetRectangle().IntersectsWith(Program.PT.GetRectangle()))
                            p = 1;
                    }
                    for (int j = 0; j < Program.listWall.Count; j++)
                    {
                        if (Program.listWall[j].GetRectangle().IntersectsWith(Program.PT.GetRectangle()))
                        {
                            p = 1;
                            this.Y -= this.Speed;
                        }
                    }
                    if (p == 0)
                        base.Move();
                    p = 0;
                    break;
                case Keys.A:
                    this.Dir = Direction.Left;
                    for (int i = 0; i < Program.listEnemyTank.Count; i++)
                    {
                        if (Program.listEnemyTank[i].GetRectangle().IntersectsWith(Program.PT.GetRectangle()))
                            p = 1;
                    }
                    for (int j = 0; j < Program.listWall.Count; j++)
                    {
                        if (Program.listWall[j].GetRectangle().IntersectsWith(Program.PT.GetRectangle()))
                        {
                            p = 1;
                            this.X += this.Speed;
                        }
                    }
                    if (p == 0)
                        base.Move();
                    p = 0;
                    break;
                case Keys.D:
                    this.Dir = Direction.Right;
                    for (int i = 0; i < Program.listEnemyTank.Count; i++)
                    {
                        if (Program.listEnemyTank[i].GetRectangle().IntersectsWith(Program.PT.GetRectangle()))
                            p = 1;
                    }
                    for (int j = 0; j < Program.listWall.Count; j++)
                    {
                        if (Program.listWall[j].GetRectangle().IntersectsWith(Program.PT.GetRectangle()))
                        {
                            p = 1;
                            this.X -= this.Speed;
                        }
                    }
                    if (p == 0)
                        base.Move();
                    p = 0;
                    break;
                case Keys.K:
                    Fire();
                    break;

            }
        }
        #endregion

        public override void Fire()//玩家开火
        {
            SingleObject.GetSingle().AddGameObject(new PlayerBullet(this, 10, 10, 1));
        }


        public override void IsOver()//玩家over
        {
            SingleObject.GetSingle().AddGameObject(new Boom(this.X - 25, this.Y - 25));
            SingleObject.GetSingle().RemoveGameObject(Program.PT);
            Log y = new Log();
            y.save();
            if (Program.t == 0)
            {
                Failure use3 = new Failure();
                use3.Show();
                Game use1 = new Game();
                use1.Close();
                Program.t = 1;
            }
        }


    }
}
