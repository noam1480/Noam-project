using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Users:BaseEntity
    {
        private string name;
        private string email;
        private string pass;
        private bool isActive;

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Pass { get => pass; set => pass = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
    }
}
