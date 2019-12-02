﻿using DrinkPartyBillSplit.Models;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace DrinkPartyBillSplit.Views
{
    /// <summary>
    /// NewItemPageのコードビハインド
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        /// <summary>
        /// Itemオブジェクト
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item()
            {
                Name = "",
                Date = DateTime.Today,
                TotalFee = 0
            };

            BindingContext = this;
        }

        /// <summary>
        /// 保存のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// キャンセルのイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}