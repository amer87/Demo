using Com.Data;
using System;
using System.Collections.Generic;

namespace Com.Services
{
    public interface IUsersService
    {
        /// <summary>
        /// Get all the errors
        /// </summary>
        /// <returns></returns>
        List<string> GetErrors();

        /// <summary>
        /// This function is responsible to auth the user giving their username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>User object if the auth succeeded</returns>
        User Authenticate(string username, string password);

        /// <summary>
        /// Get all the users
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetUsers();

        /// <summary>
        /// Get one user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        User GetUser(Guid id);

        /// <summary>
        /// This function takes a user object and registers it in the system
        /// </summary>
        /// <param name="user">User details</param>
        User Register(User user);

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="user"></param>
        void UpdateUser(Guid Id, User user);

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="Id"></param>
        void DeleteUser(Guid id);
    }
}
