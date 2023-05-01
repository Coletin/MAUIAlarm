﻿using System;
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

            Alarms.Add(new Alarm() { Description = "Descripcion", Name = "Nombre" });
        }
    }
}
