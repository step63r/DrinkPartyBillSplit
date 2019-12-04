using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkPartyBillSplit.Models;

namespace DrinkPartyBillSplit.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Grade> grades;
        List<Attendee> attendees;
        List<Item> items;

        public MockDataStore()
        {
            // 役職のモック作成
            grades = new List<Grade>();
            var mockGrades = new List<Grade>
            {
                new Grade { Id = 1, Name = "Professional" },
                new Grade { Id = 2, Name = "Chief" },
                new Grade { Id = 3, Name = "Assistant"}
            };
            foreach (var item in mockGrades)
            {
                grades.Add(item);
            }

            // 参加者のモック作成
            attendees = new List<Attendee>();
            //var mockAttendees = new List<Attendee>
            //{
            //    new Attendee { GradeID = 1, TotalCount = 3, GuestCount = 0 },
            //    new Attendee { GradeID = 2, TotalCount = 5, GuestCount = 0 },
            //    new Attendee { GradeID = 3, TotalCount = 5, GuestCount = 1 }
            //};
            //foreach (var item in mockAttendees)
            //{
            //    attendees.Add(item);
            //}

            //// 飲み会のモック作成
            //items = new List<Item>();
            //var mockItems = new List<Item>
            //{
            //    new Item { Id = Guid.NewGuid().ToString(), Date = new DateTime(2019, 4, 1), Name = "新人歓迎会", Attendees = mockAttendees, TotalFee = 30000 },
            //    new Item { Id = Guid.NewGuid().ToString(), Date = new DateTime(2019, 8, 1), Name = "決起集会", Attendees = mockAttendees, TotalFee = 24900 },
            //    new Item { Id = Guid.NewGuid().ToString(), Date = new DateTime(2019, 12, 31), Name = "忘年会", Attendees = mockAttendees, TotalFee = 19000 },
            //    new Item { Id = Guid.NewGuid().ToString(), Date = new DateTime(2020, 1, 1), Name = "新年会", Attendees = mockAttendees, TotalFee = 45000 },
            //    new Item { Id = Guid.NewGuid().ToString(), Date = new DateTime(2019, 3, 31), Name = "送別会", Attendees = mockAttendees, TotalFee = 18500 }
            //};
            //foreach (var item in mockItems)
            //{
            //    items.Add(item);
            //}
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}