using DrinkPartyBillSplit.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DrinkPartyBillSplit.Views
{
    [DesignTimeVisible(false)]
    public partial class GradesPage : ContentPage
    {
        /// <summary>
        /// ViewModelオブジェクト
        /// </summary>
        private GradesViewModel _viewModel;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GradesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new GradesViewModel();
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewGradePage()));
        }
    }
}