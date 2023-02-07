using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Drawing;


namespace TowerDefence
{
    internal class TextureManager
        
    {
        
        public static Texture2D texEnemyOrdinary, texTowerStrong, texTowerOrdinary, texBackground, texHeart, texCar, texCityMap, texRoad, texTurningTorso;

        public static void LoadTextures(ContentManager content, GraphicsDevice device)
        {
            texEnemyOrdinary = content.Load<Texture2D>("EnemyOrdinary");
            texTowerOrdinary = content.Load<Texture2D>("TowerOrdinary");
            texTowerStrong = content.Load<Texture2D>("TowerStrong");
            texBackground = content.Load<Texture2D>("Background");
            texHeart = content.Load<Texture2D>("heart");
            texCar = content.Load<Texture2D>("car");
            texRoad = content.Load<Texture2D>("roadGrey");
            texCityMap = content.Load<Texture2D>("map2");
            texTurningTorso = content.Load<Texture2D>("turningTorso");
            
        }
    }
}

