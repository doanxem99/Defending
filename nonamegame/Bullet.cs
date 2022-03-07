using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nonamegame
{
    internal class Bullet
    {
        private int bulletWidth = 10, bulletHeight = 10;
        private double x, xx, y, yy, z, zz, zzz, speedBullet = 40;
        public double mouseXpos { get; set; }
        public double mouseYpos { get; set; }
        public double bulletXpos { get; set; }
        public double bulletYpos { get; set; }

        

        public bool finish = false;

        public void Prepare()
        {
            x = 1.0 * (bulletXpos + (bulletWidth / 2));
            y = 1.0 * (bulletYpos + (bulletHeight / 2));
            xx = 1.0 * (1.0 * mouseXpos);
            yy = 1.0 * (1.0 * mouseYpos);
            z = Math.Sqrt(((xx - x) * (xx - x)) + ((yy - y) * (yy - y)));
            zz = (1.0 * Math.Sin((xx - x) / z) * speedBullet);
            zzz = (1.0 * Math.Sin((yy - y) / z) * speedBullet);
        }

        public void Solve()
        {
            bulletXpos = (double)(1.0 * bulletXpos + 1.0 * zz);
            bulletYpos = (double)(1.0 * bulletYpos + 1.0 * zzz);
        }
    }
}
