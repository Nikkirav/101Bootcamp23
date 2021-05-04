using LibraryCommon.DataEntity;
using LibraryDatabaseAccessLayer;
using System;
using System.Collections.Generic;

namespace LibraryBusinessLogicLayer
{
    public class RoleBusinessLogic
    {
        // data
        private RoleDataAccess _data;

        // constructor
        public RoleBusinessLogic() 
        {
            _data = new RoleDataAccess();
        }

        public RoleBusinessLogic(string conn)
        {
            _data = new RoleDataAccess(conn);
        }

        public List<Role> GetRolesPassThru() 
        {
            List<Role> _list =  _data.GetRoles();
            return _list;
        }

        public void CreateRolePassThru(Role r)
        {
            _data.CreateRole(r);
        }

        public void DeleteRolePassThru(int id)
        {
            Role r = new Role() { RoleID = id };
            _data.DeleteRole(r);
        }

        public void UpdateRolePassThru(Role role)
        {
            _data.UpdateRole(role);
        }
    }
}
