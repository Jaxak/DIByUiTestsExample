using DiExample.Selenium.Page;
using OpenQA.Selenium;

namespace DiExample.Selenium
{
    public interface IBrowser
    {
        TPage GoToPage<TPage>() where TPage : class, IPage;
        TPage GoToPage<TPage>(string path) where TPage : class, IPage;
        void GoToUrl<TPage>(string url) where TPage : class, IPage;
    }

    public class Browser : IBrowser
    {
        #region Реализация

        private readonly IWebDriver _webDriver;
        private readonly IPageFactory _pageFactory;

        public Browser(IWebDriver webDriver, IPageFactory pageFactory)
        {
            _webDriver = webDriver;
            _pageFactory = pageFactory;
        }

        public TPage GoToPage<TPage>() where TPage : class, IPage
            => _pageFactory.Create<TPage>(_webDriver);

        public TPage GoToPage<TPage>(string path) where TPage : class, IPage
            => _pageFactory.Create<TPage>(_webDriver, path);

        public void GoToUrl<TPage>(string url) where TPage : class, IPage
            => _webDriver.Navigate().GoToUrl(url);

        #endregion
    }
}