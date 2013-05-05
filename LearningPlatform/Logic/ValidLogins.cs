using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningPlatform.Logic
{
    public class ValidLogins
    {
        public static List<string> valid_Logins = new List<string>();

        public static List<string> Valid_Logins
        {
            get { return valid_Logins; }
        }

        public static List<string> getValidLogins()
        {
            if(Valid_Logins.Count == 0)
            {
                Valid_Logins.Add("student_1");
                Valid_Logins.Add("student_2");
                Valid_Logins.Add("student_3");
                Valid_Logins.Add("student_4");
                Valid_Logins.Add("student_5");
                Valid_Logins.Add("student_6");
                Valid_Logins.Add("student_7");
                Valid_Logins.Add("student_8");
                Valid_Logins.Add("student_9");
                Valid_Logins.Add("student_10");
                Valid_Logins.Add("student_11");
            }

            return Valid_Logins;
        }

        public static bool ValidateLogin(string user_name, string password)
        {
            if (user_name != password)
                return false;
            if (getValidLogins().Contains(user_name))
                return true;
            return false;
        }
    }
}
