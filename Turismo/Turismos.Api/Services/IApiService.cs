using Azure;
using Turismos.Shared.Responses;

namespace Turismos.Api.Services
{
    public interface IApiService
    {
        Task<Shared.Responses.Response> GetListAsync<T>(string servicePrefix, string controller);
    }
}


