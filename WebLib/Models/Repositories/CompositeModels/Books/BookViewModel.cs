using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories.CompositeModels.Books
{
    public class BookViewModel
    {
        public AuthorModel Author { get; set; }
        public BookModel Book { get; set; }
        public DepartmentModel Department { get; set; }
        public LibraryModel Library { get; set; }
    }
}
