using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjetNET.Models;

public partial class ProjetNetdbContext : DbContext
{
    public ProjetNetdbContext()
    {
    }

    public ProjetNetdbContext(DbContextOptions<ProjetNetdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Commentaire> Commentaires { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ProjetNetConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admin__3214EC077C0AF50E");

            entity.ToTable("Admin");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(9)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(50)
                .HasColumnName("photo_url");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__chat__3214EC07B9527D81");

            entity.ToTable("chat");

            entity.Property(e => e.Feeling)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("feeling");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");

            entity.HasOne(d => d.Reciver).WithMany(p => p.ChatRecivers)
                .HasForeignKey(d => d.ReciverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reciver_User");

            entity.HasOne(d => d.Sender).WithMany(p => p.ChatSenders)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sender_User");
        });

        modelBuilder.Entity<Commentaire>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Commenta__3214EC07E3AE9D2D");

            entity.ToTable("Commentaire");

            entity.Property(e => e.Content)
                .HasMaxLength(50)
                .HasColumnName("content");
            entity.Property(e => e.Time)
                .HasMaxLength(50)
                .HasColumnName("time");
            entity.Property(e => e.UserName)
                .HasMaxLength(15)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPhoto)
                .HasMaxLength(50)
                .HasColumnName("user_photo");

            entity.HasOne(d => d.Post).WithMany(p => p.Commentaires)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_comment");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC075430816A");

            entity.ToTable("Notification");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Content).HasColumnName("content");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notif_User");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Photo__3214EC070614F55D");

            entity.ToTable("Photo");

            entity.Property(e => e.Fullpath)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("fullpath");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("url");

            entity.HasOne(d => d.Post).WithMany(p => p.Photos)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_photo");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC078C3BB587");

            entity.ToTable("Post");

            entity.Property(e => e.Countcomment).HasColumnName("countcomment");
            entity.Property(e => e.Countlike).HasColumnName("countlike");
            entity.Property(e => e.Countshare).HasColumnName("countshare");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Reserve).HasColumnName("reserve");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC076E48FD4E");

            entity.ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(9)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
