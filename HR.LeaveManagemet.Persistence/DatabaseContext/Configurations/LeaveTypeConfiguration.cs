﻿using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HR.LeaveManagemet.Persistence.DatabaseContext.Configurations
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                            new LeaveType
                            {
                                Id = 1,
                                Name = "Vacation",
                                DefaultDays = 10,
                                DateCreated = DateTime.Now,
                                DateModified = DateTime.Now
                            }
            );

            builder.Property(q => q.Name)
            .IsRequired()
            .HasMaxLength(100);
        }

    }
}
