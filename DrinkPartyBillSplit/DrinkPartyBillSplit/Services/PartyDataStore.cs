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

        public async Task<bool> AddItemAsync(Party item)
        {
            Parties.Add(item);
            await SaveAsync();
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = Parties.Where((Party arg) => arg.ID == int.Parse(id)).FirstOrDefault();
            Parties.Remove(oldItem);
            await SaveAsync();
            return await Task.FromResult(true);
        }

        public async Task<Party> GetItemAsync(string id)
        {
            return await Task.FromResult(Parties.FirstOrDefault(s => s.ID == int.Parse(id)));
        }

        public async Task<IEnumerable<Party>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Parties);
        }

        public async Task<bool> UpdateItemAsync(Party item)
        {
            var oldItem = Parties.Where((Party arg) => arg.ID == item.ID).FirstOrDefault();
            Parties.Remove(oldItem);
            Parties.Add(item);
            await SaveAsync();
            return await Task.FromResult(true);
        }

        private async Task<bool> SaveAsync()
        {
            await PCLManager.SaveXmlAsync(new ObservableCollection<Party>(await GetItemsAsync()), DataFormat.BaseDirectory, DataFormat.PartyFileName);
            return await Task.FromResult(true);
        }
    }
}
