using System.Configuration;

namespace mime_print.helpers
{
    public static class config_helper {
        public static string get_printer_by_type(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return null;

            if (type == "ZPL" || type == "EPL") { // zpl printers understand epl
                var zplPrinter = ConfigurationManager.AppSettings["ZPLPrinter"];
                return string.IsNullOrWhiteSpace(zplPrinter) ? null : zplPrinter;
            }

            var defaultPrinter = ConfigurationManager.AppSettings["DefaultPrinter"];
            return string.IsNullOrWhiteSpace(defaultPrinter) ? null : defaultPrinter;
        }
    }
}
