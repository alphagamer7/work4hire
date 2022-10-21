using System;

namespace work4hire.Model
{
    public class Worker : Person
    {

        public List<string> Speciality { get; set; }


        public Worker(string firstname, string lastname, string email, string address, string image, List<string> speciality)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Address = address;
            Image = image;
            Speciality = speciality;
        }
    }
}


