﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LogingApp.Models;

public partial class BookStoreDbv001Context : DbContext
{
    //Scaffold-DbContext "Server=DESKTOP-79KOML2\SQLEXPRESS;Database=BookStoreDBV001;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
    public BookStoreDbv001Context()
    {
    }

    public BookStoreDbv001Context(DbContextOptions<BookStoreDbv001Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(60);
            entity.Property(e => e.LastName).HasMaxLength(60);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Isbn).HasMaxLength(20);
            entity.Property(e => e.Summary).HasMaxLength(60);
            entity.Property(e => e.Title).HasMaxLength(30);

            entity.HasOne(d => d.Author).WithMany(p => p.Books).HasForeignKey(d => d.AuthorId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}