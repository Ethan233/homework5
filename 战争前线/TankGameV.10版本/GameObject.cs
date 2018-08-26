﻿using System.Drawing;

namespace TankGameV._10版本
{
    #region 初始化游戏对象的属性
    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    abstract class GameObject
    {
        #region 游戏对象的属性
        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public int Speed
        { 
            get;
            set; 
        }

        public int Life
        {
            get;
            set;
        }


        public Direction Dir
        {
            get;
            set;
        }
        #endregion

        //初始化对象
        public GameObject(int x, int y, int width, int height, int speed, int life, Direction dir)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Speed = speed;
            this.Life = life;
            this.Dir = dir;
        }
        #endregion


        public abstract void Draw(Graphics g);

        #region 坦克移动的基类方法
        public virtual void Move()
        {
            switch (this.Dir)
            {
                case Direction.Up:
                    this.Y -= Speed;
                    break;
                case Direction.Down:                   
                        this.Y +=Speed;     
                    break;
                case Direction.Left:                    
                        this.X -= Speed;

                    break;
                case Direction.Right:
                        this.X += Speed;
                    break;
            }
            //在游戏对象移动完成后 我们应该判断一下 当前游戏对象是否超出当前的窗体 
            if (this.X <= 0)
            {
                this.X = 0;
            }
            if (this.Y <= 0)
            {
                this.Y = 0;
            }
            if (this.X >= 720)
            {
                this.X = 720;
            }
            if (this.Y >= 600)
            {
                this.Y = 600;
            }
        }
        #endregion



        public Rectangle GetRectangle()//获取坐标区域以判断相撞
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }


        public GameObject(int x, int y): this(x, y, 0, 0, 0, 0, 0)
        { 
            
        }

        public GameObject(int x, int y, int width, int height) : this(x, y)
        {
            Width = width;
            Height = height;
        }
    }
}
