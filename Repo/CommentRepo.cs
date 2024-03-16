using BusinessObject.BusinessObject;
using DAO;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class CommentRepo : ICommentRepo
    {
        private readonly CommentDAO dao;
        public CommentRepo()
        {
            dao = new CommentDAO();
        }

        public void AddNewComment(Comment comment) => dao.AddNewComment(comment);

        public void DeleteComment(Comment comment) => dao.DeleteComment(comment);

        public List<Comment> GetAllComment() => dao.GetAllComment();

        public Comment GetCommentByID(int id) => dao.GetCommentByID(id);

        public void UpdateComment(Comment comment) => dao.UpdateComment(comment);

    }
}
