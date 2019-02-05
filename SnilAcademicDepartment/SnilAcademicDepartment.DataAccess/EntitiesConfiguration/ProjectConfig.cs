﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SnilAcademicDepartment.DataAccess.Models;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    class ProjectConfig : EntityTypeConfiguration<Project>
    {
        public ProjectConfig()
        {
            this.Property(p => p.ProjectId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.CommonID)
                .IsRequired();

            this.Property(p => p.ProjectName)
                .HasMaxLength(300)
                .IsRequired();

            this.Property(p => p.Description)
                .HasMaxLength(600)
                .IsRequired();

			this.Property(p => p.ShortDescription)
                .HasMaxLength(400)
                .IsRequired();

			this.Property(p => p.Status)
				.HasMaxLength(20)
				.IsRequired();
		}
    }
}
