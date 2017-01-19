using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BPT.ViewModels.Home
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Id = Guid.NewGuid();
        }


        public Guid Id { get; set; }

        [DisplayName("Starter Text")]
        [MaxLength(140, ErrorMessage = "Too long 140 characters only")]
        public string StarterText { get; set; }

    }
}
