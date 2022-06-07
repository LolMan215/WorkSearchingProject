using Microsoft.AspNetCore.Authorization;
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
    [Route("api/comments")]
    public class CommentController: Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateNew([FromBody] CommentDTO data)
        {
            return Ok(_commentService.AddAsync(data));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("forumid/{id:int}")]
        public async Task<ActionResult> GetByForumId(int id)
        {
            return Ok(await _commentService.GetByForumId(id));
        }

        [HttpPatch]
        [Route("{id}/edit")]
        public async Task<ActionResult> Edit(int id, [FromBody] CommentDTO data)
        {
            await _commentService.UpdateAsync(id, data);
            return StatusCode(204);
        }

        [HttpDelete]
        [Route("{id:int}/delete")]
        public async Task<ActionResult> Delete(int id)
        {
            await _commentService.DeleteByIdAsync(id);
            return StatusCode(204);
        }
    }
}
