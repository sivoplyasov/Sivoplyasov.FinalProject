using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sivoplyasov.FinalProject.BLL.Contracts;
using Sivoplyasov.FinalProject.Common.Entities;

namespace Sivoplyasov.FinalProject.BLL.Core
{
    public class TopicLogic : ITopicLogic
    {
        public bool Add(Topic topic)
        {
            topic.DateOfCreation = DateTime.Now;
            if (topic.Name.Length > 50 || topic.Description.Length > 50)
            {
                throw new ArgumentException();
            }

            return Daos.TopicDAO.Add(topic);
        }

        public bool Add(Topic topic, out int topicId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetAll()
        {
            var topics = Daos.TopicDAO.GetAll().ToList();
            for (int i = 0; i < topics.Count; i++)
            {
                topics[i].CountOfPosts = Daos.TopicDAO.GetCountOfPostsByTopicId(topics[i].Id);
                topics[i].LastPost = Daos.PostDAO.GetLastPostByTopicId(topics[i].Id);
            }

            return topics;
        }

        public IEnumerable<Topic> GetTopicsByCategoryId(int id)
        {
            var topics = Daos.TopicDAO.GetTopicsByCategoryId(id).ToList();
            for (int i = 0; i < topics.Count; i++)
            {
                topics[i].CountOfPosts = Daos.TopicDAO.GetCountOfPostsByTopicId(topics[i].Id);
                topics[i].LastPost = Daos.PostDAO.GetLastPostByTopicId(topics[i].Id);
            }

            return topics;
        }

        public int GetCountOfPostsByTopicId(int id)
        {
            return Daos.TopicDAO.GetCountOfPostsByTopicId(id);
        }

        public Topic GetTopicById(int id)
        {
            var topic = Daos.TopicDAO.GetTopicById(id);
            if (topic != null)
            {
                topic.CountOfPosts = Daos.TopicDAO.GetCountOfPostsByTopicId(topic.Id);
                topic.LastPost = Daos.PostDAO.GetLastPostByTopicId(topic.Id);
            }

            return topic;
        }

        public int GetLastTopicId()
        {
            return Daos.TopicDAO.GetLastTopicId();
        }

        public bool RemoveTopicById(int id)
        {
            return Daos.TopicDAO.RemoveTopicById(id);
        }

        public bool CloseTopic(Topic topic)
        {
            return Daos.TopicDAO.CloseTopic(topic);
        }
    }
}
