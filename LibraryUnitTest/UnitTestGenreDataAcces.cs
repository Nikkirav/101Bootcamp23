using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LibraryUnitTest
{
    [TestClass]

    public class UnitTestGenreDataAcess
    {

        private string _conn;
        public static string Genre;
        private readonly object dt;
        public string Name;
        public string salt;
        public static bool Genre1 { get; private set; }


        //Constructor
        public


        /* public*/UnitTestGenreDataAcess(string conn, object dt)



        {
            _conn = conn;
            this.dt = dt;
        }

        public static bool GetGenre1()
        {
            return Genre1;
        }

        public static void SetGenre1(bool value)
        {
            Genre1 = value;
        }

        public static bool GetGenre()
        {
            return GetGenre1();
        }

        static internal void SetGenre(bool value)
        {
            SetGenre1(value);
        }
    }
}
