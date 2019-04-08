using Com.Data;
using Com.Repo;
using System;

namespace Com.Services
{
    internal static class UtilFunctions
    {
        public static bool Exists<T>(Guid Id, IRepository repo) where T:BaseEntity
        {
            if (repo.GetById<T>(Id) != null) return true;
             
            return false;

        }
    }
}
