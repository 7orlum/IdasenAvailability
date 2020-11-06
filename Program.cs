using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System.Net.Mail;
using System.Net;

namespace IdasenAvailability
{
    class Program
    {
        static ScrapingBrowser _browser = new ScrapingBrowser();
        static void Main(string[] args)
        {
            string desk_url = "https://www.ikea.com/pl/pl/p/idasen-biurko-z-regulacja-wysokosci-czarny-ciemnoszary-s19280939/";
            var html = GetHtml(desk_url);

            var availability_box = html.CssSelect("span.range-revamp-stockcheck__text");

            var availability_text = availability_box.ElementAt(0).InnerText;

            Console.WriteLine(availability_text);
        }

        static HtmlNode GetHtml(string url) {

            _browser.IgnoreCookies = true;
            WebPage webpage = _browser.NavigateToPage(new Uri(url));
            
            return webpage.Html;
        }
    }
}
