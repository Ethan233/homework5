using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankSound;

namespace TankGameV._10版本
{

    /// <summary>
    /// 这个单例类用来创建我们全局唯一的游戏对象
    /// </summary>
    class SingleObject
    {
        public static SingleObject w = new SingleObject();
       public SingleObject()
        { }
        public int k=0;
        public static SingleObject _singleObject = null;

        public static SingleObject GetSingle()
        {
            if (_singleObject == null)
            {
                _singleObject = new SingleObject();
            }
            return _singleObject;
        }


        //将我们的敌人存储在泛型集合中
        List<PlayerBullet> listPlayerBullet = new List<PlayerBullet>();
        List<EnemyBullet> listEnemyBullet = new List<EnemyBullet>();
        List<Boom> listBoom = new List<Boom>();

        #region 游戏对象类
        // 添加游戏对象
        public void AddGameObject(GameObject go)
        {
            if (go is PlayerTank)
            {
                Program.PT = go as PlayerTank;
            }
            else if (go is EnemyTank)
            {
                Program.listEnemyTank.Add(go as EnemyTank);
            }
            else if (go is PlayerBullet)
            {
                listPlayerBullet.Add(go as PlayerBullet);
            }
            else if (go is EnemyBullet)
            {
                listEnemyBullet.Add(go as EnemyBullet);
            }
            else if (go is Boom)
            {
                listBoom.Add(go as Boom);
            }
            else if (go is Wall)
            {
                Program.listWall.Add(go as Wall);
            }
        }

        //移除游戏对象
        public void RemoveGameObject(GameObject go)
        {
            if (go is Boom)
            {
                listBoom.Remove(go as Boom);
            }
            if (go is PlayerBullet)
            {
                listPlayerBullet.Remove(go as PlayerBullet);
            }
            if (go is EnemyBullet)
            {
                listEnemyBullet.Remove(go as EnemyBullet);
            }
            if (go is EnemyTank)
            {
                Program.listEnemyTank.Remove(go as EnemyTank);
            }
            if (go is PlayerTank)
            {
                Program.PT = null;
                k = 1;
            }
        }



        /// <summary>
        /// 绘制游戏对象
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            if(k==0)
                Program.PT.Draw(g);
            for (int i = 0; i < Program.listEnemyTank.Count; i++)
            {
                Program.listEnemyTank[i].Draw(g);
            }
            for (int i = 0; i < listPlayerBullet.Count; i++)
            {
                listPlayerBullet[i].Draw(g);
            }
            for (int i = 0; i < listEnemyBullet.Count; i++)
            {
                listEnemyBullet[i].Draw(g);
            }
            for (int i = 0; i < listBoom.Count; i++)
            {
                listBoom[i].Draw(g);
            }
            for (int i = 0; i < Program.listWall.Count; i++)
            {
                Program.listWall[i].Draw(g);
            }
        }
        #endregion


        #region 检测是否击中的方法
        //检测是否击中的方法
        public void PZJC()
        {
            //判断电脑子弹是否击中玩家坦克
            for (int i = 0; i < listPlayerBullet.Count; i++)
            {
                for (int j = 0; j < Program.listEnemyTank.Count; j++)
                {
                    
                    if (listPlayerBullet[i].GetRectangle().IntersectsWith(Program.listEnemyTank[j].GetRectangle()))
                    {
                        GetSingle().RemoveGameObject(listPlayerBullet[i]);
                        Program.listEnemyTank[j].Life -= 1;
                        Sound.Play("Sound/wall.wav");
                        if (Program.listEnemyTank[j].Life<=0)
                        Program.listEnemyTank[j].IsOver();
                        break;
                    }
                }
            }
            //判断玩家子弹是否打到墙上
            for (int i = 0; i < listPlayerBullet.Count; i++)
            {
                for (int j = 0; j < Program.listWall.Count; j++)
                {

                    if (listPlayerBullet[i].GetRectangle().IntersectsWith(Program.listWall[j].GetRectangle()))
                    {
                        GetSingle().RemoveGameObject(listPlayerBullet[i]);
                        Sound.Play("Sound/tie.wav");
                        break;
                    }
                }
            }
            //判断电脑子弹是否打到墙上
            for (int i = 0; i < listEnemyBullet.Count; i++)
            {
                for (int j = 0; j < Program.listWall.Count; j++)
                {

                    if (listEnemyBullet[i].GetRectangle().IntersectsWith(Program.listWall[j].GetRectangle()))
                    {
                        GetSingle().RemoveGameObject(listEnemyBullet[i]);
                        Sound.Play("Sound/tie.wav");
                        break;
                    }
                }
            }
            //判断电脑子弹是否击中玩家坦克
            for (int i = 0; i < listEnemyBullet.Count; i++)
            {

                if (listEnemyBullet[i].GetRectangle().IntersectsWith(Program.PT.GetRectangle()))
                {
                    Program.PT.IsOver();
                    break;
                }

            }
            //判断玩家坦克是否撞到电脑坦克
            for (int i = 0; i < Program.listEnemyTank.Count; i++)
            {
                if (Program.listEnemyTank[i].GetRectangle().IntersectsWith(Program.PT.GetRectangle()))
                {
                    Program.PT.IsOver();
                    break;
                }
            }
        }
        #endregion
    }
}
