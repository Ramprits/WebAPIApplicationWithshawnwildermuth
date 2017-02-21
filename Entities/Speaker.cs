using System.Collections.Generic;

namespace WebAPIApplication.Entities
{
    public class Speaker
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public string CompanyName { get; set; }
    public string PhoneNumber { get; set; }
    public string WebsiteUrl { get; set; }
    public string TwitterName { get; set; }
    public string GitHubName { get; set; }
    public string Bio { get; set; }
    public string HeadShotUrl { get; set; }
    public CampUser User { get; set; }

    public virtual ICollection<Talk> Talks { get; set; }

    public int CampId { get; set; }

    public virtual Camp Camp { get; set; }

    public byte[] RowVersion { get; set; }

    }
}