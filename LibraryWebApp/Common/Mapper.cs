using LibraryCommon;
using LibraryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWebApp.Common
{
    public static class Mapper
    {

        internal static GenreModel GenreModel(LibraryCommon.DataEntity.Genre inGenre)
        public List<Genre> Get;
        public object Item2;

        public NewStruct(List<Genre> get, object item2)
        {
            Get = get;
            Item2 = item2;
        }

        public override bool Equals(object obj)
        {
            return obj is NewStruct other &&
           System.Collections.Generic.EqualityComparer<List<Genre>>.Default.Equals(Get, y: other.Get) &&
           System.Collections.Generic.EqualityComparer<object>.Default.Equals(Item2, other.Item2);



            GenreModel _genreModel = new GenreModel();
            _genreModel.Name = inUf.Name;


            _GenreModel.GenreId = inGenre.GenreId_FK;
            _GenreModel.GenreName = Mapper.GenreIdToGenreName(inGenre.GenreId_FK);
            _GenreModel.GenreId = inGenre.GenreID;
            _GenreModel.Genrename = inGenre.GenreName;
            return _genreModel;


        }



        internal static IEnumerable<GenreModel> GenreListToGenreModels(List<LibraryCommon.DataEntity.Genre> list)
        {
            List<GenreModel> toReturn = new List<GenreModel>();

            foreach (LibraryCommon.DataEntity.Genre _currentItem in list)
            {
                GenreModel newModel = new GenreModel();
                newModel.Name = _currentItem.Name;

                newModel.GenreId = _currentItem.GenreId_FK;

                toReturn.Add(newModel);
            }

            return toReturn;
        }

        internal static List<GenreModel> GenreListToGenreModelList(List<LibraryCommon.DataEntity.Genre> inList)
        {
            List<GenreModel> list = new List<GenreModel>();

            foreach (LibraryCommon.DataEntity.Genre _current in inList)
            {
                GenreModel gm = new GenreModel();
                gm.GenreId = _current.GenreId;
                gm.GenreName = _current.GenreName;
                list.Add(gm);



                return list;
            }

            private static string GenreIdToGenreName(int inGenreId)
            {
                switch (inGenreId)
                {
                    case 1:
                        return GenreType.Administrator.ToString();
                    case 2:
                        return GenreType.Librarian.ToString();
                    case 3:
                        return GenreType.Patron.ToString();
                    default:
                        return GenreType.Anonymous.ToString();


                }
            }

            internal static LibraryCommon.DataEntity.Genre GenreModelToGenre(GenreModel model)
            {
                return new LibraryCommon.DataEntity.Genre { GenreId = model.GenreId, GenreName = model.GenreName };
            }


            internal static LibraryCommon.DataEntity.Genre LoginModelToGenre(LoginModel inModel)
            {
                // TODO: mapping
                LibraryCommon.DataEntity.Genre _Genre = new LibraryCommon.DataEntity.Genre();

                _Genre.GenreName = inModel.Genrename;
                _Genre.Password = inModel.Password;

                return _Genre;
            }
        }
    }
}       
      