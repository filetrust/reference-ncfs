namespace ReferenceNcfs.Api.Configuration
{
    public class NcfsPolicy : INcfsPolicy
    {
        public NcfsOption UnprocessableFileTypeAction { get; set; }
        public NcfsOption GlasswallBlockedFilesAction { get; set; }
    }
}