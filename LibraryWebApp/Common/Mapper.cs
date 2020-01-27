﻿using LibraryCommon;
using LibraryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWebApp.Common
{
    public static class Mapper
    {

        public static User UserModelToUser(UserModel inUserModel) 
        {
            // TODO: mapping
            User _user = new User();

            _user.FirstName = inUserModel.FirstName;
            _user.LastName = inUserModel.LastName;
            _user.Username = inUserModel.Username;
            _user.Password = inUserModel.Password;

            return _user;
        }

    }
}