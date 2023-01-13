using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{
    internal class Heart
    {
        Texture2D heartTex;
        Vector2 pos;

        public Heart(Texture2D heartTex, Vector2 pos)
        {
            this.heartTex = heartTex;
            this.pos = pos;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(heartTex, pos, Color.White);
        }
    }
}