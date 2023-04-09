namespace BuildYourHead.Persistence.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] Content { get; set; } = Array.Empty<byte>();
    }
}
