using System;
using System.Text;

namespace mime_print.helpers
{
    public static class encode_decode_helper
    {
        public static string base64_decode_to_string(string data)
        {
            try
            {
                byte[] data_bytes = Convert.FromBase64String(data);
                return Encoding.UTF8.GetString(data_bytes);
            }
            catch (Exception ex)
            {
                logger.evenlog_error(ex.ToString());
                return data;
            }
        }

        public static byte[] base64_decode_to_array(string data)
        {
            try
            {
                byte[] data_bytes = Convert.FromBase64String(data);
                return data_bytes;
            }
            catch (Exception ex)
            {
                logger.evenlog_error(ex.ToString());
                return null;
            }
        }
    }
}
