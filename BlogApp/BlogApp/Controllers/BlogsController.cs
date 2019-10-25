using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApp.Controllers
{

    public class BlogsController : BaseController
    {
        private readonly IBlogRepository _service;
        public BlogsController(IBlogRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]BlogCriteria blogCriteria)
        {
            var result = await _service.GetPagedAsync(blogCriteria);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetBlogAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Blog blog)
        {
            var result = await _service.CreateBlogAsync(blog);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Blog blog)
        {
            var result = await _service.UpdateBLogAsync(id, blog);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteBlogAsync(id);
            return Ok(result);
        }

    }
}
