using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm.Services.ConditionalCompilation {
    [BroadcastReceiver(Exported = true, Enabled = true)]
    public class AlarmReceiver : BroadcastReceiver {
        public override void OnReceive(Context context, Intent intent) {
            int test = 1;
            test++;
        }
    }
}
