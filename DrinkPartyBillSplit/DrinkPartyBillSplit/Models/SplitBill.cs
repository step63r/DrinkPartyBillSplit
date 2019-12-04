namespace DrinkPartyBillSplit.Models
{
    /// <summary>
    /// 割り勘後支払額クラス
    /// </summary>
    public class SplitBill
    {
        public Grade Grade { get; set; }
        public int Amount { get; set; }
    }
}
