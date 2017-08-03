using Bookself.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookself.DAL
{
    public interface ITagSource
    {
        List<Tag> AllUserTagsForABook(int userId, int bookIsbn);
        bool AddTag(Tag newTag);
        bool DeleteTag(Tag tagToDelete);
        List<Tag> AllUserTags(int userId);
    }
}
