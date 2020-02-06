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
    }
}