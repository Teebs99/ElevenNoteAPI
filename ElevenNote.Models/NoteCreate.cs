using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevenNote.WebAPI.Models
{
    public class NoteCreate
    {
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}