using Com.Data;
using Com.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
namespace Com.Services
{
    public abstract class BaseService<T> where T : BaseEntity
    {
        internal IRepository _repo;
        private List<string> _errors;

        internal BaseService(IRepository repo)
        {
            _repo = repo;
            _errors = new List<string>();
        }

        internal IEnumerable<T> GetAll() => _repo.GetAll<T>();

        internal T GetById(Guid Id)
        {
            try
            {
                Guards.IsNotEmptyGuid(Id, "Id");
                return _repo.GetById<T>(Id);
            }
            catch (ArgumentException ex)
            {
                _errors.Add(ex.Message);
                return null;
            }
        }

        internal T Create(T entity)
        {
            try
            {
                _repo.Create(entity);
                _repo.Save();
            }
            catch (Exception ex)
            {
                _errors.Add($"Internal error {nameof(entity)} was not created : {ex.Message}");
            }

            return entity;
        }

        internal void Update(Guid Id, T enttity)
        {
            if (Id != enttity.Id)
            {
                _errors.Add("Access Violation ");
            }

            try
            {
                _repo.Update(enttity);
                _repo.Save();
            }
            catch (DbUpdateConcurrencyException ex) when(UtilFunctions.Exists<T>(Id, _repo))
            {
                _errors.Add($"Internal error {nameof(enttity)} was not updated, {ex.Message}");
            }

        }

        internal void Delete(Guid Id)
        {
            var enttity = _repo.GetById<T>(Id);
            if (enttity == null)
            {
                _errors.Add($"{nameof(enttity)}  is not found");
            }

            try
            {
                _repo.Delete(enttity);
                _repo.Save();
            }
            catch (Exception ex)
            {
                _errors.Add($"Internal error {nameof(enttity)} was not deleted : {ex.Message}");
            }
        }

        internal void AddError(string error)
        {
            if (string.IsNullOrEmpty(error)) return;

            _errors.Add(error);
        }

        public virtual List<string> GetErrors() => _errors;
        
    }
}
