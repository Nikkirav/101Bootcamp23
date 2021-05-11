using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary.DataEntity
{
    public class Genre
    {


        public int GenreID { get; set; }
        public bool IsFiction { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public static bool Isfiction { get; set; }

        private bool genre;

        public bool GetGenre()
        {
            return genre;
        }

        public void SetGenre(bool value)
        {
            genre = value;
        }

        public class ListAsync : Genre
        {
        }

        public static void Find(string id)
        {
            throw new NotImplementedException();
        }
    }
}
