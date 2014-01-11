using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemberRegister
{
    class RegisterLoader
    {
        enum ReaderStatus
        {
            Initiate, Name, PhoneNumber, ID
        }

        private string _path;

        public string Path
        {
            get { return _path; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The string \"path\" is null or empty.");
                }
                _path = value;
            }
        }

        public RegisterLoader(string path)
        {
            Path = path;
        }
        public List<Member> Load()
        {
            int index = -1;
            string line;
            List<Member> m = new List<Member>();
            ReaderStatus readerStatus = ReaderStatus.Initiate;

            using (StreamReader sr = new StreamReader(Path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (String.IsNullOrWhiteSpace(line))
                        continue;

                    if (line == "[Name]")
                    {
                        readerStatus = ReaderStatus.Name;
                        index++;
                    }
                    else if (line == "[Number]")
                    {
                        readerStatus = ReaderStatus.PhoneNumber;
                    }
                    else if (line == "[ID]")
                    {
                        readerStatus = ReaderStatus.ID;
                    }
                    else
                    {
                        if (readerStatus == ReaderStatus.Name)
                        {
                            m.Add(new Member(line));
                        }
                        else if (readerStatus == ReaderStatus.PhoneNumber)
                        {
                            m[index].AddNumber(line);
                        }
                        else if (readerStatus == ReaderStatus.ID)
                        {
                            m[index].AddID(int.Parse(line));
                        }
                        else
                            throw new ArgumentException("Something went wrong when attempting to create/add something to the Member object.");
                    }
                }
            }

            return m;
        }

        public void Save(List<Member> members)
        {

            using (StreamWriter sw = new StreamWriter(Path))
            {
                foreach (Member member in members)
                {
                    sw.WriteLine("[Name]");
                    sw.WriteLine(member.Name);
                    sw.WriteLine("[Number]");
                    sw.WriteLine(member.PhoneNumber);
                    sw.WriteLine("[ID]");
                    sw.WriteLine(member.ID);
                }
            }
            Console.WriteLine("Members saved.");
            Thread.Sleep(1000);
            Console.Clear();
        }

        public List<Member> AddNewMember(List<Member> members)
        {
            string name;
            int number;
            string phoneNumber = "";
            bool ok = true;
            int ID = 0;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ╔═══════════════════════════════╗ ");
            Console.WriteLine(" ║       Add a new member        ║ ");
            Console.WriteLine(" ╚═══════════════════════════════╝ ");
            Console.ResetColor();

            do
            {
                Console.Write("Enter full name: ");
                name = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("The string cannot be empty or whitespace, try again? j/n");
                    if (Console.ReadKey(true).Key == ConsoleKey.J)
                    {
                        continue;
                    }
                    else
                         return members;
                }

                
                while (ok)
                {
                    Console.Write("Enter Phone number: ");
                    Console.WriteLine();
                    if ((int.TryParse(Console.ReadLine(), out number) && number > 0))
                    {
                        phoneNumber = phoneNumber + number;
                        ok = false;
                    }
                    else
                    {
                        Console.Write("You did not enter a allowed phone number, try again? j/n");
                        if (Console.ReadKey(true).Key == ConsoleKey.J)
                        {
                            continue;
                            
                        }
                        else
                            return members;
                    }
                }
                ID = members[members.Count - 1].ID + 1;
            } while (ok);

            if (ID != 0)
            {
                members.Add(new Member(name, phoneNumber, ID));
                Console.WriteLine("Member added to register.");
                Thread.Sleep(1000);
                Console.Clear();
            }

            return members;
        }
    }
}
