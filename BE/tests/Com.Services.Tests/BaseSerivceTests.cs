using Com.Data;
using Com.Repo;
using Moq;
using System;
using System.Linq;
using System.Linq.Expressions;
using Moq.Language.Flow;

namespace Com.Services.Tests
{
    public abstract class BaseSerivceTests<T> 
        where T: BaseEntity
    {
        internal Mock<IRepository> _mockRepo = new Mock<IRepository>(MockBehavior.Strict);


        public ISetup<IRepository, IQueryable<T>> GetRepoGetSetUp() => _mockRepo.Setup(m => m.Get(
                It.IsAny<Expression<Func<T, bool>>>(),
                It.IsAny<Func<IQueryable<T>, IOrderedQueryable<T>>>(),
                It.IsAny<string>(),
                It.IsAny<int?>(),
                It.IsAny<int?>()));

        public ISetup<IRepository, IQueryable<T>> GetRepoGetAllSetUp() => _mockRepo.Setup(m => m.GetAll(
                It.IsAny<Func<IQueryable<T>, IOrderedQueryable<T>>>(),
                It.IsAny<string>(),
                It.IsAny<int?>(),
                It.IsAny<int?>()));

        public ISetup<IRepository, T> GetRepoGetByIdSetUp() => _mockRepo.Setup(m => m.GetById<T>(It.IsAny<Guid>()));

        public ISetup<IRepository> GetRepoCreateSetUp() => _mockRepo.Setup(m => m.Create(It.IsAny<T>()));

        public ISetup<IRepository> GetRepoSaveSetUp() => _mockRepo.Setup(m => m.Save());
    }
}
