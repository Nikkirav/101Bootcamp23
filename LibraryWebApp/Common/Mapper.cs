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

        internal static List<RoleModel> RoleListToRoleModelList(List<LibraryCommon.DataEntity.Role> inList)
        {
            List<RoleModel> list = new List<RoleModel>();

            foreach (LibraryCommon.DataEntity.Role _current in inList)
            {
                RoleModel rm = new RoleModel();
                rm.RoleId = _current.RoleID;
                rm.RoleName = _current.RoleName;
                list.Add(rm);
            }

            return list;
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

        internal static BooksModel ResultsBooksToBooksModel(ResultBooks inResultsBooks)
        {
            BooksModel _booksModel = new BooksModel();
            List<BookModel> _list = new List<BookModel>();
            _booksModel.DialogMessage = inResultsBooks.Message;
            _booksModel.DialogMessageType = inResultsBooks.Type.ToString();

            foreach (var _current in inResultsBooks.ListOfBooks)
            {
                // map properties
                 BookModel _book = new BookModel();
                _book.Author = _current.Author;
                _book.BookID = _current.BookID.ToString();
                _book.BookStatus = _current.BookStatus;
                _book.Title = _current.Title;
                _book.Genre = _current.Genre;

                // nullable
                _book.UserID = _current.UserID.ToString();
                _book.Borrower = _current.Borrower == null ? null : _current.Borrower;
                _book.CheckOutDate = _current.CheckOutDate == DateTime.MinValue ? null : _current.CheckOutDate.ToString(); // TODO: format
                _book.DueDateBack = _current.DueDateBack == DateTime.MinValue ? null : _current.DueDateBack.ToString(); // TODO: format
                _book.ReturnedDate = _current.ReturnedDate == DateTime.MinValue ? null : _current.ReturnedDate.ToString(); // TODO: format

                // add to the return list
                _list.Add(_book);
            }

            _booksModel.ListOfBookModel = _list;
            return _booksModel;
        }

        internal static UsersModel ResultUsersToUsersModel(ResultUsers resultUsers)
        {
            UsersModel _usersModel = new UsersModel();
            List<UserModel> _list = new List<UserModel>();

            foreach (User _current in resultUsers.ListOfUsers)
            {
                _list.Add(Mapper.UserToUserModel(_current));
            }

            // TODO: SET IT _usersModel.ListOfUsers
            _usersModel.ListOfUsers = _list;
            return _usersModel;
        }
    }
}