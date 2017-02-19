using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPIApplication.Entities
{
    public class Camp
    {
        [Key]
        public int Id { get; set; }
        public string Moniker { get; set; }
        public string Name { get; set; }
        public DateTime? EventDate { get; set; } = DateTime.MinValue;
        public int Length { get; set; }

        public string Description { get; set; }
        public int LocationId { get; set; }
        public CampUser User { get; set; }
        public Location Location { get; set; }

        public ICollection<Speaker> Speakers { get; set; }

          public byte[] RowVersion { get; set; }
    }
}