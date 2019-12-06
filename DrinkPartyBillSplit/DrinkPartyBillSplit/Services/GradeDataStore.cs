using DrinkPartyBillSplit.Common;
using DrinkPartyBillSplit.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkPartyBillSplit.Services
{
    public class GradeDataStore : IDataStore<Grade>
    {
        /// <summary>
        /// データストア用のコレクション
        /// </summary>
        public ObservableCollection<Grade> Grades;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GradeDataStore()
        {
            try
            {
                Grades = PCLManager.LoadXmlAsync<ObservableCollection<Grade>>(DataFormat.BaseDirectory, DataFormat.GradeFileName).Result;
            }
            catch (Exception)
            {
                Grades = new ObservableCollection<Grade>();
            }
        }

        /// <summary>
        /// データを追加する
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> AddItemAsync(Grade item)
        {
            Grades.Add(item);
            await SaveAsync();
            return await Task.FromResult(true);
        }
        
        /// <summary>
        /// データを削除する
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteItemAsync(Grade item)
        {
            Grades.Remove(item);
            await SaveAsync();
            return await Task.FromResult(true);
        }

        /// <summary>
        /// データを取得する
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Grade> GetItemAsync(string id)
        {
            return await Task.FromResult(Grades.FirstOrDefault(s => s.Id == int.Parse(id)));
        }

        /// <summary>
        /// 全てのデータを取得する
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Grade>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Grades);
        }

        /// <summary>
        /// データを更新する
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> UpdateItemAsync(Grade item)
        {
            var oldItem = Grades.Where((Grade arg) => arg.Id == item.Id).FirstOrDefault();
            Grades.Remove(oldItem);
            Grades.Add(item);
            await SaveAsync();
            return await Task.FromResult(true);
        }

        /// <summary>
        /// データをxmlに保存する
        /// </summary>
        /// <returns></returns>
        private async Task<bool> SaveAsync()
        {
            await PCLManager.SaveXmlAsync(new ObservableCollection<Grade>(await GetItemsAsync()), DataFormat.BaseDirectory, DataFormat.GradeFileName);
            return await Task.FromResult(true);
        }
    }
}
