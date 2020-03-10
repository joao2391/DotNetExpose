using System;

namespace Expose.Main
{
    /// <summary>
    /// Report about the DOM
    /// </summary>
    public class ReportHtmlDocument
    {
        /// <summary>
        /// The Id of Report
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// How many CSS is in the page
        /// </summary>
        public int AmountCSS { get; set; }

        /// <summary>
        /// How many JS is in the page
        /// </summary>
        public int AmountJS { get; set; }

        /// <summary>
        /// How many Html Elements is in the page
        /// </summary>
        public int AmountHtmlElements { get; set; }

        /// <summary>
        /// How many Meta is in the page
        /// </summary>
        public int AmountMeta { get; set; }

        /// <summary>
        /// How many JS Event is in the page
        /// </summary>
        public int AmountButtonJSEvents { get; set; }

        /// <summary>
        /// How many Forms is in the page
        /// </summary>
        public int AmountForms { get; set; }

        /// <summary>
        /// How many Forms info is in the page
        /// </summary>
        public int AmountFormsInfo { get; set; }

        /// <summary>
        /// How many JS Content is in the page
        /// </summary>
        public int AmountJSContent { get; set; }

        /// <summary>
        /// How many CSS Content is in the page
        /// </summary>
        public int AmountCSSContent { get; set; }

    }
}
