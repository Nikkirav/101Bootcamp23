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

        internal static UserModel UserToUserModel(LibraryCommon.DataEntity.User inUser) 
        {
            UserModel _userModel = new UserModel();
            _userModel.FirstName = inUser.FirstName;
            _userModel.LastName = inUser.LastName;
            _userModel.Password = inUser.Password;
            _userModel.RoleId = inUser.RoleID_FK;
            _userModel.RoleName = Mapper.RoleIdToRoleName(inUser.RoleID_FK);
            _userModel.UserId = inUser.UserID;
            _userModel.Username = inUser.UserName;
            return _userModel;
        }

        internal static IEnumerable<UserModel> UserListToUserModels(List<LibraryCommon.DataEntity.User> list)
        {
            List<UserModel> toReturn = new List<UserModel>();

            foreach (LibraryCommon.DataEntity.User _currentItem in list)
            {
                UserModel newModel = new UserModel();

                newModel.UserId = _currentItem.UserID;
                newModel.FirstName = _currentItem.FirstName;
                newModel.LastName = _currentItem.LastName;
                newModel.Username = _currentItem.UserName;
                newModel.Password = _currentItem.Password;
                newModel.RoleId = _currentItem.RoleID_FK;

                toReturn.Add(newModel);
            }

            return toReturn;
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

        internal static LibraryCommon.DataEntity.Role RoleModelToRole(RoleModel model)
        {
            return new LibraryCommon.DataEntity.Role { RoleID = model.RoleId, RoleName = model.RoleName };
        }


        internal static LibraryCommon.DataEntity.User LoginModelToUser(LoginModel inModel)
        {
            // TODO: mapping
            LibraryCommon.DataEntity.User _user = new LibraryCommon.DataEntity.User();

            _user.UserName = inModel.Username;
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

        internal static RoleModel RoleToRoleModel(LibraryCommon.DataEntity.Role r)
        {
            return new RoleModel { RoleId = r.RoleID, RoleName = r.RoleName };
        }

        internal static LibraryCommon.DataEntity.User UserModelToUser(UserModel inModel)
        {
            throw new NotImplementedException();
        }
    }
}