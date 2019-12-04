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

        public async Task<bool> AddItemAsync(Grade item)
        {
            Grades.Add(item);
            await SaveAsync();
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = Grades.Where((Grade arg) => arg.Id == int.Parse(id)).FirstOrDefault();
            Grades.Remove(oldItem);
            await SaveAsync();
            return await Task.FromResult(true);
        }

        public async Task<Grade> GetItemAsync(string id)
        {
            return await Task.FromResult(Grades.FirstOrDefault(s => s.Id == int.Parse(id)));
        }

        public async Task<IEnumerable<Grade>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Grades);
        }

        public async Task<bool> UpdateItemAsync(Grade item)
        {
            var oldItem = Grades.Where((Grade arg) => arg.Id == item.Id).FirstOrDefault();
            Grades.Remove(oldItem);
            Grades.Add(item);
            await SaveAsync();
            return await Task.FromResult(true);
        }

        private async Task<bool> SaveAsync()
        {
            await PCLManager.SaveXmlAsync(new ObservableCollection<Grade>(await GetItemsAsync()), DataFormat.BaseDirectory, DataFormat.GradeFileName);
            return await Task.FromResult(true);
        }
    }
}
