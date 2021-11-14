namespace DAL
{
  using DAL.Model;
  using System;
  using System.Data.Entity;
  using System.Linq;

  public class ExpanceDBModel : DbContext
  {
    // Your context has been configured to use a 'ExpanceDBModel' connection string from your application's 
    // configuration file (App.config or Web.config). By default, this connection string targets the 
    // 'DAL.ExpanceDBModel' database on your LocalDb instance. 
    // 
    // If you wish to target a different database and/or database provider, modify the 'ExpanceDBModel' 
    // connection string in the application configuration file.
    public ExpanceDBModel()
        : base("name=ExpanceDataBaseModel")
    {
    }

    // Add a DbSet for each entity type that you want to include in your model. For more information 
    // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

     public virtual DbSet<tbl_Email> tbl_Emails { get; set; }
    public virtual DbSet<tbl_Users> tbl_User { get; set; }
  }

  
}
