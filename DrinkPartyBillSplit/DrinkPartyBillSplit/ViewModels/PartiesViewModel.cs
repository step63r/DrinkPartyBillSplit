using DrinkPartyBillSplit.Models;
using DrinkPartyBillSplit.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DrinkPartyBillSplit.ViewModels
{
    /// <summary>
    /// PartiesPageのViewモデルクラス
    /// </summary>
    public class PartiesViewModel : BaseViewModel<Party>
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

            MessagingCenter.Subscribe<NewPartyPage, Party>(this, "AddParty", async (obj, item) =>
            {
                var newItem = item as Party;
                Parties.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });

            // 初期化時にデータをロード
            LoadPartiesCommand.Execute(null);
        }

        /// <summary>
        /// コレクションロードイベント
        /// </summary>
        /// <returns></returns>
        private async Task ExecuteLoadPartiesCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                Parties.Clear();
                var parties = await DataStore.GetItemsAsync(true);
                foreach (var party in parties)
                {
                    Parties.Add(party);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
