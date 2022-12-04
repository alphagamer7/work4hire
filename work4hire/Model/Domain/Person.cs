using System;
namespace work4hire.Model
{
    public abstract class Person
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string ContactNo { get; set; }
        public int Status { get; set; } // 1-0 to denote if status exist or not
        public double CreatedDate { get; set; } // Stroing date in unix format
        public double EditedDate { get; set; } // Stroing date in unix format

    }
}



