using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expose.Main.Interfaces
{
    interface IHtmlDocument
    {
        Task<int> CountCSSAsync();
        int CountCss();

        Task<int> CountJSAsync();
        int CountJS();

        Task<int> CountHtmlElementsAsync();
        int CountHtmlElements();

        Task<int> CountMetaAsync();
        int CountMeta();

        Task<int> CountOnclickEventsAsync();
        int CountOnclickEvents();

        Task<int> CountFormsAsync();
        int CountForms();

        Task<long?> GetSizeOfPageAsync();
        long? GetSizeOfPage();

        Task<string> GetReportAsync();
        string GetReport();

        Task<bool> HasAjaxCallAsync();
        bool HasAjaxCall();

        Task<Dictionary<string,string>> FormsInfoAsync();
        Dictionary<string, string> FormsInfo();

        Task<HashSet<string>> GetJSContentAsync();
        HashSet<string> GetJSContent();

        Task<HashSet<string>> GetOnClickValueAsync();
        HashSet<string> GetOnClickValue();

        Task<HashSet<string>> GetCSSContentAsync();
        HashSet<string> GetCSSContent();
    }

}
