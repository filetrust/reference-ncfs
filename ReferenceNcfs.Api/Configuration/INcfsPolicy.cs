namespace ReferenceNcfs.Api.Configuration
{
    public interface INcfsPolicy
    {
        public NcfsOption UnprocessableFileTypeAction { get; set; }
        public NcfsOption GlasswallBlockedFilesAction { get; set; }
    }
}