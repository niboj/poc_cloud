using RQ_ASPNET_WebApplication_MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RQ_ASPNET_WebApplication_MVC.Controllers
{
    public class EventLogController : Controller
    {

        const string sourceName = "POC_CLOUD";
        const string logName = "Application";

        EventLog appLog;

        public EventLogController()
        {
            EventLog appLog = new EventLog(logName);
            appLog.Source = sourceName;
        }

        // GET: EventLog
        public ActionResult Index()
        {

            EventLog log = new EventLog(logName);
            log.Source = sourceName;

                            
            List<RQ_ASPNET_WebApplication_MVC.Models.EventLogEntryModel> model = new List<RQ_ASPNET_WebApplication_MVC.Models.EventLogEntryModel>();
            for(int i = log.Entries.Count-1; i­­ > log.Entries.Count -100; i--)
            {
               
                    EventLogEntryModel entry = new EventLogEntryModel(log.Entries[i]);
                    model.Add(entry);
               
            }

            return View(model);
        }

        // GET: EventLog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventLog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventLog/Create
        [HttpPost]
        public ActionResult Create(EventLogEntryModel  model)
         // public ActionResult Create(FormCollection collection)
        {
            try
            {

                EventLog log1 = new EventLog(logName);
                log1.Source = sourceName;

                EventLogEntryType entryType;
                if (model.Erreur)
                    entryType = EventLogEntryType.Error;
                else if (model.Avertissement)
                    entryType = EventLogEntryType.Warning;
                else
                    entryType = EventLogEntryType.Information;

                for (int i = 1; i < model.NbToCreate; i++)
                { 
                   log1.WriteEntry(model.Message + " - " + i.ToString(), entryType, 100);
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EventLog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventLog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EventLog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventLog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
