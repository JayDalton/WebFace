using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace WebFace.Models
{
  // Sie können Profildaten für den Benutzer durch Hinzufügen weiterer Eigenschaften zur ApplicationUser-Klasse hinzufügen. Weitere Informationen finden Sie unter "http://go.microsoft.com/fwlink/?LinkID=317594".
  public class ApplicationUser : IdentityUser
  {
    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    {
      // Beachten Sie, dass der "authenticationType" mit dem in "CookieAuthenticationOptions.AuthenticationType" definierten Typ übereinstimmen muss.
      var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
      // Benutzerdefinierte Benutzeransprüche hier hinzufügen
      return userIdentity;
    }

    [Display(Name = "Vorname")]
    public string Forename { get; set; }

    [Display(Name = "Nachname")]
    public string Surname { get; set; }

    [Display(Name = "Adresse")]
    public string Address { get; set; }

    [Display(Name = "Land")]
    public string State { get; set; }

    [Display(Name = "Firma")]
    public string Company { get; set; }

    [Display(Name = "Telefon")]
    public string Phone { get; set; }

    [Display(Name = "Webadresse")]
    public string Homepage { get; set; }

    public string DisplayAddress
    {
      get
      {
        string dspAddress = string.IsNullOrWhiteSpace(this.Address) ? "" : this.Address;
        //string dspCity = string.IsNullOrWhiteSpace(this.City) ? "" : this.City;
        string dspState = string.IsNullOrWhiteSpace(this.State) ? "" : this.State;
        //string dspPostalCode = string.IsNullOrWhiteSpace(this.PostalCode) ? "" : this.PostalCode;

        return string.Format("{0} {1}", dspAddress, dspState);
        //return string.Format("{0} {1} {2} {3}", dspAddress, dspCity, dspState, dspPostalCode);
      }
    }

    public string DisplayFullName
    {
      get
      {
        return string.Format("{0} {1}", Forename, Surname);
      }
    }

  }

  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext()
      : base("DefaultConnection", throwIfV1Schema: false)
    {
    }

    public static ApplicationDbContext Create()
    {
      return new ApplicationDbContext();
    }
  }
}