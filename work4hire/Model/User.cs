using System;
namespace work4hire.Model
{
	public class User: Person
	{
     

        public User(string firstname,string lastname, string email, string address, string image, int status)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Address = address;
            Image = image;
            Status = status;
        }

	}
}

