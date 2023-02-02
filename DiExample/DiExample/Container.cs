using System;
using DiExample.Selenium;
using DiExample.Selenium.Page;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DiExample
{
    public class Container
    {
        public IServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
                .AddTransient<IBrowser, Browser>()
                .AddTransient<IWebDriver, ChromeDriver>()
                .AddScoped<IPageFactory, PageFactory>()
                .BuildServiceProvider();
        }
    }
}