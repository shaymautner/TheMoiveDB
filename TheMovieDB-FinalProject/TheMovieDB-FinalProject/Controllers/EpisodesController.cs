﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheMovieDB.Models;
using TheMovieDB.Models.DAL;

namespace TheMovieDB.Controllers
{
    public class EpisodesController : ApiController
    {
        /*
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            DataServices ds = new DataServices();
            return ds.Get();
        }
        */
        // GET api/<controller>/5
        public HttpResponseMessage Get(int user_id, int tv_id)
        {
            try
            {
                Episode ep = new Episode();
                List<Episode> epList = ep.Get(user_id, tv_id);
                if (epList == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No saved episodes exist for user id " + user_id);
                return Request.CreateResponse(HttpStatusCode.OK, epList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
        }

        // POST api/Episodes
        public HttpResponseMessage Post([FromBody] Episode ep)
        {
            try
            {
                if (ep.Insert() == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Cannot add the episode to the database.");
                return Request.CreateResponse(HttpStatusCode.OK, "Episode was succesfully added to the database.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, ex.Message);
            }
        }
        /*
        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        */
    } // End of class definition - EpisodesController.

}