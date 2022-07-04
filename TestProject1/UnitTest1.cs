using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {


        public IWebDriver driver;

        [TestMethod]
        public void TestMethod1()
        {
            DirectoryInfo di = new DirectoryInfo(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\..\..")));
           
            string rpath = Path.Combine(di.FullName, @".nuget\packages\selenium.webdriver.chromedriver\");
            
            string[] list = Directory.GetFiles(rpath, "chromedriver.exe", SearchOption.AllDirectories);

            Dictionary<string, DateTime> dctinFile = new Dictionary<string, DateTime>();

           foreach (string s in list)
            {
               
                FileInfo fi = new FileInfo(s);
                var created = Convert.ToDateTime(fi.CreationTime);
                dctinFile.Add(s, created);
            }

            var sortedDict = dctinFile.OrderByDescending(x => x.Value).FirstOrDefault();

            var stringPath =sortedDict.Key.ToString ().Split(new string[] { "chromedriver.exe" }, StringSplitOptions.None);

             driver = new ChromeDriver(stringPath[0]);
             driver.Navigate().GoToUrl("https://www.google.com");          
           
        }


        [TestMethod]
        public void TestEdge()
        {
            DirectoryInfo di = new DirectoryInfo(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\..\..")));

            string rpath = Path.Combine(di.FullName, @".nuget\packages\selenium.webdriver.msedgedriver\");

            string[] list = Directory.GetFiles(rpath, "msedgedriver.exe", SearchOption.AllDirectories);

            Dictionary<string, DateTime> dctinFile = new Dictionary<string, DateTime>();

            foreach (string s in list)
            {

                FileInfo fi = new FileInfo(s);
                var created = Convert.ToDateTime( fi.CreationTime);
                dctinFile.Add(s, created);
            }

            var sortedDict = dctinFile.OrderByDescending(x => x.Value).FirstOrDefault();

            var stringPath = sortedDict.Key.ToString().Split(new string[] { "msedgedriver.exe" }, StringSplitOptions.None);
            var msedgedriverExe = @"msedgedriver.exe";

            var driv = EdgeDriverService.CreateDefaultService(stringPath[0], msedgedriverExe);
            driver = new EdgeDriver(driv);
            driver.Navigate().GoToUrl("https://www.google.com");

        }




    }
}
