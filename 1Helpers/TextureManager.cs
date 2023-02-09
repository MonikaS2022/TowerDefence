using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Drawing;


namespace TowerDefence
{
    internal class TextureManager
        
    {
        
        public static Texture2D texEnemyOrdinary, texTowerStrong,texEnemyStrong, texTowerOrdinary, texParticle, texCube, texBackground, texHeart, texCar, texCityMap, texRoad, texTurningTorso, texEnemy;

        public static void LoadTextures(ContentManager content, GraphicsDevice device)
        {
            texParticle = content.Load<Texture2D>("kube");

            texEnemyOrdinary = content.Load<Texture2D>("ram2");
            texEnemyStrong = content.Load<Texture2D>("EnemyWhite1");

            texTowerOrdinary = content.Load<Texture2D>("TowerOrdinary");
            texTowerStrong = content.Load<Texture2D>("TowerStrong");

            texBackground = content.Load<Texture2D>("map2");
            texHeart = content.Load<Texture2D>("heart");
            texRoad = content.Load<Texture2D>("roadGreyDark");
            

        }
    }
}

