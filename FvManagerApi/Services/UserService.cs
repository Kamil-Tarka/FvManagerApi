using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FvManagerApi.Entities;
using FvManagerApi.Exceptions;
using FvManagerApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FvManagerApi.Services
{
    public class UserService : IUserService
    {
        private readonly FvManagerDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;

        public UserService(FvManagerDbContext dbContext, IPasswordHasher<User> passwordHasher, IMapper mapper)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public void Delete(int userId)
        {
            var user = _dbContext.User.FirstOrDefault(u => u.Id == userId);

            if (user is null)
            {
                throw new NotFoundException("User not found");
            }

            if (user.IsActive)
            {
                throw new ForbiddenException("Delete active user is not allowed.");
            }

            _dbContext.User.Remove(user);
            _dbContext.SaveChanges();
        }

        public void DisableUser(int userId)
        {
            var user = _dbContext.User.FirstOrDefault(u => u.Id == userId);

            if (user is null)
            {
                throw new NotFoundException("User not found");
            }

            user.IsActive = false;

            _dbContext.SaveChanges();
        }

        public void EnableUser(int userId)
        {
            var user = _dbContext.User.FirstOrDefault(u => u.Id == userId);

            if (user is null)
            {
                throw new NotFoundException("User not found");
            }

            user.IsActive = true;

            _dbContext.SaveChanges();
        }

        public List<UserDto> GetAll(string searchName, string searchEmail, string searchRole, string searchIsActive)
        {
            var users = _dbContext.User
                .Include(u => u.Role)
                .Where(u => searchName == null || u.UserName.Contains(searchName))
                .Where(u => searchEmail == null || u.UserEmail.Contains(searchEmail))
                .Where(u => searchIsActive == null || u.IsActive == bool.Parse(searchIsActive))
                .Where(u => searchRole == null || u.Role.Name.Contains(searchRole))
                .ToList();

            var usersDto = _mapper.Map<List<UserDto>>(users);

            return usersDto;
        }

        public UserDto GetById(int userId)
        {
            var user = _mapper.Map<UserDto>(_dbContext.User.Include(u => u.Role).FirstOrDefault(u => u.Id == userId));

            return user;
        }

        public void Update(int userId, UpdateUserDto dto)
        {
            var user = _dbContext.User.FirstOrDefault(u => u.Id == userId);

            if (user is null)
            {
                throw new NotFoundException("Invalid username or password");
            }

            if (dto.UserName is not null && dto.UserName != user.UserName)
            {
                user.UserName = dto.UserName;
            }
            if (dto.UserEmail is not null && dto.UserEmail != user.UserEmail)
            {
                user.UserEmail = dto.UserEmail;
            }
            if (dto.NewPassword is not null)
            {
                var hashedPassword = _passwordHasher.HashPassword(user, dto.NewPassword);
                user.PasswordHash = hashedPassword;
            }
            if (dto.RoleId > 0 && dto.RoleId != user.RoleId)
            {
                user.RoleId = dto.RoleId;
            }

            _dbContext.SaveChanges();
        }
    }
}
