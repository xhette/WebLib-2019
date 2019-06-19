using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories.CompositeModels.Books
{
    public class BookEditModel
    {
        public BookModel Book { get; set; }
        public AuthorModel Author { get; set; }
        public SelectList Departments { get; set; }
        public SelectList Libraries { get; set; }
        public int SelectedLibraryId { get; set; }
        public int SelectedDepartmentId { get; set; }
    }
}
