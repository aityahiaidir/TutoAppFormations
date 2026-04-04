namespace TutoAppFormations;

public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var url =  new Uri("https://www.stable-diffusion-france.fr/Guide_StableDiffusion_fr_v1.pdf");
         await Browser.Default.OpenAsync(url, BrowserLaunchMode.SystemPreferred);

    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());

    }
}