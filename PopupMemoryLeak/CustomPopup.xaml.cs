using CommunityToolkit.Maui.Views;

namespace PopupMemoryLeak;

public partial class CustomPopup : Popup
{
	public CustomPopup(string scenario)
	{
		InitializeComponent();

		_scenario = scenario;

		// Allocate a bunch of memory 
		for (int i = 0; i < 500000000; i++)
		{
			bytes[i] = 100;
		}
    }

	string _scenario;

	byte[] bytes = new byte[500000000];

	~CustomPopup()
	{
		// Put breakpoint here:
		Console.WriteLine($"Finalizer called for {_scenario}");
	}
}