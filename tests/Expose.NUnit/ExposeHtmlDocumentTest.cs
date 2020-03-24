using Expose.Main;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expose.NUnit
{
    public class ExposeHtmlDocumentTest
    {
        private ExposeHtmlDocument document;        

        [SetUp]
        public void Setup()
        {
            document = new ExposeHtmlDocument(Constants.URL_STACKOVERFLOW_PT);      
        }

        [Test]
        public async Task CountCss_Should_Return_Value_Grater_Than_Zero_Async()
        {            
           
            int value = await document.CountCSSAsync();

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public void CountCss_Should_Return_Value_Grater_Than_Zero()
        {

            int value = document.CountCss();

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public async Task CountJs_Should_Return_Value_Grater_Than_Zero_Async()
        {
            int value = await document.CountJSAsync();

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public void CountJs_Should_Return_Value_Grater_Than_Zero()
        {
            int value = document.CountJS();            

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public async Task CountHtmlElements_Should_Return_Value_Grater_Than_Zero_Async()
        {
            int value = await document.CountHtmlElementsAsync();

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public void CountHtmlElements_Should_Return_Value_Grater_Than_Zero()
        {
            int value = document.CountHtmlElements();

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public async Task CountMeta_Should_Return_Value_Grater_Than_Zero_Async()
        {
            int value = await document.CountMetaAsync();

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public void CountMeta_Should_Return_Value_Grater_Than_Zero()
        {
            int value = document.CountMeta();

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public async Task GetJSContent_Should_Return_Value_Grater_Than_Zero_Async()
        {
            var hsJS = await document.GetJSContentAsync();
            int value = hsJS.Count;

            Assert.Greater(value, Constants.ZERO);

        }

        [Test]
        public void GetJSContent_Should_Return_Value_Grater_Than_Zero()
        {
            var hsJS = document.GetJSContent();
            int value = hsJS.Count;

            Assert.Greater(value, Constants.ZERO);

        }

        [Test]
        public async Task GetCSSContent_Should_Return_Value_Grater_Than_Zero_Async()
        {
            var hsCSS = await document.GetCSSContentAsync();
            int value = hsCSS.Count;

            Assert.Greater(value, Constants.ZERO);

        }

        [Test]
        public void GetCSSContent_Should_Return_Value_Grater_Than_Zero()
        {
            var hsCSS = document.GetCSSContent();
            int value = hsCSS.Count;

            Assert.Greater(value, Constants.ZERO);

        }

        [Test]
        public async Task CountOnclickEvents_Should_Return_Value_Grater_Than_Zero_Async()
        {
            int value = await document.CountOnclickEventsAsync();

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public void CountOnclickEvents_Should_Return_Value_Grater_Than_Zero()
        {
            int value = document.CountOnclickEvents();

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public async Task CountForms_Should_Return_Value_Grater_Than_Zero_Async()
        {
            int value = await document.CountFormsAsync();

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public void CountForms_Should_Return_Value_Grater_Than_Zero()
        {
            int value = document.CountForms();

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public async Task FormsInfo_Should_Return_Value_Grater_Than_Zero_Async()
        {
            Dictionary<string,string> dicForms = await document.FormsInfoAsync();
            int value = dicForms.Count;

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public void FormsInfo_Should_Return_Value_Grater_Than_Zero()
        {
            Dictionary<string, string> dicForms = document.FormsInfo();
            int value = dicForms.Count;

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public async Task GetSizeOfPage_Should_Return_Value_Grater_Than_Zero_Async()
        {
            long? value = await document.GetSizeOfPageAsync();

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public void GetSizeOfPage_Should_Return_Value_Grater_Than_Zero()
        {
            long? value = document.GetSizeOfPage();

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]        
        public async Task GetOnClickValue_Should_Return_Value_Grater_Than_Zero_Async()
        {
            HashSet<string> hsOnclick = await document.GetOnClickValueAsync();
            int countEvents = await document.CountOnclickEventsAsync();
            
            int value = hsOnclick.Count;

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public void GetOnClickValue_Should_Return_Value_Grater_Than_Zero()
        {
            HashSet<string> hsOnclick = document.GetOnClickValue();
            int countEvents = document.CountOnclickEvents();
            int value = hsOnclick.Count;

            Assert.Greater(value, Constants.ZERO);
        }

        [Test]
        public async Task GetReport_Should_Return_Value_Grater_Than_Zero_Async()
        {
            string json = await document.GetReportAsync();
            int value = json.Length;

            Assert.Greater(value, Constants.ZERO);

        }

        [Test]
        public void GetReport_Should_Return_Value_Grater_Than_Zero()
        {
            string json = document.GetReport();
            int value = json.Length;

            Assert.Greater(value, Constants.ZERO);

        }

        [Test]
        public async Task HasAjaxCall_Should_Return_False_Async()
        {
            Assert.IsTrue(await document.HasAjaxCallAsync());
            
        }

        [Test]
        public void HasAjaxCall_Should_Return_False()
        {
            Assert.IsTrue(document.HasAjaxCall());
        }
    }
}