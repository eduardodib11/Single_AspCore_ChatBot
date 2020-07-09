using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace chatbot.Models
{
    public class cModel
    {
        [ReadOnly(true)]
        public string Textarea { get; set; }
        [Required]
        public string Input { get; set; }
    }
}