using Android.App;
using Android.Runtime;

namespace TutoAppFormations
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() { 
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
                if (view is not null)
                {
                    handler.PlatformView.BackgroundTintList = 
                    Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
                }
            });
            return MauiProgram.CreateMauiApp(); 
        }
    }
}
