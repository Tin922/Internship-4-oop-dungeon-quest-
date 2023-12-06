
using System;

namespace Domain.Repositories.Monster
{
    internal class Goblin : Monster, IStats
    {
        private Random random = new Random();

        public Goblin()
        {
            this.ExpForKilling = 30;
            SetStatsForMonster();
        }
        
           
            public void SetStatsForMonster()
           {
                    Random random = new Random();
                    int health = random.Next(100, 120);
                    int damage = random.Next(50, 70);
                    this.HealthPoints = health;
                    this.Damage = damage;
                    this.Name = "Goblin";


        }
     


    }
}
