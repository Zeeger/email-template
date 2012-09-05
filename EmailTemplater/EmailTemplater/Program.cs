using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EmailTemplater
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                OutlookInterop.SendOne();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
