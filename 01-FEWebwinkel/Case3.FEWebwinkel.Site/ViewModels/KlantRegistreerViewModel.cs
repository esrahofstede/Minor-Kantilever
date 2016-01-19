using System.ComponentModel.DataAnnotations;

namespace Case3.FEWebwinkel.Site.ViewModels
{
    /// <summary>
    /// This is the KlantRegistreerViewModel used for displaying the KlantRegistreer Form
    /// </summary>
    public class KlantRegistreerViewModel
    {
        [Required(ErrorMessage = "{0} is verplicht")]
        [MinLength(2, ErrorMessage = "De {0} moet minimaal 2 letters bevatten")]
        [MaxLength(100, ErrorMessage = "De {0} mag maximaal 100 letters bevatten")]
        public string Voornaam { get; set; }

        [MinLength(2, ErrorMessage = "Het {0} moet minimaal 2 letters bevatten")]
        [MaxLength(10, ErrorMessage = "Het {0} mag maximaal 10 letters bevatten")]
        public string Tussenvoegsel { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [MinLength(2, ErrorMessage = "De {0} moet minimaal 2 letters bevatten")]
        [MaxLength(150, ErrorMessage = "De {0} mag maximaal 150 letters bevatten")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        public string AdresRegel1 { get; set; }

        public string AdresRegel2 { get; set; }

        /// <summary>
        /// Postcode will validate on the following inputs:
        /// 1234AB
        /// 1234 AB
        /// </summary>
        [Required(ErrorMessage = "{0} is verplicht")]
        [RegularExpression(@"^[1-9]\d{3} ?[A-Z]{2}$", ErrorMessage = "Het formaat van een postcode is: 1234AB of 1234 AB")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [MinLength(2, ErrorMessage = "De {0} moet minimaal 2 letters bevatten")]
        [MaxLength(30, ErrorMessage = "De {0} mag maximaal 30 letters bevatten")]
        public string Woonplaats { get; set; }

        /// <summary>
        /// Telefoonnummer will validate on the following phonenumbers:
        /// 0123456789 (normal Dutch phone number)
        /// 06-12345678 (mobile phone number with stripes)
        /// 012-3456789 (Dutch 3 number net phone number with stripe)
        /// 0123-456789 (Dutch 4 number net phone number with stripe)
        /// +31123456789 (Dutch international phonenumber)
        /// </summary>
        [Required(ErrorMessage = "{0} is verplicht")]
        [RegularExpression(@"^(\d{2}-?\d{8}|\d{3}-?\d{7}|\d{4}-?\d{6}|\+31-?\d{9})$", ErrorMessage = "Het formaat van een telefoonnummer is: 06-12345678, 012-3456789, 0123-456789, 0123456789 of +31123456789")]
        public string Telefoonnummer { get; set; }

        /// <summary>
        /// Email will validate on the following adresses:
        /// janjansen@test.nl
        /// jan_jansen@test.nl
        /// jan.jansen@test.nl
        /// jan-jansen@test.nl
        /// janjansen@test.com
        /// </summary>
        [RegularExpression(@"^[A-Za-z0-9_\-\.]*@[A-Za-z]*.\w{2,3}$", ErrorMessage = "Het formaat van een e-mailadres is: janjansen@test.nl, jan_jansen@test.nl, jan.jansen@test.nl, jan-jansen@test.nl, janjansen@test.com")]
        public string Emailadres { get; set; }
    }
}