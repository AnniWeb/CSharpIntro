using System;

namespace les4
{
    public class Task1
    {
        static public string GetFullName(string firstName, string lastName, string patronymic)
        {
            string fullName = "";

            if (firstName != String.Empty)
            {
                fullName += firstName;
            }
            
            if (firstName != String.Empty)
            {
                fullName += (fullName != String.Empty ? " " : "") + lastName;
            }
            
            if (firstName != String.Empty)
            {
                fullName += (fullName != String.Empty ? " " : "") + patronymic;
            }

            return fullName;
        }
    }
}