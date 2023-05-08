using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

//[assembly: Xamarin.Forms.]
namespace Alarm.Models {
    internal class Alarm {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public int AlarmHour { get; set; }
        public int AlarmMinutes { get; set; }
        public TimeSpan AlarmTime {
            get { return new TimeSpan(this.AlarmHour, this.AlarmMinutes, 0); }
            set { this.AlarmHour = value.Hours;this.AlarmMinutes = value.Minutes; }
        }
        public string SonaraEn {
            get { return "10 minutos"; }
        }


        public string ToJSON() {
            JObject mainObject = new JObject();
            JProperty pName = new JProperty("Name",this.Name);
            JProperty pDesc = new JProperty("Description", this.Description);
            JProperty pHour = new JProperty("Hour", this.AlarmHour);
            JProperty pMinute = new JProperty("Minute", this.AlarmMinutes);
            mainObject.Add(pName);
            mainObject.Add(pDesc);
            mainObject.Add(pHour);
            mainObject.Add(pMinute);
            return mainObject.ToString(); 
        }

        public void LoadFromJSON(string json) {
            try {
                JObject mainObject = JObject.Parse(json);
                this.Name = mainObject.Property("Name").Value.ToString();
                this.Description = mainObject.Property("Description").Value.ToString();
                this.AlarmHour = int.Parse(mainObject.Property("Hour").Value.ToString());
                this.AlarmMinutes = int.Parse(mainObject.Property("Minute").Value.ToString());
            } catch(Exception e) { }
        }

        public void test() {
            Services.ConditionalCompilation.ClockAlarm clockAlarm = new Services.ConditionalCompilation.ClockAlarm();
            clockAlarm.test();
            //if (PhoneDialer.IsSupported)
            //    PhoneDialer.Default.Open("123-123-1234");
        }

    }
}
