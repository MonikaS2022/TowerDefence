using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TowerDefence.Bullets;
using TowerDefence.Enemies;
using TowerDefence.Towers;

namespace TowerDefence
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public EnemyManager enemyManager;
        OrdinaryEnemy ordinaryEnemy;


        public static  TowerManager towerManager;

        Vector2 position = new Vector2(100, 100);


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;

        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.LoadTextures(Content);

            enemyManager = new EnemyManager();
            for (int i = 0; i < 1; i++)
            {
                position.X += 50;
                position.Y += 50;
                ordinaryEnemy = new OrdinaryEnemy(position, TextureManager.texEnemyOrdinary);
                EnemyManager.enemyList.Add(ordinaryEnemy);
            }

            towerManager = new TowerManager(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyMouseReader.Update();
            towerManager.Update(gameTime.ElapsedGameTime.TotalMilliseconds);
            enemyManager.Update();
            BulletManager.Update();

            if (KeyMouseReader.RightClick())
            {
                int posX = KeyMouseReader.mouseState.X;
                int posY = KeyMouseReader.mouseState.Y;

                towerManager.CreateTower(posX, posY);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            foreach (OrdinaryEnemy enemy in EnemyManager.enemyList)
            {
                _spriteBatch.Draw(enemy.texture, enemy.position, Color.White);
            }

            towerManager.Draw(_spriteBatch);
            BulletManager.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

       

    }
}