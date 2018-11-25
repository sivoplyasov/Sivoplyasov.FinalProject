using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sivoplyasov.FinalProject.Common.Entities
{
    public class Category
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public int SectionId { get; set; }

        public int CountOfTopics { get; set; }

        public int CountOfPosts { get; set; }

        public Post LastPost { get; set; }
    }
}
