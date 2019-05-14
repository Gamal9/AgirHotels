using AgirHotels.Services;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgirHotels.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        bool FinalEmail, FinalPass , PassLength;

        public Register()
        {
            InitializeComponent();
            EntryName.Completed += (Object sender, EventArgs e) =>
            {
                EntryEmail.Focus();
            };
            EntryEmail.Completed += (Object sender, EventArgs e) =>
            {
                EntryPassword.Focus();
            };
            EntryPassword.Completed += (Object sender, EventArgs e) =>
            {
                EntryConfiremPassword.Focus();
            };
        }
        private bool AllFieldsFilled()
        {
            if (!FinalEmail)
            {
                DisplayAlert("", "من فضلك أدخل البريد الإلكتروني بشكل صحيح !!", "موافق");
                return false;
            }
            if (!FinalPass)
            {
                DisplayAlert("", "من فضلك الرقم السري يجب أن يكون أكثر من 6 حروف !!", "موافق");
                return false;
            }
            if (!PassLength)
            {
                DisplayAlert("", "من فضلك كلمة السر غير متطابقة !!", "موافق");
                return false;
            }

            return true;
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            Activ.IsRunning = true;
            bool checker = false;
            if (CrossConnectivity.Current.IsConnected)
            {
                if(AllFieldsFilled())
                {
                    UserService ser = new UserService();
                    var result = await ser.Register(EntryEmail.Text, EntryPassword.Text, EntryName.Text);
                    if (result == null)
                    {
                        Activ.IsRunning = false;
                        PopAlert(checker);
                        return;
                    }
                    else
                    {
                        checker = true;
                        PopAlert(checker);
                        await Navigation.PopAsync();
                    }
                }
            }
            else
            {
                await DisplayAlert("خطأ", "من فضلك تحقق من الإتصال بالإنترنت", "موافق");
            }
            Activ.IsRunning = false;
        }

        

        private void EntryConfiremPassword_Focused(object sender, FocusEventArgs e)
        {
            LblConfermPassword.IsVisible = true;
        }
        private void EntryConfiremPassword_Unfocused(object sender, FocusEventArgs e)
        {
            LblConfermPassword.IsVisible = false;
        }

        private void EntryEmail_Focused(object sender, FocusEventArgs e)
        {
            LblEmail.IsVisible = true;
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

        private void EntryEmail_Unfocused(object sender, FocusEventArgs e)
        {
            LblEmail.IsVisible = false;
        }

        private void EntryPassword_Focused(object sender, FocusEventArgs e)
        {
            LblPassword.IsVisible = true;
        }

        private void EntryPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            PassLength = false;
            if (EntryPassword.Text.Length >=6)
            {
                FrmMainPass.BorderColor = Color.White;
                PassLength = true;
            }
            else
            {
                FrmMainPass.BorderColor = Color.Red;
                PassLength = false;
            }
        }

        private void EntryName_Focused(object sender, FocusEventArgs e)
        {
            LblName.IsVisible = true;
        }

        private void EntryName_Unfocused(object sender, FocusEventArgs e)
        {
            LblName.IsVisible = false;
        }

        private void EntryConfiremPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            FinalPass = false;
            if (EntryPassword.Text == EntryConfiremPassword.Text)
            {
                FrmPass.BorderColor = Color.White;
                FinalPass = true;
            }
            else
            {
                FrmPass.BorderColor = Color.Red;
            }
        }

        private void EntryPassword_Unfocused(object sender, FocusEventArgs e)
        {
            LblPassword.IsVisible = false;
        }

        private void PopAlert(bool x)
        {
            PopupNavigation.Instance.PushAsync(new RequestPopUp(x, 0));
            return;
        }
    }
}