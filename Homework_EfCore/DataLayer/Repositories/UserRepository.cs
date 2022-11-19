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
    public sealed class UserRepository : IUserRepository
    {
        private readonly MyDBContext _context;

        public UserRepository(MyDBContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users.AsQueryable();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public Task Add(User entity)
        {
            return _context.Users.AddAsync(entity).AsTask();
        }

        public async Task Delete(Guid id)
        {
            var user = await GetById(id);

            if (user is null)
            {
                return;
            }

            _context.Users.Remove(user);
        }

        public void Update(Guid id, User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
