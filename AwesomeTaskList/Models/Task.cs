using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AwesomeTaskList.Models
{
    //[Table("Tasks")]

    public class Task
    {
        //connectionString="data source=(SQLusername);initial catalog=(Database);
        //integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" 
        //providerName="System.Data.SqlClient"

            //[Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueTime { get; set; }
        public bool Completed { get; set; }

        
    }
}