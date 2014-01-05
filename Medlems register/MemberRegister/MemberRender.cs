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
            foreach (Member member in members)
            {
                Console.Write(member.ID + " ");
                Console.WriteLine(member.Name + "\n");
            }
        }

        private static void HeaderRender(string header)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("!    {0}    !\n", header);
            Console.ResetColor();
        }
    }
}
