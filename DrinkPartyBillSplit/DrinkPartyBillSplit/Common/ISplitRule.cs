using DrinkPartyBillSplit.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrinkPartyBillSplit.Common
{
    /// <summary>
    /// 割り勘ルールインタフェース
    /// </summary>
    public interface ISplitRule
    {
        /// <summary>
        /// 参加者の役職ごとの金額を計算する
        /// </summary>
        /// <param name="party">宴会</param>
        /// <returns></returns>
        Task<List<(Attendee, int)>> CalculateAmountAsync(Party party);
    }
}
