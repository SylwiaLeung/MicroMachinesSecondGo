using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using UserService.Services;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;

        public UsersController(IMapper mapper, IUserRepository userRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserReadDto>> GetUserById(int userId)
        {
            var user = await _userRepo.GetSingle(userId);

            if (user == null)
                return NotFound("No such user found");

            return Ok(_mapper.Map<UserReadDto>(user));
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserReadDto>> UpdateUserFunds(int userId, [FromQuery] decimal amount)
        {
            var user = await _userRepo.GetSingle(userId);

            if (user == null)
                return NotFound();

            user.Funds += amount;
            await _userRepo.Save();

            return Ok(_mapper.Map<UserReadDto>(user));
        }
    }
}
