using DrinkPartyBillSplit.Models;

namespace DrinkPartyBillSplit.ViewModels
{
    /// <summary>
    /// PartyDetailPageのViewModelクラス
    /// </summary>
    public class PartyDetailViewModel : BaseViewModel<Party>
    {
        /// <summary>
        /// Partyオブジェクト
        /// </summary>
        public Party Party { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="party"></param>
        public PartyDetailViewModel(Party party = null)
        {
            Title = party?.Name;
            Party = party;
        }
    }
}
