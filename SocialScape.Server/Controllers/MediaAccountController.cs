using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialScape.Server.Repositories.MediaAccountRep;
using SocialScape.Shared.Models.MediaAccountFold;

namespace SocialScape.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaAccountController : ControllerBase
    {
        private readonly IMediaAccountRepository _mediaAccountRepository;

        public MediaAccountController(IMediaAccountRepository mediaAccountRepository)
        {
            _mediaAccountRepository = mediaAccountRepository;
        }


        [HttpGet("GetMediaAccountByEmail/{email}")]
        public async Task<IActionResult> GetMediaAccountByEmail(string email)
        {
            var result = await _mediaAccountRepository.GetMediaAccountByEmail(email);
            if(result is null)
            {
                return NotFound();
            }
            return Ok(result);  
        }


        [HttpPut("UpdateMediaAccount/{id}")]
        public async Task<IActionResult> UpdateMediaAccount(int id, MediaAccount mediaAccountUpdated)
        {
            var mediaAccount = await _mediaAccountRepository.GetMediaAccountById(id);
            if(mediaAccount is null)
            {
                return NotFound();
            }

            mediaAccount.Photo = mediaAccountUpdated.Photo;
            mediaAccount.Email = mediaAccountUpdated.Email;
            mediaAccount.FullName = mediaAccountUpdated.FullName;   
            mediaAccount.UserName = mediaAccountUpdated.UserName;
            mediaAccount.Description = mediaAccountUpdated.Description;


           var resultUpdate = _mediaAccountRepository.Update(mediaAccount);
            if(resultUpdate)
            {
                return Ok("Updated");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
       
    }
}
