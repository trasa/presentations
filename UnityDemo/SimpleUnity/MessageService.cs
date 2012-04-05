using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleUnity
{
    public interface IMessageService
    {
        string GetMessage();
    }


    public class HappyMessageService : IMessageService
    {
        public string GetMessage()
        {
            return "HAI!";
        }
    }

    public class SadMessageService : IMessageService
    {
        public string GetMessage()
        {
            return "oh, hi.";
        }
    }
}
