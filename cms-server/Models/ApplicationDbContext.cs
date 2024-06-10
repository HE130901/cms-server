using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cms_server.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Floor> Floors { get; set; }

    public virtual DbSet<Niche> Niches { get; set; }

    public virtual DbSet<NicheReservation> NicheReservations { get; set; }

    public virtual DbSet<Recipient> Recipients { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceOrder> ServiceOrders { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<VisitRegistration> VisitRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=trunghieu;Database=cmsdb1;User Id=sa;Password=abcd1234;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Area__70B820289B39041E");

            entity.ToTable("Area");

            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.AreaName).HasMaxLength(255);
            entity.Property(e => e.FloorId).HasColumnName("FloorID");

            entity.HasOne(d => d.Floor).WithMany(p => p.Areas)
                .HasForeignKey(d => d.FloorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Area__FloorID__4E88ABD4");
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingId).HasName("PK__Building__5463CDE40BA3EEBF");

            entity.ToTable("Building");

            entity.Property(e => e.BuildingId).HasColumnName("BuildingID");
            entity.Property(e => e.BuildingName).HasMaxLength(255);
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK__Contract__C90D3409DD4D7890");

            entity.ToTable("Contract");

            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.NicheId).HasColumnName("NicheID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.RecipientId).HasColumnName("RecipientID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contract__Custom__5FB337D6");

            entity.HasOne(d => d.Niche).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.NicheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contract__NicheI__60A75C0F");

            entity.HasOne(d => d.Recipient).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.RecipientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contract__Recipi__619B8048");

            entity.HasOne(d => d.Staff).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contract__StaffI__628FA481");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B82229613B");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.CitizenId, "UQ__Customer__6E49FBED67674557").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D10534AB36B0C7").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CitizenId)
                .HasMaxLength(50)
                .HasColumnName("CitizenID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Floor>(entity =>
        {
            entity.HasKey(e => e.FloorId).HasName("PK__Floor__49D1E86BFF359D5B");

            entity.ToTable("Floor");

            entity.Property(e => e.FloorId).HasColumnName("FloorID");
            entity.Property(e => e.BuildingId).HasColumnName("BuildingID");
            entity.Property(e => e.FloorName).HasMaxLength(255);
            entity.Property(e => e.NichePrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Building).WithMany(p => p.Floors)
                .HasForeignKey(d => d.BuildingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Floor__BuildingI__4BAC3F29");
        });

        modelBuilder.Entity<Niche>(entity =>
        {
            entity.HasKey(e => e.NicheId).HasName("PK__Niche__57FA5922997A0AF0");

            entity.ToTable("Niche");

            entity.Property(e => e.NicheId).HasColumnName("NicheID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.NicheName).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Area).WithMany(p => p.Niches)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Niche__AreaID__5165187F");
        });

        modelBuilder.Entity<NicheReservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__NicheRes__B7EE5F04F2958CFF");

            entity.ToTable("NicheReservation");

            entity.HasIndex(e => e.RecipientId, "UQ__NicheRes__F0A601ACE0EAEFDD").IsUnique();

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.NicheId).HasColumnName("NicheID");
            entity.Property(e => e.RecipientId).HasColumnName("RecipientID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.ConfirmedByNavigation).WithMany(p => p.NicheReservations)
                .HasForeignKey(d => d.ConfirmedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NicheRese__Confi__75A278F5");

            entity.HasOne(d => d.Customer).WithMany(p => p.NicheReservations)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NicheRese__Custo__72C60C4A");

            entity.HasOne(d => d.Niche).WithMany(p => p.NicheReservations)
                .HasForeignKey(d => d.NicheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NicheRese__Niche__74AE54BC");

            entity.HasOne(d => d.Recipient).WithOne(p => p.NicheReservation)
                .HasForeignKey<NicheReservation>(d => d.RecipientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NicheRese__Recip__73BA3083");
        });

        modelBuilder.Entity<Recipient>(entity =>
        {
            entity.HasKey(e => e.RecipientId).HasName("PK__Recipien__F0A601ADD1F99A16");

            entity.ToTable("Recipient");

            entity.HasIndex(e => e.CitizenId, "UQ__Recipien__6E49FBED3EF462F0").IsUnique();

            entity.Property(e => e.RecipientId).HasColumnName("RecipientID");
            entity.Property(e => e.CitizenId)
                .HasMaxLength(50)
                .HasColumnName("CitizenID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.NicheId).HasColumnName("NicheID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Recipients)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recipient__Custo__59FA5E80");

            entity.HasOne(d => d.Niche).WithMany(p => p.Recipients)
                .HasForeignKey(d => d.NicheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recipient__Niche__59063A47");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Report__D5BD48E5F03933E4");

            entity.ToTable("Report");

            entity.Property(e => e.ReportId).HasColumnName("ReportID");
            entity.Property(e => e.ReportType).HasMaxLength(50);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__C51BB0EA47D15BB7");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ServiceName).HasMaxLength(255);
        });

        modelBuilder.Entity<ServiceOrder>(entity =>
        {
            entity.HasKey(e => e.ServiceOrderId).HasName("PK__ServiceO__8E1ABD05887603EC");

            entity.ToTable("ServiceOrder");

            entity.Property(e => e.ServiceOrderId).HasColumnName("ServiceOrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.NicheId).HasColumnName("NicheID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.ServiceOrders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ServiceOr__Custo__6754599E");

            entity.HasOne(d => d.Niche).WithMany(p => p.ServiceOrders)
                .HasForeignKey(d => d.NicheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ServiceOr__Niche__68487DD7");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceOrders)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ServiceOr__Servi__693CA210");

            entity.HasOne(d => d.Staff).WithMany(p => p.ServiceOrders)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ServiceOr__Staff__6A30C649");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF7D768F8D8");

            entity.HasIndex(e => e.Email, "UQ__Staff__A9D10534807D8C46").IsUnique();

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.StaffName).HasMaxLength(255);
        });

        modelBuilder.Entity<VisitRegistration>(entity =>
        {
            entity.HasKey(e => e.VisitId).HasName("PK__VisitReg__4D3AA1BE6226DB0F");

            entity.ToTable("VisitRegistration");

            entity.Property(e => e.VisitId).HasColumnName("VisitID");
            entity.Property(e => e.ApprovalStatus).HasMaxLength(50);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.NicheId).HasColumnName("NicheID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.VisitRegistrations)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("FK__VisitRegi__Appro__6EF57B66");

            entity.HasOne(d => d.Customer).WithMany(p => p.VisitRegistrations)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VisitRegi__Custo__6D0D32F4");

            entity.HasOne(d => d.Niche).WithMany(p => p.VisitRegistrations)
                .HasForeignKey(d => d.NicheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VisitRegi__Niche__6E01572D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
