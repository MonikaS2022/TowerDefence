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

        public Rectangle hitBox;

        public Bullet(Vector2 position, Texture2D texture) : base(position, texture)
        {
            hitBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public virtual void Update()
        {
            hitBox.Location = position.ToPoint();
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, Color.White);
        }

    }
}
