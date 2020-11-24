using System.ComponentModel.DataAnnotations;

namespace ReferenceNcfs.Api.Models
{
    public class NcfsRequestModel
    {
        [Required]
        public string Base64Body { get; set; }

        public string DetectedFiletype { get; set; }
    }
}