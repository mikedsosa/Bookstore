using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mike05.Models;

namespace Mike05.Models.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}

