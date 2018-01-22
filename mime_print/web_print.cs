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
using System.Threading;
using System.Windows.Forms;

namespace mime_print {
    class web_print {
        
        static void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e){
            ((WebBrowser)sender).Print();
            ((WebBrowser)sender).Dispose();
        }

        public static void print(string text) {
            var th = new Thread(() => {
                WebBrowser webBrowser = new WebBrowser();
                webBrowser.DocumentText = text;
                webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
                webBrowser.Visible = false;
                webBrowser.ScrollBarsEnabled = false;
                webBrowser.ScriptErrorsSuppressed = true;
                Application.Run();
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
}
