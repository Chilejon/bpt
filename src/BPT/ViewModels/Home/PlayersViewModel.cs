using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPT.ViewModels.Home
{
    public class PlayersViewModel
    {
        public string StarterId { get; set; }
        [Required]
        public string YourEmail { get; set; }
        [Required]
        public string Player2 { get; set; }
        [Required]
        public string Player3 { get; set; }
        [Required]
        public string Player4 { get; set; }
        [Required]
        public string Player5 { get; set; }
        [Required]
        public string Player6 { get; set; }
        [Required]
        public string Player7 { get; set; }
    }
}
