using AgirHotels.Helper;
using AgirHotels.Services;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AgirHotels.ViewModel;

namespace AgirHotels.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        bool checker = false, FinalEmail;
        public Login()
        {
            InitializeComponent();
            EntryEmail.Completed += (Object sender, EventArgs e) =>
            {
                EntryPassword.Focus();
            };
            
        }

        

        private void EntryEmail_Focused_1(object sender, FocusEventArgs e)
        {
            LblEmail.IsVisible = true;
        }

        private void EntryEmail_Unfocused(object sender, FocusEventArgs e)
        {
            LblEmail.IsVisible = false;
        }

        private void EntryPassword_Focused(object sender, FocusEventArgs e)
        {
            LblPassword.IsVisible = true;
        }

        private void EntryPassword_Unfocused(object sender, FocusEventArgs e)
        {
            LblPassword.IsVisible = false;
        }

        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Activ.IsRunning = true;
            checker = false;
            if(CrossConnectivity.Current.IsConnected)
            {
                if (FinalEmail)
                {
                    UserService ser = new UserService();
                    var result = await ser.UserLogin(EntryEmail.Text, EntryPassword.Text);
                    if (result == null)
                    {
                        Activ.IsRunning = false;
                        PopAlert(checker);
                        return;
                    }
                    else
                    {
                        checker = true;
                        AppSettings.LastUserID = result.id;
                        PopAlert(checker);
                        Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new MainPage());
                    }
                }
                else
                {
                    await DisplayAlert("", "من فضلك أدخل البريد الإلكتروني بشكل صحيح !!", "موافق");
                }
            }
            else
            {
                await DisplayAlert("خطأ", "من فضلك تحقق من الإتصال بالإنترنت", "موافق");
            }
            Activ.IsRunning = false;
        }
        private void PopAlert(bool x)
        {
            PopupNavigation.Instance.PushAsync(new RequestPopUp(x, 0));
            return;
        }

        private void BtnRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }

        private void EntryEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EntryEmail.Text.IndexOf('@') != -1)
            {
                if (EntryEmail.Text.Split('@')[1].Length >= 5)
                {
                    FrmEmail.BorderColor = Color.White;
                    FinalEmail = true;
                }
                else
                {
                    FrmEmail.BorderColor = Color.Red;
                    FinalEmail = false;
                }
            }
            else
            {
                FrmEmail.BorderColor = Color.Red;
                FinalEmail = false;
            }
        }
    }
}