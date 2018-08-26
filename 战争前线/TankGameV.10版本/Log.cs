using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankGameV._10版本
{
    class Log
    {
        public void save()
        {
            string result1 = @"D:\得分查询.txt";
            FileStream fs = new FileStream(result1, FileMode.Append);
            StreamWriter wr = null;
            wr = new StreamWriter(fs);
            wr.WriteLine(DateTime.Now.ToString()+"      本局得分  ：" + Program.score);
            wr.Close();
        }
    }
}
