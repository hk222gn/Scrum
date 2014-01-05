using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemberRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> members = new List<Member>();
            members = LoadRegister();

            do
            {
                switch (GetMenuChoice())
	            {
                    case 0:
                        return;

                    case 1:
                        //Add a new member
                        break;

                    case 2:
                        //Delete member
                        break;

                    case 3: 
                        //Modify member
                        break;
                    case 4:
                        RenderMembers(members);
                        break;

                    case 5:
                        //Render specific member

                        break;
		            default:
                        break;
	            }
            } while (true);


        }

        private static int GetMenuChoice()
        {
            int choice;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" ╔══════════════════════════════╗ ");
                Console.WriteLine(" ║       Member Register        ║ ");
                Console.WriteLine(" ╚══════════════════════════════╝ ");
                Console.ResetColor();
                Console.WriteLine("\n- Options ----------------------------\n");
                Console.WriteLine("0. Exit application.");
                Console.WriteLine("1. Add a new member.");
                Console.WriteLine("2. Delete a member.");
                Console.WriteLine("3. Modify an existing member.");
                Console.WriteLine("4. Render a list with all members");
                Console.WriteLine("5. Render a specific member");
                Console.WriteLine("\n================================================\n");
                Console.Write("Enter choice [0-5]: ");

                if (!(int.TryParse(Console.ReadLine(), out choice) && choice >= 0 && choice <= 5))
                {
                    Console.WriteLine("You have to enter a number in the range of 0-5.");
                    Thread.Sleep(1000);
                }
                else
                    break;
            }

            return choice;
        }

        private static List<Member> LoadRegister()
        {
            RegisterLoader rl = new RegisterLoader("register.txt");
            List<Member> m = new List<Member>();

            try
            {
                m = rl.Load();
            }
            catch
            {
                throw new ArgumentException("Something went wrong when reading the member register file.");
            }

            return m;
        }

        private static void RenderMembers(List<Member> members, bool viewAll = false)
        {
            MemberRender mr = new MemberRender();
            mr.Render(members);
            ContinueOnKeyPressed();
        }

        private static void ContinueOnKeyPressed()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nTryck en tangent för att fortsätta\n");
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.ReadKey(true);
            Console.Clear();
            Console.CursorVisible = true;
        }
    }
}
