using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BuildYourHead.Infrastructure.ImageStorage
{
    public class DbImageStorage : IImageStorage
    {
        private readonly ImageDbContext _context;

        public DbImageStorage(IOptions<ImageStorageOptions> options)
        {
            _context = new ImageDbContext(options.Value.ConnectionString);
        }

        public Image? Get(string path)
        {
            return _context.Images.FirstOrDefault(x => x.Path == path);
        }

        public Image Upload(byte[] data)
        {
            return Upload(Guid.NewGuid().ToString(), data);
        }

        public Image Upload(string path, byte[] data)
        {
            var entity = new Image { Path = path, Content = data };
            var entry = _context.Images.Add(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public void Delete(string path)
        {
            var entry = _context.Images.First(x => x.Path == path);
            _context.Images.Remove(entry);
            _context.SaveChanges();
        }

        public void Delete(IEnumerable<string> paths)
        {
            var entries = _context.Images.Where(x => paths.Contains(x.Path));
            _context.Images.RemoveRange(entries);
            _context.SaveChanges();
        }
    }

    class ImageDbContext : DbContext
    {
        private readonly string _connectionString;

        public ImageDbContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var imageTypeBuilder = builder.Entity<Image>();
            imageTypeBuilder.ToTable("Images");
            imageTypeBuilder.HasKey("Id");
            imageTypeBuilder.Property(x => x.Path).HasColumnName("Path");
            imageTypeBuilder.Property(x => x.Content).HasColumnName("Content");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(_connectionString, new MySqlServerVersion("8.0.32"));
        }
    }
}
