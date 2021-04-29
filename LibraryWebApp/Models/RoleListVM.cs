using LibraryCommon.DataEntity;
using LibraryWebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWebApp.Models
{
    public class RoleListVM
    {
        // data
        public IEnumerable<RoleModel> ListOfRoleModel { get; set; }

        // constructors
        public RoleListVM(List<RoleModel> rmlist)
        {
            ListOfRoleModel = rmlist;
        }

    }
}