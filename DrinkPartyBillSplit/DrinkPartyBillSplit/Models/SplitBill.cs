namespace DrinkPartyBillSplit.Models
{
    /// <summary>
    /// 割り勘後支払額クラス
    /// </summary>
    public class SplitBill
    {
        /// <summary>
        /// 役職
        /// </summary>
        public Grade Grade { get; set; }
        /// <summary>
        /// 支払人数
        /// </summary>
        public int Payer { get; set; }
        /// <summary>
        /// 一人あたり金額
        /// </summary>
        public int Amount { get; set; }
    }
}
