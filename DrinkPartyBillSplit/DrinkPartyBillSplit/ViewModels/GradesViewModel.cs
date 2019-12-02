using System.Threading.Tasks;
using Xamarin.Forms;

namespace DrinkPartyBillSplit.ViewModels
{
    /// <summary>
    /// GradesPageのViewModelクラス
    /// </summary>
    public class GradesViewModel : BaseViewModel
    {
        #region コマンド・プロパティ
        /// <summary>
        /// 追加コマンド
        /// </summary>
        public Command AddCommand { get; private set; }
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GradesViewModel()
        {
            Title = "役職";
        }

        /// <summary>
        /// 追加コマンドを実行する
        /// </summary>
        /// <returns></returns>
        private async Task ExecuteAddCommand()
        {
        }
    }
}
