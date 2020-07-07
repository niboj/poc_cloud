using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;

namespace RQ_ASPNET_WebApplication_MVC.Models
{
    public class EventLogEntryModel
    {
        private EventLogEntry entry;

        public EventLogEntryModel(EventLogEntry entry)
        {
            this.Category = entry.Category;
            this.EntryType = entry.EntryType;
            this.InstanceID = entry.InstanceId;
            this.Message = entry.Message;
            this.Username = entry.UserName;
            this.MachineName = entry.MachineName;
            this.TimeGenerated = entry.TimeGenerated;
            this.NbToCreate = 1;

        }

        public EventLogEntryModel()
        {
            this.NbToCreate = 1;

        }

        public String Category { get; set; }

        public EventLogEntryType EntryType { get; set; }

        public long InstanceID { get; set; }

        public string Message { get; set; }

        public string Username { get; set; }

        public string MachineName { get; set; }

        public DateTime TimeGenerated { get; set; }

        public bool Information { get; set; }
        
        public bool Avertissement { get; set; }

        public bool Erreur { get; set; }

        public int NbToCreate { get; set; }
    }
}