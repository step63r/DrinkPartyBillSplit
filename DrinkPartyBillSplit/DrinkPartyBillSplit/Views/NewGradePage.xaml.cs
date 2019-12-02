using DrinkPartyBillSplit.Models;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace DrinkPartyBillSplit.Views
{
    /// <summary>
    /// NewGradePageのコードビハインド
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class NewGradePage : ContentPage
    {
        /// <summary>
        /// Gradeオブジェクト
        /// </summary>
        public Grade Grade { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewGradePage()
        {
            InitializeComponent();

            Grade = new Grade()
            {
                Id = 0,
                Name = ""
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
            MessagingCenter.Send(this, "AddGrade", Grade);
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