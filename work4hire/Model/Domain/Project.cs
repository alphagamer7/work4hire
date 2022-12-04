using System;

namespace work4hire.Model
{
	public class Project
	{
        public int ProjectId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string ProjectAddress { get; set; }
        public double CreatedDate { get; set; } // Stroing date in unix format
        public double EditedDate { get; set; } // Stroing date in unix format
        public int AssignedWorkerId { get; set; }
        public int Distance { get; set; }
        public int Status { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public Boolean isArchived { get; set; }

        public Project(int projectId, string category, string title, string description, string projectAddress, int createdDate, int editedDate, int assignedWorkerId, int distance, int status, int latitude, int longitude)
		{
            ProjectId = projectId;
            ProjectAddress = projectAddress;
            Category = category;
            Title = title;
            Description = description;
            CreatedDate = createdDate;
            EditedDate = editedDate;
            AssignedWorkerId = assignedWorkerId;
            Distance = distance;
            Status = status;
            Latitude = latitude;
            Longitude = longitude;
        }
	}
}

