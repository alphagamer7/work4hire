using System;
using static Java.Util.Jar.Attributes;

namespace work4hire.Model
{
	public class Project
	{
        public int ProductId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Createdate { get; set; }
       
        public Project(int productid, string category, string title, string description, int createdate)
		{
            Productid = productid;
            Category = category;
            Title = Title;
            Description = description;
            Createdate = createdate;
        }
	}
}

