using Domain.Repositories.Hero;
using Domain.Repositories.Monster;
using static Presentation.internship_4_oop_dungeon_quest.Functions;

PlayGame();
static void PlayGame() 
{

    Console.WriteLine("Unesite ime heroja");
    string heroName = AskUserForString();
    string heroClass = AskForHeroClass();


    Hero hero = null;

    if (heroClass.ToLower() == "gladiator")
        hero = new Gladiator(heroName);
    else if (heroClass.ToLower() == "enchater")
        hero = new Enchater(heroName);
    else if (heroClass.ToLower() == "marksman")
        hero = new Marksman(heroName);

    Console.WriteLine($"Zelite li sami unijeti HP? Trenuto vas heroj ima {hero.HealthPoints} HP-a");
    if (AskUserForChange())
    {
        Console.WriteLine("Koliki HP zelite?");
        int hp = GetInt();
        hero.HealthPoints = hp;
        hero.MaxHealthPoints = hp;
    }

    Console.WriteLine($"Zelite li sami unijeti Damage? Trenuto vas heroj ima {hero.Damage} damagea");
    if (AskUserForChange())
    {
        Console.WriteLine("Koliki damagea zelite?");
        hero.Damage = GetInt();
    }

    var monsters = Monster.GenerateMonsters(10);
    int roundNumber = 1;
    int fightStatus;
    bool isStunned = false;
    while (monsters.Count > 0) {

        var currentMonster = monsters.First();
        Console.WriteLine($"\nRunda {roundNumber}. pocinje\n");
        while (true)
        {
            hero.PrintStats();
            currentMonster.MonsterPrintStats();

            if (isStunned)
            {
                fightStatus = 1;
                isStunned = false;
                Console.WriteLine("Cudoviste je stunano. Pobjedio si sljedeci potez!");

            }
            else
                fightStatus = PlayRound(hero.HeroAttack(), currentMonster.Attack());


            if (fightStatus == 0)
            {
                Console.WriteLine("Nerijesno!\n");
                continue;
            }
            else if (fightStatus == 1)
            {
                Console.WriteLine("Zadao si cudovistu udarac\n");
                if (hero is Marksman)
                {
                    Marksman marksman = hero as Marksman;
                    marksman.AttackDamage(currentMonster, ref isStunned);
                }
                else
                    hero.AttackDamage(currentMonster);
            }
            else
            {
                Console.WriteLine("Cudoviste ti je zadalo udarac\n");

                if (currentMonster is Brute)
                {
                    Brute bruteMonster = currentMonster as Brute;
                    bruteMonster.AttackDamage(hero);
                }
                else if (currentMonster is Witch)
                {
                    Witch witchMonster = currentMonster as Witch;
                    witchMonster.AttackDamage(hero, monsters);

                }
                else
                {
                    currentMonster.AttackDamage(hero);
                }
            }

            if (currentMonster.HealthPoints <= 0)
            {
                if (currentMonster is Witch)
                {
                    Witch witchMonster = currentMonster as Witch;
                    var newMonstersAfterWitchDeath = witchMonster.WitchDeath();
                    Console.WriteLine("Ubio si vjesticu! Vjestica je stvorila dva nova cudovista:");
                    foreach (var newMonster in newMonstersAfterWitchDeath) Console.WriteLine($"{newMonster.Name}");
                    monsters.AddRange(newMonstersAfterWitchDeath);

                }
                hero.Experience += currentMonster.ExpForKilling;
                monsters.Remove(currentMonster);
                Console.WriteLine("Ubio si cudoviste!");
                isStunned = false;
                break;
            }
            else if (hero.HealthPoints <= 0)
            {
                if (hero.Death() == true)
                {
                    Console.WriteLine($"\n\n{hero.Name} je izgubio");
                    Console.WriteLine("Zelite li pokusati ponovno?");
                    if (AskUserForChange())
                    {
                        PlayGame();
                        Console.Clear();
                    }
                    else return;
                }
                else continue;
            }
        }
        hero.HandleLevelUp();
        hero.RoundOver();
        roundNumber++;

        
    }
    Console.WriteLine($"\n\n{hero.Name} je pobjedio");
}
static int PlayRound(int playerChoice, int monsterChoice)
{
    //0 draw, 1 player won, 2 monster won
    if (playerChoice == monsterChoice) return 0;
    else if (playerChoice == 4) return 1; //stun
    else if (playerChoice == 1 && monsterChoice == 2 || playerChoice == 2 && monsterChoice == 3 || playerChoice == 3 && monsterChoice == 1)
        return 1;
    else
        return 2;
}
static string AskForHeroClass()
{
    while (true)
    {
        Console.WriteLine("Odabreite jednu od klasa: Gladiator, Enchater ili Marksman");

        string userInput = Console.ReadLine().Trim();

        if (!string.IsNullOrEmpty(userInput))
        {
            string lowerInput = userInput.ToLower();

            if (lowerInput == "marksman" || lowerInput == "gladiator" || lowerInput == "enchater")
            {
                return lowerInput; 
            }
            else
            {
                Console.WriteLine("Ta klasa ne postoji. Odaberite između Marksman, Gladiator, ili Enchater.");
            }
        }
        else
        {
            Console.WriteLine("Upisite klasu heroja.");
        }
    }
}
static string AskUserForString()
{
    while (true)
    {
        string input = Console.ReadLine().Trim();

        if (!string.IsNullOrEmpty(input))
        {
            return input;
        }
        else
        {
            Console.WriteLine("Upisite neko ime");
        }
    }
}