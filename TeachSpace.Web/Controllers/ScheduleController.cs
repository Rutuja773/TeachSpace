using NLog;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();


        private TeachSpaceDBEntities entities = new TeachSpaceDBEntities();
        public ScheduleController()
        {
            this.entities = new TeachSpaceDBEntities();
        }


        //Fetch The User Emails from the Database

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
        }


        //Fetch The Topic Names From the Database

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
            
        }


        //create a schedule for the user 

        [Route("api/Schedule/AddSchedule")]
        [HttpPost]
        public IHttpActionResult AddSchedule(CreateSchedule schedule)
        {
            //List<sp_GetUsersEmail_Result> useremail = new List<sp_GetUsersEmail_Result>();
            ObjectParameter errorMessage = new ObjectParameter("errorMessage", typeof(string));
            entities.sp_CreateSchedule(schedule.UserID,schedule.TopicID,schedule.Date,schedule.Time,schedule.MODE, errorMessage);
            entities.SaveChanges();
           
            logger.Info("Schedule Successful");
            return Ok();
        }


        //Get the Schedule list of user

        [Route("api/Schedule/GetSchedule")]
        [HttpGet]
        public IHttpActionResult GetSchedule()
        {
            List<sp_GetSchedule_Result> schedulelist = new List<sp_GetSchedule_Result>();
            schedulelist = entities.sp_GetSchedule().ToList();      
            return Json(schedulelist);
        }


        //Get the Schedule list for a specific user
        [Route("api/Schedule/GetUserSchedule")]
        [HttpGet]
        public IHttpActionResult GetUserSchedule()
        {
            List<sp_GetUserSchedule_Result> userschedulelist = new List<sp_GetUserSchedule_Result>();
            userschedulelist = entities.sp_GetUserSchedule(AccountController.UserId).ToList();
            return Json(userschedulelist);
        }


        //Get The Audit list

        [Route("api/Schedule/GetAudit")]
        [HttpGet]
        public IHttpActionResult GetAudit()
        {
            List<sp_GetAudit_Result> auditlist = new List<sp_GetAudit_Result>();
            auditlist = entities.sp_GetAudit().ToList();
            return Json(auditlist);
        }

        //[Route("api/Schedule/CreateTopic")]
        //[HttpPost]
        //public IHttpActionResult CreateTopic(CreateTopic createtopic)
        //{
        //    entities.CreateTopic(createtopic.Name);
        //    entities.SaveChanges();
        //    logger.Info("Topic Name Added Sucesfully");
        //    return Ok();
        //}

    }
}
