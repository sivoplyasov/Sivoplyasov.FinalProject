using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sivoplyasov.FinalProject.Common.Entities
{
    public class Post 
    {
        public int Id { get; set; }

        public int Topic_Id { get; set; }

        public string PostText { get; set; }

        public DateTime DateOfCreation { get; set; }

        public int User_Id { get; set; }

        public int? Reply_Id { get; set; }
    }
}
