using DrinkPartyBillSplit.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DrinkPartyBillSplit.ViewModels
{
    /// <summary>
    /// PartiesPageのViewモデルクラス
    /// </summary>
    public class PartiesViewModel : BaseViewModel
    {
        #region コマンド・プロパティ
        /// <summary>
        /// Partyコレクション
        /// </summary>
        public ObservableCollection<Party> Parties { get; set; }
        /// <summary>
        /// コレクションロードコマンド
        /// </summary>
        public Command LoadPartiesCommand { get; set; }
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PartiesViewModel()
        {
            Title = "宴会";
            Parties = new ObservableCollection<Party>();
            LoadPartiesCommand = new Command(async () => await ExecuteLoadPartiesCommand());

            //MessagingCenter.Subscribe<>
        }

        private async Task ExecuteLoadPartiesCommand()
        {

        }
    }
}
