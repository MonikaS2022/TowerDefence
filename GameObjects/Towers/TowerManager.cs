using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefence.Bullets;

namespace TowerDefence.Towers
{
    public class TowerManager
    {
        public RenderTarget2D renderTarget;
        readonly GraphicsDevice device;
        public List<Tower> towerList;
        public OrdinaryTower towerOrdinary;

        public TowerManager(GraphicsDevice device)
        {
            this.device = device;
            renderTarget = new RenderTarget2D(device, device.Viewport.Width, device.Viewport.Height);
            towerList = new List<Tower>();
        }

        public void Update(double delta)
        {
            DrawOnRenderTarget(renderTarget);
            foreach (Tower tower in towerList)
            {
                tower.Update(delta);
            }
        }

        public void Draw (SpriteBatch sb)
        {
            sb.Draw(renderTarget, Vector2.Zero, Color.White);
        }

        public void CreateTower(int posX, int posY)
        {
            towerOrdinary = new OrdinaryTower(new Vector2(posX, posY), TextureManager.texTowerOrdinary);

            if (CanPlace(towerOrdinary))
            {
                towerList.Add(towerOrdinary);
            }
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
            SpriteBatch sb = new SpriteBatch(device);
            device.SetRenderTarget(renderTarget);
            device.Clear(Color.Transparent);
            sb.Begin();

            sb.Draw(TextureManager.texBackground, Vector2.Zero, Color.White);

            foreach (Tower t in towerList)
            {
                sb.Draw(t.texture, t.position, Color.White);
            }

            sb.End();

            device.SetRenderTarget(null);
        }

        public bool CanShoot()
        {
            bool canShoot = false;
            foreach (Tower t in towerList)
            {
                if((t.position + new Vector2(t.radius, t.radius)) == new Vector2(0,0))
                {
                    canShoot = true;
                }
            }
                return canShoot;
        }

        

    }
}
