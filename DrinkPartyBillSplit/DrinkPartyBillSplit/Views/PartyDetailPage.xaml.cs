using DrinkPartyBillSplit.ViewModels;
using System.ComponentModel;

using Xamarin.Forms;

namespace DrinkPartyBillSplit.Views
{
    /// <summary>
    /// PartyDetailPageのコードビハインド
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class PartyDetailPage : ContentPage
    {
        /// <summary>
        /// ViewModelオブジェクト
        /// </summary>
        PartyDetailViewModel _viewModel;

        /// <summary>
        /// 引数ありコンストラクタ
        /// </summary>
        /// <param name="viewModel">ViewModelオブジェクト</param>
        public PartyDetailPage(PartyDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this._viewModel = viewModel;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PartyDetailPage()
        {
            InitializeComponent();

            BindingContext = _viewModel;
        }
    }
}