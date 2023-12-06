    

namespace Presentation.internship_4_oop_dungeon_quest
{
    public class Functions
    {
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
        public static int GetInt()
        {
            int userInput;

            do
            {


                if (!int.TryParse(Console.ReadLine(), out userInput) || userInput <= 0)
                {
                    Console.WriteLine("Neispravan unos");
                }

            } while (userInput <= 0);

            return userInput;
        }
    }
}
