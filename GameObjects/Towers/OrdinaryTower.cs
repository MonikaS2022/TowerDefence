using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.Bullets;
using TowerDefence.Enemies;

namespace TowerDefence.Towers
{
    public class OrdinaryTower : Tower
    {
        Timer towerTimer;
        
        public Vector2 enemyPosition;
        public OrdinaryTower(Vector2 position, Texture2D texture) : base(position, texture)
        {
            radius = 500;
            towerTimer = new Timer();
            
        }

        public override void Update(double deltaTime)
        {
            towerTimer.Update(deltaTime);   
            
            if (EnemyIsFound() && towerTimer.IsDone())
            {
                Shoot(GetDirection(position, enemyPosition));
                towerTimer.ResetAndStart(5000);
            }
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Shoot(Vector2 direction)
        {
            BulletManager.CreateBullet(direction, position);
        }

        public bool EnemyIsFound()
        {
            bool enemyFound = false;
            foreach (Enemy e in EnemyManager.enemyList)
            {
                Vector2 relativePosition = e.position - position;
                float distanceBetweenPoints = relativePosition.Length();
                if (distanceBetweenPoints <= radius)
                {
                    enemyFound = true;
                    enemyPosition = e.position;
                    return enemyFound;
                }
            }

            return enemyFound;

        }

        public Vector2 GetDirection(Vector2 towerPos, Vector2 enemyPos)
        {
            Vector2 dir = new Vector2(0, 0);
            dir.X = enemyPos.X - towerPos.X;
            dir.Y = enemyPos.Y - towerPos.Y;
            dir.Normalize();

            return dir;
        }
    }
}
