using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankGameV._10版本.Properties;
using System.Drawing;

namespace TankGameV._10版本
{
    internal class Wall : GameObject
    {
        private Image[] imgs = new Image[] { };
        public Wall(int x, int y, int width, int height)
            : base(x, y,60,60)
        {

        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Resources.TQ, this.X, this.Y);
        }


    }
}
