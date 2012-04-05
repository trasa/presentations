using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace Blackfin.Cms.Test
{
    [TestFixture]
    public class FooFixture
    {
        [Test]
        public void Foo()
        {
            MockRepository mocks = new MockRepository();
            MyClass c = mocks.CreateMock<MyClass>();
            using (mocks.Record())
            {
                Expect.Call(c.Bar()).Return(2);
            }
            using(mocks.Playback())
            {
                Assert.AreEqual(7, c.Foo());
            }
        }
    }

    public class MyClass
    {
        public int Foo()
        {
            // stuff happens here
            int i = Bar();
            // do more stuff here    
            return i + 5;
        }

        public virtual int Bar()
        {
            // do some logic
            return 1;
        }
    }

}
