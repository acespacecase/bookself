using Bookself.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookself.DAL
{
    public interface IBookSource
    {
        List<Book> GetUsersBooks(int userId);
        Book GetBook(int bookIsbn);
        bool AddBook(Book newBook, int userId);
        bool DeleteBook(Book bookToDelete);
    }
}
