using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Towers
{
    public class TowerManager
    {
        public List<Tower> towerList;
        public RenderTarget2D renderTarget;


        public TowerManager()
        {
            towerList = new List<Tower>();

        }

        public void Update()
        {
            foreach(Tower tower in towerList)
            {
                tower.Update();
            }
        }


    }
}
