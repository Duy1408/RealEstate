using BusinessObject.BusinessObject;
using Repo.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _service;
        public CommentService(ICommentRepo service)
        {
            _service = service;
        }

        public void AddNewComment(Comment comment) => _service.AddNewComment(comment);

        public void DeleteComment(Comment comment) => _service.DeleteComment(comment);

        public List<Comment> GetAllComment() => _service.GetAllComment();

        public Comment GetCommentByID(int id) => _service.GetCommentByID(id);

        public void UpdateComment(Comment comment) => _service.UpdateComment(comment);

    }
}
