using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectB.Logic
// This file contains the validations for creating a new account (full name, e-mail and password).
{
    public class ValidationsLogic
    {
        public bool ValidateName(string fullName)
        {
            return fullName.Contains(" ");
        }

        public bool ValidateEmail(string emailAddress)
        {
            return emailAddress.Contains("@");
        }

        public bool ValidatePassword(string password)
        {
            string passwordNum = "1234567890";
            string passwordUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string passwordCharacters = "!@#$%^&*()_+";

            bool containsNumber = false;
            bool containsUpper = false;
            bool containsCharacter = false;

            foreach (char c in password)
            {
                if (passwordNum.Contains(c))
                {
                    containsNumber = true;
                }
                if (passwordCharacters.Contains(c))
                {
                    containsCharacter = true;
                }
                if (passwordUpper.Contains(c))
                {
                    containsUpper = true;
                }
            }

            if (password.Length >= 8 && containsNumber == true && containsUpper == true && containsCharacter == true)
            {
                return true;
            }
            return false;
        }
    }
}
