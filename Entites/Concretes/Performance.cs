using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concretes
{
    public class Performance:IEntites
    {
       public int Id {  get; set; }
       public int EmployeeId { get; set; }
       public Employee Employee { get; set; }
       public DateTime ReiewDate { get; set; }
       public string ReviewBy  { get; set; }
       public string Comments { get; set;}
       public int Rating  { get; set;}
    } 
}
