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

namespace mime_print {
        public class document {
            public string min_supported_version = "1.0.0.0";
            public string type ="ZPL";
            public string name ="Document";
            public string text =@"^XA
                    ^LRN^MNY^MFN,N^LH10,12^MCY^POI^PW812^CI27
                    ^FO620,1140
                    ^GFA,00969,00969,019,FFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000000
                    FFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000000
                    FFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000000
                    FFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000000
                    F0000000000001F8000000000000F000000000
                    F0000000000001F8000000000000F000000000
                    F0000000003F81F83FC000000000F000000000
                    F0000000003F81F83FC000000000F000000000
                    F000000000FFF9F9FFF000000000F000000000
                    F000000000FFF9F9FFF000000000F000000000
                    F000000000FFFFFFFFFC00000000F000000000
                    F000000000FFFFFFFFFC00000000F000000000
                    F000000000F07FFFF0FC00000000F000000000
                    F000000000F07FFFF0FC00000000F000000000
                    F000000000FC1FFFC3F000000000F000000000
                    F000000000FC1FFFC3F000000000F000000000
                    F000000000FFFFFFFFF000000000F000000000
                    F000000000FFFFFFFFF000000000F000000000
                    F0000000003FFFFFFFC000000000F000000000
                    F0000000003FFFFFFFC000000000F000000000
                    FFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000000
                    FFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000000
                    FFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000000
                    F00000000001FFFFF00000000000F000000000
                    F00000000001FFFFF00000000000F000000000
                    F00000000003FFF9FC0000000000F000000000
                    F00000000003FFF9FC0000000000F000000000
                    F0000000003FE1F87FC000000000F000000000
                    F0000000003FE1F87FC000000000F000000000
                    F000000000FF81F83FF000000000F000000000
                    F000000000FF81F83FF000000000F000000000
                    F000000000FE01F803F000000000F000000000
                    F000000000FE01F803F000000000F000000000
                    F000000000F001F800F000000000F000000000
                    F000000000F001F800F000000000F000000000
                    F0000000000001F8000000000000F000000000
                    F0000000000001F8000000000000F0FFDC1C00
                    FFFFFFFFFFFFFFFFFFFFFFFFFFFFF0FFDC1C00
                    FFFFFFFFFFFFFFFFFFFFFFFFFFFFF00C1E3C00
                    FFFFFFFFFFFFFFFFFFFFFFFFFFFFF00C1E3C00
                    FFFFFFFFFFFFFFFFFFFFFFFFFFFFF00C1A2C00
                    FFFFFFFFFFFFFFFFFFFFFFFFFFFFF00C1B6C00
                    FFFFFFFFFFFFFFFFFFFFFFFFFFFFF00C1B6C00
                    0000000000000000000000000000000C1B6C00
                    0000000000000000000000000000000C19CC00
                    0000000000000000000000000000000C19CC00
                    0000000000000000000000000000000C19CC00
                    0000000000000000000000000000000C188C00
                    00000000000000000000000000000000000000
                    00000000000000000000000000000000000000
                    00000000000000000000000000000000000000
                    ^DN
                    ^FT20,630^CVY^BD2^FH_
                    ^FD003840981040000[)>_1E01_1D961Z95910936_1DUPSN_1DRF2488_1E073_0D4*FB%E7Q""DAY'7(S*E:_1D*EC)#(162G_0D2R#_1DB$15KP_0D_1E_04^FS
                    ^FT15,23^A0N,20,24
                    ^FVSHIPPING^FS
                    ^FT15,42^A0N,20,24
                    ^FV2024676868^FS
                    ^FT15,61^A0N,20,24
                    ^FVLIQUIDITY SERVICES^FS
                    ^FT15,81^A0N,20,24
                    ^FV3000 INTERNET BLVD^FS
                    ^FT15,100^A0N,20,24
                    ^FVFRISCO  TX 75034^FS
                    ^FT60,181^A0N,26,30
                    ^FVMANAGER^FS
                    ^FT60,208^A0N,26,30
                    ^FV2065574164^FS
                    ^FT60,236^A0N,26,30
                    ^FVCOMPANY X^FS
                    ^FT60,263^A0N,26,30
                    ^FVSUITE 200^FS
                    ^FT60,290^A0N,26,30
                    ^FV616 1ST AVE^FS
                    ^FT60,334^A0N,45,44
                    ^FVSEATTLE  WA 98104^FS
                    ^FT380,30^A0N,30,34
                    ^FV5 LBS ^FS
                    ^FT673,34^A0N,28,32
                    ^FV 1 OF 1^FS
                    ^FT620,736^A0N,100,76
                    ^FV   ^FS
                    ^FO677,640^GB123,123,122^FS
                    ^FT300,618^BY3^BCN,103,N,N,,A
                    ^FV42098104^FS
                    ^FT290,493^A0N,80,70
                    ^FVWA 981 9-05^FS
                    ^FT10,704^A0N,56,58
                    ^FVUPS GROUND^FS
                    ^FT10,737^A0N,26,30
                    ^FVTRACKING #: 1Z RF2 488 03 9591 0936^FS
                    ^FO0,762^GB800,4,4^FS
                    ^FT790,1039^A0N,22,26
                    ^FV ^FS
                    ^FT10,1035^A0N,22,26
                    ^FVBILLING: ^FS
                    ^FT126,1035^A0N,22,26
                    ^FVP/P ^FS
                    ^FT10,1151^A0N,22,26
                    ^FVReference No.1: M11111^FS
                    ^FT10,1173^A0N,22,26
                    ^FVReference No.2: PO11111^FS
                    ^FT15,153^A0N,28,32
                    ^FVSHIP TO: ^FS
                    ^FO0,637^GB798,14,14^FS
                    ^FO0,997^GB800,14,14^FS
                    ^FO0,416^GB800,4,4^FS
                    ^FO240,416^GB3,221,3^FS
                    ^FT190,1188^A0N,14,20
                    ^FVXOL 15.05.02          NV45 63.0A 04/2015^FS
                    ^FT105,982^BY3^BCN,202,N,N,,A
                    ^FV1ZRF24880395910936^FS
                    ^FT273,896^A0N,95,74
                    ^FVSAMPLE^FS
                    ^XZ
                    ^XZ";
            public string printer_address="office zpl";
    }
}
