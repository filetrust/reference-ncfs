﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReferenceNcfs.Api.Models
{
    public class NcfsRequestModel
    {
        [Required]
        public string Base64Body { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FileType DetectedFiletype { get; set; }
    }

    public enum FileType
    {
        Unknown = 0,
        FileIssues = 1,
        BufferIssues = 2,
        InternalIssues = 3,
        LicenseExpired = 4,
        PasswordProtectedOpcFile = 5,
        Pdf = 16,
        Doc = 17,
        Docx = 18,
        Ppt = 19,
        Pptx = 20,
        Xls = 21,
        Xlsx = 22,
        Png = 23,
        Jpeg = 24,
        Gif = 25,
        Emf = 26,
        Wmf = 27,
        Rtf = 28,
        Bmp = 29,
        Tiff = 30,
        // Pe = 31,
        // Macho = 32,
        //Elf = 33,
        //Mp4 = 34,
        //Mp3 = 35,
        //Mp2 = 36,
        //Wav = 37,
        //Mpg = 38,
        // Coff = 39
        Zip = 256,
        Gzip = 257,
        //Bzip2 = 258,
        SevenZip = 259,
        Rar = 260,
        Tar = 261
    }
}