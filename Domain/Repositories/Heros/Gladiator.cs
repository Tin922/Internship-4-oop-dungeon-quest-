

using Domain.Repositories.Heros;

namespace Domain.Repositories.Hero
{
    public class Gladiator : Hero, IPrintStats
    {
        public Gladiator(string name)
        {
            this.HealthPoints = 400;
            this.MaxHealthPoints = 400;
            this.Damage = 100;
            this.Name = name;

        }
        public bool RageMode = false;
        public override void PrintStats()
        {
            Console.WriteLine($"Tvoj heroj: Health: {this.HealthPoints.ToString("0.")}/{this.MaxHealthPoints} Damage: {this.Damage} Exp: {this.Experience}");

        }
        public override int HeroAttack()
        {
            if (RageMode)
            {
                RageMode = false;
                this.Damage /= 2;
            }
            Console.WriteLine("1 - Direktan napad");
            Console.WriteLine("2 - Napad s boka");
            Console.WriteLine("3 - Protunapad");
            Console.WriteLine("4 - Ukljuci napad iz bijesa");
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
                    case "4":
                        if (RageMode)
                        {
                            Console.WriteLine("Napad iz bijesa je vec ukljucen");
                            break;
                        }
                        this.Damage *= 2;
                        this.HealthPoints = this.HealthPoints - this.HealthPoints * 0.15;
                        RageMode = true;
                        Console.WriteLine($"Snaga napada je sada {this.Damage}, a health iznosi {this.HealthPoints.ToString("0.0")}");
                        break;
                    default:
                        Console.WriteLine("krivi unos");
                        break;

                }
            }
        }
    }
}
