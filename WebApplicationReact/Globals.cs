using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationReact.Models;

namespace WebApplicationReact
{
    public static class Globals
    {
        static Globals()
        {
            Users = new List<User>();
            Roles = new List<Role>();
        }

        public static List<User> Users { get; set; }

        public static List<Role> Roles { get; set; }

        public static int GetLastUserId()
        {
            int res = 0;

            var lastUser = Users.OrderByDescending(x => x.Id).FirstOrDefault();

            if (lastUser != null)
            {
                res = lastUser.Id + 1;
            }

            return res;
        }

        public static int GetLastRoleId()
        {
            int res = 0;

            var lastUser = Users.OrderByDescending(x => x.Id).FirstOrDefault();

            if (lastUser != null)
            {
                res = lastUser.Id + 1;
            }

            return res;
        }
    }
}
