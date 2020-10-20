using DvdLibrary.Models;
using DvdLibrary.Models.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DvdLibrary.Controllers
{
    //Use methods like Milestone 2 lesson 8
    public class DvdController : ApiController
    {
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            var repos = new RepoFactory().OrderFactory();
            return Ok(repos.RetrieveAll());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetById(int id)
        {
            var repos = new RepoFactory().OrderFactory();
            Dvd dvd = repos.RetrieveById(id);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            var repos = new RepoFactory().OrderFactory();
            List<Dvd> dvd = repos.RetrieveByTitle(title);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByYear(string releaseYear)
        {
            var repos = new RepoFactory().OrderFactory();
            List<Dvd> dvd = repos.RetrieveByYear(int.Parse(releaseYear));

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirector(string directorName)
        {
            var repos = new RepoFactory().OrderFactory();
            List<Dvd> dvd = repos.RetrieveByName(directorName);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            var repos = new RepoFactory().OrderFactory();
            List<Dvd> dvd = repos.RetrieveByRating(rating);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(Dvd dvd)
        {
            var repos = new RepoFactory().OrderFactory();
            repos.Create(dvd);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit(Dvd dvd)
        {
            var repos = new RepoFactory().OrderFactory();
            repos.Update(dvd);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int id)
        {
            var repos = new RepoFactory().OrderFactory();
            repos.Delete(id);

            return Ok();
        }
    }
}
