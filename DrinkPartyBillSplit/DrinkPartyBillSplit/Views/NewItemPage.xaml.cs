using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DrinkPartyBillSplit.Models;

namespace DrinkPartyBillSplit.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
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

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}