using System;
using Xamarin.Forms;

namespace xLab2.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ListView ListView;

        public ItemsPage()
        {
            InitializeComponent();

            ListView = ItemsListView;

            BindingContext = viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}