using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DAL.DBO;

namespace WebApp.DAL.DBO
{
    public class Anime
    {
        public int ID { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        [DisplayName("Status")]
        public int StatusID { get; set; }

        public Status Status { get; set; }

        [DisplayName("Age restriction")]
        public int AgeRestriction { get; set; }

        [Required]
        [DisplayName("Amount of episodes")]
        [Range(1, int.MaxValue)]
        public int EpisodesAmount { get; set; }

        [Required]
        [MinLength(3)]
        public string Author { get; set; }

        [Required]
        [MinLength(1)]
        public string Studio { get; set; }

        [DisplayName("Dubbing team")]
        public string DubTeam { get; set; }

        [Required]
        [DisplayName("Link")]
        public string LinkToWatch { get; set; }
    }
}
