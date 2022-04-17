namespace Strategy
{
    /// <summary>
    /// S
    /// Open Closed Principle
    /// L
    /// I
    /// D
    /// File compression abstract strategy interface, this is pattern closer for principle in SOLID (Open Closed Principle)
    /// </summary>
    public interface ICompression
    {
        void CompressFolder(string compressedArchiveFileName);
    }

    /// <summary>
    /// Concrete strategy for compress with rar format
    /// </summary>
    public class RarCompression : ICompression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine($"Folder is compressed using Rar approach {compressedArchiveFileName}.rar is crated!");
        }
    }

    /// <summary>
    /// Concrete strategy for compress zip format
    /// </summary>
    public class ZipCompression : ICompression
    {
        public void CompressFolder(string compressedArchiveFileName)
        {
            Console.WriteLine($"Folder is compressed using Zip approach {compressedArchiveFileName}.zip is created!");
        }
    }

    /// <summary>
    /// The compression context stores a reference to the object of a particular strategy, 
    /// working with it through the general strategy interface.
    /// </summary>
    public class CompressionContext
    {
        private ICompression compression;

        public CompressionContext(ICompression compression)
        {
            this.compression = compression;
        }

        public void CreateArchive(string compressArchiveFileName)
        {
            if (this.compression is null)
                throw new ArgumentNullException(nameof(compression));

            this.compression.CompressFolder(compressArchiveFileName);
        }
    }

    /// <summary>
    /// Example class for test
    /// </summary>
    public class Example2
    {
        /// <summary>
        /// Start test
        /// </summary>
        public static void Test()
        {
            CompressionContext ctxRar = new(new RarCompression());
            ctxRar.CreateArchive("StrategyDesignPattern");

            CompressionContext ctxZip = new(new ZipCompression());
            ctxZip.CreateArchive("StrategyDesignPattern");
        }
    }
}
