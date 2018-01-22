using System;
using System.Management;

namespace mime_print.helpers
{
    public static class printer_helper {
        public static string get_printer_by_type(string document_type) {
            if (document_type == "ZPL") {
                return loop_through_printers("ZPL");
            }

            if (document_type == "EPL") {
                return loop_through_printers("EPL");
            }

            return loop_through_printers("DEFAULT");
        }

        public static string loop_through_printers(string mode) {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
            foreach (ManagementObject printer in searcher.Get()) {
                string printerName = printer["Name"].ToString().ToLower();

                string caption = (string)printer["Caption"];
                bool default_prn = (bool)printer["Default"];
                Console.WriteLine(printerName);
                if (mode == "ZPL" && caption.Contains("ZPL")) {
                    return printerName;
                }
                if (mode == "EPL" && caption.Contains("ZPL")) { // zpl printers can print epl
                    return printerName;
                }
                if (mode == "DEFAULT" && default_prn) {
                    return printerName;
                }

                /*Caption
                ExtendedPrinterStatus
                Availability
                Default
                DetectedErrorState
                ExtendedDetectedErrorState
                ExtendedPrinterStatus
                LastErrorCode
                PrinterState
                PrinterStatus
                Status
                WorkOffline
                Local*/
            }
            return "";
        }
    }
}
