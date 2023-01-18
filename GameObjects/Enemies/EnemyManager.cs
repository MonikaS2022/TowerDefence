using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Enemies
{
    public class EnemyManager
    {
        public static List<Enemy> enemyList;

        public EnemyManager()
        {
            enemyList = new List<Enemy>();

        }

        public void Update()
        {
            foreach(Enemy enemy in enemyList)
            {
                enemy.Update();
            }
        }
    }
}
