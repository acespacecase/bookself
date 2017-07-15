using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookself.Models;
using System.Data.SqlClient;
using Dapper;

namespace Bookself.DAL
{
    public class BookSqlDal : IBookSource
    {
        private const string SQL_AddBookToUser = "INSERT INTO user_book VALUES (@isbn, @userId);";
        private const string SQL_AddNewBook = "INSERT INTO book VALUES (@isbn, @title, @author);";
        private const string SQL_GetSingleBook = "SELECT * FROM book WHERE isbn = @bookIsbn;";
        private const string SQL_GetUsersBook = "SELECT * FROM book INNER JOIN user_book ON user_book.book_isbn = book.isbn WHERE user_book.user_id = @userId;";
        readonly string connectionString;

        public BookSqlDal(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        public bool AddBook(Book newBook, int userId)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // add book to book table first, if it's not already there
                    if(GetBook(newBook.Isbn) == null)
                    {
                        conn.Execute(SQL_AddNewBook, new { isbn = newBook.Isbn, title = newBook.Title, authors = string.Join(", ", newBook.Authors)});
                    }

                    // add existing book to user
                    int affectedRows = conn.Execute(SQL_AddBookToUser, new { isbn = newBook.Isbn, userId = userId });
                    if (affectedRows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteBook(Book bookToDelete)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    int rowsAffected = conn.Execute("DELETE FROM user_book WHERE book_isbn = @bookisbn;", new { bookisbn = bookToDelete.Isbn });

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public Book GetBook(int bookIsbn)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    Book currentBook = conn.QueryFirstOrDefault<Book>(SQL_GetSingleBook, new { bookIsbn = bookIsbn });

                    return currentBook;
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Book> GetUsersBooks(int userId)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    List<Book> currentUsersBooks = conn.Query<Book>(SQL_GetUsersBook, new { userId = userId }).ToList();

                    return currentUsersBooks;
                }
            }
            catch
            {
                throw;
            }
        }
        
    }
}