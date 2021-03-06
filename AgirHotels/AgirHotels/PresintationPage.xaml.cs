﻿using AgirHotels.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgirHotels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PresintationPage : ContentPage
    {
        public class item
        {
            public string Img { get; set; }
            public string Text { get; set; }
        }
        List<item> list;
        public PresintationPage()
        {
            InitializeComponent();
            list = new List<item>
            {
                new item
                {
                    Img="AA.png",Text="Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                },
                new item
                {
                    Img="AB.png",Text="Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                },
                new item
                {
                    Img="AC.png",Text="Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                },
                new item
                {
                    Img="AD.png",Text="Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                },
                new item
                {
                    Img="AF.png",Text="Lorem Ipsum is simply dummy text of the printing and typesetting industry."
                },
            };
            this.BindingContext = list;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (caro.Position == 4)
            {
                Activ.IsRunning = true;
                Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new Login()));
                Activ.IsRunning = false;
            }
            else
            {
                caro.Position++;
            }
            
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if(caro.Position>0)
                caro.Position--;
        }

        private void Caro_PositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            if (caro.Position == 0)
                SkipBtn.IsVisible = false;
            else
                SkipBtn.IsVisible = true;
        }
    }
}