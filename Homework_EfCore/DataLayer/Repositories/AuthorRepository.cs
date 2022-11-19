using DataLayer.Repositories.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public sealed class AuthorRepository : IAuthorRepository
    {
        private readonly MyDBContext _context;

        public AuthorRepository(MyDBContext context)
        {
            _context = context;
        }

        public IQueryable<Author> GetAll()
        {
            return _context.Authors.AsQueryable();
        }

        public async Task<Author> GetById(Guid id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public Task Add(Author entity)
        {
            return _context.Authors.AddAsync(entity).AsTask();
        }

        public async Task Delete(Guid id)
        {
            var author = GetById(id);

            if (author is null)
            {
                return;
            }

            _context.Remove(author);
        }

        public void Update(Guid id, Author entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
