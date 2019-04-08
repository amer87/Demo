using Com.Data;
using Com.Repo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Services
{
    public class UsersService : BaseService<User>,  IUsersService
    {

        public UsersService(IRepository repo) : base(repo){}

        public IEnumerable<User> GetUsers() => GetAll();

        public User GetUser(Guid id) => GetById(id);

        public void UpdateUser(Guid Id, User user) => Update(Id, user);

        public void DeleteUser(Guid Id) => Delete(Id);
        
        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {

                AddError("Username and password are required");
                return null;
            }

            var user = _repo.Get<User>(x=>x.UserName == username).FirstOrDefault();
            if (user == null)
            {
                AddError("Username is wrong");
                return null;
            }

            if (!VerifyPasswordHash(password, user.Password))
            {
                AddError("Password is wrong");
                return null;
            }

            return user;
        }

        public User Register(User user) 
        {
            if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                AddError("Username and password are required");
                return null;
            }

            if (_repo.Get<User>(x=> x.UserName == user.UserName) != null)
            {
                AddError("Username is already in use");
                return null;
            }

            user.Password = SecurePasswordHasher.Hash(user.Password);
            return Create(user);
        }

        private bool VerifyPasswordHash(string password, string storedPassword)
        {
            return SecurePasswordHasher.Verify(password, storedPassword);
        }
    }
}
