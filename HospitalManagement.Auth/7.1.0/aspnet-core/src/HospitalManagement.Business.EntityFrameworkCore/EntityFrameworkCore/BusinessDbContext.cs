using Abp.EntityFrameworkCore;
using HospitalManagement.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Business.EntityFrameworkCore
{
    public class BusinessDbContext : AbpDbContext
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<HospitalizationTracking> HospitalizationTrackings { get; set; }
        public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }
        public virtual DbSet<Surgery> Surgeries { get; set; }
        public virtual DbSet<SurgeryType> SurgeryTypes { get; set; }
        public virtual DbSet<SurgeryDoctor> SurgeryDoctors { get; set; }
        public virtual DbSet<TestType> TestTypes { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<AppPermission> Permissions { get; set; }


        public BusinessDbContext(DbContextOptions<BusinessDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurgeryDoctor>().HasKey(c => new { c.SurgeryId, c.DoctorId });
            //modelBuilder.Entity<SurgeryDoctor>().HasOne<Surgery>(c => c.Surgery)
            //    .WithMany(s => s.SurgeryDoctors)
            //    .HasForeignKey(c => c.SurgeryId);
            //modelBuilder.Entity<SurgeryDoctor>().HasOne<Employee>(c => c.Doctor)
            //    .WithMany(s => s.SurgeryDoctors)
            //    .HasForeignKey(c => c.DoctorId);
        }
    }
}
