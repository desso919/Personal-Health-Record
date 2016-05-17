using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Personal.Health.Care.DesktopApp.Utills
{
    public static class SecurityUtil
    {
        private const int MAX_LENTH = 100;

        public static string ConvertToString(this SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public static string HashPassword(SecureString password)
        {
            var data = System.Text.Encoding.ASCII.GetBytes(DecryptPassword(password));
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }

        private static string DecryptPassword(SecureString encryptedPassword)
        {
            try
            {
                var passwordBSTR = Marshal.SecureStringToBSTR(encryptedPassword);
                return Marshal.PtrToStringBSTR(passwordBSTR);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static bool isEGN(string egn)
        {
            if (egn != null)
            {
                string regExPattern = @"^[0-9]+$";
                Regex pattern = new Regex(regExPattern);
                return pattern.IsMatch(egn);
            }
            return false;
        }

        public static bool isValidString(string value)
        {
            if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value) && value.Length < MAX_LENTH)
            {
                return true;
            }
            return false;
        }

        public static string getProperMessage(string value, string field)
        {
            if (value == null || value.Length > MAX_LENTH)
            {
                return "Please insert a valid value for " + field;
            }
            return String.Empty;
        }

        public static string getErrorMessage(string field)
        {
            if (field != null)
            {
                return "Please insert a valid value for " + field;
            }
            return String.Empty;
        }

        public static bool isValidDate(string date)
        {
            if (date != null && !date.Equals(String.Empty))
            {
                try
                {
                    DateTime _birthday = Convert.ToDateTime(date);
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }  
            }
            return false;
        }
    }
}
