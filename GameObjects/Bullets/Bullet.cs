using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.GameObjects;
using System.Windows.Forms;

namespace TowerDefence.Bullets
{
    public abstract class Bullet : GameObject
    {

        public Bullet(Vector2 position, Texture2D texture) : base(position, texture)
        {
        }

        public virtual void Update()
        {
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, Color.White);
        }

    }
}
