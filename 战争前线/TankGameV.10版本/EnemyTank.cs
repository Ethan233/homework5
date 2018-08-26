using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankGameV._10版本.Properties;
using System.Drawing;
using TankSound;

namespace TankGameV._10版本
{
    class EnemyTank : TankFather
    {
        #region 电脑坦克图片资源
        private static Image[] imgs1 = {
                                       Resources.enemy1U,
                                       Resources.enemy1D,
                                       Resources.enemy1L,
                                       Resources.enemy1R
                                       };
        private static Image[] imgs2 = {
                                       Resources.enemy2U,
                                       Resources.enemy2D,
                                       Resources.enemy2L,
                                       Resources.enemy2R
                                       };
        private static Image[] imgs3 = {
                                       Resources.enemy3U,
                                       Resources.enemy3D,
                                       Resources.enemy3L,
                                       Resources.enemy3R
                                       };
        #endregion


        //存储敌人坦克的速度
        private static int _speed;
        //存储敌人坦克的生命
        private static int _life;

        public int EnemyTankType
        {
            get;
            set;
        }


        //设置敌人坦克的速度
        public static int SetSpeed(int type)
        {
            switch (type)
            {
                case 0: _speed = 1;
                    break;
                case 1: _speed = 2;
                    break;
                case 2: _speed = 2;
                    break;
            }
            return _speed;
        }

        //设置敌人坦克的生命
        public static int SetLife(int type)
        {
            switch (type)
            {
                case 0:
                    _life = 1;
                    break;
                case 1:
                    _life = 2;
                    break;
                case 2:
                    _life = 3;
                    break;
            }
            return _life;
        }

        //电脑坦克属性
        public EnemyTank(int x, int y, int type, Direction dir)
            : base(x, y, imgs1, SetSpeed(type), SetLife(type), dir)
        {
            this.EnemyTankType = type;
        }


        #region 在窗体当中绘制我们的敌人坦克
        public override void Draw(Graphics g)
        {
            EnemyMove();//一绘制我们的敌人坦克 就让坦克移动
            switch (EnemyTankType)
            {
                case 0:
                    switch (this.Dir)
                    {
                        case Direction.Up:
                            g.DrawImage(imgs1[0], this.X, this.Y);
                            break;
                        case Direction.Down:
                            g.DrawImage(imgs1[1], this.X, this.Y);
                            break;
                        case Direction.Left:
                            g.DrawImage(imgs1[2], this.X, this.Y);
                            break;
                        case Direction.Right:
                            g.DrawImage(imgs1[3], this.X, this.Y);
                            break;
                    }
                    break;
                case 1:
                    switch (this.Dir)
                    {
                        case Direction.Up:
                            g.DrawImage(imgs2[0], this.X, this.Y);
                            break;
                        case Direction.Down:
                            g.DrawImage(imgs2[1], this.X, this.Y);
                            break;
                        case Direction.Left:
                            g.DrawImage(imgs2[2], this.X, this.Y);
                            break;
                        case Direction.Right:
                            g.DrawImage(imgs2[3], this.X, this.Y);
                            break;
                    }
                    break;
                case 2:
                    switch (this.Dir)
                    {
                        case Direction.Up:
                            g.DrawImage(imgs3[0], this.X, this.Y);
                            break;
                        case Direction.Down:
                            g.DrawImage(imgs3[1], this.X, this.Y);
                            break;
                        case Direction.Left:
                            g.DrawImage(imgs3[2], this.X, this.Y);
                            break;
                        case Direction.Right:
                            g.DrawImage(imgs3[3], this.X, this.Y);
                            break;
                    }
                    break;
            }

            //敌人坦克一边移动一遍发射子弹
            if (r.Next(0, 100) < 2)
            {
                Fire();
            }

        }
        #endregion


        public override void Fire()//电脑开火
        {
            SingleObject.GetSingle().AddGameObject(new EnemyBullet(this, 10, 10, 1));
        }

        public override void IsOver()//电脑over
        {
            SingleObject.GetSingle().AddGameObject(new Boom(this.X - 25, this.Y - 25));
            Sound.Play("Sound/Explode.wav");
            SingleObject.GetSingle().RemoveGameObject(this);
            Program.score += 500;
            if(Program.listEnemyTank.Count==0)
            {
                Log y = new Log();
                y.save();
                Sound.Play("Sound/WIN.wav");
                if (Program.t == 0)
                {
                    Success use4 = new Success();
                    use4.Show();
                    Game use1 = new Game();
                    use1.Close();
                    Program.t = 1;
                }
            }
        }

        static Random r = new Random();


        #region 判断电脑坦克是否撞墙或其他电脑坦克
        public bool IsTouchWall()
        {
            for (int i = 0; i < Program.listEnemyTank.Count; i++)
            { 
                for (int j = 0; j < Program.listWall.Count; j++)
                {
                    if (crash(Program.listEnemyTank[i].GetRectangle(), Program.listWall[j].GetRectangle()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsTouchTank()
        {
            for (int i = 0; i < Program.listEnemyTank.Count; i++)
            {
                if (this != Program.listEnemyTank[i] && crash(this.GetRectangle(), Program.listEnemyTank[i].GetRectangle()))
                {
                    return true;
                }
            }
            return false;
        }
#endregion

        #region 电脑坦克随机移动
        public void EnemyMove()
        {

            for (int i = 0; i < Program.listEnemyTank.Count; i++)
            {
                if (Program.listEnemyTank[i].IsTouchTank()|| Program.listEnemyTank[i].IsTouchWall())
                {
                    switch (Program.listEnemyTank[i].Dir)
                    {
                        case Direction.Down:
                            Program.listEnemyTank[i].Dir = Direction.Up;
                            break;
                        case Direction.Up:
                            Program.listEnemyTank[i].Dir = Direction.Down;
                            break;
                        case Direction.Right:
                            Program.listEnemyTank[i].Dir = Direction.Left;
                            break;
                        case Direction.Left:
                            Program.listEnemyTank[i].Dir = Direction.Right;
                            break;
                        default:
                            break;
                    }
                }
            }
            for (int i = 0; i < Program.listEnemyTank.Count; i++)
            {
                Program.listEnemyTank[i].Move();

            }
            //给一个很小的概率 产生随机数
            if (r.Next(0, 100) < 4)
            {
                switch (r.Next(0, 4))
                {
                    case 0:
                        this.Dir = Direction.Up;
                        break;
                    case 1:
                        this.Dir = Direction.Down;
                        break;
                    case 2:
                        this.Dir = Direction.Left;
                        break;
                    case 3:
                        this.Dir = Direction.Right;
                        break;
                }
            }
        }

        //广义两个矩形
        public static bool crash(Rectangle rectangle1, Rectangle rectangle2)
        {
            if (rectangle1.IntersectsWith(rectangle2))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
