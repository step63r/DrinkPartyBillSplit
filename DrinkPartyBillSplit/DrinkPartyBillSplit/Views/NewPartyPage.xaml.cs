using DrinkPartyBillSplit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace DrinkPartyBillSplit.Views
{
    /// <summary>
    /// NewPartyPageのコードビハインド
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class NewPartyPage : ContentPage
    {
        /// <summary>
        /// Partyオブジェクト
        /// </summary>
        public Party Party { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewPartyPage()
        {
            InitializeComponent();

            Party = new Party()
            {
                ID = 0,
                Date = DateTime.Now,
                Name = "",
                Attendees = new List<Attendee>(),
                TotalFee = 0
            };

            BindingContext = this;
        }

        /// <summary>
        /// 保存のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddParty", Party);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// キャンセルのイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}