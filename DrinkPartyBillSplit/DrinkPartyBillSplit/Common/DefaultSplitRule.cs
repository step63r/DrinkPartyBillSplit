using DrinkPartyBillSplit.Models;
using System;
using System.Collections.Generic;
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
        /// <returns></returns>
        public Task<List<(Attendee, int)>> CalculateAmountAsync(Party party)
        {
            throw new NotImplementedException();
        }
    }
}
