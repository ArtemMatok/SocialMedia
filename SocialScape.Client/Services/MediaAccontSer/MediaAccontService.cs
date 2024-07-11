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

        public async Task<(MediaAccount? mediaAccount, bool Successfull)> GetMediaAccountByEmail(string email)
        {
            var result = await _httpClient.GetFromJsonAsync<MediaAccount>($"api/MediaAccount/GetMediaAccountByEmail/{email}");

            if(result is null)
            {
                return (null, false);
            }
            return (result, true);  
        }

        public async Task<bool> UpdateMediaAccount(int id, MediaAccount mediaAccountUpdated)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/MediaAccount/UpdateMediaAccount/{id}", mediaAccountUpdated);
            if(result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
