using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthorsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors(CancellationToken cancellationToken)
        {
            var owners = await _serviceManager.AuthorService.GetAllAsync(cancellationToken);

            return Ok(owners);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] AuthorCreationDto ownerForCreationDto)
        {
            var ownerDto = await _serviceManager.AuthorService.CreateAsync(ownerForCreationDto);

            return Ok();
        }
    }
}
