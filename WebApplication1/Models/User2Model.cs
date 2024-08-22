using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class User2Model
    {

        public User2Model() { }

        public int Id { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }

        public virtual ICollection<RightModel> Rights { get; set; }

        public User2Model(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
            Rights = new List<RightModel>(); // Initialize collection
        }
    }
}