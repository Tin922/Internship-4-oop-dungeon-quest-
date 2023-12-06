namespace Domain.Repositories.Monster
{
    
    public class Brute : Monster, IStats
    {
        private Random random = new Random();
       
        public Brute()
        {           
            SetStatsForMonster();
        }
       


        public void SetStatsForMonster()        {
            
            int health = random.Next(130, 170);
            int damage = random.Next(100, 120);
            this.HealthPoints = health;
            this.Damage = damage;
            this.ExpForKilling = 40;
            this.Name = "Brute";
        }
        


    }
}
