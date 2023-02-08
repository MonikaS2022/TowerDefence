using CatmullRom;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.Bullets;
using TowerDefence.Towers;

namespace TowerDefence.Enemies
{
    public static class EnemyManager
    {
        public static List<Enemy> enemyList = new List<Enemy>();


        public static void Update(float deltaTime, CatmullRomPath path)
        {
            for(int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].totalDistanceTravelled += enemyList[i].speed * deltaTime;
                if (enemyList[i].totalDistanceTravelled > 1.0f)
                {
                    enemyList.RemoveAt(i);
                    i--;
                    continue;
                }
                // Car: get position from curve and draw it
                var position = path.EvaluateAt(enemyList[i].totalDistanceTravelled);
                var angle = 0.0f;
                //
                // Optional: create rotation w.r.t. the curve's tangent
                Vector2 dir = path.EvaluateTangentAt(enemyList[i].totalDistanceTravelled);
                angle = System.MathF.Atan2(dir.Y, dir.X);
                angle += MathHelper.ToRadians(90); // Add rotation if needed w.r.t. texture orientation
                                                   //
                enemyList[i].angle = angle;

                enemyList[i].Update(position);
                if (enemyList[i].lives <= 0)
                {
                    enemyList.RemoveAt(i);
                    i--;
                    Points.AddAmount(1);
                    continue;
                }
                if (enemyList.Count != 0)
                {
                    if (enemyList[i].position.X >= 1280 || enemyList[i].position.Y >= 720)
                    {
                        enemyList.RemoveAt(i);
                        i--;
                    }
                }


            }
        }

        public static void CreateEnemy(Vector2 position)
        {
            Enemy ordinaryEnemy = new OrdinaryEnemy(position, TextureManager.texEnemy);
            ordinaryEnemy.totalDistanceTravelled = 0.0f;
            EnemyManager.enemyList.Add(ordinaryEnemy);
        }

        public static void CreateStrongEnemy(Vector2 position)
        {
            Enemy strongEnemy = new StrongEnemy(position, TextureManager.texEnemyStrong);
            strongEnemy.totalDistanceTravelled = 0.0f;
            EnemyManager.enemyList.Add(strongEnemy);
        }

        public static void Draw(SpriteBatch sb)
        {
            foreach (Enemy enemy in enemyList)
            {
                enemy.DrawEnemy(sb, enemy.position, enemy.angle);
            }
        }
    }
}
