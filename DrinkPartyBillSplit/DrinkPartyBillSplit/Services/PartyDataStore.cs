using DrinkPartyBillSplit.Common;
using DrinkPartyBillSplit.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkPartyBillSplit.Services
{
    public class PartyDataStore : IDataStore<Party>
    {
        /// <summary>
        /// データストア用のコレクション
        /// </summary>
        public ObservableCollection<Party> Parties;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PartyDataStore()
        {
            try
            {
                Parties = PCLManager.LoadXmlAsync<ObservableCollection<Party>>(DataFormat.BaseDirectory, DataFormat.PartyFileName).Result;
            }
            catch (Exception)
            {
                Parties = new ObservableCollection<Party>();
            }
        }

        /// <summary>
        /// データを追加する
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> AddItemAsync(Party item)
        {
            Parties.Add(item);
            await SaveAsync();
            return await Task.FromResult(true);
        }

        /// <summary>
        /// データを削除する
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteItemAsync(Party item)
        {
            Parties.Remove(item);
            await SaveAsync();
            return await Task.FromResult(true);
        }

        /// <summary>
        /// データを取得する
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Party> GetItemAsync(string id)
        {
            return await Task.FromResult(Parties.FirstOrDefault(s => s.ID == int.Parse(id)));
        }

        /// <summary>
        /// 全てのデータを取得する
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Party>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Parties);
        }

        /// <summary>
        /// データを更新する
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> UpdateItemAsync(Party item)
        {
            var oldItem = Parties.Where((Party arg) => arg.ID == item.ID).FirstOrDefault();
            Parties.Remove(oldItem);
            Parties.Add(item);
            await SaveAsync();
            return await Task.FromResult(true);
        }

        /// <summary>
        /// データをxmlに保存する
        /// </summary>
        /// <returns></returns>
        private async Task<bool> SaveAsync()
        {
            await PCLManager.SaveXmlAsync(new ObservableCollection<Party>(await GetItemsAsync()), DataFormat.BaseDirectory, DataFormat.PartyFileName);
            return await Task.FromResult(true);
        }
    }
}
