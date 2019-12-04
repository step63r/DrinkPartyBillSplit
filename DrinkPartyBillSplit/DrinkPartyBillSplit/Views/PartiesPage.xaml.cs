using DrinkPartyBillSplit.Models;
using DrinkPartyBillSplit.ViewModels;
using System;
using System.ComponentModel;

using Xamarin.Forms;

namespace DrinkPartyBillSplit.Views
{
    /// <summary>
    /// PartiesPageのコードビハインド
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class PartiesPage : ContentPage
    {
        /// <summary>
        /// ViewModelオブジェクト
        /// </summary>
        PartiesViewModel _viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PartiesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PartiesViewModel();
        }

        /// <summary>
        /// アイテムが選択されたときのイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Party;
            if (item is null)
            {
                return;
            }

            await Navigation.PushAsync(new PartyDetailPage(new PartyDetailViewModel(item)));

            PartiesListView.SelectedItem = null;
        }

        /// <summary>
        /// 追加のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddParty_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewPartyPage()));
        }
    }
}