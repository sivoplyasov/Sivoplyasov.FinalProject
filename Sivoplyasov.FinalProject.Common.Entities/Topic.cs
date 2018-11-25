using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sivoplyasov.FinalProject.Common.Entities
{
    public class Topic
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfCreation { get; set; }

        public int Category_Id { get; set; }

        public int Author_Id { get; set; }

        public string Description { get; set; }

        public int CountOfPosts { get; set; }

        public Post LastPost { get; set; }

        public bool IsClosed { get; set; }
    }
}
