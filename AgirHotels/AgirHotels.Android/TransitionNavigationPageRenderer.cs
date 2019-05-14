using System.ComponentModel;
using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using AgirHotels.Droid.Render;
using AgirHotels.Helper;

[assembly: ExportRenderer(typeof(TransitionNavigationPage), typeof(TransitionNavigationPageRenderer))]
namespace AgirHotels.Droid.Render
{
    public class TransitionNavigationPageRenderer : NavigationPageRenderer
    {
        private TransitionType _transitionType = TransitionType.Default;

        public TransitionNavigationPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == TransitionNavigationPage.TransitionTypeProperty.PropertyName)
                UpdateTransitionType();
        }

        protected override void SetupPageTransition(Android.Support.V4.App.FragmentTransaction transaction, bool isPush)
        {
            switch (_transitionType)
            {
                case TransitionType.None:
                    transaction.SetCustomAnimations(Resource.Animation.EnterFromLeft, Resource.Animation.ExitToRight,
                                                        Resource.Animation.EnterFromRight, Resource.Animation.ExitToLeft);
                    break;
                case TransitionType.Default:
                    transaction.SetCustomAnimations(Resource.Animation.EnterFromLeft, Resource.Animation.ExitToRight,
                                                        Resource.Animation.EnterFromRight, Resource.Animation.ExitToLeft);
                    break;
                case TransitionType.Fade:
                    transaction.SetCustomAnimations(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out,
                                                    Resource.Animation.abc_fade_out, Resource.Animation.abc_fade_in);
                    break;
                case TransitionType.Flip:
                    transaction.SetCustomAnimations(Resource.Animation.design_bottom_sheet_slide_in, Resource.Animation.design_bottom_sheet_slide_out,
                                                    Resource.Animation.design_bottom_sheet_slide_out, Resource.Animation.design_bottom_sheet_slide_in);
                    break;
                case TransitionType.Scale:
                    transaction.SetCustomAnimations(Resource.Animation.abc_grow_fade_in_from_bottom, Resource.Animation.abc_shrink_fade_out_from_bottom,
                                                    Resource.Animation.abc_shrink_fade_out_from_bottom, Resource.Animation.abc_grow_fade_in_from_bottom);
                    break;
                case TransitionType.SlideFromLeft:
                    if (isPush)
                    {
                        transaction.SetCustomAnimations(Resource.Animation.EnterFromLeft, Resource.Animation.ExitToRight,
                                                        Resource.Animation.EnterFromRight, Resource.Animation.ExitToLeft);
                    }
                    else
                    {
                        transaction.SetCustomAnimations(Resource.Animation.EnterFromRight, Resource.Animation.ExitToLeft,
                                                        Resource.Animation.EnterFromLeft, Resource.Animation.ExitToRight);
                    }
                    break;
                case TransitionType.SlideFromRight:
                    if (isPush)
                    {
                        transaction.SetCustomAnimations(Resource.Animation.EnterFromRight, Resource.Animation.ExitToLeft,
                                                        Resource.Animation.EnterFromLeft, Resource.Animation.ExitToRight);
                    }
                    else
                    {
                        transaction.SetCustomAnimations(Resource.Animation.EnterFromLeft, Resource.Animation.ExitToRight,
                                                        Resource.Animation.EnterFromRight, Resource.Animation.ExitToLeft);
                    }
                    break;
                case TransitionType.SlideFromTop:
                    if (isPush)
                    {
                        transaction.SetCustomAnimations(Resource.Animation.tooltip_enter, Resource.Animation.tooltip_exit,
                                                        Resource.Animation.tooltip_exit, Resource.Animation.tooltip_enter);
                    }
                    else
                    {
                        transaction.SetCustomAnimations(Resource.Animation.tooltip_enter, Resource.Animation.tooltip_exit,
                                                        Resource.Animation.tooltip_exit, Resource.Animation.tooltip_enter);
                    }
                    break;
                case TransitionType.SlideFromBottom:
                    if (isPush)
                    {
                        transaction.SetCustomAnimations(Resource.Animation.design_snackbar_in, Resource.Animation.design_snackbar_out,
                                                        Resource.Animation.design_snackbar_out, Resource.Animation.design_snackbar_in);
                    }
                    else
                    {
                        transaction.SetCustomAnimations(Resource.Animation.design_bottom_sheet_slide_in, Resource.Animation.design_bottom_sheet_slide_out,
                                                        Resource.Animation.design_bottom_sheet_slide_out, Resource.Animation.design_bottom_sheet_slide_in);
                    }
                    break;
                default:
                    return;
            }
        }


        private void UpdateTransitionType()
        {
            var transitionNavigationPage = (TransitionNavigationPage)Element;
            _transitionType = transitionNavigationPage.TransitionType;
        }
    }

}