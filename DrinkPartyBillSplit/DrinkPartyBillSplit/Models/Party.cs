using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkPartyBillSplit.Models
{
    /// <summary>
    /// 飲み会クラス
    /// </summary>
    public class Party
    {
        /// <summary>
        /// 飲み会ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 開催日付
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 飲み会名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 参加者リスト
        /// </summary>
        public List<Attendee> Attendees { get; set; }
        /// <summary>
        /// 合計金額
        /// </summary>
        public int TotalFee { get; set; }
    }
}