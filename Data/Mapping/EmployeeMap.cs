using Core.Setup;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        EmployeeMap()
        {
            //key
            HasKey(t => t.ID);
            //properties
            Property(t => t.AddedDate).IsRequired();
            Property(t => t.Department).IsRequired();
            Property(t => t.EmployeeName).IsRequired();
            Property(t => t.LastName).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();

            //table
            ToTable("Employee");
        }
    }
}
