using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManager
{
    public class MovieCollection
    {
        private Movie[] movieList = new Movie[10];
        private int pointer = 0;

        public MovieCollection()
        {

        }

        public Movie GetMovie(int i)
        {
            return movieList[i];
        }

        public void AddMovie(Movie i)
        {
            if (pointer == 10)
            {
                Console.WriteLine("FULL!");
            }
            else
            {
                Console.WriteLine("{0} movie(s) full", i);
                movieList[pointer] = i;
                pointer += 1;
            }
        }

        public void RemoveMovie(int indexOfMovie)
        {
            movieList[indexOfMovie] = null;
            for (int i = indexOfMovie+1; i < 10; i++)
            {
                if (movieList[i] != null)
                {
                    movieList[i-1] = movieList[i];
                    movieList[i] = null;
                    pointer -=1;
                }
            }
        }

        public int GetNumMovies()
        {
            return pointer;
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
}
