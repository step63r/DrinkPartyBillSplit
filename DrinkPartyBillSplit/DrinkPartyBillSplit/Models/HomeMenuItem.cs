using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkPartyBillSplit.Models
{
    public enum MenuItemType
    {
        Browse,
        Grade,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
