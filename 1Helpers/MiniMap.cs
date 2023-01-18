using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using System.Collections.Generic;
using TowerDefence.Enemies;
using TowerDefence.Towers;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace TowerDefence
{
    /// <summary>
    /// This class represents a minimap. The minimap hold a render target to which it draws a collection och drawable GameObjects to.
    /// The render target is then used to draw the minimap onto the screen.
    /// </summary>
    class MiniMap
    {
        readonly GraphicsDevice device;
        RenderTarget2D renderTarget;
        Rectangle viewSize;

        /// <summary>
        /// Gets or sets the size of the minimaps view.
        /// The view is used to deicide what to draw on the minimap.
        /// </summary>
        public Rectangle ViewSize
        {
            get{ return viewSize; }
            set
            {
                if (renderTarget != null)
                {
                    //We resize the rendertarget to the size of the view.
                    renderTarget = new RenderTarget2D(device, value.Width, value.Height);
                }
                viewSize = value;
            }
        }

        /// <summary>
        /// Gets the texture that is the result of the <see cref="Redraw(List{GameObject})" method./>
        /// </summary>
        public Texture2D View
        {
            get { return renderTarget; }
        }

        /// <summary>
        /// Creates a new <see cref="MiniMap"/> instance. This defaults the the view of the minimap to the default viewport's view.
        /// </summary>
        /// <param name="device">The device which is used to draw the minimap with.</param>
        public MiniMap(GraphicsDevice device)
        {
            this.device = device;
            ViewSize = new Rectangle(0, 0, device.Viewport.Width, device.Viewport.Height);
            renderTarget = new RenderTarget2D(device, device.Viewport.Width, device.Viewport.Height);
        }

        /// <summary>
        /// Create a new <see cref="MiniMap"/> instance.
        /// </summary>
        /// <param name="device">The device which is used to dra the minimap wih.</param>
        /// <param name="worldSize">The size of the minimaps <see cref="ViewSize"/>.</param>
        public MiniMap(GraphicsDevice device, Rectangle viewSize) : this(device)
        {
            ViewSize = viewSize;
        }

        /// <summary>
        /// Redraws the minimap. Should be called whenever the minimap should update its content.
        /// </summary>
        public void Redraw(List<Towers.Tower> drawables)
        {
            //Create a new spritebatch to collect textures.

            SpriteBatch sb = new SpriteBatch(device);
            //Clear the backbuffer.

            //Set the render target of the device to our renderTarget.
            device.SetRenderTarget(renderTarget);
            //Begin drawing to the render target.

            sb.Begin();
            device.Clear(Color.White);

            sb.Draw(TextureManager.texBackground, Vector2.Zero, Color.White);
            //Draw all the objects in the list.
            
                foreach (OrdinaryEnemy enemy in EnemyManager.enemyList)
                {
                    sb.Draw(enemy.texture, enemy.position, Color.White);
                }
            
            foreach (var e in drawables)
            {
                e.Draw(sb);
            }

            foreach (Tower t in Game1.towerManager.towerList)
            {
                sb.Draw(t.texture, t.position, Color.White);
            }



            sb.End();

            //Reset the rendertarget of the device.
            device.SetRenderTarget(null);
        }

        /// <summary>
        /// Draws the minimap at the given destination with the provided spritebatch.
        /// </summary>
        /// <param name="destinationRectangle">The destination at which the minimap should be drawn.</param>
        /// <param name="spriteBatch">The spritebatch used to draw the minimap.</param>
        public void Draw(Rectangle destinationRectangle, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(renderTarget, destinationRectangle, Color.White);
        }

    }
}
