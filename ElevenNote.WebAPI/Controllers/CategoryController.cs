using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ElevenNote.Data;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;

namespace ElevenNote.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        public CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            return service;

        }

        public IHttpActionResult Get()
        {
            var service = CreateCategoryService();
            var categories = service.GetCategories();
            return Ok(categories);
        }
        public IHttpActionResult Post(Category model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCategoryService();
            if (!service.CreateCategory(model))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(Category model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var service = CreateCategoryService();
            if (!service.UpdateCategory(model))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCategoryService();
            if (!service.DeleteCategory(id))
                return InternalServerError();
            return Ok();
        }
    }
}
