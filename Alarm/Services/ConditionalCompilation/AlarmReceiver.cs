using Alarm.Views;
using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm.Services.ConditionalCompilation {
    [BroadcastReceiver(Exported = true, Enabled = true)]
    public class AlarmReceiver : BroadcastReceiver {
        public override async void OnReceive(Context context, Intent intent) {
            //context.SendBroadcast(new Intent("Ventana_Alarma"));
            await Shell.Current.GoToAsync(nameof(Views.VentanaAlarma));
            //var navigation = new NavigationPage(new VentanaAlarma());
        }
    }
}
