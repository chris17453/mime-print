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
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace mime_print {
    class download {
         public class WebClientEx : WebClient{
          private CookieContainer _cookieContainer = new CookieContainer();
          protected override WebRequest GetWebRequest(Uri address){
            this.Proxy = (IWebProxy) null;
            WebRequest webRequest = base.GetWebRequest(address);
            if (webRequest is HttpWebRequest)
              (webRequest as HttpWebRequest).CookieContainer = this._cookieContainer;
            return webRequest;
          }
        }

        public static List<document> label_package(string url) {
            WebClientEx wc=new WebClientEx();
            byte[] label_bytes=wc.DownloadData(url);
            byte[] IV = Encoding.ASCII.GetBytes("417E34469A8F457F");
            byte[] Key= Encoding.ASCII.GetBytes("AB5B67D53EB4ACB5B3C03D5836B31A69");
            string label_string=security.RijndaelDecryptStringFromBytes(label_bytes,Key,IV);
            JavaScriptSerializer jss=new JavaScriptSerializer();
            List<document> documents=jss.Deserialize<List<document>>(label_string);
            return documents;
        }
    }
}
