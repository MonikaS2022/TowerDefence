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
            texEnemy = content.Load<Texture2D>("ram2");
            texParticle = content.Load<Texture2D>("kube");
            texEnemyOrdinary = content.Load<Texture2D>("EnemyOrdinary");
            texEnemyStrong = content.Load<Texture2D>("EnemyWhite1");

            texTowerOrdinary = content.Load<Texture2D>("TowerOrdinary");
            texTowerStrong = content.Load<Texture2D>("TowerStrong");
            texBackground = content.Load<Texture2D>("Background");
            texHeart = content.Load<Texture2D>("heart");
            texCar = content.Load<Texture2D>("car");
            texRoad = content.Load<Texture2D>("roadGreyDark");
            texCityMap = content.Load<Texture2D>("map2");
            texTurningTorso = content.Load<Texture2D>("turningTorso");
            texCube = content.Load<Texture2D>("kube");

        }
    }
}

