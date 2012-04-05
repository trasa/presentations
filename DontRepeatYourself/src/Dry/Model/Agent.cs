using System.Collections.Generic;

namespace Dry.Model
{
    public class Agent
    {
        public Agent()
        {
            Contacts = new List<AgentContact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IList<AgentContact> Contacts { get; set; }
    }
}
