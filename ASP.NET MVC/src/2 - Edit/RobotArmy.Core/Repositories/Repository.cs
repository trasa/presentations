using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;

namespace RobotArmy.Core.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        protected virtual ISession Session
        {
            get { return NHibernateSession.Current; }
        }

        public T Get(int id)
        {
            return Session.Get<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Session
                .CreateCriteria(typeof(T))
                .List<T>();
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
        }

        public T Save(T entity)
        {
            Session.SaveOrUpdate(entity);
            return entity;
        }

        public List<T> FindAll(T exampleInstance, params string[] propertiesToExclude)
        {
            ICriteria criteria = Session.CreateCriteria(typeof(T));
            Example example = Example.Create(exampleInstance);

            foreach (string propertyToExclude in propertiesToExclude)
            {
                example.ExcludeProperty(propertyToExclude);
            }
            criteria.Add(example);
            return criteria.List<T>().ToList();
        }
    }
}
