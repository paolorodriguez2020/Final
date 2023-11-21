using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudNov.Entities
{
    internal class User
    { 
        
        private String name;
        private String lastName;
        private String username;
        private String password;

        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }


        public void Register(string n, string ln, string us, string p)
        {
            this.name = n; 
            this.lastName = ln;
            this.username = us; 
            this.password = p;


        }

        public bool Login (string us, string p)
        {
            if (username == us && password == p) return true;
            else return false;         
               
        }


    }


}
