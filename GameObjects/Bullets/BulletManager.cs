using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Bullets
{
    public static class BulletManager
    {
        public static List<Bullet> bulletList = new List<Bullet>();

       

        public static void Update()
        {
            foreach(Bullet bullet in bulletList)
            {
                bullet.Update();
            }
        }

        public static void CreateBullet(Vector2 direction, Vector2 position)
        {
            OrdinaryBullet bullet = new OrdinaryBullet(direction, position, TextureManager.texHeart);
            bulletList.Add(bullet);
        }

        public static void Draw(SpriteBatch sb)
        {
            foreach (Bullet bullet in bulletList)
            {
                bullet.Draw(sb);
            }
        }
    }
}
