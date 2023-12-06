



namespace Domain.Repositories.Monster
{
    using Domain.Repositories.Hero;
    using System;

    public class Monster
    {
        public string Name { get; set; }
        public double HealthPoints { get; set; }
        public int Damage { get; set; }
        public int ExpForKilling { get; set; }
        private Random random = new Random();
        
        public int Attack()
        {
            int randomMove = random.Next(1, 4);
            return randomMove;

        }
        public static List<Monster> GenerateMonsters(int numberOfMonsters)
        {
            List<Monster> monsters = new List<Monster>();
            Random random = new Random();

            for (int i = 0; i < numberOfMonsters; i++)
            {
                double probability = random.NextDouble() * 100;

                if (probability <= 30)
                {
                    monsters.Add(new Brute());
                }
                else if (probability <= 80)
                {
                    monsters.Add(new Goblin());
                }
                else
                {
                    monsters.Add(new Witch());
                }
            }
            
            return monsters;
        }
        public void MonsterPrintStats()
        {
            Console.WriteLine($"Tvoj neprijatelj: Ime: {this.Name} Health: {this.HealthPoints} Damage: {this.Damage}\n");

        }
        public virtual void AttackDamage()
        {
            
        }

        public virtual void AttackDamage(Hero hero)
        {
             hero.HealthPoints -= this.Damage;
        }
        
        public virtual void AttackDamage(Hero hero, List<Monster> monsters)
        {

        }
    }
}
