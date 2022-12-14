using CommunityToolkit.Maui.Views;

namespace PopupMemoryLeak;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button1_Clicked(object sender, EventArgs e)
    {
        new CustomPopup("Created, but not opened");
    }

    private async void Button2_Clicked(object sender, EventArgs e)
    {
        await this.ShowPopupAsync(new CustomPopup("Opened from MainPage")).ConfigureAwait(true);
    }

    private async void Button3_Clicked(object sender, EventArgs e)
    {
        ContentPage newPage = new ContentPage() { Title = "New Page" };
        await Navigation.PushAsync(newPage);

        await Task.Delay(500).ConfigureAwait(true);
        await newPage.ShowPopupAsync(new CustomPopup("Opened using New Page")).ConfigureAwait(true);
    }

    private async void Button4_Clicked(object sender, EventArgs e)
    {
        GC.Collect();
    }
}

