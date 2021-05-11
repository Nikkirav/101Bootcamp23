using System.Collections.Generic;
using ConsoleLibrary.DataEntity;

namespace LibraryWebApp.Controllers
{
    internal class GenreListVM : RoleListVM
    {
        private List<Genre> list;

        public GenreListVM(List<Genre> list)
        {
            this.list = list;
        }
    }
}