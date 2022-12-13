using System;
namespace work4hire.Model
{
    public class User : Person
    {
        public string Password { get; set; }
        public User(string firstname, string lastname, string password, string email, string address, string image)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Address = address;
            Image = image;
            Password = password;
        }

        public User(string firstname, string lastname, string email, string address, string image, int status, int createdDate, int editedDate)
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

        public User(string firstname, string lastname, string email, string address, string image)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Address = address;
            Image = image;
           
        }


        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public User()
        {

        }
    }

    public class UserResponse
    {
        public User user { get; set; }

    }
}

