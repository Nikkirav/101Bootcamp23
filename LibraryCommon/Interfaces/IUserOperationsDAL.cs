using System.Data;

namespace LibraryCommon.Interfaces
{
    public interface IUserOperationsDAL
    {

        IDbConnection Connection { get; set; }

        ResultUsers LoginUserToDatabase(User inUser);
        Result RegisterUserToDatabase(User inUser);
    }


}