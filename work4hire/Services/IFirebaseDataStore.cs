using System;
using work4hire.Model;

namespace work4hire.Services
{
    public interface IFirebaseDataStore<T>
    {
        Task<User> RegisterUser(User user);
    }
}

