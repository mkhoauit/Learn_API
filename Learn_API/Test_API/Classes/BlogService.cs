using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_API.Classes
{
    public static class BlogService
    {
        static List<Blog> Blogs { get; }
        static int nextId = 14; 
        static BlogService()
        {
            Blogs = new List<Blog>
            {
                new Blog { BlogId = 11, Url = "test.com", Rating = 4, IsDeleted = true },
                new Blog { BlogId = 12, Url = "dev.com", Rating = 5, IsDeleted = false },
                new Blog { BlogId = 13, Url = "learnAPI.com", Rating = 3, IsDeleted = false },
            };
        }

        public static List<Blog> GetAll() => Blogs;

        public static Blog? Get(int id) => Blogs.FirstOrDefault(p => p.BlogId == id);

        public static void Add(Blog blog)
        {
            blog.BlogId = nextId++;
            Blogs.Add(blog);
        }

        public static void Delete(int id)
        {
            var blog = Get(id);
            if(blog is null)
                return;
            Blogs.Remove(blog);
        }

        public static void Update(Blog blog)
        {
            var index = Blogs.FindIndex(p => p.BlogId == blog.BlogId);
            if(index == -1)
                return;
            Blogs[index] = blog;
        }
    }
}