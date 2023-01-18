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

        }

        public override void Update()
        {
            position.X += 1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
