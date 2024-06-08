﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cms_server.Models;

#nullable disable

namespace cms_server.Migrations
{
    [DbContext(typeof(CmsbdContext))]
    [Migration("20240608012857_AddFloorNameToFloor_Fixed")]
    partial class AddFloorNameToFloor_Fixed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("cms_server.Models.Area", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AreaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AreaId"));

                    b.Property<string>("AreaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AreaNumber")
                        .HasColumnType("int");

                    b.Property<int>("FloorId")
                        .HasColumnType("int")
                        .HasColumnName("FloorID");

                    b.HasKey("AreaId")
                        .HasName("PK__Area__70B820282BCE14E3");

                    b.HasIndex("FloorId");

                    b.ToTable("Area", (string)null);
                });

            modelBuilder.Entity("cms_server.Models.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BuildingID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuildingId"));

                    b.Property<string>("BuildingDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuildingName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("BuildingId")
                        .HasName("PK__Building__5463CDE47370088E");

                    b.ToTable("Building", (string)null);
                });

            modelBuilder.Entity("cms_server.Models.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ContractID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContractId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("NicheId")
                        .HasColumnType("int")
                        .HasColumnName("NicheID");

                    b.Property<bool>("NotificationSent")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ContractId")
                        .HasName("PK__Contract__C90D3409E5855441");

                    b.HasIndex("CustomerId");

                    b.HasIndex("NicheId");

                    b.ToTable("Contract", (string)null);
                });

            modelBuilder.Entity("cms_server.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CitizenId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CitizenID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__A4AE64B804D4836B");

                    b.HasIndex(new[] { "CitizenId" }, "UQ__Customer__6E49FBEDFA3F002E")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Customer__A9D1053485CB6DB4")
                        .IsUnique();

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("cms_server.Models.Deceased", b =>
                {
                    b.Property<int>("DeceasedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DeceasedID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeceasedId"));

                    b.Property<string>("CitizenId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("CitizenID");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateOfDeath")
                        .HasColumnType("date");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("NicheId")
                        .HasColumnType("int")
                        .HasColumnName("NicheID");

                    b.HasKey("DeceasedId")
                        .HasName("PK__Deceased__E7DB31FD717813D8");

                    b.HasIndex("CustomerId");

                    b.HasIndex("NicheId");

                    b.HasIndex(new[] { "CitizenId" }, "UQ__Deceased__6E49FBED0D9C831A")
                        .IsUnique();

                    b.ToTable("Deceased", (string)null);
                });

            modelBuilder.Entity("cms_server.Models.Floor", b =>
                {
                    b.Property<int>("FloorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FloorID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FloorId"));

                    b.Property<int>("BuildingId")
                        .HasColumnType("int")
                        .HasColumnName("BuildingID");

                    b.Property<string>("FloorDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FloorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NichePrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("FloorId")
                        .HasName("PK__Floor__49D1E86B6D874806");

                    b.HasIndex("BuildingId");

                    b.ToTable("Floor", (string)null);
                });

            modelBuilder.Entity("cms_server.Models.Niche", b =>
                {
                    b.Property<int>("NicheId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NicheID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NicheId"));

                    b.Property<int>("AreaId")
                        .HasColumnType("int")
                        .HasColumnName("AreaID");

                    b.Property<string>("NicheDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NicheNumber")
                        .HasColumnType("int");

                    b.Property<string>("Qrcode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("QRCode");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("NicheId")
                        .HasName("PK__Niche__57FA5922A4430C5F");

                    b.HasIndex("AreaId");

                    b.HasIndex(new[] { "Qrcode" }, "UQ__Niche__5B869AD90670D113")
                        .IsUnique();

                    b.ToTable("Niche", (string)null);
                });

            modelBuilder.Entity("cms_server.Models.NicheReservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReservationID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<DateOnly>("ConfirmationDate")
                        .HasColumnType("date");

                    b.Property<int>("ConfirmedBy")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<int>("DeceasedId")
                        .HasColumnType("int")
                        .HasColumnName("DeceasedID");

                    b.Property<int>("NicheId")
                        .HasColumnType("int")
                        .HasColumnName("NicheID");

                    b.Property<DateOnly>("ReservationDate")
                        .HasColumnType("date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ReservationId")
                        .HasName("PK__NicheRes__B7EE5F04445C0380");

                    b.HasIndex("ConfirmedBy");

                    b.HasIndex("CustomerId");

                    b.HasIndex("NicheId");

                    b.HasIndex(new[] { "DeceasedId" }, "UQ__NicheRes__E7DB31FCE57F4663")
                        .IsUnique();

                    b.ToTable("NicheReservation", (string)null);
                });

            modelBuilder.Entity("cms_server.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NotificationID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<int?>("ContractId")
                        .HasColumnType("int")
                        .HasColumnName("ContractID");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("NotificationDate")
                        .HasColumnType("date");

                    b.Property<int?>("ServiceOrderId")
                        .HasColumnType("int")
                        .HasColumnName("ServiceOrderID");

                    b.Property<int?>("VisitId")
                        .HasColumnType("int")
                        .HasColumnName("VisitID");

                    b.HasKey("NotificationId")
                        .HasName("PK__Notifica__20CF2E320801CF05");

                    b.HasIndex("ContractId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ServiceOrderId");

                    b.HasIndex("VisitId");

                    b.ToTable("Notification", (string)null);
                });

            modelBuilder.Entity("cms_server.Models.Report", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReportID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportId"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("GeneratedDate")
                        .HasColumnType("date");

                    b.Property<string>("ReportType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ReportId")
                        .HasName("PK__Report__D5BD48E541ADAA21");

                    b.ToTable("Report", (string)null);
                });

            modelBuilder.Entity("cms_server.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ServiceID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ServiceId")
                        .HasName("PK__Service__C51BB0EA1227FECD");

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("cms_server.Models.ServiceOrder", b =>
                {
                    b.Property<int>("ServiceOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ServiceOrderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceOrderId"));

                    b.Property<string>("CompletionImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<int>("NicheId")
                        .HasColumnType("int")
                        .HasColumnName("NicheID");

                    b.Property<bool>("NotificationToCustomerSent")
                        .HasColumnType("bit");

                    b.Property<bool>("NotificationToStaffSent")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("OrderDate")
                        .HasColumnType("date");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int")
                        .HasColumnName("ServiceID");

                    b.Property<int>("StaffId")
                        .HasColumnType("int")
                        .HasColumnName("StaffID");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ServiceOrderId")
                        .HasName("PK__ServiceO__8E1ABD0557B68453");

                    b.HasIndex("CustomerId");

                    b.HasIndex("NicheId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("StaffId");

                    b.ToTable("ServiceOrder", (string)null);
                });

            modelBuilder.Entity("cms_server.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StaffID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StaffId")
                        .HasName("PK__Staff__96D4AAF7FC86BE2B");

                    b.HasIndex(new[] { "Email" }, "UQ__Staff__A9D105349A052BFC")
                        .IsUnique();

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("cms_server.Models.VisitRegistration", b =>
                {
                    b.Property<int>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VisitID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VisitId"));

                    b.Property<DateOnly?>("ApprovalDate")
                        .HasColumnType("date");

                    b.Property<string>("ApprovalStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ApprovedBy")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<int>("NicheId")
                        .HasColumnType("int")
                        .HasColumnName("NicheID");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateOnly>("VisitDate")
                        .HasColumnType("date");

                    b.HasKey("VisitId")
                        .HasName("PK__VisitReg__4D3AA1BE23434FAD");

                    b.HasIndex("ApprovedBy");

                    b.HasIndex("CustomerId");

                    b.HasIndex("NicheId");

                    b.ToTable("VisitRegistration", (string)null);
                });

            modelBuilder.Entity("cms_server.Models.Area", b =>
                {
                    b.HasOne("cms_server.Models.Floor", "Floor")
                        .WithMany("Areas")
                        .HasForeignKey("FloorId")
                        .IsRequired()
                        .HasConstraintName("FK_Area_Floor");

                    b.Navigation("Floor");
                });

            modelBuilder.Entity("cms_server.Models.Contract", b =>
                {
                    b.HasOne("cms_server.Models.Customer", "Customer")
                        .WithMany("Contracts")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_Contract_Customer");

                    b.HasOne("cms_server.Models.Niche", "Niche")
                        .WithMany("Contracts")
                        .HasForeignKey("NicheId")
                        .IsRequired()
                        .HasConstraintName("FK_Contract_Niche");

                    b.Navigation("Customer");

                    b.Navigation("Niche");
                });

            modelBuilder.Entity("cms_server.Models.Deceased", b =>
                {
                    b.HasOne("cms_server.Models.Customer", "Customer")
                        .WithMany("Deceaseds")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_Deceased_Customer");

                    b.HasOne("cms_server.Models.Niche", "Niche")
                        .WithMany("Deceaseds")
                        .HasForeignKey("NicheId")
                        .IsRequired()
                        .HasConstraintName("FK_Deceased_Niche");

                    b.Navigation("Customer");

                    b.Navigation("Niche");
                });

            modelBuilder.Entity("cms_server.Models.Floor", b =>
                {
                    b.HasOne("cms_server.Models.Building", "Building")
                        .WithMany("Floors")
                        .HasForeignKey("BuildingId")
                        .IsRequired()
                        .HasConstraintName("FK_Floor_Building");

                    b.Navigation("Building");
                });

            modelBuilder.Entity("cms_server.Models.Niche", b =>
                {
                    b.HasOne("cms_server.Models.Area", "Area")
                        .WithMany("Niches")
                        .HasForeignKey("AreaId")
                        .IsRequired()
                        .HasConstraintName("FK_Niche_Area");

                    b.Navigation("Area");
                });

            modelBuilder.Entity("cms_server.Models.NicheReservation", b =>
                {
                    b.HasOne("cms_server.Models.Staff", "ConfirmedByNavigation")
                        .WithMany("NicheReservations")
                        .HasForeignKey("ConfirmedBy")
                        .IsRequired()
                        .HasConstraintName("FK_NicheReservation_Staff");

                    b.HasOne("cms_server.Models.Customer", "Customer")
                        .WithMany("NicheReservations")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_NicheReservation_Customer");

                    b.HasOne("cms_server.Models.Deceased", "Deceased")
                        .WithOne("NicheReservation")
                        .HasForeignKey("cms_server.Models.NicheReservation", "DeceasedId")
                        .IsRequired()
                        .HasConstraintName("FK_NicheReservation_Deceased");

                    b.HasOne("cms_server.Models.Niche", "Niche")
                        .WithMany("NicheReservations")
                        .HasForeignKey("NicheId")
                        .IsRequired()
                        .HasConstraintName("FK_NicheReservation_Niche");

                    b.Navigation("ConfirmedByNavigation");

                    b.Navigation("Customer");

                    b.Navigation("Deceased");

                    b.Navigation("Niche");
                });

            modelBuilder.Entity("cms_server.Models.Notification", b =>
                {
                    b.HasOne("cms_server.Models.Contract", "Contract")
                        .WithMany("Notifications")
                        .HasForeignKey("ContractId")
                        .HasConstraintName("FK_Notification_Contract");

                    b.HasOne("cms_server.Models.Customer", "Customer")
                        .WithMany("Notifications")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_Notification_Customer");

                    b.HasOne("cms_server.Models.ServiceOrder", "ServiceOrder")
                        .WithMany("Notifications")
                        .HasForeignKey("ServiceOrderId")
                        .HasConstraintName("FK_Notification_ServiceOrder");

                    b.HasOne("cms_server.Models.VisitRegistration", "Visit")
                        .WithMany("Notifications")
                        .HasForeignKey("VisitId")
                        .HasConstraintName("FK_Notification_Visit");

                    b.Navigation("Contract");

                    b.Navigation("Customer");

                    b.Navigation("ServiceOrder");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("cms_server.Models.ServiceOrder", b =>
                {
                    b.HasOne("cms_server.Models.Customer", "Customer")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_ServiceOrder_Customer");

                    b.HasOne("cms_server.Models.Niche", "Niche")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("NicheId")
                        .IsRequired()
                        .HasConstraintName("FK_ServiceOrder_Niche");

                    b.HasOne("cms_server.Models.Service", "Service")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("ServiceId")
                        .IsRequired()
                        .HasConstraintName("FK_ServiceOrder_Service");

                    b.HasOne("cms_server.Models.Staff", "Staff")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("StaffId")
                        .IsRequired()
                        .HasConstraintName("FK_ServiceOrder_Staff");

                    b.Navigation("Customer");

                    b.Navigation("Niche");

                    b.Navigation("Service");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("cms_server.Models.VisitRegistration", b =>
                {
                    b.HasOne("cms_server.Models.Staff", "ApprovedByNavigation")
                        .WithMany("VisitRegistrations")
                        .HasForeignKey("ApprovedBy")
                        .HasConstraintName("FK_VisitRegistration_Staff");

                    b.HasOne("cms_server.Models.Customer", "Customer")
                        .WithMany("VisitRegistrations")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_VisitRegistration_Customer");

                    b.HasOne("cms_server.Models.Niche", "Niche")
                        .WithMany("VisitRegistrations")
                        .HasForeignKey("NicheId")
                        .IsRequired()
                        .HasConstraintName("FK_VisitRegistration_Niche");

                    b.Navigation("ApprovedByNavigation");

                    b.Navigation("Customer");

                    b.Navigation("Niche");
                });

            modelBuilder.Entity("cms_server.Models.Area", b =>
                {
                    b.Navigation("Niches");
                });

            modelBuilder.Entity("cms_server.Models.Building", b =>
                {
                    b.Navigation("Floors");
                });

            modelBuilder.Entity("cms_server.Models.Contract", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("cms_server.Models.Customer", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("Deceaseds");

                    b.Navigation("NicheReservations");

                    b.Navigation("Notifications");

                    b.Navigation("ServiceOrders");

                    b.Navigation("VisitRegistrations");
                });

            modelBuilder.Entity("cms_server.Models.Deceased", b =>
                {
                    b.Navigation("NicheReservation");
                });

            modelBuilder.Entity("cms_server.Models.Floor", b =>
                {
                    b.Navigation("Areas");
                });

            modelBuilder.Entity("cms_server.Models.Niche", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("Deceaseds");

                    b.Navigation("NicheReservations");

                    b.Navigation("ServiceOrders");

                    b.Navigation("VisitRegistrations");
                });

            modelBuilder.Entity("cms_server.Models.Service", b =>
                {
                    b.Navigation("ServiceOrders");
                });

            modelBuilder.Entity("cms_server.Models.ServiceOrder", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("cms_server.Models.Staff", b =>
                {
                    b.Navigation("NicheReservations");

                    b.Navigation("ServiceOrders");

                    b.Navigation("VisitRegistrations");
                });

            modelBuilder.Entity("cms_server.Models.VisitRegistration", b =>
                {
                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
