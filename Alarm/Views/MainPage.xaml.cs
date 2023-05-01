namespace Alarm;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new Models.AlarmManager();
		
	}

    protected override void OnAppearing() {
        ((Models.AlarmManager)BindingContext).LoadAlarms();
    }

    private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		//if (count == 1)
		//	CounterBtn.Text = $"Clicked {count} time";
		//else
		//	CounterBtn.Text = $"Clicked {count} times";

		//SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e) {
		await Shell.Current.GoToAsync(nameof(Views.AddAlarm));
    }

    private void ToolbarItem_Clicked2(object sender, EventArgs e) {
        ((Models.AlarmManager)BindingContext).Alarms.Add(new Models.Alarm() { Description = "La nueva", Name = "Nueva" });
    }
}

