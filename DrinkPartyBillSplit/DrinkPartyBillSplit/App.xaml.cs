﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DrinkPartyBillSplit.Services;
using DrinkPartyBillSplit.Views;

namespace DrinkPartyBillSplit
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<PartyDataStore>();
            DependencyService.Register<GradeDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
