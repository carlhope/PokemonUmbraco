using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.Security;
using Microsoft.Extensions.Logging;


namespace PokemonUmbraco.Controllers
{


    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IMemberManager _memberManager;
        private readonly MemberSignInManager _signInManager;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            IMemberService memberService,
            IMemberManager memberManager,
            MemberSignInManager signInManager,
            ILogger<AuthController> logger)
        {
            _memberService = memberService;
            _memberManager = memberManager;
            _signInManager = signInManager;
            _logger = logger;
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            _logger.LogInformation("All roles: {roles}", string.Join(", ", _memberService.GetAllRoles()));

            if (_memberService.GetByEmail(dto.Email) != null)
                return BadRequest("Email already exists.");

            var member = _memberService.CreateMember(dto.Email, dto.Email, dto.Email, "Member");
            _memberService.Save(member);

            _memberService.AssignRole(member.Id, "Registered");
            _memberService.Save(member);

            var assigned = _memberService.GetMembersInRole("Registered");
            _logger.LogInformation("Assigned roles: {roles}", string.Join(", ", assigned));


            var newMember = await _memberManager.FindByEmailAsync(dto.Email);
            
            if (newMember == null)
                return BadRequest("Failed to create member.");
            else
            {
                await _memberManager.AddPasswordAsync(newMember, dto.Password);
                await _signInManager.SignInAsync(newMember, isPersistent: false);

                return Ok();
            }
        }

        public class RegisterDto
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }

}
