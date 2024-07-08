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

       
    }
}
