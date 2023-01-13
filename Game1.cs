using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Security.Principal;
using TowerDefence.Enemies;
using TowerDefence.GameObjects;
using TowerDefence.Towers;
using static System.Net.Mime.MediaTypeNames;

namespace TowerDefence
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        OrdinaryEnemy ordinaryEnemy;
        public EnemyManager enemyManager;
        public TowerManager towerManager;
        public OrdinaryTower towerOrdinary;
        Vector2 position = new Vector2(100, 100);
        public RenderTarget2D renderTarget;
        MiniMap map;


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
            map = new MiniMap(GraphicsDevice);
            enemyManager = new EnemyManager();
            towerManager = new TowerManager();
            
            renderTarget = new RenderTarget2D(GraphicsDevice, Window.ClientBounds.Width, Window.ClientBounds.Height);

            for (int i = 0; i < 3; i++)
            {
                position.X += 50;
                position.Y += 50;
                ordinaryEnemy = new OrdinaryEnemy(position, TextureManager.texEnemyOrdinary);
                enemyManager.enemyList.Add(ordinaryEnemy);
            }

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyMouseReader.Update();
            towerManager.Update();

            if (KeyMouseReader.RightClick())
            {
                int posX = KeyMouseReader.mouseState.X;
                int posY = KeyMouseReader.mouseState.Y;

                towerOrdinary = new OrdinaryTower(new Vector2(posX, posY), TextureManager.texTowerOrdinary);

                if (CanPlace(towerOrdinary))
                {
                    towerManager.towerList.Add(towerOrdinary);
                }
            }

            DrawOnRenderTarget(renderTarget);
            map.Redraw(towerManager.towerList);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _spriteBatch.Draw(renderTarget, Vector2.Zero, Color.White);
            foreach (OrdinaryEnemy enemy in enemyManager.enemyList)
            {
                _spriteBatch.Draw(enemy.texture, enemy.position, Color.White);
            }

            map.Draw(new Rectangle(0,0, 100, 100), _spriteBatch);

            _spriteBatch.End();


            base.Draw(gameTime);
        }

        public bool CanPlace(Tower t)
        {
            try
            {
                Color[] pixels = new Color[t.texture.Width * t.texture.Height];
                Color[] pixels2 = new Color[t.texture.Height * t.texture.Width];
                t.texture.GetData<Color>(pixels2);
                renderTarget.GetData(0, t.hitBox, pixels, 0, pixels.Length);
                for (int i = 0; i < pixels.Length; i++)
                {
                    if (pixels[i].A > 0.0f && pixels[i].A > 0.0f)
                        return false;
                }
            }
            catch
            {
                Debug.WriteLine("Out of window");
            }
            return true;
        }

        private void DrawOnRenderTarget(RenderTarget2D renderTarget)
        {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.Transparent);
            _spriteBatch.Begin();

            _spriteBatch.Draw(TextureManager.texBackground, Vector2.Zero, Color.White);

            foreach (Tower t in towerManager.towerList)
            {
                _spriteBatch.Draw(t.texture, t.position, Color.White);
            }

            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
        }
    }
}