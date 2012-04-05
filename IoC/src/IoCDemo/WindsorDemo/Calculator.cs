using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCDemo.WindsorDemo
{
    public class Calculator
    {
        private readonly INumberFactory numberFactory;
        private readonly IOutputService outputService;

        public Calculator(INumberFactory numberFactory, IOutputService outputService)
        {
            this.numberFactory = numberFactory;
            this.outputService = outputService;
        }

        /// <summary>
        /// Gets two numbers from the factory, adds them, and outputs the result.
        /// </summary>
        public void Add()
        {
            int result = numberFactory.Get() + numberFactory.Get();
            outputService.WriteLine("The Result is: " + result);
        }

    }
}
