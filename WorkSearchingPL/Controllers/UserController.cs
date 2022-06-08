using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSearchingBLL.DTOs;
using WorkSearchingBLL.Interfaces;

namespace WorkSearchingPL.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController: Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> GetAll()
        {
            return Ok( _userService.GetAll());
        }


        [HttpPatch]
        [Route("{id}/edit")]
        public async Task<ActionResult> Edit(string id, [FromBody] UserDTO data)
        {
            await _userService.UpdateAsync(data);

            return StatusCode(204); // NoContent
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<ActionResult> Delete(string id)
        {
            await _userService.DeleteByIdAsync(id);

            return StatusCode(204); // NoContent
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }

        [HttpGet]
        [Route("{title}/user")]
        public async Task<ActionResult> GetByForumTitle(string title)
        {
            return Ok(await _userService.GetUserByForumTitle(title));
        }

    }
}
