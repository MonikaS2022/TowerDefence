using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.GameObjects
{
    public abstract class GameObject
    {
        public Vector2 position;
        public Texture2D texture;
        

        public GameObject(Vector2 position, Texture2D texture)
        {
            this.position = position;
            this.texture = texture;
        }

        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
