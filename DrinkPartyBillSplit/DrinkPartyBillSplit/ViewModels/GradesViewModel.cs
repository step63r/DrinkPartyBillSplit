using DrinkPartyBillSplit.Models;
using DrinkPartyBillSplit.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DrinkPartyBillSplit.ViewModels
{
    /// <summary>
    /// GradesPageのViewModelクラス
    /// </summary>
    public class GradesViewModel : BaseViewModel<Grade>
    {
        #region コマンド・プロパティ
        /// <summary>
        /// Gradeコレクション
        /// </summary>
        public ObservableCollection<Grade> Grades { get; set; }
        /// <summary>
        /// 選択された役職
        /// </summary>
        public Grade SelectedGrade { get; set; }
        /// <summary>
        /// コレクションロードコマンド
        /// </summary>
        public Command LoadGradesCommand { get; set; }
        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GradesViewModel()
        {
            Title = "役職";
            Grades = new ObservableCollection<Grade>();
            LoadGradesCommand = new Command(async () => await ExecuteLoadGradesCommand());

            MessagingCenter.Subscribe<NewGradePage, Grade>(this, "AddGrade", async (obj, item) =>
            {
                var newItem = item as Grade;
                Grades.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });

            MessagingCenter.Subscribe<GradesPage, Grade>(this, "RemoveGrade", async (obj, item) =>
            {
                if (item != null)
                {
                    var targetItem = item as Grade;
                    Grades.Remove(targetItem);
                    await DataStore.DeleteItemAsync(targetItem);
                    LoadGradesCommand.Execute(null);
                }
            });

            // 初期化時にデータをロード
            LoadGradesCommand.Execute(null);
        }

        /// <summary>
        /// コレクションロードイベント
        /// </summary>
        /// <returns></returns>
        private async Task ExecuteLoadGradesCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                Grades.Clear();
                var grades = await DataStore.GetItemsAsync(true);
                foreach (var grade in grades)
                {
                    Grades.Add(grade);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
