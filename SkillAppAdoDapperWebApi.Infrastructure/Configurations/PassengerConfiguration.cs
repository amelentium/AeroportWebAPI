using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillManagement.DataAccess.Entities.SQLEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillAppAdoDapperWebApi.Infrastructure.Configurations
{
	public class PassengerConfiguration : IEntityTypeConfiguration<SQLPassenger>
	{
		public void Configure(EntityTypeBuilder<SQLPassenger> builder)
		{
			builder.HasOne(p => p.Flight).WithMany();
		}
	}
}
