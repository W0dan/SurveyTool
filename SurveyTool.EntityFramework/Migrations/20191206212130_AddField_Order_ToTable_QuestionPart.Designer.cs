﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveyTool.EntityFramework;

namespace SurveyTool.EntityFramework.Migrations
{
    [DbContext(typeof(SurveyToolContext))]
    [Migration("20191206212130_AddField_Order_ToTable_QuestionPart")]
    partial class AddField_Order_ToTable_QuestionPart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SurveyTool.EntityFramework.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid?>("SurveyPageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SurveyPageId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("SurveyTool.EntityFramework.QuestionAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnswerText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SurveyAnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SurveyAnswerId");

                    b.ToTable("QuestionAnswer");
                });

            modelBuilder.Entity("SurveyTool.EntityFramework.QuestionPart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionPart");
                });

            modelBuilder.Entity("SurveyTool.EntityFramework.QuestionPartAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("QuestionAnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("QuestionPartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionAnswerId");

                    b.HasIndex("QuestionPartId");

                    b.ToTable("QuestionPartAnswer");
                });

            modelBuilder.Entity("SurveyTool.EntityFramework.Survey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("LogoImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("SurveyTool.EntityFramework.SurveyAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SurveyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyAnswer");
                });

            modelBuilder.Entity("SurveyTool.EntityFramework.SurveyPage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PageNumber")
                        .HasColumnType("int");

                    b.Property<Guid?>("SurveyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyPage");
                });

            modelBuilder.Entity("SurveyTool.EntityFramework.Question", b =>
                {
                    b.HasOne("SurveyTool.EntityFramework.SurveyPage", "SurveyPage")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyPageId");
                });

            modelBuilder.Entity("SurveyTool.EntityFramework.QuestionAnswer", b =>
                {
                    b.HasOne("SurveyTool.EntityFramework.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");

                    b.HasOne("SurveyTool.EntityFramework.SurveyAnswer", "SurveyAnswer")
                        .WithMany("QuestionAnswers")
                        .HasForeignKey("SurveyAnswerId");
                });

            modelBuilder.Entity("SurveyTool.EntityFramework.QuestionPart", b =>
                {
                    b.HasOne("SurveyTool.EntityFramework.Question", "Question")
                        .WithMany("Parts")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("SurveyTool.EntityFramework.QuestionPartAnswer", b =>
                {
                    b.HasOne("SurveyTool.EntityFramework.QuestionAnswer", "QuestionAnswer")
                        .WithMany("QuestionPartAnswers")
                        .HasForeignKey("QuestionAnswerId");

                    b.HasOne("SurveyTool.EntityFramework.QuestionPart", "QuestionPart")
                        .WithMany("QuestionPartAnswers")
                        .HasForeignKey("QuestionPartId");
                });

            modelBuilder.Entity("SurveyTool.EntityFramework.SurveyAnswer", b =>
                {
                    b.HasOne("SurveyTool.EntityFramework.Survey", "Survey")
                        .WithMany("Answers")
                        .HasForeignKey("SurveyId");
                });

            modelBuilder.Entity("SurveyTool.EntityFramework.SurveyPage", b =>
                {
                    b.HasOne("SurveyTool.EntityFramework.Survey", null)
                        .WithMany("Pages")
                        .HasForeignKey("SurveyId");
                });
#pragma warning restore 612, 618
        }
    }
}
