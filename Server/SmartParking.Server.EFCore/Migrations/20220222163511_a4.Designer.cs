// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartParking.Server.EFCore;

namespace SmartParking.Server.EFCore.Migrations
{
    [DbContext(typeof(EFCoreContext))]
    [Migration("20220222163511_a4")]
    partial class a4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MenuInfoRoleInfo", b =>
                {
                    b.Property<int>("MenuInfosMenuId")
                        .HasColumnType("int");

                    b.Property<int>("RoleInfosRoleId")
                        .HasColumnType("int");

                    b.HasKey("MenuInfosMenuId", "RoleInfosRoleId");

                    b.HasIndex("RoleInfosRoleId");

                    b.ToTable("MenuInfoRoleInfo");
                });

            modelBuilder.Entity("RoleInfoSysUserInfo", b =>
                {
                    b.Property<int>("RoleInfosRoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserInfosUserId")
                        .HasColumnType("int");

                    b.HasKey("RoleInfosRoleId", "UserInfosUserId");

                    b.HasIndex("UserInfosUserId");

                    b.ToTable("RoleInfoSysUserInfo");
                });

            modelBuilder.Entity("SmartParking.Server.Models.MenuInfo", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<string>("MenuHeader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuIcon")
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("MenuType")
                        .HasColumnType("int");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("TargetView")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenuId");

                    b.ToTable("MenuInfo");
                });

            modelBuilder.Entity("SmartParking.Server.Models.RoleInfo", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("RoleId");

                    b.ToTable("RoleInfo");
                });

            modelBuilder.Entity("SmartParking.Server.Models.SysUserInfo", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PassWord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RealName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserIcon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("SysUserInfo");
                });

            modelBuilder.Entity("MenuInfoRoleInfo", b =>
                {
                    b.HasOne("SmartParking.Server.Models.MenuInfo", null)
                        .WithMany()
                        .HasForeignKey("MenuInfosMenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartParking.Server.Models.RoleInfo", null)
                        .WithMany()
                        .HasForeignKey("RoleInfosRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleInfoSysUserInfo", b =>
                {
                    b.HasOne("SmartParking.Server.Models.RoleInfo", null)
                        .WithMany()
                        .HasForeignKey("RoleInfosRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartParking.Server.Models.SysUserInfo", null)
                        .WithMany()
                        .HasForeignKey("UserInfosUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
