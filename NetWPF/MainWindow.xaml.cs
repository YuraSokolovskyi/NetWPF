using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RickAndMorty_API_CORE.Data.API;
using RickAndMorty_API_CORE.Domain.Models;
using RickAndMorty_API_CORE.Domain.Models.ProviderJson;

namespace RickAndMorty_API
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RAM_API_ENGINE _engine { get; set; }
        private List<Character> _characters { get; set; }
        private int _page = 1;
        private int _maxPageNumber = 1;
        
        // filters
        public string NameFilter { get; set; } = "";
        public string LocationFilter { get; set; } = "";
        
        public MainWindow()
        {
            InitializeComponent();
            _engine = new RAM_API_ENGINE();
        }
        
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            updatePage();
            
            // update max page number
            var pageResult = _engine.GetPage(_page);
            int maxNumber = JsonProvider.GetNumberOfPages(pageResult);
            _maxPageNumber = maxNumber;
        }

        private async void updatePage()
        {
            var pageResult = _engine.GetPage(_page);
            _characters = JsonProvider.FromJsonToCharacterList(pageResult)
                .Where(character => NameFilter.Trim() != "" ? character.Name.Contains(NameFilter) : true)
                .Where(character => LocationFilter.Trim() != "" ? character.Location.Contains(LocationFilter) : true)
                .ToList();

            MainListView.ItemsSource = _characters;
                
            MainListView.Items.Refresh();
            PageNumber.Text = _page.ToString();
        }

        private void NextBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (_page < _maxPageNumber)
            {
                _page++;
                updatePage();
            }
        }

        private void PrevBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (_page != 1)
            {
                _page--;
                updatePage();
            }
        }

        private void Filters_OnChanged(object sender, EventArgs e)
        {
            NameFilter = FiltersName.Text;
            LocationFilter = FiltersLocation.Text;
            updatePage();
        }
    }
}