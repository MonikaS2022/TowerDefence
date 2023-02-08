using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.Enemies;

// if tyhey dont hit? ta bort fron lista när ute av shkarmen
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

            foreach (Enemy enemy in EnemyManager.enemyList)
            {
                for (int i = 0; i < bulletList.Count; i++)
                {
                    if (bulletList[i].hitBox.Intersects(enemy.hitBox))
                    {
                        if (bulletList[i] is StrongBullet)
                        {
                            enemy.speed -= 0.000002f;
                        }
                        bulletList.RemoveAt(i);
                        enemy.TakeDamage(1);
                        i--;
                    }
                }
            }
        }

        public static void CreateBullet(Vector2 direction, Vector2 position)
        {
            OrdinaryBullet bullet = new OrdinaryBullet(direction, position, TextureManager.texHeart);
            bulletList.Add(bullet);
        }

        public static void CreateStrongBullet(Vector2 direction, Vector2 position)
        {
            StrongBullet bullet = new StrongBullet(direction, position, TextureManager.texHeart);
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
