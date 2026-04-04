using Android.Webkit;
using System.Diagnostics;
using TutoAppFormations.Models;

namespace TutoAppFormations
{
    public partial class MainPage : ContentPage
    {

        List<Categorie> categories = new List<Categorie>();
        public List<Categorie> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public MainPage()
        {
            InitializeComponent();
            //LoadCategoriesFromApi();
            LoadCategoriesFromAssets();


        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //TODO : Naviguer vers la page Profil
            Navigation.PushAsync(new UserPage());
        }

        public async void LoadCategoriesFromAssets()
        { 
            using var stream = await FileSystem.OpenAppPackageFileAsync("categories.json");
            using var reader = new StreamReader(stream);
            var json = await reader.ReadToEndAsync();
            var categories = System.Text.Json.JsonSerializer.Deserialize<List<Categorie>>(json, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            lc.ItemsSource = categories;
        }
        public async void LoadCategoriesFromApi()
        {
            try
            {
                var httpClient = new HttpClient();

                var url = "http://10.0.2.2:5206/Categorie/";

                var response = await httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"Erreur HTTP: {response.StatusCode}");
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();
             
                var categories = System.Text.Json.JsonSerializer.Deserialize<List<Categorie>>(json, new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                lc.ItemsSource = categories;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
           
            }
        }
    }
}
