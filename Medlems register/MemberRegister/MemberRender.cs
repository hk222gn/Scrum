using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegister
{
    class MemberRender
    {
        public void Render(List<Member> members)
        {
            HeaderRender("===========================");
            foreach (Member member in members)
            {
                Console.WriteLine(String.Format("ID: {0} \nName: {1} \n", member.ID, member.Name));
            }
            HeaderRender("===========================");
        }

        public void Render(Member member)
        {
            Console.WriteLine(String.Format("ID: {0} \nName: {1} \nPhone number: {2}\n", member.ID, member.Name, member.PhoneNumber));
        }

        private static void HeaderRender(string header)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("==={0}============\n", header);
            Console.ResetColor();
        }
    }
}
