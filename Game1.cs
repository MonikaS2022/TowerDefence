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
using Table;

namespace TowerDefence
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Form1 myForm;
        //ParticleSystem particleSystem;

        Timer enemyTimer;
        GameStates gameStates;
        

        List <int> waveList = new List<int>(){ 2, 3, 4 };
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
            myForm = new Form1();
            myForm.Show();
            List<Texture2D> textures = new List<Texture2D>();
            textures.Add(Content.Load<Texture2D>("star"));
            textures.Add(Content.Load<Texture2D>("diamond"));


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
            gameStates = GameStates.MainMenu;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gameStates == GameStates.MainMenu)
            {
                //if (KeyMouseReader.RightClick())
                //{
                //    cpath_road.SetPoint(0, new Vector2(KeyMouseReader.mouseState.X, KeyMouseReader.mouseState.Y));
                //}

                //if (Keyboard.GetState().IsKeyDown(Keys.S))
                //{
                //    System.Diagnostics.Debug.WriteLine(cpath_road.GetPoints().Length);
                //    SavePathToFile(cpath_road, "../../../newpath.txt");
                //    LoadPathFromFile(cpath_road, "../../../newpath.txt");
                //    gameStates = GameStates.Play;
                //}
                if(myForm.IsStarted)
                {
                    gameStates = GameStates.Play;
                    myForm.Hide();
                }
            }

                //if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                //{
                //    gameStates = GameStates.Play;
                //}
            

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

                //particleSystem.EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                //particleSystem.Update();

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
            _spriteBatch.Draw(TextureManager.texCityMap, new Rectangle(0, 0, 1280, 720), Color.White);

            if (gameStates == GameStates.MainMenu)
            {
                //GraphicsDevice.Clear(Color.LavenderBlush);
                //_spriteBatch.Draw(TextureManager.texCityMap, new Rectangle(0, 0, 1280, 720), Color.White);
            }

            if (gameStates == GameStates.Play)
            {
                //_spriteBatch.Draw(TextureManager.texCityMap, new Rectangle(0, 0, 1280, 720), Color.White);
                towerManager.Draw(_spriteBatch);

                EnemyManager.Draw(_spriteBatch);
                //foreach (Enemy e in EnemyManager.enemyList)
                //{
                //    _spriteBatch.DrawRectangle(e.hitBox, Color.Red);
                //}

                BulletManager.Draw(_spriteBatch);
                //foreach (Bullet b in BulletManager.bulletList)
                //{
                //    _spriteBatch.DrawRectangle(b.hitBox, Color.Blue);
                //}
            }

            if (gameStates == GameStates.GameOver)
            {
                GraphicsDevice.Clear(Color.MediumSeaGreen);
            }

            _spriteBatch.End();
            //particleSystem.Draw(_spriteBatch);

            //cpath_road.DrawPoints(_spriteBatch, Color.Black, 6);

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