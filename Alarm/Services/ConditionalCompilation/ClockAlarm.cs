using Android.Content;
using Android.App;

using Microsoft.Maui.Controls.Compatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm.Services.ConditionalCompilation {
    public class ClockAlarm {
        public void test() {

#if ANDROID
            var alarmIntent = new Intent(Android.App.Application.Context,typeof(AlarmReceiver));
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(Android.App.Application.Context, 0, alarmIntent, PendingIntentFlags.Immutable);
            alarmIntent.PutExtra("pendingIntent", pendingIntent);
            AlarmManager alarmManager = (AlarmManager)Android.App.Application.Context.GetSystemService(Context.AlarmService);
            DateTime startTime = DateTime.Today.AddMinutes(1);
            long interval = 10 * 1000;
            //alarmManager.SetRepeating(AlarmType.RtcWakeup, startTime.Ticks, interval, pendingIntent);
            alarmManager.Set(AlarmType.ElapsedRealtimeWakeup, Android.OS.SystemClock.ElapsedRealtime() + interval, pendingIntent);
#endif

        }
    }
}
