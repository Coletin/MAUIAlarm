using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm.Models {
    internal class AlarmManager {
        public ObservableCollection<Alarm> Alarms { get; set;} = new ObservableCollection<Alarm>();

        public AlarmManager() => LoadAlarms();

        public void LoadAlarms() {            
            Alarms.Clear();

            //Alarms.Add(new Alarm() { Description = "Descripcion", Name = "Nombre" });

            string appRoute = FileSystem.AppDataDirectory;

            IEnumerable<string> files = Directory.EnumerateFiles(appRoute, "*.alarm.txt");
            foreach (string file in files) {
                Alarm newA= new Alarm();
                newA.FileName = file;
                newA.LoadFromJSON(File.ReadAllText(file));
                Alarms.Add(newA);
            }
        }
    }
}
