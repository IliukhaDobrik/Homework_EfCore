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
    public class UserBookRepository : IUserBookRepository
    {
        private readonly MyDBContext _context;

        public UserBookRepository(MyDBContext context)
        {
            _context = context;
        }

        public IQueryable<UserBook> GetAll()
        {
            return _context.UserBooks.AsQueryable();
        }

        public Task Add(UserBook entity)
        {
            return _context.UserBooks.AddAsync(entity).AsTask();
        }

        public async Task Delete(Guid id)
        {
            var userBook = await GetById(id);
        }

        public async Task<UserBook> GetById(Guid id)
        {
            return await _context.UserBooks.FindAsync(id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(Guid id, UserBook entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
