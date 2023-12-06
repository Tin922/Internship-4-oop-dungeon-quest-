
namespace Domain.Repositories.Hero
{
    using Domain.Repositories.Heros;
    using Domain.Repositories.Monster;
    public class Hero : IPrintStats
    {

        public string Name { get; set; }
        public double HealthPoints { get; set; }
        public double MaxHealthPoints { get; set; }
        public double Damage { get; set; }
        public double Experience { get; set; }

        public virtual int HeroAttack()
        {
            return 0;
        }
        public virtual void HandleLevelUp()
        {
            if(this.Experience > 100)
            {
                this.MaxHealthPoints += 10;
                this.Damage += 10;
                this.Experience -= 100;
            }

        }
        public virtual void PrintStats()
        {
            Console.WriteLine($"Tvoj heroj: Health: {this.HealthPoints.ToString("0.")}/{this.MaxHealthPoints} Damage: {this.Damage} Exp: {this.Experience}");

        }
        public virtual void RoundOver()
        {
            this.HealthPoints = this.HealthPoints  + this.HealthPoints * 0.25;
            if(this.HealthPoints > this.MaxHealthPoints) 
                this.HealthPoints = MaxHealthPoints;
            Console.WriteLine($"Imate {this.Experience} xp-a. Ako potrosite pola možete obnoviti cijeli health");
            if (AskUserForChange()) 
            {
                this.Experience /= 2;
                this.HealthPoints = this.MaxHealthPoints;
            }
        }
        public static bool AskUserForChange()
        {

            while (true)
            {
                Console.WriteLine("y/n");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "y")
                {
                    return true;
                }
                else if (userInput.ToLower() == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Krivi unos. Upisite y za da ili n za ne");
                }
            }
        }
        public virtual bool Death()
        {
            return true;
        }
        public virtual void AttackDamage(Monster currentMonster)
        {
            currentMonster.HealthPoints = currentMonster.HealthPoints - this.Damage;
        }
        public virtual void AttackDamage(Monster monster, ref bool isStunned)
        {

        }

    }
   
   
}
