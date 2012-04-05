using System.Collections.Generic;

namespace RobotArmy.Core.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        void Delete(T entity);

        T Save(T entity);

        List<T> FindAll(T exampleInstance, params string[] propertiesToExclude);
    }
}
