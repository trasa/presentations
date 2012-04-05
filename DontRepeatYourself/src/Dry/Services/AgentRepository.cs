using System.Collections.Generic;
using System.Linq;
using Dry.Model;

namespace Dry.Services
{
    public class AgentRepository : IRepository<Agent>
    {
        private readonly List<Agent> agents = new List<Agent>();

        public AgentRepository()
        {
            agents.Add(new Agent
                           {
                               Id = 1,
                               Name = "Bob Agent",
                               Contacts = new List<AgentContact>
                                              {
                                                  new AgentContact {FirstName = "Jim", MiddleName = "A.", LastName = "Person"}
                                              }
                           });
        }

        public Agent Get(int id)
        {
            return agents.SingleOrDefault(a => a.Id == id);
        }

        public void Save(Agent a)
        {
            if (!agents.Contains(a))
                agents.Add(a);
        }
    }
}
