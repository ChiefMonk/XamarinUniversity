using System;
using System.Collections.Generic;

namespace BookClient.Data
{
    public class Book
    {
	    public Book()
	    {
		    ISBN = null;
		    Title = null;
		    Authors = new List<string>();
		    PublishDate = DateTime.Now;
		    Genre = null;
		}

		public string ISBN { get; set; }
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
    }
}

