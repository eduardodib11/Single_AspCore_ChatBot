using System;
using System.ComponentModel.DataAnnotations;

namespace chatbot.Models
{
    public class cMessage
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}