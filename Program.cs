﻿using System;
using System.Collections.Generic;

namespace MovieManager
{
    public class Movie
    {
        private static int id;
        private static int numCompies;
        private static int timesBorrowed;
        private static int numCopies;
        private static string director;
        private static string duration;
        public int GetID() { return id; }
        public static void BorrowItem()
        {
            numCompies -= 1;
            timesBorrowed += 1;
        }
    }

    public class MovieCollection
    {
        public class TreeNode
        {
            public Movie Movie;
            public TreeNode Left;
            public TreeNode Right;
            public void DisplayMovie()
            {
                Console.Write(Movie + " ");
            }
        }
        public TreeNode root;
        public MovieCollection()
        {
            root = null;
        }
        public void AddMovie(Movie i)
        {
            TreeNode newNode = new TreeNode();
            newNode.Movie = i;
            if (root == null)
                root = newNode;
            else
            {
                TreeNode current = root;
                TreeNode parent;
                while (true)
                {
                    parent = current;
                    if (i.GetID() < current.Movie.GetID())
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }

                        else
                        {
                            current = current.Right;
                            if (current == null)
                            {
                                parent.Right = newNode;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void RemoveMovie(Movie i)
        {
            int key = i.GetID();
        }
        public void DisplayInfoMovie()
        {

        }
        public void DisplayTop10Borrowed()
        {

        }
    }

    public class Member
    {
        private string firstName;
        private string lastName;
        private int password;
        private int contactNumber;
        private Movie[] holding = new Movie[10];
        public string UserName { get => lastName+firstName; }
        public Member(string first, string last, int pass)
        {
            firstName = first;
            lastName = last;
            password = pass;
        }
    }

    public class Staff
    {
        private string username;
        private string password;
        public Staff(string user, string pass)
        {
            username = user;
            password = pass;
        }
        public bool checkUser(string user)
        {
            return user == username;
        } 
        public bool checkPass(string pass)
        {
            return pass == password;
        }
    }

    public class MemberCollection
    {
        private static Member[] memberArr = new Member[10];
        public static void RegisterMember()
        {

        }

        public static int GetPhoneNumber(Member member)
        {
            return 0;
        }

        public static void BorrowMovie()
        {

        }

        public static void ReturnMovie()
        {

        }

        public static void ListOfMovies(Member member) 
        {

        }
    }


    class Program
    {
        private static int MainMenu()
        {
            Console.WriteLine("Welcome to the Community Library");
            Console.WriteLine("===========Main Menu============");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("================================\n");
            Console.Write("Please make a selection (1-2, or 0 to exit): ");
            return 0;
        }

        private static void StaffMenu()
        {
            Console.WriteLine("===========Staff Menu============");
            Console.WriteLine("1. Add a new movie DVD");
            Console.WriteLine("2. Remove a movie DVD");
            Console.WriteLine("3. Register a new Member");
            Console.WriteLine("4. Find a registered member's phone number");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("================================\n");
            Console.Write("Please make a selection (1-4, or 0 to return to main menu): ");
        }

        private static void MemberMenu()
        {
            Console.WriteLine("===========Member Menu============");
            Console.WriteLine("1. Display all movies");
            Console.WriteLine("2. Borrow a movie DVD");
            Console.WriteLine("3. Return a movie DVD");
            Console.WriteLine("4. List current borrowed movie DVDs");
            Console.WriteLine("5. Display top 10 most popular movies");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("================================\n");
            Console.Write("Please make a selection (1-5, or 0 to return to main menu): ");
        }

        private static bool StaffLogIn(Staff staff)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            bool correctUser = staff.checkUser(username);
            while (!correctUser)
            {
                Console.Write("Wrong username! Enter username: ");
                username = Console.ReadLine();
                correctUser = staff.checkUser(username);
            }

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            bool correctPass = staff.checkPass(password);
            while (!correctPass)
            {
                Console.Write("Wrong password! Enter password: ");
                password = Console.ReadLine();
                correctPass = staff.checkPass(password);
            }

            return correctUser && correctPass;
        }
        static void Main(string[] args)
        {
            Staff staff = new Staff("staff", "today123");
            int userOption;
            // print main menu
            MainMenu();

            List<int> validUserOptions = new List<int> { 0, 1, 2};
            while (!Int32.TryParse(Console.ReadLine(), out userOption) || !validUserOptions.Contains(userOption))
            {
                Console.WriteLine("Not a valid option!");
                Console.Write("Please make a selection (1-2, or 0 to exit): ");
            }

            // if staff login
            if (userOption == 1)
            {
                // login method
                bool staffLoggedIn = StaffLogIn(staff);

                if (staffLoggedIn)
                {
                    StaffMenu();
                    int staffOption;
                    List<int> validStaffOptions = new List<int>{0, 1, 2, 3, 4};
                    while (!Int32.TryParse(Console.ReadLine(), out staffOption) || !validStaffOptions.Contains(staffOption))
                    {
                        Console.WriteLine("Not a valid option!");
                        Console.Write("Please make a selection (1-4, or 0 to exit): ");
                    }
                    switch (staffOption) 
                    {
                        case 0: //return to main menu
                            Console.WriteLine("You selected 0");
                            break;
                        case 1: // add a new movie dvd
                            Console.WriteLine("You selected 1");
                            break;
                        case 2: // remove movie dvd
                            Console.WriteLine("You selected 2");
                            break;
                        case 3: // register movie dvd
                            Console.WriteLine("You selected 3");
                            break;
                        case 4: // find a registered member's phone number
                            Console.WriteLine("You selected 4");
                            break;
                    }
                }

            }

            // member login
            else if (userOption == 2)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();
            }


            // user press 0 to exit
            else
            {
                Console.WriteLine("Goodbye!");
            }
        }
    }
}