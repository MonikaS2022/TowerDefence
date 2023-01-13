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

        public Rectangle hitBox;

        public Enemy(Vector2 position, Texture2D texture) : base(position, texture)
        {
            hitBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public virtual void Update()
        {
           
        }

        public virtual void Draw()
        {

        }
    }
}
