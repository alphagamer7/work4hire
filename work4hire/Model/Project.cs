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
        public int CreateDate { get; set; }
        public int AssignedWorkerId { get; set; }

        public Project(int productid, string category, string title, string description, int createDate, int assignedWorkerId)
		{
            ProductId = productid;
            Category = category;
            Title = Title;
            Description = description;
            CreateDate = createDate;
            AssignedWorkerId = assignedWorkerId;
        }
	}
}

