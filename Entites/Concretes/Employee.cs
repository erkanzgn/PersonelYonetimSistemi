using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concretes
{
    public class Employee:IEntites
    {
       public int Id { get; set; } 
       public int UserId { get; set; }  
       public DateTime HireDate { get; set; }
       public int DeparmentId { get; set; }
       public Deparment Deparment { get; set; }
       public ICollection<WorkRequest> WorkRequests  { get; set;}
       public ICollection<Performance> Performances { get; set ;}
    }
}
