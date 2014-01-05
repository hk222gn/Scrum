using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
                    throw new ArgumentException("The path string is null or empty.");
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
    }
}
