using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookself.Models
{
    public class Book
    {
        public int Isbn { get; set; }
        public string Title { get; set; }
        public List<string> Authors { get; set; }
    }
}