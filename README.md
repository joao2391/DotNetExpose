# DotNetExpose

DotNetExpose is a .Net library for helping you to scrap web pages. It shows you a lot of information about the page.

## Notes
Version 1.0.1:
Added a report function. It allows you to get a report on all information. The return type is a JSON.

## Installation

Use the package manager to install.

```bash
Install-Package DotNetExpose -Version 1.0.1
```

## Usage

After install the package:
```C#
using Expose.Main;
```

Create an instance of ExposeHtmlDocument. The constructor needs an URL. This URL will be scraped.
```C#
const string URL = "https://www.google.com.br/"

ExposeHtmlDocument expose = new ExposeHtmlDocument(URL);
```
 
Return total of CSS files referenced in the html page
```C#
int countCSS = expose.CountCSSAsync();
```
Return total of JS files referenced in the html page
```C#
int countJS = expose.CountJSAsync();
```
Return total of Html Elements
```C#
int countHtmlElements = CountHtmlElementsAsync();
```
Return total of META elements
```C#
int countMetaTags = expose.CountMetaAsync();
```
Return all the JS content
```C#
HashSet<string> hsJS = expose.GetJSContentAsync();
```
Return all the CSS content
```C#
HashSet<String> hsCSS =  expose.GetCSSContentAsync();
```
Return the total of onclick events in all elements in the html
```C#
int countOnclickEvents = expose.CountOnclickEventsAsync();
```
Return the total of Forms in html page
```C#
int countForms = expose.CountFormsAsync();
```
Return the Action and HttpMethod from Form
```C#
Dictionary<string,string> dicFormInfo = expose.FormsInfoAsync();
```
Return the size in Kb of the page
```C#
long? pageSize = expose.GetSizeOfPageAsync();
```
Return the JSON with the amount of info found
```C#
string report = expose.GetReportAsync();
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
