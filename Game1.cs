using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TowerDefence.Bullets;
using TowerDefence.Enemies;
using TowerDefence.Towers;
using CatmullRom;
using System.IO;
using System;
using System.Collections.Generic;
//using Table;

namespace TowerDefence
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont pointFont, bigFont, bigItalicFont;
        //Form1 myForm;

        Timer enemyTimer;
        GameStates gameStates;
        

        List <int> waveList = new List<int>(){ 8, 12, 20 };
        int currentWave = 0;
        int wavesEnemyCounter;


        CatmullRomPath cpath_road;
        
        public static  TowerManager towerManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            float tension_road = 0.5f;
            cpath_road = new CatmullRomPath(GraphicsDevice, tension_road);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //myForm = new Form1();
            //myForm.Show();
            
            pointFont = Content.Load<SpriteFont>("points");
            bigFont = Content.Load<SpriteFont>("bigFont");
            bigItalicFont = Content.Load<SpriteFont>("bigItalicFont");

            TextureManager.LoadTextures(Content, GraphicsDevice);
            DebugRectangle.Init(GraphicsDevice);
            enemyTimer = new Timer();
            enemyTimer.ResetAndStart(2000);

            towerManager = new TowerManager(GraphicsDevice);
            towerManager.cpath_road = cpath_road;

            cpath_road.Clear();
            LoadPathFromFile(cpath_road, "../../../road1.txt");
            cpath_road.DrawFillSetup(GraphicsDevice, 25, 1, 256);

            wavesEnemyCounter = waveList[currentWave];
            //gameStates = GameStates.GameOver;
            gameStates = GameStates.Play;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gameStates == GameStates.MainMenu)
            {
                /*
                if(myForm.IsStarted)
                {
                    gameStates = GameStates.Play;
                    myForm.Hide();
                }*/
            }

            if (gameStates == GameStates.Play)
            {
               enemyTimer.Update(gameTime.ElapsedGameTime.TotalMilliseconds);
                             

                if (wavesEnemyCounter != 0)
                {
                    if (enemyTimer.IsDone())
                    {
                        
                        if (wavesEnemyCounter == 1)
                        {
                            EnemyManager.CreateStrongEnemy(cpath_road.EvaluateAt(0));
                        }
                        else
                        {
                            EnemyManager.CreateEnemy(cpath_road.EvaluateAt(0));
                        }
                        wavesEnemyCounter--;
                        enemyTimer.ResetAndStart(2000 - new Random().Next(0, 500));
                    }

                }

                else if (EnemyManager.enemyList.Count == 0)
                {
                    currentWave++;
                    if (currentWave == waveList.Count)
                    {
                        gameStates = GameStates.GameOver;
                    }
                    else
                    {
                        wavesEnemyCounter = waveList[currentWave];
                        enemyTimer.ResetAndStart(2000);
                    }
                }

                KeyMouseReader.Update();
                towerManager.Update(gameTime.ElapsedGameTime.TotalMilliseconds);
                EnemyManager.Update((float)gameTime.ElapsedGameTime.TotalMilliseconds, cpath_road);
                BulletManager.Update();

                if (KeyMouseReader.RightClick())
                {
                    int posX = KeyMouseReader.mouseState.X;
                    int posY = KeyMouseReader.mouseState.Y;
                    towerManager.CreateOrdinaryTower(posX, posY);

                }

                if (KeyMouseReader.LeftClick())
                {
                    int posX = KeyMouseReader.mouseState.X;
                    int posY = KeyMouseReader.mouseState.Y;
                    towerManager.CreateStrongTower(posX, posY);
                }

                if(Points.points >= 1000)
                {
                    Points.AddDonation(Points.points);
                }
              
            }

            if (gameStates == GameStates.GameOver)
            {

            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
                       
            _spriteBatch.Begin();
            _spriteBatch.Draw(TextureManager.texBackground, new Rectangle(0, 0, 1280, 720), Color.White);

            if (gameStates == GameStates.MainMenu)
            {
                _spriteBatch.DrawString(bigFont, "THE GALLERY was ROBBED!", new Vector2(440, 350), Color.White);
                _spriteBatch.DrawString(bigItalicFont, "Get our COLORS back!", new Vector2(445, 430), Color.White);



            }

            if (gameStates == GameStates.Play)
            {
                _spriteBatch.DrawString(pointFont, "You have: " + Points.points + " colors", new Vector2(10, 580), Color.White);

                _spriteBatch.DrawString(pointFont, "Reach 1000 colors and it will be donated double", new Vector2(12, 600), Color.White);

                _spriteBatch.DrawString(pointFont, "You donated: " + Points.donations + " colors", new Vector2(10, 620), Color.White);


                _spriteBatch.Draw(TextureManager.texTowerOrdinary, new Rectangle(10, 660, 20, 20), Color.White);
                _spriteBatch.DrawString(pointFont, "Ordinary. Cost: 100 colors. Press right to build.", new Vector2(40, 660), Color.White);

                _spriteBatch.Draw(TextureManager.texTowerStrong, new Rectangle(10, 690, 20, 20), Color.White);
                _spriteBatch.DrawString(pointFont, "Strong - slows down enemies; wider range. Cost: 200 colors. Press left to build.", new Vector2(40, 690), Color.White);


                towerManager.Draw(_spriteBatch);

                EnemyManager.Draw(_spriteBatch);

                BulletManager.Draw(_spriteBatch);
            }

            if (gameStates == GameStates.GameOver)
            {
                GraphicsDevice.Clear(Color.MediumSeaGreen);
                _spriteBatch.DrawString(bigFont, "You have saved " + Points.amount + " paintings", new Vector2(440, 350), Color.White);
                _spriteBatch.DrawString(bigItalicFont, "You have donated " + Points.donations + ".", new Vector2(445, 430), Color.White);


            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }


        void LoadPathFromFile(CatmullRomPath path, string file)
        {
            string[] lines = File.ReadAllLines(file);
            foreach(string line in lines)
            {
                path.AddPoint(InputParser.parse_Vector2(line));
            }

        }

        void SavePathToFile(CatmullRomPath path, string file)
        {
            Vector2[] points = path.GetPoints();
            string[] lines = new string[points.Length];
            for (int i = 0; i < points.Length; i++)
                lines[i] = ((int)(points[i].X)).ToString() + "," + ((int)points[i].Y).ToString();
            System.IO.File.WriteAllLines(file, lines);
        }



    }
}