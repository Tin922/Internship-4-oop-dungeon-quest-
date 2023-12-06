


namespace Domain.Repositories.Hero
{
    using Domain.Repositories.Heros;
    using Domain.Repositories.Monster;
    public class Marksman : Hero, IPrintStats
    {

        private Random random = new Random();
        private double CriticalChance;
        private double StunChance;
        private const double CriticalHitBonusDamage = 50;
        public Marksman(string name)
        {
            this.HealthPoints = 200;
            this.MaxHealthPoints = 200;
            this.Damage = 50;
            this.CriticalChance = 0.2;
            this.StunChance = 0.4;
            this.Name = name;
        }

        public override void HandleLevelUp()
        {
            if (this.Experience > 100)
            {
                this.CriticalChance += 0.1;
                this.StunChance += 0.1;
            }
            base.HandleLevelUp();
        }
        public override void PrintStats()
        {
            base.PrintStats();
            Console.WriteLine($"Critical Chance {(this.CriticalChance* 100).ToString("0.00")}% StunChance {(this.StunChance* 100).ToString("0.00")}%");
        }
        public override int HeroAttack()
        {
            Console.WriteLine("1 - Direktan napad");
            Console.WriteLine("2 - Napad s boka");
            Console.WriteLine("3 - Protunapad");

            while (true)
            {
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        return 1;
                    case "2":
                        return 2;
                    case "3":
                        return 3;
                    default:
                        Console.WriteLine("krivi unos");
                        break;
                }
            }
        }

        public override void AttackDamage(Monster currentMonster, ref bool isStunned)
        {
            if (IsCriticalHit())
            {
                Console.WriteLine("Critical Hit!");
                currentMonster.HealthPoints = currentMonster.HealthPoints - (this.Damage + CriticalHitBonusDamage);

            }
            else if (IsStunHit())
            {
                base.AttackDamage(currentMonster);
                isStunned = true;
            }
            else
                base.AttackDamage(currentMonster);
        }

        private bool IsCriticalHit()
        {
            return random.NextDouble() <= CriticalChance;
        }

        private bool IsStunHit()
        {
            return random.NextDouble() <= StunChance;
        }

    }
}
