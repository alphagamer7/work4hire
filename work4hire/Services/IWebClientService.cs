using System;
namespace work4hire.Services
{
	public interface IWebClientService
	{
        Task<string> GetAsync(string uri);
        Task<string> PostAsync(string uri, string body, string type);
        Task<string> PutAsync(string uri, string body, string type);
    }
}

