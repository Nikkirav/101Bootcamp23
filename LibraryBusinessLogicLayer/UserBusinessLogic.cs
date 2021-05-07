using LibraryCommon;
using LibraryCommon.Common;
using LibraryCommon.DataEntity;
using LibraryDatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace LibraryBusinessLogicLayer
{
    public class UserBusinessLogic
    {
        // data
        private UserDataAccess _data;
        Hasher _hash = new Hasher();

        // constructor
        public UserBusinessLogic()
        {
            _data = new UserDataAccess();
        }

        public UserBusinessLogic(string conn)
        {
            _data = new UserDataAccess(conn);
        }

        public ResultUser LoginUserPassThru(LibraryCommon.DataEntity.User inUser)
        {
            ResultUser r = new ResultUser();
            string _hashed = "", _salt = "";
            Hasher _hasher = new Hasher();

            // 1. get the users
            List<LibraryCommon.DataEntity.User> _list = _data.GetUsers();

            // 2. find this user by username , assume there's not dups
            LibraryCommon.DataEntity.User _foundUser = _list.Where(u => u.UserName == inUser.UserName).
                FirstOrDefault();

            // 3. if user match is found, get the salt
            if (_foundUser != null)
            {
                _salt = _foundUser.Salt;
                // 4. run hash process for this password with the salt
                _hashed = _hasher.HashedValue(_salt + inUser.Password);

            }
            else
            { 
                // no found user, no salt
            }


            // 5. compare the hashes
            if (_hashed == _foundUser.Password)
            {
                // 6. if match, we have a user with a role
                r.User = _foundUser;
                r.Type = ResultType.Success;
            }
            else 
            {
                // 7. otherwise no match and return a error message
                r.User = null;
                r.Message = "Username not found or password did not match.";
                r.Type = ResultType.Failure;
            }
                   
            return r;
        }

        public Result RegisterUser(LibraryCommon.DataEntity.User user)
        {
            throw new NotImplementedException();
        }

        private static string CreateSalt(int size)
        {

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        public List<LibraryCommon.DataEntity.User> GetUsersPassThru()
        {
            List<LibraryCommon.DataEntity.User> _list = _data.GetUsers();
            return _list;
        }
      
        public void CreateUserPassThru(LibraryCommon.DataEntity.User inUser)
        {
            LibraryCommon.DataEntity.User u = HashUser(inUser);
            _data.CreateUser(u);
        }

        public void UpdateUserPassThru(LibraryCommon.DataEntity.User inUser)
        {
            LibraryCommon.DataEntity.User u = HashUser(inUser);
            _data.UpdateUser(u);
        }

        private LibraryCommon.DataEntity.User HashUser(LibraryCommon.DataEntity.User u)
        {
            LibraryCommon.DataEntity.User _returnUser = new LibraryCommon.DataEntity.User();
            _returnUser = u;
            string salt = Guid.NewGuid().ToString();
            string saltAndPassword = salt + u.Password;
            string _hashed = _hash.HashedValue(saltAndPassword);
            _returnUser.Password = _hashed;
            _returnUser.Salt = salt;

            return _returnUser;
        }

        public void DeleteUserPassThru(LibraryCommon.DataEntity.User u)
        {
            _data.DeleteUser(u);
        }
    }

}
