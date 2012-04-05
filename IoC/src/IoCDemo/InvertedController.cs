using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCDemo
{
    public class InvertedController
    {
        private IRepository repository;
        private IValidator validator;

        // InvertedController is "given" its dependencies.
        public InvertedController(IRepository repository, IValidator validator)
        {
            this.repository = repository;
            this.validator = validator;
        }
    }
}
