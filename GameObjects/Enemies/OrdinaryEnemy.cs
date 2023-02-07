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
        

        public OrdinaryEnemy(Vector2 position, Texture2D texture) : base(position, texture)
        {
            lives = 3;
            speed = 0.00005f;
            color = Color.White;
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
            color.A -= 80;
        }
    }
}
