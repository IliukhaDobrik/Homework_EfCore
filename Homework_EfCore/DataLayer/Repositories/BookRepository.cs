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
    public sealed class BookRepository : IBookRepository
    {
        private readonly MyDBContext _context;

        public BookRepository(MyDBContext context)
        {
            _context = context;
        }

        public Task Add(Book entity)
        {
            return _context.Books.AddAsync(entity).AsTask();
        }

        public async Task Delete(Guid id)
        {
            var book = await GetById(id);

            if (book is null)
            {
                return;
            }

            _context.Remove(book);
        }

        public IQueryable<Book> GetAll()
        {
            return _context.Books.AsQueryable();
        }

        public async Task<Book> GetById(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(Guid id, Book entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
