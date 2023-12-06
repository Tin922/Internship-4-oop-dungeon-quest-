
using Domain.Repositories.Heros;

namespace Domain.Repositories.Hero
{
    public class Enchater : Hero, IPrintStats
    {
        public double Mana;
        public double MaxMana;
        public bool Revive;
        public Enchater(string name)
        {
            this.HealthPoints = 300;
            this.MaxHealthPoints = 300;
            this.Damage = 200;
            this.Mana = 100;
            this.MaxMana = 100;
            this.Revive = true;
            this.Name = name;

        }
        public override int HeroAttack()
        {

            if (this.Mana <= 0) 
            {
                Console.WriteLine("Ostao si bez mane pa jedan potez moras cekati");
                this.Mana = this.MaxMana;
                    return 0; 
            }
            Console.WriteLine("1 - Direktan napad");
            Console.WriteLine("2 - Napad s boka");
            Console.WriteLine("3 - Protunapad");
            Console.WriteLine("4 - Obnovi HP s manom");
            
            while (true)
            {
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        this.Mana -= 30;
                        return 1;
                    case "2":
                        this.Mana -= 30;
                        return 2;
                    case "3":
                        this.Mana -= 30;
                        return 3;
                    case "4":
                        if(this.Mana > 50 && this.HealthPoints+50 <= this.MaxHealthPoints)
                        {
                            this.Mana -= 50;
                            this.HealthPoints += 50;
                            Console.WriteLine($"Health sada iznosi {this.HealthPoints.ToString("0.")}/{this.MaxHealthPoints}");
                            return 0;
                        }
                        else if (this.Mana < 50)
                                    Console.WriteLine("Nemas dovoljno mane");
                        else Console.WriteLine("Ne mozes obnoviti HP jer bi HP isao vise od maksimalne vrijednosti");
                        break;
                    default:
                        Console.WriteLine("krivi unos");
                        break;

                }
            }
        }
        public override void HandleLevelUp()
        {
            if (this.Experience > 100)
                this.MaxMana += 20;
            base.HandleLevelUp();
                        
            
        }
        
        
            public override void PrintStats()
            {
            Console.WriteLine($"Tvoj heroj: Health: {this.HealthPoints.ToString("0.")}/{this.MaxHealthPoints} Damage: {this.Damage} Exp: {this.Experience} Mana: {this.Mana}/{this.MaxMana}");

            }
           
        
        public override void RoundOver()
        {
            base.RoundOver();
            this.Mana = this.MaxMana;
        }
        public override bool Death()
        {
            if (this.Revive)
            {
                this.Revive = false;
                Console.WriteLine("Revive mogucnost je iskoristena");
                this.HealthPoints = this.MaxHealthPoints;
                this.Mana=this.MaxMana;
                return false;
            }
            else
            return true;
        }
        
    }
}
