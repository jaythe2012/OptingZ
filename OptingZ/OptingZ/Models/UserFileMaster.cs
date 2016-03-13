using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OptingZ.Models
{
    public class UserFileMaster
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int UserMasterID { get; set; }
        
    }

    public enum FileType
    {
        ProfilePic = 1
    }
}