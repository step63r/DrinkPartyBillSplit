﻿using System;
using System.Collections.Generic;

namespace DrinkPartyBillSplit.Models
{
    public class Item
    {
        /// <summary>
        /// 飲み会ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 開催日付
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 飲み会名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 参加者リスト
        /// </summary>
        public List<Attendee> Attendees { get; set; }
        /// <summary>
        /// 合計金額
        /// </summary>
        public int TotalFee { get; set; }
    }
}