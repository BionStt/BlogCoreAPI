using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string Content { get; set; }

        public DateTime Upload { get; set; }

        public DateTime LastChange { get; set; }

        // Virtual

        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
