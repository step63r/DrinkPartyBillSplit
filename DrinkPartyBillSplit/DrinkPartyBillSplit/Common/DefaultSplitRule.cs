using DrinkPartyBillSplit.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DrinkPartyBillSplit.Common
{
    /// <summary>
    /// デフォルト割り勘ルールクラス
    /// </summary>
    public class DefaultSplitRule : ISplitRule
    {
        /// <summary>
        /// 割り勘金額を計算する
        /// </summary>
        /// <param name="party">宴会</param>
        /// <returns>役職ごとの支払額</returns>
        public async Task<ObservableCollection<SplitBill>> CalculateAmountAsync(Party party)
        {
            var ret = new ObservableCollection<SplitBill>();

            // 主賓を除く参加人数
            int numPayers = 0;
            foreach (var attendee in party.Attendees)
            {
                numPayers += attendee.TotalCount - attendee.GuestCount;
            }

            // 割り勘金額の計算
            foreach (var attendee in party.Attendees)
            {
                if (attendee.TotalCount == 0)
                {
                    continue;
                }

                ret.Add(new SplitBill()
                {
                    Grade = attendee.Grade,
                    Amount = party.TotalFee / numPayers
                });
            }

            return await Task.FromResult(ret);
        }
    }
}
