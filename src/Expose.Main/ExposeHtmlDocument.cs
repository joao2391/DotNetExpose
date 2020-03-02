using AngleSharp;
using AngleSharp.Dom;
using Expose.Main.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Expose.Main
{
    public class ExposeHtmlDocument : IHtmlDocument
    {
        /// <summary>
        /// Initial config
        /// </summary>
        private readonly IConfiguration _config;
        private readonly IBrowsingContext _browsingContext;
        private readonly IDocument _document;
        private string _url = string.Empty;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">The url that will be "scrapped"</param>
        public ExposeHtmlDocument(string url)
        {
            _config = Configuration.Default.WithDefaultLoader();            
            _browsingContext = BrowsingContext.New(_config);
            _document = _browsingContext.OpenAsync(url).Result;
            _url = url;
        }

        /// <summary>
        /// Count the CSS referenced
        /// </summary>
        /// <returns>Return total of CSS files referenced in the html page</returns>
        public async Task<int> CountCSSAsync()
        {
            var document = await _browsingContext.OpenAsync(_url);            
            
            
            int countCSS = 0;//document.Head.GetElementsByTagName("link").Length;

            CountCSSInHeadChildren(ref countCSS, document);
            CountCSSInBodyChildren(ref countCSS, document);

            return countCSS;

        }
      
        /// <summary>
        /// Count the CSS referenced
        /// </summary>
        /// <returns>Return total of CSS files referenced in the html page</returns>
        public int CountCss()
        {           

            int countCSS = 0;//document.Head.GetElementsByTagName("link").Length;

            CountCSSInHeadChildren(ref countCSS, _document);
            CountCSSInBodyChildren(ref countCSS, _document);


            return countCSS;
        }

        /// <summary>
        /// Count the JS referenced
        /// </summary>
        /// <returns>Return total of JS files referenced in the html page</returns>
        public async Task<int> CountJSAsync()
        {
            var document = await _browsingContext.OpenAsync(_url);

            int countJs = document.Head.GetElementsByTagName("script").Length;

            return countJs;
        }

        /// <summary>
        /// Count the JS referenced
        /// </summary>
        /// <returns>Return total of JS files referenced in the html page</returns>
        public int CountJS()
        {
            int countJs = _document.Head.GetElementsByTagName("script").Length;

            return countJs;
        }

        /// <summary>
        /// Count the Html Elements
        /// </summary>
        /// <returns>Return total of Html Elements</returns>
        public async Task<int> CountHtmlElementsAsync()
        {
            var document = await _browsingContext.OpenAsync(_url);

            int headElementsCount = document.Head.ChildElementCount;
            int bodyElementsCount = document.Body.ChildElementCount;

            int countHtmlElements = headElementsCount + bodyElementsCount;

            return countHtmlElements;
        }

        /// <summary>
        /// Count the Html Elements
        /// </summary>
        /// <returns>Return total of Html Elements</returns>
        public int CountHtmlElements()
        {
            int headElementsCount = _document.DocumentElement.Children[0].ChildElementCount;
            int bodyElementsCount = _document.DocumentElement.Children[1].ChildElementCount;

            int countHtmlElements = headElementsCount + bodyElementsCount;

            return countHtmlElements;
        }

        /// <summary>
        /// Count the META elements
        /// </summary>
        /// <returns>Return total of META elements</returns>
        public async Task<int> CountMetaAsync()
        {
            var document = await _browsingContext.OpenAsync(_url);

            int metaElementsCount = document.Head.GetElementsByTagName("META").Length;

            return metaElementsCount;
        }

        /// <summary>
        /// Count the META elements
        /// </summary>
        /// <returns>Return total of META elements</returns>
        public int CountMeta()
        {
            int metaElementsCount = _document.Head.GetElementsByTagName("META").Length;

            return metaElementsCount;
        }

        /// <summary>
        /// Get the text content from <script> Html Tag 
        /// </summary>
        /// <returns>A HashSet of string containing the JavaScript</returns>
        public async Task<HashSet<string>> GetJSContentAsync()
        {
            var document = await _browsingContext.OpenAsync(_url);            
            HashSet<string> hsJs = new HashSet<string>();            
            var scripts = document.Body.Children.Filter("script");

            foreach (var item in scripts)
            {
                hsJs.Add(item.TextContent);
            }            
            
            return hsJs;
        }

        /// <summary>
        /// Get the text content from <script> Html Tag 
        /// </summary>
        /// <returns>A HashSet of string containing the JavaScript</returns>
        public HashSet<string> GetJSContent()
        {            
            HashSet<string> hsJs = new HashSet<string>();
            var scripts = _document.Body.Children.Filter("script");

            foreach (var item in scripts)
            {
                hsJs.Add(item.TextContent);
            }

            return hsJs;
        }

        /// <summary>
        /// Get the text content from <style> Html Tag 
        /// </summary>
        /// <returns>A HashSet of string containing the CSS</returns>
        public async Task<HashSet<string>> GetCSSContentAsync()
        {
            var document = await _browsingContext.OpenAsync(_url);
            HashSet<string> hsCss = new HashSet<string>();            
            
            var scripts = document.GetElementsByTagName("style");

            foreach (var item in scripts)
            {
                hsCss.Add(item.TextContent);
            }

            return hsCss;
        }

        /// <summary>
        /// Get the text content from <style> Html Tag 
        /// </summary>
        /// <returns>A HashSet of string containing the CSS</returns>
        public HashSet<string> GetCSSContent()
        {
            HashSet<string> hsCss = new HashSet<string>();
            var scripts = _document.GetElementsByTagName("style");

            foreach (var item in scripts)
            {
                hsCss.Add(item.TextContent);
            }

            return hsCss;
        }

        /// <summary>
        /// Count the button events
        /// </summary>
        /// <returns>The total of events in all of buttons in the html</returns>
        public async Task<int> CountButtonJSEventsAsync()
        {            
            int countEvents = 0;

            countEvents = await CountJSEvents();

            return countEvents;
        }

        /// <summary>
        /// Count the button events
        /// </summary>
        /// <returns>The total of events in all of buttons in the html</returns>
        public int CountButtonJSEvents()
        {
            int countEvents = 0;

            //countEvents = CountJSEvents().Result;

            return countEvents;
        }

        /// <summary>
        /// Count the amount of Forms in the HTML
        /// </summary>
        /// <returns>Total of Forms in html page</returns>
        public async Task<int> CountFormsAsync()
        {
            var document = await _browsingContext.OpenAsync(_url);
            int countForms = document.Body.GetElementsByTagName("form").Length;

            return countForms;
        }

        /// <summary>
        /// Count the amount of Forms in the HTML
        /// </summary>
        /// <returns>Total of Forms in html page</returns>
        public int CountForms()
        {            
            int countForms = _document.Body.GetElementsByTagName("form").Length;

            return countForms;
        }

        /// <summary>
        /// Information about the forms
        /// </summary>
        /// <returns>Action and HttpMethod from Form</returns>
        public async Task<Dictionary<string, string>> FormsInfoAsync()
        {
            var document = await _browsingContext.OpenAsync(_url);
            Dictionary<string, string> dicForm = new Dictionary<string, string>();

            FillDic(ref dicForm, document);

            return dicForm;
        }

        /// <summary>
        /// Information about the forms
        /// </summary>
        /// <returns>Action and HttpMethod from Form</returns>
        public Dictionary<string, string> FormsInfo()
        {            
            Dictionary<string, string> dicForm = new Dictionary<string, string>();

            FillDic(ref dicForm, _document);

            return dicForm;
        }

        /// <summary>
        /// The size of the page
        /// </summary>
        /// <returns>The size in Kb of the page</returns>
        public async Task<long?> GetSizeOfPageAsync()
        {
            var document = await _browsingContext.OpenAsync(_url);
            HttpClient client = new HttpClient();
            long? sizeOfPage = 0;
            var result = await client.GetAsync(_url);
            var tamanho = result.Content.Headers.ContentLength;
             sizeOfPage = tamanho / 1024;

            return sizeOfPage;
        }

        /// <summary>
        /// The size of the page
        /// </summary>
        /// <returns>The size in Kb of the page</returns>
        public long? GetSizeOfPage()
        {            
            HttpClient client = new HttpClient();
            long? sizeOfPage = 0;
            var result = client.GetAsync(_url).Result;
            var tamanho = result.Content.Headers.ContentLength;
            sizeOfPage = tamanho / 1024;

            return sizeOfPage;
        }

        #region Private Methods

        private int CountCSSInBodyChildren(ref int countCSS, IDocument document)
        {
            var bodyChildren = document.Body.Children;

            for (int i = 0; i < bodyChildren.Length; i++)
            {

                if (bodyChildren[i].IsLink())
                {
                    if (bodyChildren[i].GetAttribute(AttributeNames.Rel).Contains("stylesheet"))
                    {
                        countCSS++;
                    }

                }
                else if (bodyChildren[i].TagName == "STYLE")
                {
                    countCSS++;
                }
            }

            return countCSS;
        }
        private int CountCSSInHeadChildren(ref int countCSS, IDocument document)
        {
            var headChildren = document.Head.Children;

            for (int i = 0; i < headChildren.Length; i++)
            {

                if (headChildren[i].IsLink())
                {
                    if (headChildren[i].GetAttribute(AttributeNames.Rel).Contains("stylesheet"))
                    {
                        countCSS++;
                    }

                }
                else if (headChildren[i].TagName == "STYLE")
                {
                    countCSS++;
                }
            }

            return countCSS;
        }      

        private async Task<int> CountJSEvents()
        {
            HttpClient client = new HttpClient();
            int countEvents = 0;
            var result = await client.GetAsync(_url).Result.Content.ReadAsStringAsync();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(result);
                        
            var body = doc.DocumentNode.SelectSingleNode("//body");

            for (int i = 0; i < body.ChildNodes.Count; i++)
            {
                if (body.ChildNodes[i].ChildNodes.Count > 0)
                {
                    for (int j = 0; j < body.ChildNodes[i].ChildNodes.Count; j++)
                    {
                        if (body.ChildNodes[i].ChildNodes[j].Attributes.Contains("onclick"))
                        {
                            countEvents++;

                        }
                    }
                }
            }


            return countEvents;
        }

        private Dictionary<string, string> FillDic(ref Dictionary<string, string> dicForm, IDocument document)
        {
            if (CountFormsAsync().Result > 0)
            {
                var forms = document.Body.GetElementsByTagName("form");

                for (int i = 0; i < forms.Length; i++)
                {
                    string action = forms[i].GetAttribute(AttributeNames.Action);
                    string httpMethod = forms[i].GetAttribute(AttributeNames.Method);

                    dicForm.Add(action, httpMethod);
                }
            }

            return dicForm;
        }

        #endregion

    }
}
