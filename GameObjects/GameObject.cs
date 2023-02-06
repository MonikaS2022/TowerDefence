using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TowerDefence.GameObjects
{
    public abstract class GameObject
    {
        public Vector2 position;
        public float angle;
        public Texture2D texture;
        

        public GameObject(Vector2 position, Texture2D texture)
        {
            this.position = position;
            this.texture = texture;
        }

        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
