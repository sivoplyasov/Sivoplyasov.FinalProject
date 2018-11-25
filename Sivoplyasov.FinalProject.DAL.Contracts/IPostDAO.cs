using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sivoplyasov.FinalProject.Common.Entities;

namespace Sivoplyasov.FinalProject.DAL.Contracts
{
    public interface IPostDAO
    {
        bool RemovePostById(int id);

        bool Add(Post post);

        bool EditPost(Post post);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetPostsByTopicId(int id);

        Post GetPostById(int id);

        Post GetLastPostByCategoryId(int id);

        Post GetLastPostByTopicId(int id);
    }
}
