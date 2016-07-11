using System;

namespace WriteReadObjects
{
	[Serializable()]
	public class Contact
	{
		//Variabilele de instanta
		public string nume;
		public string prenume;
		public string telefon;
		//Constructorul clasei 
		public Contact (string nume, string prenume, string telefon)
		{
			this.nume = nume;
			this.prenume = prenume;
			this.telefon = telefon;
		}

		public string Nume {
			get {
				return this.nume;
			}
			set {
				this.nume = value;
			}
		}

		public string Prenume {
			get {
				return this.prenume;
			}
			set {
				this.prenume = value;
			}
		}

		public string Telefon {
			get {
				return this.telefon;
			}
			set {
				this.telefon = value;
			}
		}

		public override string ToString ()
		{
			return nume+" "+prenume+" "+telefon;
		}
	}
}

