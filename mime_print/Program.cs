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
using System;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using mime_print.helpers;

namespace mime_print {
    class Program
    {

        private const string message_box_caption = "Print Control";

        private static string build_html_gif_document(string text) {
            if (string.IsNullOrWhiteSpace(text)) return null;

            var ret_val = string.Format("<html style=\"width: 100%;margin: 0px;\"><head></head><body style=\"width: 100%;margin: 0px;\"><img style=\"width: 100%;\" src=\"data:image/gif;base64,{0}\"/></body></html>", text);
            return ret_val;
        }

        static void Main(string[] args) {
            try {
                List<WebBrowser> browsers=new List<WebBrowser>();
                mime_registration.register();                              //Make sure the mime type is registered.
                if(args.Length<1) {
                    MessageBox.Show("Missing label url.", message_box_caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string url=args[0].Substring(args[0].IndexOf(':')+1);
                List<document> label_package=download.label_package(url);          
                if(null==label_package||label_package.Count==0) {
                    MessageBox.Show("No label to print.", message_box_caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var version = Assembly.GetExecutingAssembly().GetName().Version;
                var min_version = label_package[0].min_supported_version;
                if (!string.IsNullOrWhiteSpace(label_package[0].min_supported_version) && !version_helper.valid_version(version, min_version))
                {
                    MessageBox.Show(string.Format("Current version is {0}, minimum required version is {1}!\nPlease install version {1}!", version, min_version), message_box_caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (document d in label_package) {
                    if (String.IsNullOrWhiteSpace(d.printer_address)) {                     // try to get the printer address (name) from the document received from the web api
                        d.printer_address = config_helper.get_printer_by_type(d.type);      // try to get the printer address (name) from the app.config file (app.config is in the process memory so it should be fast)
                        if (String.IsNullOrWhiteSpace(d.printer_address)) {
                            d.printer_address = printer_helper.get_printer_by_type(d.type); // try to find the printer address (name) from the available printers
                        }
                    }
                    switch(d.type) { 
                        case "ZPL"  : direct_print  .print(d.printer_address, encode_decode_helper.base64_decode_to_string(d.text), d.name);  break;    //for raw printing zpl to printer
                        case "EPL"  : direct_print  .print(d.printer_address, encode_decode_helper.base64_decode_to_string(d.text), d.name); break;     //zpl printer understands epl
                        case "GIF"  : web_print     .print(build_html_gif_document(d.text)); break;                                                     //gif zpl?--Add if for gif2zpl
                        case "PDF"  : pdf_print     .print(d.printer_address, encode_decode_helper.base64_decode_to_array(d.text), d.name);  break;     //for raw printing pdf to printer
                        case "HTML" : web_print     .print(encode_decode_helper.base64_decode_to_string(d.text)); break;                                //use webbrowser control for html...
                        default     : web_print     .print(encode_decode_helper.base64_decode_to_string(d.text)); break;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, message_box_caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}