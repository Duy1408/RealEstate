using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interface
{
    public interface ICommentRepo
    {
        List<Comment> GetAllComment();
        void AddNewComment(Comment comment);
        void UpdateComment(Comment comment);
        Comment GetCommentByID(int id);
        void DeleteComment(Comment comment);

    }
}
