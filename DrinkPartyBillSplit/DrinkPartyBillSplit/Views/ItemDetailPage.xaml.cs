using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DrinkPartyBillSplit.Models;
using DrinkPartyBillSplit.ViewModels;
using System.Collections.Generic;

namespace DrinkPartyBillSplit.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Name = "飲み会名",
                Date = new DateTime(2019, 1, 1),
                Attendees = new List<Attendee>
                {
                    new Attendee { GradeID = 1, TotalCount = 3, GuestCount = 0 },
                    new Attendee { GradeID = 2, TotalCount = 5, GuestCount = 0 },
                    new Attendee { GradeID = 3, TotalCount = 5, GuestCount = 1 }
                },
                TotalFee = 34567
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}