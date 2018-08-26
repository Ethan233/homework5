using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankGameV._10版本
{
    static class Program
    {
        # region 调用其他类成员
        public static PlayerTank PT
        {
            get;
            set;
        }
        public  static List<EnemyTank> listEnemyTank = new List<EnemyTank>();
        public static List<Wall> listWall = new List<Wall>();
        public static int score=0;
        public static int t = 0;
        #endregion


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Start());
        }
    }
}
