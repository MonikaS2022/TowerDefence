using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Enemies
{
    public class OrdinaryEnemy : Enemy
    {
        private Random random = new Random();

        public OrdinaryEnemy(Vector2 position, Texture2D texture) : base(position, texture)
        {
            lives = 5;
            speed = 0.00005f;
            color = new Color(
                    (float)random.NextDouble(),
                    (float)random.NextDouble(),
                    (float)random.NextDouble());
            color.A = 1;
        }

        public override void Update(Vector2 pos)
        {
            base.Update(pos);
            this.position.X = pos.X;
            this.position.Y = pos.Y;
        }

       
        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void TakeDamage(int i)
        {
            lives = lives - i;
            color.A += 45;
            color.R += (byte)random.Next(1, 255);
            color.G += (byte)random.Next(1, 255); 
            color.B += (byte)random.Next(1, 255); 
            

        }
    }
}
