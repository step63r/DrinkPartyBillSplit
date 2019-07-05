using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkPartyBillSplit.Models
{
    /// <summary>
    /// 役職クラス
    /// </summary>
    public class Grade
    {
        /// <summary>
        /// 役職ID（地位の高い順に小さい数値）
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 役職名
        /// </summary>
        public string Name { get; set; }
    }
}