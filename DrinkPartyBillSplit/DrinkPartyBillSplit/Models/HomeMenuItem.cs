namespace DrinkPartyBillSplit.Models
{
    public enum MenuItemType
    {
        Party,
        Grade,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
