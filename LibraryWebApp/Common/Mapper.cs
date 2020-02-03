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

        internal static User UserModelToUser(UserModel inUserModel) 
        {
            // TODO: mapping
            User _user = new User();

            _user.FirstName = inUserModel.FirstName;
            _user.LastName = inUserModel.LastName;
            _user.Username = inUserModel.Username;
            _user.Password = inUserModel.Password;
            return _user;
        }

        internal static UserModel UserToUserModel(User inUser) 
        {
            UserModel _userModel = new UserModel();
            _userModel.FirstName = inUser.FirstName;
            _userModel.LastName = inUser.LastName;
            _userModel.Password = inUser.Password;
            _userModel.RoleId = inUser.RoleId;
            _userModel.RoleName = Mapper.RoleIdToRoleName(inUser.RoleId);
            _userModel.UserId = inUser.UserId;
            _userModel.Username = inUser.Username;
            return _userModel;
        }

        private static string RoleIdToRoleName(int inRoleId)
        {
            switch (inRoleId)
            {
                case 1:
                    return RoleType.Administrator.ToString();
                case 2:
                    return RoleType.Librarian.ToString();
                case 3:
                    return RoleType.Patron.ToString();
                default:
                    return RoleType.Anonymous.ToString();
            }
        }

        internal static User LoginModelToUser(LoginModel inModel)
        {
            // TODO: mapping
            User _user = new User();

            _user.Username = inModel.Username;
            _user.Password = inModel.Password;

            return _user;
        }
    }
}