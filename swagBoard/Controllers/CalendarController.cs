using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DHTMLX.Scheduler;
using DHTMLX.Common;
using DHTMLX.Scheduler.Data;
using swagBoard.Models;

namespace SimpleScheduler.Controllers
{
    public class CalendarController : Controller
    {

        [Authorize]
        public ActionResult Index()
        {
            var scheduler = new DHXScheduler(this);
            scheduler.Skin = DHXScheduler.Skins.Terrace;
            scheduler.InitialDate = new DateTime(2016, 04, 01);

            scheduler.Config.multi_day = true;//render multiday eventsd

            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;

            return View(scheduler);
        }
        

        public ContentResult Data()
        {
            var data = new SchedulerAjaxData(
                    new SampleDataContext().Events
                );

            return (ContentResult)data;
        }

        public ContentResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);
            var changedEvent = (Event)DHXEventsHelper.Bind(typeof(Event), actionValues);
            var data = new SampleDataContext();

            try
            {
                
                    switch (action.Type)
                    {
                        case DataActionTypes.Insert: // define here your Insert logic
                            data.Events.InsertOnSubmit(changedEvent);

                            break;
                        case DataActionTypes.Delete: // define here your Delete logic

                        changedEvent = data.Events.SingleOrDefault(ev => ev.id == action.SourceId);
                        data.Events.DeleteOnSubmit(changedEvent);
                        break;
                    default:// "update" // define here your Update logic
                            var eventToUpdate = data.Events.SingleOrDefault(ev => ev.id == action.SourceId);
                            DHXEventsHelper.Update(eventToUpdate, changedEvent, new List<string>() { "id" });//update all properties, except for id
                            break;
                    }
                    data.SubmitChanges();
                    action.TargetId = changedEvent.id;

            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
                Console.WriteLine("Error: "+a);
            }
            return (new AjaxSaveResponse(action));
        }
    }
}