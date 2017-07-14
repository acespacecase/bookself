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
        List<Book> GetUsersBook(int userId);
        Book GetBook(int bookIsbn);
        bool AddBook(Book newBook, int userId);
        bool UpdateBook(Book bookToUpdate);
        bool DeleteBook(Book bookToDelete);
    }
}
