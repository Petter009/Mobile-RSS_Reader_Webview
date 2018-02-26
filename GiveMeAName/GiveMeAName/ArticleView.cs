using GiveMeAName.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GiveMeAName
{
	public class ArticleView : ContentPage
	{
		public ArticleView ()
		{
            Title = "EAL Mobile";
            var listView = new ListView();

            var textCell = new DataTemplate(typeof(TextCell));
            textCell.SetBinding(TextCell.TextProperty, "Title");
            textCell.SetBinding(TextCell.DetailProperty, "PubDate");
            listView.ItemTemplate = textCell;
            listView.ItemsSource = NewsService.LoadData();

            listView.ItemSelected += ListView_ItemSelected;

            Content = listView;
		}

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) { return; }

            var articleDetail = new ArticleWebView { newsDetail=e.SelectedItem as NewsDetail };
            Navigation.PushAsync(articleDetail);

            var listview = sender as ListView;
            listview.SelectedItem = null;

        }
    }
}