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
                        AddMemberToList(members);
                        break;

                    case 2:
                        RemoveMember(members);
                        break;

                    case 3: 
                        //Modify member
                        break;
                    case 4:
                        RenderMember(members);
                        break;

                    case 5:
                        RenderMember(members, false);
                        break;
		            default:
                        break;
	            }
            } while (true);
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

        private static void AddMemberToList(List<Member> members)
        {
            RegisterLoader rl = new RegisterLoader("register.txt");

            try
            {
                rl.AddNewMember(members);
            }
            catch
            {
                throw new ArgumentException("Something went wrong when trying to add a new member.");
            }
            SaveMembersToFile(members);
        }

        private static Member GetMember(string header, List<Member> members)
        {
            int choice;

            //Visar en meny med recepten och ger användaren en möjlighet att välja ett av dem.
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("╔════════════════════════════════╗");
                Console.WriteLine("║{0}║", header);
                Console.WriteLine("╚════════════════════════════════╝");
                Console.ResetColor();
                Console.WriteLine("0. Avsluta\n");
                Console.WriteLine("----------------------");
                for (int i = 0; i < members.Count; i++)
                {
                    Console.Write("{0}. ", i + 1);
                    Console.WriteLine(members[i].Name);
                }
                Console.WriteLine("----------------------");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 0 && choice <= members.Count)
                {
                    if (choice == 0)
                    {
                        Console.Clear();
                        return null;
                    }
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Du måste mata in ett heltal inom 0 till {0}", members.Count);
                    ContinueOnKeyPressed();
                }
            }
            return members[choice - 1];
        }

        private static void RemoveMember(List<Member> members)
        {


            //When a member is deleted, their unique ID will be reset, meaning, using a foreach loop, they all will be given a new id starting from 0, to ensure noone gets the same ID.
            SaveMembersToFile(members);
        }

        private static void RenderMember(List<Member> members)
        {
            MemberRender mr = new MemberRender();
            mr.Render(members);//ändra, fel denna ska visa en
            ContinueOnKeyPressed();
        }

        private static void RenderMember(List<Member> members, bool viewAll = false)
        {
            MemberRender mr = new MemberRender();
            Member m;
            try
            {
                m = GetMember("   Choose a member to display   ", members);
                if (m != null)
                {
                    Console.Clear();
                    mr.Render(m);
                    ContinueOnKeyPressed();
                }
            }
            catch
            {
                throw new ArgumentException("Something went wrong when attempting to display the member list.");
            }

        }

        private static void SaveMembersToFile(List<Member> members)
        {
            RegisterLoader rl = new RegisterLoader("register.txt");
            try
            {
                rl.Save(members);
            }
            catch
            {
                throw new ArgumentException("Something went wrong when attempting to save the members to the file.");
            }
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
    }
}
