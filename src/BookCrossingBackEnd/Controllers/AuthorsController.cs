﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto;
using Application.Services.Interfaces;
using BookCrossingBackEnd.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookCrossingBackEnd.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthor _authorService;

        public AuthorsController(IAuthor authorService)
        {
            _authorService = authorService;
        }

        // GET: api/Authors/5
        [HttpGet("{id:min(1)}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            var author = await _authorService.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
        
        [HttpGet]
        public async Task<ActionResult<PaginationDto<AuthorDto>>> GetPage([FromQuery] int page, [FromQuery] int pageSize = 10)
        {
            return Ok(await _authorService.GetPage(page,pageSize));
        }
        // PUT: api/Authors
        [ValidationFilter]
        [HttpPut]
        public async Task<IActionResult> PutAuthor(AuthorDto authorDto)
        {
            await _authorService.Update(authorDto);
            return NoContent();
        }

        // POST: api/Authors
        [ValidationFilter]
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> PostAuthor(NewAuthorDto authorDto)
        {
            var author = await _authorService.Add(authorDto);
            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [ValidationFilter]
        [HttpDelete("{id:min(1)}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _authorService.Remove(id);
            if (author == false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
