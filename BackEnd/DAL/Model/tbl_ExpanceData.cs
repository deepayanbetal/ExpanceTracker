using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
  public class tbl_ExpanceData
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ExpnceID { get; set; }
    public string ExpanceItem { get; set; }
    public DateTime ExpanceDate { get; set; }
    public decimal Price { get; set; }
    public string PriceBreakUp { get; set; }
    public string PaymentMethod { get; set; }
    public decimal CashBack { get; set; }
  }
}
