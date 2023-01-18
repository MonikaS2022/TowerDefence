using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Bullets
{
    public class OrdinaryBullet : Bullet
    {
        Vector2 direction;
        float speed;

        public OrdinaryBullet(Vector2 direction, Vector2 position, Texture2D texture) : base(position, texture)
        {
            this.direction = direction;
            //this.speed = speed;
            speed = 15;
        }

        public override void Update()
        {
            position += direction*speed;
        }

       
    }
}
