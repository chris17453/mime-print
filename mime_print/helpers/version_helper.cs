using System;

namespace mime_print.helpers
{
    public static class version_helper
    {
        public static bool valid_version(Version curernt_version, string min_supported_version)
        {
            Version ver;
            if (!Version.TryParse(min_supported_version, out ver))
                return false;

            var compare_result = curernt_version.CompareTo(ver);
            return compare_result >= 0;
        }
    }
}
