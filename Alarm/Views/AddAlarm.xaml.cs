namespace Alarm.Views;

[QueryProperty(nameof(ItemID), nameof(ItemID))]
public partial class AddAlarm : ContentPage
{
    public string ItemID { 
        set { LoadAlarm(value); } 
    }
    public AddAlarm()
	{
		InitializeComponent();

        string dataPath = FileSystem.AppDataDirectory;
        string randomName = $"{Path.GetRandomFileName()}.alarm.txt";

        LoadAlarm(Path.Combine(dataPath,randomName));
	}

    private async void Save_Clicked(object sender, EventArgs e) {
        if (this.BindingContext is Models.Alarm alarm)
            File.WriteAllText(alarm.FileName, alarm.ToJSON());

        await Shell.Current.GoToAsync("..");
    }

    private async void Delete_Clicked(object sender, EventArgs e) {
        if (BindingContext is Models.Alarm alarm && File.Exists(alarm.FileName))
            File.Delete(alarm.FileName);
        await Shell.Current.GoToAsync("..");    
    }

    private void LoadAlarm(string Path) {
        Models.Alarm alarma = new Models.Alarm();
        alarma.FileName = Path;

        if(File.Exists(Path)) {
            alarma.LoadFromJSON(File.ReadAllText(Path));
        }

        this.BindingContext= alarma;
    }
}