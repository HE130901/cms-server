using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cms_server.Models;

public partial class CmsbdContext : DbContext
{
    public CmsbdContext()
    {
    }

    public CmsbdContext(DbContextOptions<CmsbdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Deceased> Deceaseds { get; set; }

    public virtual DbSet<Floor> Floors { get; set; }

    public virtual DbSet<Niche> Niches { get; set; }

    public virtual DbSet<NicheReservation> NicheReservations { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceOrder> ServiceOrders { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<VisitRegistration> VisitRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=trunghieu;Database=cmsbd;User Id=sa;Password=abcd1234;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Area__70B820282BCE14E3");

            entity.ToTable("Area");

            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.FloorId).HasColumnName("FloorID");

            entity.HasOne(d => d.Floor).WithMany(p => p.Areas)
                .HasForeignKey(d => d.FloorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Area_Floor");
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingId).HasName("PK__Building__5463CDE47370088E");

            entity.ToTable("Building");

            entity.Property(e => e.BuildingId).HasColumnName("BuildingID");
            entity.Property(e => e.BuildingName).HasMaxLength(255);
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK__Contract__C90D3409E5855441");

            entity.ToTable("Contract");

            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.NicheId).HasColumnName("NicheID");
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Customer");

            entity.HasOne(d => d.Niche).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.NicheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Niche");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B804D4836B");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.CitizenId, "UQ__Customer__6E49FBEDFA3F002E").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D1053485CB6DB4").IsUnique();

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

        modelBuilder.Entity<Deceased>(entity =>
        {
            entity.HasKey(e => e.DeceasedId).HasName("PK__Deceased__E7DB31FD717813D8");

            entity.ToTable("Deceased");

            entity.HasIndex(e => e.CitizenId, "UQ__Deceased__6E49FBED0D9C831A").IsUnique();

            entity.Property(e => e.DeceasedId).HasColumnName("DeceasedID");
            entity.Property(e => e.CitizenId)
                .HasMaxLength(50)
                .HasColumnName("CitizenID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.NicheId).HasColumnName("NicheID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Deceaseds)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Deceased_Customer");

            entity.HasOne(d => d.Niche).WithMany(p => p.Deceaseds)
                .HasForeignKey(d => d.NicheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Deceased_Niche");
        });

        modelBuilder.Entity<Floor>(entity =>
        {
            entity.HasKey(e => e.FloorId).HasName("PK__Floor__49D1E86B6D874806");

            entity.ToTable("Floor");

            entity.Property(e => e.FloorId).HasColumnName("FloorID");
            entity.Property(e => e.BuildingId).HasColumnName("BuildingID");
            entity.Property(e => e.NichePrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Building).WithMany(p => p.Floors)
                .HasForeignKey(d => d.BuildingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Floor_Building");
        });

        modelBuilder.Entity<Niche>(entity =>
        {
            entity.HasKey(e => e.NicheId).HasName("PK__Niche__57FA5922A4430C5F");

            entity.ToTable("Niche");

            entity.HasIndex(e => e.Qrcode, "UQ__Niche__5B869AD90670D113").IsUnique();

            entity.Property(e => e.NicheId).HasColumnName("NicheID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.Qrcode)
                .HasMaxLength(255)
                .HasColumnName("QRCode");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Area).WithMany(p => p.Niches)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Niche_Area");
        });

        modelBuilder.Entity<NicheReservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__NicheRes__B7EE5F04445C0380");

            entity.ToTable("NicheReservation");

            entity.HasIndex(e => e.DeceasedId, "UQ__NicheRes__E7DB31FCE57F4663").IsUnique();

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeceasedId).HasColumnName("DeceasedID");
            entity.Property(e => e.NicheId).HasColumnName("NicheID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.ConfirmedByNavigation).WithMany(p => p.NicheReservations)
                .HasForeignKey(d => d.ConfirmedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NicheReservation_Staff");

            entity.HasOne(d => d.Customer).WithMany(p => p.NicheReservations)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NicheReservation_Customer");

            entity.HasOne(d => d.Deceased).WithOne(p => p.NicheReservation)
                .HasForeignKey<NicheReservation>(d => d.DeceasedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NicheReservation_Deceased");

            entity.HasOne(d => d.Niche).WithMany(p => p.NicheReservations)
                .HasForeignKey(d => d.NicheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NicheReservation_Niche");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E320801CF05");

            entity.ToTable("Notification");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ServiceOrderId).HasColumnName("ServiceOrderID");
            entity.Property(e => e.VisitId).HasColumnName("VisitID");

            entity.HasOne(d => d.Contract).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK_Notification_Contract");

            entity.HasOne(d => d.Customer).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notification_Customer");

            entity.HasOne(d => d.ServiceOrder).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.ServiceOrderId)
                .HasConstraintName("FK_Notification_ServiceOrder");

            entity.HasOne(d => d.Visit).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.VisitId)
                .HasConstraintName("FK_Notification_Visit");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Report__D5BD48E541ADAA21");

            entity.ToTable("Report");

            entity.Property(e => e.ReportId).HasColumnName("ReportID");
            entity.Property(e => e.ReportType).HasMaxLength(50);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__C51BB0EA1227FECD");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ServiceName).HasMaxLength(255);
        });

        modelBuilder.Entity<ServiceOrder>(entity =>
        {
            entity.HasKey(e => e.ServiceOrderId).HasName("PK__ServiceO__8E1ABD0557B68453");

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
                .HasConstraintName("FK_ServiceOrder_Customer");

            entity.HasOne(d => d.Niche).WithMany(p => p.ServiceOrders)
                .HasForeignKey(d => d.NicheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceOrder_Niche");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceOrders)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceOrder_Service");

            entity.HasOne(d => d.Staff).WithMany(p => p.ServiceOrders)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceOrder_Staff");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF7FC86BE2B");

            entity.HasIndex(e => e.Email, "UQ__Staff__A9D105349A052BFC").IsUnique();

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<VisitRegistration>(entity =>
        {
            entity.HasKey(e => e.VisitId).HasName("PK__VisitReg__4D3AA1BE23434FAD");

            entity.ToTable("VisitRegistration");

            entity.Property(e => e.VisitId).HasColumnName("VisitID");
            entity.Property(e => e.ApprovalStatus).HasMaxLength(50);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.NicheId).HasColumnName("NicheID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.VisitRegistrations)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("FK_VisitRegistration_Staff");

            entity.HasOne(d => d.Customer).WithMany(p => p.VisitRegistrations)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VisitRegistration_Customer");

            entity.HasOne(d => d.Niche).WithMany(p => p.VisitRegistrations)
                .HasForeignKey(d => d.NicheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VisitRegistration_Niche");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
