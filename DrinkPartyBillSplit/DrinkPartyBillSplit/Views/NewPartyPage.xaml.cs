using DrinkPartyBillSplit.Models;
using DrinkPartyBillSplit.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
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
        /// 参加者リスト
        /// </summary>
        public List<Attendee> Attendees { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewPartyPage()
        {
            InitializeComponent();

            Attendees = new List<Attendee>();

            // Gradeのデータストアを無理やり取得
            var store = DependencyService.Get<IDataStore<Grade>>();
            var grades = store.GetItemsAsync().Result;

            if (store is null)
            {
                throw new Exception("データストアが初期化されていません");
            }

            foreach (var grade in grades)
            {
                Attendees.Add(new Attendee()
                {
                    Grade = grade,
                    TotalCount = 0,
                    GuestCount = 0
                });
            }

            Party = new Party()
            {
                // TODO: (r-uchiyama) auto increment
                ID = 0,
                Date = DateTime.Now,
                Name = "",
                Attendees = Attendees,
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