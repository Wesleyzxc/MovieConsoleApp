using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManager
{
    public class Movie
    {
        private int id;
        private int timesBorrowed;
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
        public int GetID() { return id; }
        public void BorrowItem()
        {
            copies -= 1;
            timesBorrowed += 1;
        }

        public string GetTitle()
        {
            return movieTitle;
        }

        public void AddCopies(int i) { copies += i; }
    }
}
