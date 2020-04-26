using System;
using System.Collections.Generic;

namespace MovieManager
{
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
            Int32.TryParse(Console.ReadLine(), out int userOption);
            return userOption;
        }

        private static void StaffMenu()
        {
            Console.WriteLine("\n===========Staff Menu============");
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

        private static void StaffOption1(MovieCollection movieList)
        {
            Console.Write("Enter the movie title: ");
            string title = Console.ReadLine();

            int titleExists = -1;
            for(int i = 0; i < movieList.GetNumMovies(); i++)
            {
                // already exists
                if (title == movieList.GetMovie(i).GetTitle())
                {
                    titleExists = i;
                    break;
                }
            }
            if (titleExists >= 0)
            {
                Console.Write("Enter the number of copies you would like to add: ");
                Int32.TryParse(Console.ReadLine(), out int addCopies);
                movieList.GetMovie(titleExists).AddCopies(addCopies);
                Console.WriteLine("Added {0} new copies of {1}\n", addCopies, movieList.GetMovie(titleExists).GetTitle());
            }
            else
            {
                Console.Write("Enter the starring actor(s): ");
                string starring = Console.ReadLine();
                Console.Write("Enter the director(s): ");
                string director = Console.ReadLine();

                Dictionary<int, string> genres = new Dictionary<int, string>
            {
                {1, "Drama" }, {2, "Adventure"}, {3, "Family" }, {4, "Action" },
                {5, "Sci-Fi"}, {6, "Comedy"}, {7, "Thriller"}, {8, "Other"},
            };
                Console.WriteLine("Select the genre:");
                foreach (var pair in genres)
                {
                    Console.WriteLine("{0}. {1}", pair.Key, pair.Value);
                }
                Console.Write("Make selection (1-8): ");
                Int32.TryParse(Console.ReadLine(), out int selectedGenre);

                Dictionary<int, string> classifications = new Dictionary<int, string> { { 1, "General (G)" }, { 2, "Parental Guidance (PG)" }, { 3, "Mature (M15+)" }, { 4, "Mature Accompanied (MA15+)" } };
                Console.WriteLine("Select the classification:");
                foreach (var pair in classifications)
                {
                    Console.WriteLine("{0}. {1}", pair.Key, pair.Value);
                }
                Console.Write("Make selection (1-4): ");
                Int32.TryParse(Console.ReadLine(), out int selectedClassification);

                Console.Write("Enter the duration (minutes): ");
                Int32.TryParse(Console.ReadLine(), out int duration);

                Console.Write("Enter the release date (year): ");
                Int32.TryParse(Console.ReadLine(), out int year);

                Console.Write("Enter the number of copies available: ");
                Int32.TryParse(Console.ReadLine(), out int copies);


                Movie newMovie = new Movie
                    (title, director, starring, genres[selectedGenre], classifications[selectedClassification], duration, year, copies);
                movieList.AddMovie(newMovie);
            }
        }

        private static int StaffOption2(MovieCollection movieList)
        {
            Console.Write("Enter movie title: ");
            string removeTitle = Console.ReadLine();
            for (int i = 0; i < movieList.GetNumMovies(); i++)
            {
                if (movieList.GetMovie(i).GetTitle() == removeTitle)
                {
                    movieList.RemoveMovie(i);
                    return 0;
                }
            }
            Console.WriteLine("No movies to remove!");
            return 0;
        }

        private static void StaffOption3(MemberCollection members)
        {
            Console.Write("Enter member's first name: ");
            string first = Console.ReadLine();
            Console.Write("Enter member's last name: ");
            string last = Console.ReadLine();

            // check if user exists
            int memberExists = -1;
            for (int i = 0; i < members.GetNumMembers(); i++)
            {
                Member memberToCheck = members.GetMember(i);
                // already exists
                if (first == memberToCheck.GetFirstName() && last == memberToCheck.GetLastName())
                {
                    memberExists = i;
                    break;
                }
            }
            if (memberExists >= 0) // exist
                Console.WriteLine("{0} {1} has already registered.", first, last);
            else // does not exist
            {
                Console.Write("Enter member's address: ");
                string address = Console.ReadLine();
                Console.Write("Enter member's phone number: ");
                Int32.TryParse(Console.ReadLine(), out int phone);
                Console.Write("Enter member's password (4 digits): ");

                string password = Console.ReadLine();
                int pass;
                while (!Int32.TryParse(password, out pass) || (pass > 9999 && pass < 0) || password.Length != 4)
                {
                    Console.Write("Needs to be 4 digit : ");
                    password = Console.ReadLine();
                }
                members.RegisterMember(new Member(first, last, address, phone, pass));
            }
        }

        private static void StaffOption4(MemberCollection memberList)
        {
            Console.Write("Enter member's first name: ");
            string first = Console.ReadLine();
            Console.Write("Enter member's last name: ");
            string last = Console.ReadLine();
            if (memberList.GetPhoneNumber(first, last) != 0)
                Console.WriteLine("{0} {1}'s phone number is: {2}", first, last, memberList.GetPhoneNumber(first, last));
            else
                Console.WriteLine("User does not exist!");
        }
        private static void StaffMenuOptions(MovieCollection movieList, MemberCollection memberList)
        {
            StaffMenu();
            Int32.TryParse(Console.ReadLine(), out int staffOption);
            switch (staffOption)
            {
                case 0: //return to main menu
                    MainMenuOptions(MainMenu(), movieList, memberList);
                    break;
                case 1: // add a new movie dvd
                    Console.WriteLine("(DEBUG) You selected 1");
                    StaffOption1(movieList);
                    StaffMenuOptions(movieList, memberList);
                    break;
                case 2: // remove movie dvd
                    Console.WriteLine("(DEBUG) You selected 2");
                    StaffOption2(movieList);
                    StaffMenuOptions(movieList, memberList);
                    break;
                case 3: // register new member
                    Console.WriteLine("(DEBUG) You selected 3");
                    StaffOption3(memberList);
                    StaffMenuOptions(movieList, memberList);
                    break;
                case 4: // find a registered member's phone number
                    Console.WriteLine("(DEBUG) You selected 4");
                    StaffOption4(memberList);
                    StaffMenuOptions(movieList, memberList);
                    break;
            }
        }

        private static void MainMenuOptions(int option, MovieCollection movieList, MemberCollection memberList)
        {
            if (option == 1)
            {
                // login method
                bool staffLoggedIn = StaffLogIn(new Staff("staff", "today123"));
                if (staffLoggedIn)
                {
                    StaffMenuOptions(movieList, memberList);
                }

            }
            // member login
            else if (option == 2)
            {
                Console.Write("Member Enter username: ");
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
        

        static void Main(string[] args)
        {
            MovieCollection movieCollection = new MovieCollection();
            MemberCollection memberCollection = new MemberCollection();

            int userOption;
            // print main menu
            userOption = MainMenu();
            MainMenuOptions(userOption, movieCollection , memberCollection);

            
        }
    }
}
