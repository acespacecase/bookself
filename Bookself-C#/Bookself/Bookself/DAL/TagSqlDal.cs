using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookself.Models;
using System.Data.SqlClient;
using Dapper;

namespace Bookself.DAL
{
    public class TagSqlDal : ITagSource
    {
        private const string SQL_GetAllUsersTagForABook = "SELECT tag.* FROM tag INNER JOIN book_tag ON book_tag.tag_id = tag.id INNER JOIN user_book ON book_tag.book_isbn = user_book.book_isbn WHERE user_book.[user_id] = @userId AND book_tag.book_isbn = @bookIsbn ORDER BY tag.tag_name DESC;";
        private const string SQL_DeleteTagFromBookTagTable = "DELETE FROM book_tag WHERE tag_name = @tagName;";
        private const string SQL_GetAllUsersTagForAllBooks = "SELECT tag_name FROM tag INNER JOIN book_tag ON book_tag.tag_id = tag.id INNER JOIN user_book ON user_book.book_isbn = book_tag.book_isbn WHERE user_book.user_id = @userId;";
        readonly string connectionString;

        public TagSqlDal(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        public bool AddTag(Tag newTag)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    int rowsAffected = conn.Execute("INSERT INTO tag VALUES(tag_name = @tagName);", new { tagName = newTag.Name });

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

        public List<Tag> AllUserTags(int userId)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    return conn.Query<Tag>(SQL_GetAllUsersTagForAllBooks, new { userId = userId }).ToList();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Tag> AllUserTagsForABook(int userId, int bookIsbn)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    List<Tag> allUserTagsForABook = conn.Query<Tag>(SQL_GetAllUsersTagForABook, new { userId = userId, bookIsbn = bookIsbn }).ToList();
                    return allUserTagsForABook;
                }
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteTag(Tag tagToDelete)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // deletes from book_tag table only, not tag table
                    int rowsAffected = conn.Execute(SQL_DeleteTagFromBookTagTable, new { tagName = tagToDelete.Name });

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
    }
}