

namespace Domain.Repositories.Monster
{
    using Domain.Repositories.Hero;
  

    public class Witch : Monster, IStats
    {
        private double JumbusProbability = 0.4;

        private Random random = new Random();

        public Witch()
        {
            SetStatsForMonster();
        }
       


        public void SetStatsForMonster()
        {
            int health = random.Next(130, 170);
            int damage = random.Next(70, 90);
            this.HealthPoints = health;
            this.Damage = damage;
            this.ExpForKilling = 40;
            this.Name = "Witch";

        }
        public List<Monster> WitchDeath()
        {
            List <Monster> generatedMonsters = GenerateMonsters(2);
            return generatedMonsters;
        }
       
       
        public  override void AttackDamage(Hero hero, List<Monster> monsters)
        {

            if (random.NextDouble() <= JumbusProbability)
            {
                Console.WriteLine("Đumbus aktiviran!");

                hero.HealthPoints = random.Next(50, 150);
                foreach (var monster in monsters)
                    monster.HealthPoints = random.Next(50, 150);
            }
            else base.AttackDamage();
              
        }
    }
}
