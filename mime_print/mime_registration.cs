/************************************************************************************
    ███╗   ███╗██╗███╗   ███╗███████╗        ██████╗ ██████╗ ██╗███╗   ██╗████████╗
    ████╗ ████║██║████╗ ████║██╔════╝        ██╔══██╗██╔══██╗██║████╗  ██║╚══██╔══╝
    ██╔████╔██║██║██╔████╔██║█████╗          ██████╔╝██████╔╝██║██╔██╗ ██║   ██║   
    ██║╚██╔╝██║██║██║╚██╔╝██║██╔══╝          ██╔═══╝ ██╔══██╗██║██║╚██╗██║   ██║   
    ██║ ╚═╝ ██║██║██║ ╚═╝ ██║███████╗███████╗██║     ██║  ██║██║██║ ╚████║   ██║   
    ╚═╝     ╚═╝╚═╝╚═╝     ╚═╝╚══════╝╚══════╝╚═╝     ╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝   ╚═╝   
    created by: Charles Watkins
    date: 2017-06-16
************************************************************************************/
using Microsoft.Win32;
using System;

namespace mime_print {
    static class mime_registration {
        public static bool register() {
            try {
                const string mime_type= "mime_print";
                const string application_path= @"C:\Program Files (x86)\mime-print\";
                const string application_exe= "mime-print.exe";
                RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(mime_type);
                if(registryKey == null){
                    RegistryKey subKey = Registry.ClassesRoot.CreateSubKey(mime_type);
                    subKey.SetValue(string.Empty  , (object) String.Format("URL: {0} Protocol",mime_type) );
                    subKey.SetValue("URL Protocol", (object) string.Empty);
                    registryKey = subKey.CreateSubKey("shell\\open\\command");
                    registryKey.SetValue(string.Empty, (object) String.Format("{0}{1} %1 %2 %3",application_path,application_exe));
                }
                registryKey.Close();
            } catch(Exception ex){
                logger.evenlog_error(ex.ToString());
                return false;
            }
            return true;
        }//end register mimetype

    }
}
