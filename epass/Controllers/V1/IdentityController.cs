using epass.Contracts;
using epass.Contracts.V1.Requests;
using epass.Contracts.V1.Responses;
using epass.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epass.Controllers.V1 
{
    public class IdentityController: Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }


        [HttpPost(ApiRoutes.identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var AuthResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            if (!AuthResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = AuthResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse 
            { 
                Token = AuthResponse.Token
            });
        }
    }
}
