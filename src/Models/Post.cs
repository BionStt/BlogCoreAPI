using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCoreAPI.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        public byte[] Cover { get; set; }

        public string Link { get; set; }

        public string Title { get; set; }

        public string Preview { get; set; }

        public string Content { get; set; }

        public int Views { get; set; }

        public DateTime Upload { get; set; }

        public DateTime LastChange { get; set; }

        public bool Archived { get; set; }

        public bool Pinned { get; set; }

        // Virtual

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
