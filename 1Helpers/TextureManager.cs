using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class TextureManager
    {
        public static Texture2D texEnemyOrdinary, texTowerOrdinary, texBackground, texHeart;

        public static void LoadTextures(ContentManager content)
        {
            texEnemyOrdinary = content.Load<Texture2D>("EnemyOrdinary");
            texTowerOrdinary = content.Load<Texture2D>("TowerOrdinary");
            texBackground = content.Load<Texture2D>("Background");
            texHeart = content.Load<Texture2D>("heart");
        }
    }
}
