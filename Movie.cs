using System;

namespace MovieManager
{
    public class Movie
    {
        private int timesBorrowed = 0;
        private string movieTitle;
        private string director;
        private string actor;
        private string genre;
        private string classification;
        private int duration;
        private int year;
        private int copies;
        public Movie(string title, string directors, string actors, string genres, string classifications, int time, int releaseYear, int numCopies)
        {
            movieTitle = title;
            director = directors;
            actor = actors;
            genre = genres;
            classification = classifications;
            duration = time;
            year = releaseYear;
            copies = numCopies;
        }
        public void BorrowItem()
        {
            copies -= 1;
            timesBorrowed += 1;
        }
        public void ReturnItem()
        {
            copies++;
        }
        public int GetCopies()
        {
            return copies;
        }
        public string GetTitle()
        {
            return movieTitle;
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Title: {0}", movieTitle);
            Console.WriteLine("Starring: {0}", actor);
            Console.WriteLine("Director: {0}", director);
            Console.WriteLine("Genre: {0}", genre);
            Console.WriteLine("Classification: {0}", classification);
            Console.WriteLine("Duration: {0} minutes", duration);
            Console.WriteLine("Release Date: {0}", year);
            Console.WriteLine("Copies Available: {0}", copies);
            Console.WriteLine("Times Borrowed: {0}", timesBorrowed);
        }

        public int GetTimesBorrowed()
        {
            return timesBorrowed;
        }
        public void AddCopies(int i) { copies += i; }
    }
}
