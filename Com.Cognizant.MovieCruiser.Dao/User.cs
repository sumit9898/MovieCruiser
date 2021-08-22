using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.MovieCruiser.Model;

namespace Com.Cognizant.MovieCruiser.Dao
{
    abstract public class User
    {
        abstract public List<Movie> GetMovieList();
        public List<Movie> movieList = new List<Movie>()
        {
            new Movie(1, "Avatar", 2787965087, true, "15/03/2017", "Science Fiction", true),
            new Movie(2, "The Avengers", 1518812988, true, "23/12/2017", "Superhero", false),
            new Movie(3, "Titanic", 2187463944, true, "21/08/2017", "Romance", false),
            new Movie(4, "Jurassic World", 1671713089, false, "02/07/2017", "Science Fiction", true),
            new Movie(5, "Avengers:End Game", 2750760348, false, "02/11/2022", "Superhero", true)
        };
    }
    public class Admin : User
    {
        string adminName;
        public string AdminName
        {
            get { return adminName; }
            set { adminName = value; }
        }
        string adminPassword;
        public string AdminPassword
        {
            get { return adminPassword; }
            set { adminPassword = value; }
        }
        //MOVIE LIST ADMIN
        public override List<Movie> GetMovieList()
        {
            return movieList;
        }

        public void DisplayMovieListByAdmin()
        {
            movieList = GetMovieList();
            string active = string.Empty;
            string hasteaser = string.Empty;
            Console.WriteLine(" Id   Title              Box office($) Active     Date of launch      Genre       Hasteaser");
            foreach (Movie movie in movieList)
            {
                if (movie.Active)
                {
                    active = "yes";
                }
                else
                {
                    active = "No";
                }
                if (movie.HasTeaser == true)
                {
                    hasteaser = "yes";
                }
                else
                {
                    hasteaser = "No";
                }
                Console.WriteLine("{0,3}   {1,-18} {2,-6}    {3,-11} {4}    {5,-15}   {6}", movie.Id, movie.Title, movie.BoxOffice, movie.Active, movie.DateOfLaunch, movie.Genre, movie.HasTeaser);
            }
        }

        //EDIT MOVIE
        public void EditMovie(int id)
        {
            movieList = GetMovieList();
            string active = string.Empty;
            string hasteaser = string.Empty;
            int i = id - 1;
            if (movieList.Contains(movieList[i]))
            {
                if (movieList[i].Active)
                {
                    active = "yes";
                }
                else
                {
                    active = "no";
                }
                if (movieList[i].HasTeaser == true)
                {
                    hasteaser = "yes";
                }
                else
                {
                    hasteaser = "no";
                }
                //Console.WriteLine("{0,3}   {1,-18} {2,-6}    {3,-14} {4}    {5,-15}   {6}", movieList[i].Id, movieList[i].Title, movieList[i].BoxOffice, movieList[i].Active, movieList[i].DateOfLaunch, movieList[i].Genre, movieList[i].HasTeaser);

                Console.WriteLine("Enter the Id in movielist:");
                movieList[i].Id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the new correct Title:");
                movieList[i].Title = Console.ReadLine();

                Console.WriteLine("enter the correct Box office collection in $:");
                movieList[i].BoxOffice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("enter 'true' if active or enter 'false' if not active:");
                movieList[i].Active = Convert.ToBoolean(Console.ReadLine());

                Console.WriteLine("enter the correct date of launch in dd/mm/yyyy format:");
                movieList[i].DateOfLaunch = Console.ReadLine();

                Console.WriteLine("enter the correct genre:");
                movieList[i].Genre = Console.ReadLine();

                Console.WriteLine("enter 'true' if it has teaser or enter 'false' if it has no teaser:");
                movieList[i].HasTeaser = Convert.ToBoolean(Console.ReadLine());


                Console.WriteLine("movie details edited successfully");

            }
        }
    }
    public class Customer : User
    {
        int customerId;
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        string customerName;

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public Customer() { }
        public Customer(int customerId, string customerName)
        {
            this.CustomerId = customerId;
            this.CustomerName = customerName;
        }
        public override List<Movie> GetMovieList()
        {
            return movieList;
        }
        public void DisplayMovieListByCustomer()
        {
            movieList = GetMovieList();
            string teaser = "";
            Console.WriteLine("ID title               Box office($)   genre                Has teaser");
            for (int i = 0; i < movieList.Count() - 2; i++)
            {
                if (movieList[i].HasTeaser == true)
                {
                    teaser = "yes";
                }
                else
                {
                    teaser = "no";
                }
                Console.WriteLine("{0}     {1,-18}  {2,-13}   {3,-15}    {4}", movieList[i].Id, movieList[i].Title, movieList[i].BoxOffice, movieList[i].Genre, teaser);
            }
        }
        //ADD TO FAVORITES
        public void AddToFavorites(int Id, List<Movie> favorites)
        {
            movieList = GetMovieList();
            int i = Id - 1;
            favorites.Add(movieList[i]);
            Console.WriteLine("movie added to favorites successfully");
        }
        //view favorites
        public void viewfavorites(List<Movie> favorites)
        {
            Console.WriteLine("Favorites:");
            Console.WriteLine("ID title              Box office($)     genre");
            for (int i = 0; i < favorites.Count(); i++)
            {
                Console.WriteLine("{0} {1,-18}  {2,-13}   {3}", i + 1, favorites[i].Title, favorites[i].BoxOffice, favorites[i].Genre);
            }
            Console.WriteLine("no of favorites:" + favorites.Count());
        }
        //REMOVE FAVORITES
        public void RemoveFavorites(int Id, List<Movie> favorites)
        {
            int i = Id - 1;
            favorites.Remove(favorites[i]);
            Console.WriteLine("movie removed from favorites successfully");
        }
    }
}