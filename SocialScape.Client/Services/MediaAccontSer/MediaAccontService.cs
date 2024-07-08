using SocialScape.Shared.Models.MediaAccountFold;
using SocialScape.Shared.Result.MediaAccountRes;
using System.Net.Http.Json;

namespace SocialScape.Client.Services.MediaAccontSer
{
    public class MediaAccontService : IMediaAccountService
    {
        private readonly HttpClient _httpClient;

        public MediaAccontService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MediaAccountResult> CreateMediaAccount(MediaAccount mediaAccount)
        {
            var result =await  _httpClient.PostAsJsonAsync("api/MediaAccount/CreateMediaAccount", mediaAccount);

            if (result.IsSuccessStatusCode)
            {
                return new MediaAccountResult { Successful = true };
            }
            else
            {
                return new MediaAccountResult { Successful = false, Error = "Something went wrong. Try again" };
            }
        }
    }
}
