using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkPartyBillSplit.Models
{
    /// <summary>
    /// 参加者クラス
    /// </summary>
    public class Attendee
    {
        /// <summary>
        /// 役職ID
        /// </summary>
        public int GradeID { get; set; }
        /// <summary>
        /// 参加人数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 主賓人数
        /// </summary>
        public int GuestCount { get; set; }
    }
}