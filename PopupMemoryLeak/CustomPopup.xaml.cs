using CommunityToolkit.Maui.Views;

namespace PopupMemoryLeak;

public partial class CustomPopup : Popup
{
	public CustomPopup(string scenario)
	{
		InitializeComponent();

		_scenario = scenario;

		for (int i = 0; i < 500000000; i++)
		{
			bytes[i] = 100;
		}
    }

	string _scenario;

	byte[] bytes = new byte[500000000];

	~CustomPopup()
	{
		Console.WriteLine($"Finalizer called for {_scenario}");
	}
}