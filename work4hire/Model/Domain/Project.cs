using System;

namespace work4hire.Model
{
	public class Project
	{
        public string ProjectId { get; set; }
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
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Boolean isArchived { get; set; }

        public Project(string projectId, string category, string title, string description, string projectAddress, int createdDate, int editedDate, int assignedWorkerId, int distance, int status, int latitude, int longitude)
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

        public Project( string title, string category, string description, string downloadImage, double latitude, double longitude)
        {
            Category = category;
            Title = title;
            Description = description;
            Image = downloadImage;
            Latitude = latitude;
            Longitude = longitude;
        }

        public Project(string projectId, string title, string category, string description, string image,double latitude, double longitude)
        {
            Category = category;
            Title = title;
            Description = description;
            Image = image;
            Latitude = latitude;
            Longitude = longitude;
            ProjectId = projectId;
        }

        public Project()
        {

        }

     
    }

    public class ProjectResponse
    {
        public bool status { get; set; }
        public Project job { get; set; }
    }

    public class ProjectListResponse
    {
        public bool status { get; set; }
        public List<Project> jobs { get; set; }
    }

}

