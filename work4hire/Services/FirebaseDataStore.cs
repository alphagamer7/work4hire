using System;
using Newtonsoft.Json;
using work4hire.Model;
using System.Text;

namespace work4hire.Services
{
    public class FirebaseDataStore: IFirebaseDataStore<User>
    {

        private static string BaseUrl => "https://work4hire.herokuapp.com";

        public FirebaseDataStore()
        {
        }

        public async Task<User> RegisterUser(User user)
        {
            var service = DependencyService.Get<IWebClientService>();
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
    }
}

