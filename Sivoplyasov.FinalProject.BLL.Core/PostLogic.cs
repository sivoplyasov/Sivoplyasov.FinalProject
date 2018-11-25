using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sivoplyasov.FinalProject.BLL.Contracts;
using Sivoplyasov.FinalProject.Common.Entities;

namespace Sivoplyasov.FinalProject.BLL.Core
{
    public class PostLogic : IPostLogic
    {
        public bool Add(Post post)
        {
            post.DateOfCreation = DateTime.Now;
            if (post.PostText.Length > 1000)
            {
                throw new ArgumentException();
            }

            return Daos.PostDAO.Add(post);
        }

        public bool EditPost(Post post)
        {
            return Daos.PostDAO.EditPost(post);
        }

        public IEnumerable<Post> GetAll()
        {
            return Daos.PostDAO.GetAll().ToList();
        }

        public Post GetLastPostByCategoryId(int id)
        {
            return Daos.PostDAO.GetLastPostByCategoryId(id);
        }

        public Post GetLastPostByTopicId(int id)
        {
            return Daos.PostDAO.GetLastPostByTopicId(id);
        }

        public Post GetPostById(int id)
        {
            return Daos.PostDAO.GetPostById(id);
        }

        public IEnumerable<Post> GetPostsByTopicId(int id)
        {
            return Daos.PostDAO.GetPostsByTopicId(id).ToList();
        }

        public bool RemovePostById(int id)
        {
            return Daos.PostDAO.RemovePostById(id);
        }
    }
}
