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
using System.IO;
using System.Security.Cryptography;

namespace mime_print {
    class security {
        public static string RijndaelDecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV){
            if (cipherText == null || cipherText.Length <= 0) throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)               throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)                 throw new ArgumentNullException("IV");

            string plaintext = null;
            using (Rijndael rijAlg = Rijndael.Create()){
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText)){
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)){
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt)){
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
        
    }
}
