using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.GameObjects;
using static System.Net.Mime.MediaTypeNames;

namespace TowerDefence.Enemies
{

    public abstract class Enemy : GameObject
    {
        public Color color;
        public Rectangle hitBox;
        public int lives;
        public float totalDistanceTravelled;
        public float speed = 0.0005f;

        public Enemy(Vector2 position, Texture2D texture) : base(position, texture)
        {
            hitBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public virtual void Update(Vector2 position)
        {
            hitBox.Location = position.ToPoint();
        }

        public void DrawEnemy(SpriteBatch spriteBatch, Vector2 pos, float angle)
        {
            spriteBatch.Draw(texture, pos, null, color, angle, new Vector2(40 / 2, 40 / 2), new Vector2(1f, 1f), SpriteEffects.None, 0.0f);
        }

        public virtual void TakeDamage(int i)
        {
            lives = lives - i;
            
        }
    }
}
