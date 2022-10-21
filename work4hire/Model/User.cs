using System;
namespace work4hire.Model
{
	public class User
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }

        public User(string firstname,string lastname, string email, string address, string image)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Address = address;
            Image = image;
        }

	}
}

