using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;

namespace RQ_ASPNET_WebApplication_MVC.Models
{
    public class EvenementApplicatif
    {

        private int eventId;
        private EventLogEntryType eventType;
        private string message;

        private bool information;
        private bool erreur;
        private bool avertissement;


        public EvenementApplicatif()
        {
            this.EventId = 100;
            this.Information = true;
            this.Message = string.Empty;

        }

        public int EventId { get => eventId; set => eventId = value; }
        public EventLogEntryType EventType {
            get
            {
                if (this.Avertissement)                    
                     return EventLogEntryType.Warning;
                else if (this.Erreur)
                    return EventLogEntryType.Error;
                else
                {
                    return EventLogEntryType.Information;
                }
                                       
            }
        }
        public string Message { get => message; set => message = value; }
        public bool Information { get => information; set => information = value; }
        public bool Erreur { get => erreur; set => erreur = value; }
        public bool Avertissement { get => avertissement; set => avertissement = value; }

      
            
    }
}