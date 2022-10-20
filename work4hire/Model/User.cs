using System;
namespace work4hire.Model
{
	public class User
	{
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }

        public User(string name, string origin, string image)
        {
            Name = name;
            Address = Address;
            Image = image;
        }

	}
}

