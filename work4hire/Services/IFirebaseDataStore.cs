using System;
using work4hire.Model;

namespace work4hire.Services
{
    public interface IFirebaseDataStore<T>
    {
        Task<User> RegisterUser(User user);

        Task<User> EditUser(User user);

        Task<User> LoginUser(User user);

        Task<Project> AddProject(Project project);

        Task<List<Project>> GetProjectList();
    }
}

