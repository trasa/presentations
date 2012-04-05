using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCDemo
{
    public class RegularController
    {
        private RegularRepository repository;
        private RegularValidator validator;

        // RegularController makes demands about its dependencies.
        public RegularController()
        {
            repository = new RegularRepository();
            validator = new RegularValidator();
        }
    }
}
