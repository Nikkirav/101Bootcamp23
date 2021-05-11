using LibraryCommon.DataEntity;
using LibraryDatabaseAccessLayer;
using System;
using System.Collections.Generic;

namespace LibraryBusinessLogicLayer
{
    public class GenreBusinessLogic
    {
        // data
        private GenreDataAccess _data;

        // constructor
        public GenreBusinessLogic()
        {
            _data = new GenreDataAccess();
        }

        public GenreBusinessLogic(string conn)
        {
            _data = new GenreBusinessLogic(conn);
        }

        public List<Genre> GetGenrePassThru()
        {
            List<Genre> _list = _data.GetGenre();
            return _list;
        }

        public void CreateGenrePassThru(Genre g)
        {
            _data.CreateGenre(g);
        }

        public void DeleteGenrePassThru(int id)f
        {
          GenreBusinessLogic g = new Genre() { GenreID = id };
            _data.DeleteGenre(g);
        }

        public void UpdateGenrePassThru(Genre genre)
        {
            _data.UpdateGenre(genre);
        }
    }
}
