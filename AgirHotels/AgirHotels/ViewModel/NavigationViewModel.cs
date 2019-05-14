using AgirHotels.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AgirHotels.ViewModel
{
    public class NavigationViewModel : BindableObject
    {
        public ICommand FadeCommand => new Command(Fade);
        public ICommand FlipCommand => new Command(Flip);
        public ICommand ScaleCommand => new Command(Scale);
        public ICommand SlideFromLeftCommand => new Command(SlideFromLeft);
        public ICommand SlideFromRightCommand => new Command(SlideFromRight);
        public ICommand SlideFromTopCommand => new Command(SlideFromTop);
        public ICommand SlideFromBottomCommand => new Command(SlideFromBottom);

        private void Fade()
        {
            MessagingCenter.Send(this, NavSettings.TransitionMessage, TransitionType.Fade);
        }

        private void Flip()
        {
            MessagingCenter.Send(this, NavSettings.TransitionMessage, TransitionType.Flip);
        }

        private void Scale()
        {
            MessagingCenter.Send(this, NavSettings.TransitionMessage, TransitionType.Scale);
        }

        private void SlideFromLeft()
        {
            MessagingCenter.Send(this, NavSettings.TransitionMessage, TransitionType.SlideFromLeft);
        }

        private void SlideFromRight()
        {
            MessagingCenter.Send(this, NavSettings.TransitionMessage, TransitionType.SlideFromRight);
        }

        private void SlideFromTop()
        {
            MessagingCenter.Send(this, NavSettings.TransitionMessage, TransitionType.SlideFromTop);
        }

        private void SlideFromBottom()
        {
            MessagingCenter.Send(this, NavSettings.TransitionMessage, TransitionType.SlideFromBottom);
        }
    }

}
