using System;
using Newtonsoft.Json;
using work4hire.Model;
using System.Text;
using Firebase.Auth;
using User = work4hire.Model.User;

namespace work4hire.Services
{
    
    public class FirebaseDataStore: IFirebaseDataStore<User>
    {

        private static string BaseUrl => AppConstant.baseUrl;
        IWebClientService service = DependencyService.Get<IWebClientService>();

        public FirebaseDataStore(){}

        public async Task<User> RegisterUser(User user)
        {
            string content = JsonConvert.SerializeObject(new
            {
                email = user.Email,
                password = user.Password,
                firstName = user.FirstName,
                lastName = user.LastName,
                address = user.Address,
                image = user.Image
            });


            dynamic json = await service.PostAsync(BaseUrl + "/user", content, "application/json");
            return json;
        }

        public async Task<User> LoginUser(User user)
        {
            string content = JsonConvert.SerializeObject(new
            {
                email = user.Email,
                password = user.Password
            });
           
            string json = await service.PostAsync(BaseUrl + "/user/login", content, "application/json");
            
            return buildUser(json);
        }

        public dynamic buildUser(string user)
        {
            var response = JsonConvert.DeserializeObject<UserResponse>(user);
            return response.user;
        }

        public async Task<Project> AddProject(Project project)
        {
            
            string content = JsonConvert.SerializeObject(new
            {
                title = project.Title,
                category = project.Category,
                description = project.Description,
                image= project.Image,
                latitude = project.Latitude,
                longitude = project.Longitude,
            });

            string json = await service.PostAsync(BaseUrl + "/project/add", content, "application/json");
            return buildProject(json);
        }

        public dynamic buildProject(string json)
        {
            var response = JsonConvert.DeserializeObject<ProjectResponse>(json);
            return response.job;
        }

        public async Task<List<Project>> GetProjectList()
        {
            string content = JsonConvert.SerializeObject(new {});

            string json = await service.PostAsync(BaseUrl + "/project/all", content, "application/json");

            return buildProjectList(json);
        }

        public dynamic buildProjectList(string projects)
        {
            var response = JsonConvert.DeserializeObject<List<Project>>(projects);
            return response;
        }
    }
}

