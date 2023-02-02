using System;
using NUnit.Framework;

namespace DiExample
{
    [SetUpFixture]
    public class ContainerCache
    {
        public static IServiceProvider Container = new Container().BuildServiceProvider();
    }
}