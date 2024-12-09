using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concretes
{
    public class Report:IEntites
    {
      public int Id { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public DateTime CreateTime { get; set; }
      public int CreatedById { get; set; }
      public User CreatedBy { get; set; }

    }
}
