using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLy_DaiHoc.Models;

public partial class QuanLyDaiHocContext : DbContext
{
    public QuanLyDaiHocContext()
    {
    }

    public QuanLyDaiHocContext(DbContextOptions<QuanLyDaiHocContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bomon> Bomons { get; set; }

    public virtual DbSet<CauLacBo> CauLacBos { get; set; }

    public virtual DbSet<ChatGpt> ChatGpts { get; set; }

    public virtual DbSet<DongTienRa> DongTienRas { get; set; }

    public virtual DbSet<DongTienVao> DongTienVaos { get; set; }

    public virtual DbSet<GiamHieu> GiamHieus { get; set; }

    public virtual DbSet<HocKi> HocKis { get; set; }

    public virtual DbSet<HocPhi> HocPhis { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<KhoiNganh> KhoiNganhs { get; set; }

    public virtual DbSet<LoginToken> LoginTokens { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<LopNienKhoa> LopNienKhoas { get; set; }

    public virtual DbSet<LopNienKhoa1> LopNienKhoa1s { get; set; }

    public virtual DbSet<LopSinhVien> LopSinhViens { get; set; }

    public virtual DbSet<LopSinhVienNienKhoa> LopSinhVienNienKhoas { get; set; }

    public virtual DbSet<LopTinChi> LopTinChis { get; set; }

    public virtual DbSet<Loptinchi2> Loptinchi2s { get; set; }

    public virtual DbSet<MonHoc> MonHocs { get; set; }

    public virtual DbSet<NamHoc> NamHocs { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<PhongHoc> PhongHocs { get; set; }

    public virtual DbSet<QlngayNghi> QlngayNghis { get; set; }

    public virtual DbSet<QuanLyPhong> QuanLyPhongs { get; set; }

    public virtual DbSet<QuanLyTaiSan> QuanLyTaiSans { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    public virtual DbSet<SuDungPhong> SuDungPhongs { get; set; }

    public virtual DbSet<TblBan> TblBans { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<ThamGium> ThamGia { get; set; }

    public virtual DbSet<ThongTinNguoiDung> ThongTinNguoiDungs { get; set; }

    public virtual DbSet<ToaNha> ToaNhas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=103.159.50.22,64501;Database=QuanLyDaiHoc;User Id=VuonUom;Password=123456;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bomon>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("bomon");

            entity.Property(e => e.IdBm).HasColumnName("IdBM");
            entity.Property(e => e.NameBm)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nameBM");
            entity.Property(e => e.SoT).HasColumnName("soT");
            entity.Property(e => e.SoTc).HasColumnName("soTC");
        });

        modelBuilder.Entity<CauLacBo>(entity =>
        {
            entity.HasKey(e => e.MaCauLacBo).HasName("PK__CauLacBo__1257A323EC3E37FB");

            entity.ToTable("CauLacBo");

            entity.Property(e => e.MaCauLacBo).ValueGeneratedNever();
            entity.Property(e => e.NgayThanhLap).HasColumnType("date");
            entity.Property(e => e.TenCauLacBo)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ChatGpt>(entity =>
        {
            entity.HasKey(e => e.MesseageId);

            entity.ToTable("ChatGPT");

            entity.Property(e => e.MesseageId).HasColumnName("messeageID");
            entity.Property(e => e.Answer)
                .HasColumnType("ntext")
                .HasColumnName("answer");
            entity.Property(e => e.ChatId)
                .HasColumnType("ntext")
                .HasColumnName("chatID");
            entity.Property(e => e.Question)
                .HasColumnType("ntext")
                .HasColumnName("question");
            entity.Property(e => e.RawAnswer)
                .HasColumnType("ntext")
                .HasColumnName("rawAnswer");
            entity.Property(e => e.TimeRequest)
                .HasColumnType("datetime")
                .HasColumnName("timeRequest");
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<DongTienRa>(entity =>
        {
            entity.HasKey(e => e.IdnguoiRut);

            entity.ToTable("DongTienRa");

            entity.Property(e => e.IdnguoiRut).HasColumnName("IDNguoiRut");
            entity.Property(e => e.KyDuyet)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.LyDo).HasMaxLength(50);
            entity.Property(e => e.TenNgRut).HasMaxLength(50);
        });

        modelBuilder.Entity<DongTienVao>(entity =>
        {
            entity.HasKey(e => e.IdnguoiNop);

            entity.ToTable("DongTienVao");

            entity.Property(e => e.IdnguoiNop)
                .ValueGeneratedNever()
                .HasColumnName("IDNguoiNop");
            entity.Property(e => e.LiDoNop).HasMaxLength(50);
        });

        modelBuilder.Entity<GiamHieu>(entity =>
        {
            entity.ToTable("GiamHieu");

            entity.Property(e => e.Anh).HasColumnName("anh");
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.NhiemKy).HasColumnType("datetime");
            entity.Property(e => e.Ten).HasMaxLength(50);
        });

        modelBuilder.Entity<HocKi>(entity =>
        {
            entity.HasKey(e => e.HocKiId).HasName("PK__HocKi__2BA76BAAD5328FBE");

            entity.ToTable("HocKi");

            entity.Property(e => e.HocKiId).HasColumnName("HocKiID");
            entity.Property(e => e.TenHocKi).HasMaxLength(50);
        });

        modelBuilder.Entity<HocPhi>(entity =>
        {
            entity.HasKey(e => e.HocPhiId).HasName("PK__HocPhi__4685B04F3F5FA627");

            entity.ToTable("HocPhi");

            entity.Property(e => e.HocPhiId).HasColumnName("HocPhiID");
            entity.Property(e => e.HocKiId).HasColumnName("HocKiID");
            entity.Property(e => e.KhoiNganhId).HasColumnName("KhoiNganhID");
            entity.Property(e => e.NamHocId).HasColumnName("NamHocID");
            entity.Property(e => e.NgayKetThuc).HasColumnType("date");
            entity.Property(e => e.NgayNop).HasColumnType("date");
            entity.Property(e => e.TenHocPhi).HasMaxLength(30);

            entity.HasOne(d => d.HocKi).WithMany(p => p.HocPhis)
                .HasForeignKey(d => d.HocKiId)
                .HasConstraintName("fk22");

            entity.HasOne(d => d.KhoiNganh).WithMany(p => p.HocPhis)
                .HasForeignKey(d => d.KhoiNganhId)
                .HasConstraintName("fk222");

            entity.HasOne(d => d.NamHoc).WithMany(p => p.HocPhis)
                .HasForeignKey(d => d.NamHocId)
                .HasConstraintName("fk12");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.ToTable("Khoa");

            entity.Property(e => e.KhoaId).HasColumnName("KhoaID");
            entity.Property(e => e.Anhkhoa).HasColumnType("image");
            entity.Property(e => e.Email)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Mota).HasMaxLength(50);
            entity.Property(e => e.NgayThanhLap).HasColumnType("datetime");
            entity.Property(e => e.Sodienthoai).HasMaxLength(15);
            entity.Property(e => e.TenKhoa).HasMaxLength(50);
            entity.Property(e => e.Truongkhoa).HasMaxLength(50);
        });

        modelBuilder.Entity<KhoiNganh>(entity =>
        {
            entity.ToTable("KhoiNganh");

            entity.Property(e => e.KhoiNganhId).HasColumnName("KhoiNganhID");
            entity.Property(e => e.Mota).HasMaxLength(100);
            entity.Property(e => e.TenKhoiNganh).HasMaxLength(50);
        });

        modelBuilder.Entity<LoginToken>(entity =>
        {
            entity.HasKey(e => e.TokenGuid);

            entity.ToTable("LoginToken");

            entity.Property(e => e.TokenGuid).HasMaxLength(50);

            entity.HasOne(d => d.IdNguoiDungNavigation).WithMany(p => p.LoginTokens)
                .HasForeignKey(d => d.IdNguoiDung)
                .HasConstraintName("FK_LoginToken_NguoiDung");
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.IdLop);

            entity.ToTable("Lop");

            entity.Property(e => e.IdLop).HasColumnName("idLop");
            entity.Property(e => e.TenLop)
                .HasMaxLength(50)
                .HasColumnName("tenLop");
        });

        modelBuilder.Entity<LopNienKhoa>(entity =>
        {
            entity.HasKey(e => e.NienKhoaId);

            entity.ToTable("Lop_NienKhoa");

            entity.Property(e => e.NienKhoaId).HasColumnName("NienKhoaID");
            entity.Property(e => e.DiaChiNha).HasMaxLength(100);
            entity.Property(e => e.GioiTinh).HasMaxLength(5);
            entity.Property(e => e.HocPhi).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IdLop).HasColumnName("idLop");
            entity.Property(e => e.KhoaId).HasColumnName("KhoaID");
            entity.Property(e => e.KqhocTap)
                .HasMaxLength(10)
                .HasColumnName("KQHocTap");
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.NienKhoa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SdtphuHuynh).HasColumnName("SDTPhuHuynh");
            entity.Property(e => e.TenGv)
                .HasMaxLength(50)
                .HasColumnName("TenGV");
            entity.Property(e => e.TenHs)
                .HasMaxLength(50)
                .HasColumnName("TenHS");
        });

        modelBuilder.Entity<LopNienKhoa1>(entity =>
        {
            entity.HasKey(e => e.Idlop);

            entity.ToTable("Lop_NienKhoa1");

            entity.Property(e => e.Idlop).HasColumnName("IDLop");
            entity.Property(e => e.KhoaId).HasColumnName("KhoaID");
            entity.Property(e => e.NamRa).HasColumnType("date");
            entity.Property(e => e.NamVao).HasColumnType("date");
            entity.Property(e => e.TenGv)
                .HasMaxLength(50)
                .HasColumnName("TenGV");

            entity.HasOne(d => d.Khoa).WithMany(p => p.LopNienKhoa1s)
                .HasForeignKey(d => d.KhoaId)
                .HasConstraintName("FK_Lop_NienKhoa1_Khoa");
        });

        modelBuilder.Entity<LopSinhVien>(entity =>
        {
            entity.HasKey(e => e.IdLopSinhVien);

            entity.ToTable("LopSinhVien");

            entity.Property(e => e.IdLopSinhVien).HasColumnName("idLopSinhVien");
            entity.Property(e => e.IdLopTinChi).HasColumnName("idLopTinChi");

            entity.HasOne(d => d.IdLopTinChiNavigation).WithMany(p => p.LopSinhViens)
                .HasForeignKey(d => d.IdLopTinChi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LopSinhVien_LopTinChi");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.LopSinhViens)
                .HasForeignKey(d => d.MaSinhVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LopSinhVien_NguoiDung");
        });

        modelBuilder.Entity<LopSinhVienNienKhoa>(entity =>
        {
            entity.HasKey(e => e.IdLopSinhVien);

            entity.ToTable("LopSinhVienNienKhoa");

            entity.Property(e => e.IdLopSinhVien).ValueGeneratedNever();
            entity.Property(e => e.Idlop).HasColumnName("IDLop");

            entity.HasOne(d => d.IdlopNavigation).WithMany(p => p.LopSinhVienNienKhoas)
                .HasForeignKey(d => d.Idlop)
                .HasConstraintName("FK_LopSinhVienNienKhoa_Lop_NienKhoa11");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.LopSinhVienNienKhoas)
                .HasForeignKey(d => d.MaSinhVien)
                .HasConstraintName("FK_LopSinhVienNienKhoa_NguoiDung");
        });

        modelBuilder.Entity<LopTinChi>(entity =>
        {
            entity.HasKey(e => e.IdLopTinChi);

            entity.ToTable("LopTinChi");

            entity.Property(e => e.IdLopTinChi).HasColumnName("idLopTinChi");
            entity.Property(e => e.IdMonHoc).HasColumnName("idMonHoc");
            entity.Property(e => e.NgayDay)
                .HasColumnType("date")
                .HasColumnName("ngayDay");
            entity.Property(e => e.NgayKetThuc)
                .HasColumnType("date")
                .HasColumnName("ngayKetThuc");
            entity.Property(e => e.Tenlop)
                .HasMaxLength(50)
                .HasColumnName("tenlop");

            entity.HasOne(d => d.IdMonHocNavigation).WithMany(p => p.LopTinChis)
                .HasForeignKey(d => d.IdMonHoc)
                .HasConstraintName("FK_LopTinChi_MonHoc");
        });

        modelBuilder.Entity<Loptinchi2>(entity =>
        {
            entity.HasKey(e => e.LopTinChiId);

            entity.ToTable("loptinchi2");

            entity.Property(e => e.LopTinChiId)
                .ValueGeneratedNever()
                .HasColumnName("LopTinChiID");
            entity.Property(e => e.NgayBatDau).HasColumnType("date");
            entity.Property(e => e.NgayKetThuc).HasColumnType("date");
            entity.Property(e => e.Tenloptinchi).HasColumnName("tenloptinchi");
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.HasKey(e => e.IdMonHoc);

            entity.ToTable("MonHoc");

            entity.Property(e => e.IdMonHoc).HasColumnName("idMonHoc");
            entity.Property(e => e.SoTinChi).HasColumnName("soTinChi");
            entity.Property(e => e.TenMonHoc)
                .HasMaxLength(50)
                .HasColumnName("tenMonHoc");
        });

        modelBuilder.Entity<NamHoc>(entity =>
        {
            entity.HasKey(e => e.NamHocId).HasName("PK__NamHoc__BB8C8B44591C47C5");

            entity.ToTable("NamHoc");

            entity.Property(e => e.NamHocId).HasColumnName("NamHocID");
            entity.Property(e => e.BatDau).HasColumnType("date");
            entity.Property(e => e.KetThuc).HasColumnType("date");

            entity.HasMany(d => d.HocKis).WithMany(p => p.NamHocs)
                .UsingEntity<Dictionary<string, object>>(
                    "NamHocHocKi",
                    r => r.HasOne<HocKi>().WithMany()
                        .HasForeignKey("HocKiId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk2"),
                    l => l.HasOne<NamHoc>().WithMany()
                        .HasForeignKey("NamHocId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk1"),
                    j =>
                    {
                        j.HasKey("NamHocId", "HocKiId").HasName("pknh");
                        j.ToTable("NamHoc_HocKi");
                        j.IndexerProperty<int>("NamHocId").HasColumnName("NamHocID");
                        j.IndexerProperty<int>("HocKiId").HasColumnName("HocKiID");
                    });
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.IdNguoiDung);

            entity.ToTable("NguoiDung");

            entity.Property(e => e.FieldA)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Md5Password).HasMaxLength(250);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Salt).HasMaxLength(50);
            entity.Property(e => e.TenNguoiDung).HasMaxLength(50);

            entity.HasOne(d => d.GiamHieu).WithMany(p => p.NguoiDungs)
                .HasForeignKey(d => d.GiamHieuId)
                .HasConstraintName("FK_NguoiDung_GiamHieu");
        });

        modelBuilder.Entity<PhongHoc>(entity =>
        {
            entity.HasKey(e => e.IdPhong);

            entity.ToTable("PhongHoc");

            entity.Property(e => e.IdPhong).HasColumnName("idPhong");
            entity.Property(e => e.IdToaNha).HasColumnName("idToaNha");
            entity.Property(e => e.TenPhong)
                .HasMaxLength(50)
                .HasColumnName("tenPhong");
            entity.Property(e => e.TrangThai).HasColumnName("trangThai");

            entity.HasOne(d => d.IdToaNhaNavigation).WithMany(p => p.PhongHocs)
                .HasForeignKey(d => d.IdToaNha)
                .HasConstraintName("FK_PhongHoc_ToaNha");
        });

        modelBuilder.Entity<QlngayNghi>(entity =>
        {
            entity.HasKey(e => e.Stt);

            entity.ToTable("QLNgayNghi");

            entity.Property(e => e.Stt).HasColumnName("STT");
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.HoVaTen).HasMaxLength(50);
            entity.Property(e => e.NgayNghi).HasColumnType("datetime");
        });

        modelBuilder.Entity<QuanLyPhong>(entity =>
        {
            entity.HasKey(e => e.Idphong).HasName("PK__QuanLyPh__81CB11526EF07D1D");

            entity.ToTable("QuanLyPhong");

            entity.Property(e => e.Idphong).HasColumnName("IDPhong");
            entity.Property(e => e.Dcm)
                .HasMaxLength(50)
                .HasColumnName("DCM");
            entity.Property(e => e.Sdt)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.TenP).HasMaxLength(50);
        });

        modelBuilder.Entity<QuanLyTaiSan>(entity =>
        {
            entity.HasKey(e => e.IdtaiSan);

            entity.ToTable("QuanLyTaiSan");

            entity.Property(e => e.IdtaiSan).HasColumnName("IDTaiSan");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.GiaTriTaiSan).HasMaxLength(50);
            entity.Property(e => e.IdnguoiNhap).HasColumnName("IDNguoiNhap");
            entity.Property(e => e.LoaiTaiSan).HasMaxLength(50);
            entity.Property(e => e.NgayNhap).HasColumnType("datetime");
            entity.Property(e => e.TenTaiSan).HasMaxLength(100);
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.MaSinhVien).HasName("PK__SinhVien__939AE775DAA99578");

            entity.ToTable("SinhVien");

            entity.Property(e => e.MaSinhVien).ValueGeneratedNever();
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.QueQuan)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SinhNgay).HasColumnType("date");
            entity.Property(e => e.TenSinhVien)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SuDungPhong>(entity =>
        {
            entity.HasKey(e => e.IdSdp);

            entity.ToTable("SuDungPhong");

            entity.Property(e => e.IdSdp).HasColumnName("idSDP");
            entity.Property(e => e.IdLop).HasColumnName("idLop");
            entity.Property(e => e.IdMonHoc).HasColumnName("idMonHoc");
            entity.Property(e => e.IdPhong).HasColumnName("idPhong");
            entity.Property(e => e.NgaySd)
                .HasColumnType("datetime")
                .HasColumnName("ngaySD");
            entity.Property(e => e.NgayTra)
                .HasColumnType("datetime")
                .HasColumnName("ngayTra");

            entity.HasOne(d => d.IdLopNavigation).WithMany(p => p.SuDungPhongs)
                .HasForeignKey(d => d.IdLop)
                .HasConstraintName("FK_SuDungPhong_Lop");

            entity.HasOne(d => d.IdMonHocNavigation).WithMany(p => p.SuDungPhongs)
                .HasForeignKey(d => d.IdMonHoc)
                .HasConstraintName("FK_SuDungPhong_MonHoc");

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.SuDungPhongs)
                .HasForeignKey(d => d.IdPhong)
                .HasConstraintName("FK_SuDungPhong_PhongHoc");
        });

        modelBuilder.Entity<TblBan>(entity =>
        {
            entity.HasKey(e => e.MaBan).HasName("PK__tbl_Ban__3520ED6CBEC77681");

            entity.ToTable("tbl_Ban");

            entity.Property(e => e.MaBan).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.NgayThanhLap).HasColumnType("date");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.TenBan).HasMaxLength(100);
            entity.Property(e => e.TruongBan).HasMaxLength(100);
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("test");

            entity.Property(e => e.Test1)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("test");
        });

        modelBuilder.Entity<ThamGium>(entity =>
        {
            entity.HasKey(e => new { e.MaSinhVien, e.MaCauLacBo }).HasName("PK__ThamGia__B2BF9D474F5B2A20");

            entity.Property(e => e.NgayThamGia).HasColumnType("date");

            entity.HasOne(d => d.MaCauLacBoNavigation).WithMany(p => p.ThamGia)
                .HasForeignKey(d => d.MaCauLacBo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ThamGia__MaCauLa__2180FB33");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.ThamGia)
                .HasForeignKey(d => d.MaSinhVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ThamGia__MaSinhV__208CD6FA");
        });

        modelBuilder.Entity<ThongTinNguoiDung>(entity =>
        {
            entity.HasKey(e => e.IdTtuser);

            entity.ToTable("ThongTinNguoiDung");

            entity.Property(e => e.IdTtuser)
                .ValueGeneratedNever()
                .HasColumnName("IdTTUser");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IsBgh).HasColumnName("IsBGH");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PrivateEmail)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNguoiDungNavigation).WithMany(p => p.ThongTinNguoiDungs)
                .HasForeignKey(d => d.IdNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ThongTinNguoiDung_NguoiDung");
        });

        modelBuilder.Entity<ToaNha>(entity =>
        {
            entity.HasKey(e => e.IdToaNha);

            entity.ToTable("ToaNha");

            entity.Property(e => e.IdToaNha).HasColumnName("idToaNha");
            entity.Property(e => e.TenToaNha)
                .HasMaxLength(50)
                .HasColumnName("tenToaNha");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
