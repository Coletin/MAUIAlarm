﻿namespace Alarm;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(Views.AddAlarm), typeof(Views.AddAlarm));
	}
}
