using DrinkPartyBillSplit.Common;
using DrinkPartyBillSplit.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
        /// 割り勘ルール
        /// </summary>
        public ISplitRule SplitRule { get; set; }
        /// <summary>
        /// 割り勘後支払額
        /// </summary>
        public ObservableCollection<SplitBill> Bills { get; set; }
        /// <summary>
        /// 端数
        /// </summary>
        public int Fraction { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="party"></param>
        public PartyDetailViewModel(Party party = null, ISplitRule rule = null)
        {
            Title = party?.Name;
            Party = party;

            // 支払額計算
            SplitRule = rule ?? new DefaultSplitRule();
            Bills = SplitRule.CalculateAmountAsync(Party).Result;

            // 端数計算
            int totalAmount = 0;
            foreach (var bill in Bills)
            {
                int amount = bill.Amount;
                var payer = Party.Attendees.Where(item => item.Grade == bill.Grade).FirstOrDefault();
                int num = payer.TotalCount - payer.GuestCount;
                totalAmount += amount * num;
            }
            Fraction = Party.TotalFee - totalAmount;
        }
    }
}
