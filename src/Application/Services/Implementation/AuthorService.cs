﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto;
using AutoMapper;
using Domain.RDBMS;
using Domain.RDBMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implementation
{
    public class AuthorService : Interfaces.IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IRepository<Author> authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> GetById(int authorId)
        {
            return _mapper.Map<AuthorDto>(await _authorRepository.FindByIdAsync(authorId));
        }

        public async Task<List<AuthorDto>> GetAll()
        {
            return _mapper.Map<List<AuthorDto>>(await _authorRepository.GetAll().ToListAsync());
        }
        public async Task<AuthorDto> Add(InsertAuthorDto insertAuthorDto)
        {
            var author = _mapper.Map<Author>(insertAuthorDto);
            _authorRepository.Add(author);
            await _authorRepository.SaveChangesAsync();
            return _mapper.Map<AuthorDto>(author);
        }
        public async Task<bool> Remove(int authorId)
        {
            var author = await _authorRepository.FindByIdAsync(authorId);
            if (author == null)
            {
                return false;
            }
            _authorRepository.Remove(author);
            var affectedRows = await _authorRepository.SaveChangesAsync();
            return affectedRows > 0;
        }
        public async Task<bool> Update(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            author = await _authorRepository.FindByIdAsync(author.Id);
            if (author == null)
            {
                return false;
            }
            _authorRepository.Update(author);
            var affectedRows = await _authorRepository.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}
