using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Bullets
{
    public class StrongBullet : Bullet
    {
        Vector2 direction;
        float speed;

        public StrongBullet(Vector2 direction, Vector2 position, Texture2D texture) : base(position, texture)
        {
            this.direction = direction;
            speed = 20;
        }

        public override void Update()
        {
            base.Update();
            position += direction * speed;
        }

    } 
}
