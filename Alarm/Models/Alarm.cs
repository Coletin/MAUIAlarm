using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alarm.Models {
    internal class Alarm {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }

        public string ToJSON() {
            JObject mainObject = new JObject();
            JProperty pName = new JProperty("Name",this.Name);
            JProperty pDesc = new JProperty("Description", this.Description);
            mainObject.Add(pName);
            mainObject.Add(pDesc);
            return mainObject.ToString(); 
        }

        public void LoadFromJSON(string json) {
            try {
                JObject mainObject = JObject.Parse(json);
                this.Name = mainObject.Property("Name").Value.ToString();
                this.Description = mainObject.Property("Description").Value.ToString();
            } catch(Exception e) { }
        }

    }
}
