using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concretes
{
    public class WorkRequest:IEntites
    {
       public int Id { get; set; }  
       public int EmployeeId { get; set; }
       public WorkRequestType RequestType { get; set; }
       public DateTime RequestDate { get; set; }
       public DateTime? StartDate { get; set; }
       public DateTime? EndDate { get; set;}
       public WorkRequestStatus Status { get; set; }
       public string Description { get; set; }
       

        public Employee Employee { get; set; }
    }

    public enum WorkRequestType
    {
        OverTime=1,
        Leave =2
    }
    public enum WorkRequestStatus
    {
        Pending=1,
        Approved =2,
        Rejected =3 
    }
}
