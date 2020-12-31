using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Core.Setup;

namespace Data.Mapping
{
    //public class EmployeeDetailsMap : EntityTypeConfiguration<EmployeeDetails>
    //{
    //    EmployeeDetailsMap()
    //    {
    //        //key
    //        HasKey(t => t.ID);
    //        //properties
    //        Property(t => t.Address).IsRequired();
    //        Property(t => t.Email).IsRequired();
    //        Property(t => t.Age).IsRequired();
    //        Property(t => t.AddedDate).IsRequired();
    //        Property(t => t.ModifiedDate).IsRequired();
    //        //table
    //        ToTable("EmployeeDetails");
    //        HasRequired(t => t.Employee).WithRequiredDependent(u => u.EmployeeDetails);

    //    }
    //}
}