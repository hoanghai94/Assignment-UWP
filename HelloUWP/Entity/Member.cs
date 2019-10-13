using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelloUWP.Entity
{
    class Member
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string avatar { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string introduction { get; set; }
        public int gender { get; set; }
        public string birthday { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public Dictionary<string, string> Validate()
        {
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(firstName))
            {
                errors.Add("firstName", "FirstName is required!");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                errors.Add("lastName", "LastName is required!");
            }
            if (string.IsNullOrEmpty(avatar))
            {
                errors.Add("avatar", "Avatar is required!");
            }
            if (string.IsNullOrEmpty(phone))
            {
                errors.Add("phone", "Phone is required!");
            }
            if (string.IsNullOrEmpty(birthday))
            {
                errors.Add("birthday", "Birthday is required!");
            }
            if (string.IsNullOrEmpty(address))
            {
                errors.Add("address", "Address is required!");
            }
            if (string.IsNullOrEmpty(email))
            {
                errors.Add("email", "Email is required!");
            }
            else
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (!match.Success)
                {
                    errors.Add("email", "Email is invalid!");
                }
            }
            if (string.IsNullOrEmpty(password))
            {
                errors.Add("password", "Password is required!");
            }
            if (string.IsNullOrEmpty(introduction))
            {
                errors.Add("introduction", "Introduction is required!");
            }
            return errors;
        }
    }
}
