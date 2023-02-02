using System;
using System.Threading.Tasks;
using DiExample.Selenium;
using DiExample.Selenium.Page;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DiExample
{
    public class SetUpTest
    {
        private IServiceProvider container => ContainerCache.Container;

        [Test]
        public void BrowserShouldBeContainContainer()
        {
            Assert.NotNull(container.GetService<IBrowser>());
        }

        [Test]
        public void PageFactoryShouldBeContainContainer()
        {
            Assert.NotNull(container.GetService<IPageFactory>());
        }

        [Test]
        public void WebDriverFactoryShouldBeContainContainer()
        {
            Assert.NotNull(container.GetService<IWebDriver>());
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await (container as ServiceProvider).DisposeAsync();
        }
    }
}