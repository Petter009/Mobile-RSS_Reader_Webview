using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GiveMeAName
{
	public class ArticleWebView : ContentPage
	{
        WebView _webView;
        public Model.NewsDetail newsDetail { get; set; }
        public ArticleWebView ()
		{
            Content = _webView = new WebView();	
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Title = newsDetail.Title;
            _webView.Source = new UrlWebViewSource
            {
                Url = newsDetail.Link
            };
        }
	}
}