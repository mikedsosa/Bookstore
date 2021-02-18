using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Mike05.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookDbContext _context;

        //constuctor
        public EFBookRepository(BookDbContext context)
        {
            _context = context;
        }

        //create iqueryable to iterate books list
        public IQueryable<Book> Books => _context.Books;
    }
}
