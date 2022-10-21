using System;

namespace work4hire.Model
{
    public class Worker : Person
    {
        public string AboutMe { get; set; }
        public List<string> Speciality { get; set; }
       


        public Worker(string firstname, string lastname, string email, string address, string image,string aboutMe, List<string> speciality, int status)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Address = address;
            Image = image;
            Speciality = speciality;
            AboutMe = aboutMe;
            Status = status;
        }
    }
}


