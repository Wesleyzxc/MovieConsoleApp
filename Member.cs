using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManager
{
    public class Member
    {
        private string firstName;
        private string lastName;
        private string address;
        private int contactNumber;
        private int password;
        private Movie[] holding = new Movie[10];
        public string UserName { get => lastName + firstName; }
        public Member(string first, string last, string addy, int num, int pass)
        {
            firstName = first;
            lastName = last;
            address = addy;
            contactNumber = num;
            password = pass;
        }
        public string GetFirstName()
        {
            return firstName;
        }
        public string GetLastName()
        {
            return lastName;
        }
        public int GetNumber()
        {
            return contactNumber;
        }
    }
}
