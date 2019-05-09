using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAuto.Entity
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public int UserGender { get; set; }
        public DateTime UserBirthday { get; set; }
        public string UserAddress { get; set; }
        public string Phone { get; set; }
        public string QQ { get; set; }
        public string Email { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
