using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.GameObjects;

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

        public virtual void Draw()
        {

        }

    }
}
