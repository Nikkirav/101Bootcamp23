using LibraryCommon;
using LibraryWebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWebApp.Models
{
    public class UserListVM
    {
       
        public IEnumerable<UserModel> ListOfUserModels { get; set; }

        public UserListVM(List<LibraryCommon.DataEntity.User> list)
        {
            ListOfUserModels = Mapper.UserListToUserModels(list);
        }
    }
}