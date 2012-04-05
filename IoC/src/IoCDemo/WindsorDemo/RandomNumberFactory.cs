using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCDemo.WindsorDemo
{
    public class RandomNumberFactory : INumberFactory
    {
        Random r = new Random();


        public int Get()
        {
            return r.Next(500);
        }
    }
}
