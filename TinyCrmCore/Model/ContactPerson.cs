using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrmCore.Model
{
   public class ContactPerson
    {
        public int Id { set; get; }
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public PositionCategory Position { get; set; }
    }
}
