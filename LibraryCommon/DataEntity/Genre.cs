using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon.DataEntity
{
    public class Genre
    {
        public int GenreID { get; set; }
        public bool IsFiction { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
