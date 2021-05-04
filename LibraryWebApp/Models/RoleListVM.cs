using LibraryCommon.DataEntity;
using LibraryWebApp.Common;
using System.Collections.Generic;

namespace LibraryWebApp.Models
{
    public class RoleListVM
    {
        // data
        public IEnumerable<RoleModel> ListOfRoleModel { get; set; } // list of all roles in datatabase

        public RoleListVM(List<Role> list)
        {
            ListOfRoleModel = Mapper.RoleListToRoleModelList(list);
        }
    }
}