using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace nonamegame
{
    internal class Enemy
    {
        public bool Out = false, Stop = false;
        public int enemyWidth = 50, enemyHeight = 50;
        public double x, xx, y, yy, z, zz, zzz, zzzz, zzzzz, plusspeed, angelX, angelY, radX = 40, radY = 40;
        public int Xpos, Ypos;
        public int targetX = -2, targetY = -1, time = 0;
        public Brush brush;
        public double tankXpos { get; set; }
        public double tankYpos { get; set; }
        public double randomX { get; set; }
        public double randomY { get; set; }
        public double enemyXpos { get; set; }
        public double enemyYpos { get; set; }

        public void Solve(double temp, int id)
        {
            plusspeed = temp;
            x = 1.0 * (enemyXpos);
            y = 1.0 * (enemyYpos);
            xx = 1.0 * (1.0 * tankXpos);
            yy = 1.0 * (1.0 * tankYpos);
            z = Math.Sqrt(((xx - x) * (xx - x)) + ((yy - y) * (yy - y)));
            angelX = Math.Acos((xx - x) / z);
            angelY = Math.Asin((yy - y) / z);
            zz = 1.0 * Math.Cos(angelX);
            zzz = 1.0 * Math.Sin(angelY);
            if (id == 3)
            {
                xx = 1.0 * (1.0 * randomX);
                yy = 1.0 * (1.0 * randomY);
                z = Math.Sqrt(((xx - x) * (xx - x)) + ((yy - y) * (yy - y)));
                zzzz = 1.0 * Math.Sin(Math.Asin((xx - x) / z));
                zzzzz = 1.0 * Math.Cos(Math.Acos((yy - y) / z));
                enemyXpos = (double)(1.0 * enemyXpos + 1.0 * zzzz * (plusspeed));
                enemyYpos = (double)(1.0 * enemyYpos + 1.0 * zzzzz * (plusspeed));
            }
            else
            {
                enemyXpos = (double)(1.0 * enemyXpos + 1.0 * zz * (plusspeed));
                enemyYpos = (double)(1.0 * enemyYpos + 1.0 * zzz * (plusspeed));
            }
            Xpos = (int)Math.Round(enemyXpos);
            Ypos = (int)Math.Round(enemyYpos);
        }
    }
}
