using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Test_API.Classes;

namespace Test_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : Controller
    {
        public BlogController()
        {
        }
        // GET ALL
        [HttpGet]
        public ActionResult<List<Blog>> GetAll() =>BlogService.GetAll();
        
        // GET ID
        [HttpGet("{id}")]
        public ActionResult<Blog> Get(int id)
        {
            var findID = BlogService.Get(id);
            
            if(findID is null)
                return NotFound();
            
            return findID;
        }
        // POST
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            BlogService.Add(blog);
            return CreatedAtAction(nameof(Create), new {id=blog.BlogId }, blog);
        }
        // PUT
        [HttpPut("{id}")]
        public IActionResult Update(int id, Blog blog)
        {
            if (id != blog.BlogId)
                return BadRequest();

            var existingBlog = BlogService.Get(id);
            if(existingBlog is null)
                return NotFound();

            BlogService.Update(blog);           

            return Content($"Succecfully update blog {blog.BlogId}, URL: {blog.Url}, Rating: {blog.Rating}");
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delBlog = BlogService.Get(id);

            if (delBlog is null)
                return NotFound();

            BlogService.Delete(id);

            return Content($"Succecfully DELETE blog {id}");
        }
    }
}