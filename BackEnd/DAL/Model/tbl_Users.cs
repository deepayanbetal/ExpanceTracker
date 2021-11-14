using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
  public class tbl_Users
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string UserName { get; set; }
    public string UserID { get; set; }
    public string FullName { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
  }


  public class tbl_UsersDTO
  {
    public string UserID { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
  }

}
