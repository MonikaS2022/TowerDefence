using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Towers
{
    public class OrdinaryTower : Tower
    {
        public OrdinaryTower(Vector2 position, Texture2D texture) : base(position, texture)
        {

        }

        public override void Update()
        {
            base.Update();
            //position.X += 1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
