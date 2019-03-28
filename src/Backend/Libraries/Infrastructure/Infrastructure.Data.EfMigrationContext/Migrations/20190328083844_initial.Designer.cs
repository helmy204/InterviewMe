﻿// <auto-generated />
using System;
using Infrastructure.Data.EfMigrationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.EfMigrationContext.Migrations
{
    [DbContext(typeof(InterviewMeContext))]
    [Migration("20190328083844_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Infrastructure.Data.EfMigrationContext.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BodyText");

                    b.Property<long>("InsertedBy");

                    b.Property<DateTime>("InsertedOn");

                    b.Property<string>("Title");

                    b.Property<long>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
