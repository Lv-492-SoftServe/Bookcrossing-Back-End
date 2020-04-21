﻿using Application.Dto.Comment.Book;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookCrossingBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookChildCommentsController : ControllerBase
    {
        private readonly IBookChildCommentService _childBookCommentService;
        private readonly IUserResolverService _userResolverService;
        public BookChildCommentsController(IBookChildCommentService childBookCommentService, IUserResolverService userResolverService)
        {
            _childBookCommentService = childBookCommentService;
            _userResolverService = userResolverService;
        }
       
        // PUT: api/BookChildCommants
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<int>> Put([FromBody] ChildUpdateDto updateDto)
        {
            if (updateDto.CommentOwnerId != _userResolverService.GetUserId())
            {
                return Forbid();
            }
            int number = await _childBookCommentService.Update(updateDto);
            if (number == 0)
            {
                return NotFound();
            }
            return Ok(number);
        }

        // POST: api/BookChildCommants
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Post([FromBody] ChildInsertDto insertDto)
        {
            insertDto.CommentOwnerId = _userResolverService.GetUserId();
            int number = await _childBookCommentService.Add(insertDto);
            if (number == 0)
            {
                return NotFound();
            }
            return Ok(number);
        }

        // DELETE: api/BookChildCommants
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<int>> Delete([FromBody] ChildDeleteDto deleteDto)
        {
            if (deleteDto.CommentOwnerId != _userResolverService.GetUserId() && !_userResolverService.IsUserAdmin())
            {
                return Forbid();
            }
            int number = await _childBookCommentService.Remove(deleteDto);
            if (number == 0)
            {
                return NotFound();
            }
            return Ok(number);
        }
    }
}
