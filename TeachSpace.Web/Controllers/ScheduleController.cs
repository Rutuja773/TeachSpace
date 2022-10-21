using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeachSpace.Data;
using TeachSpace.Web.Models;

namespace TeachSpace.Web.Controllers
{
    public class ScheduleController : ApiController
    {
        private TeachSpaceDBEntities entities = new TeachSpaceDBEntities();
        public ScheduleController()
        {
            this.entities = new TeachSpaceDBEntities();
        }

        [Route("api/Schedule/GetUsersEmail")]
        [HttpGet]
        public IHttpActionResult GetUsersEmail()
        {
            List<sp_GetUsersEmail_Result> useremail = new List<sp_GetUsersEmail_Result>();
            useremail = entities.sp_GetUsersEmail().ToList();
            return Json(entities.sp_GetUsersEmail().Select(x => new
            {
                UserID = x.ID,
                UserEmail = x.Email
            }).ToList());
            //return Json(useremail);
        }

        [Route("api/Schedule/GetTopicName")]
        [HttpGet]
        public IHttpActionResult GetTopicName()
        {
            List<sp_GetTopicNames_Result> topicname = new List<sp_GetTopicNames_Result>();
            topicname = entities.sp_GetTopicNames().ToList();
            return Json(entities.sp_GetTopicNames().Select(x => new
            {
                TopicID = x.ID,
                TopicName = x.Name
            }).ToList());
            //return Json(useremail);
        }

        //[HttpPost]
        //public IHttpActionResult CreateSchedule( email)

        [Route("api/Schedule/AddSchedule")]
        [HttpPost]
        public IHttpActionResult AddSchedule(CreateSchedule schedule)
        {
            //List<sp_GetUsersEmail_Result> useremail = new List<sp_GetUsersEmail_Result>();
            ObjectParameter errorMessage = new ObjectParameter("errorMessage", typeof(string));
            entities.sp_CreateSchedule(schedule.UserID,schedule.TopicID,schedule.Date,schedule.Time,schedule.MODE, errorMessage);
            entities.SaveChanges();
            return Ok();
        }

        public IHttpActionResult GetSchedule()
        {
            List<sp_GetSchedule_Result> schedulelist = new List<sp_GetSchedule_Result>();
            schedulelist = entities.sp_GetSchedule().ToList();      
            return Json(schedulelist);
        }

    }
}
