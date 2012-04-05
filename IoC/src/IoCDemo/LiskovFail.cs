using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCDemo
{
    class LiskovFail
    {
        private RegularRepository regularRepository;

        public LiskovFail(IRepository repository)
        {
            // FAIL
            regularRepository = (RegularRepository)repository;
        }
    }
}
