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
    internal class Bullet
    {
        public int bulletWidth = 10, bulletHeight = 10, bloodWidth = 15, bloodHeight = 15;
        public double x, xx, y, yy, z, zz, zzz, speedCells, angelX, angelY, tempX, tempY;
        public int Xpos, Ypos, timeCells = 0, limittimeCells = 50, bloodcellsXpos, bloodcellsYpos;
        public Brush brush;
        public bool finish = false, damage = false;
        public double mouseXpos { get; set; }
        public double mouseYpos { get; set; }
        public double bulletXpos { get; set; }
        public double bulletYpos { get; set; }
        public void Prepare()
        {
            x = 1.0 * (bulletXpos + (bulletWidth / 2));
            y = 1.0 * (bulletYpos + (bulletHeight / 2));
            xx = 1.0 * (1.0 * mouseXpos);
            yy = 1.0 * (1.0 * mouseYpos);
            z = Math.Sqrt(((xx - x) * (xx - x)) + ((yy - y) * (yy - y)));
            zz = 1.0 * Math.Cos(Math.Acos((xx - x) / z));
            zzz = 1.0 * Math.Sin(Math.Asin((yy - y) / z));
        }
        public void Solve(double speedBullet)
        {
            if (damage)
            {
                speedCells -= 0.3;
                if (speedCells < 0)
                {
                    damage = false;
                    return;
                }
                tempX = tempX + angelX * speedCells;
                tempY = tempY + angelY * speedCells;
                bloodcellsXpos = (int)Math.Round(tempX);
                bloodcellsYpos = (int)Math.Round(tempY);
            }
            else
            if (!finish)
            {
                bulletXpos = (double)(1.0 * bulletXpos +  zz * 1.0 * speedBullet);
                bulletYpos = (double)(1.0 * bulletYpos +  zzz * 1.0 * speedBullet);
                Xpos = (int)Math.Round(bulletXpos);
                Ypos = (int)Math.Round(bulletYpos);
            }
        }
    }
}
