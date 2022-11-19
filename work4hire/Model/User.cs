using System;
namespace work4hire.Model
{
	public class User: Person
	{
     

        public User(string firstname,string lastname, string email, string address, string image, int status, int createdDate, int editedDate)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Address = address;
            Image = image;
            Status = status;
            CreatedDate = createdDate;
            EditedDate = editedDate;
        }

	}
}

