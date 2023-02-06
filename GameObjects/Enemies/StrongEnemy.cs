using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Enemies
{
    public class StrongEnemy : Enemy
    {

        public StrongEnemy(Vector2 position, Texture2D texture) : base(position, texture)
        {
            lives = 5;
            speed = 0.0001f;
            color = Color.Red;
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
            color.A -= 54;
            speed -= 0.000003f;
        }
    }
}
