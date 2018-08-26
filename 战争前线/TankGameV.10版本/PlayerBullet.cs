using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankGameV._10版本.Properties;
namespace TankGameV._10版本
{
    class PlayerBullet:BulletFather
    {
        private static Image img = Resources.tankmissile;//导入玩家子弹图片
        public PlayerBullet(TankFather tf, int speed, int life, int power)
            : base(tf, speed, life, power, img)
        { 
            
        }
    }
}
