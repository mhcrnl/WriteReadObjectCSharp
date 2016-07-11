 In programarea orientata obiect, crearea obiectelor este fundamentală ca de altfel si serializarea / deserializarea acestora, care permite stocarea lor în fișiere scrise pe discul local și apoi recitirea acestora din nou în aplicații.

În acest tutorial vom crea o aplicație care să stocheze o agendă telefonică, care să aibă câmpurile nume, prenume si număr de telefon. Pentru a realiza această aplicație avem nevoie de următoarele file de cod:

    Clasa Contact.cs crează obiectele contact;
        adaugarea metodei ToString();
    Clasa ContactControl.cs se ocupă de manipularea datelor;
        adaugarea noi clase ContactControlv1.cs:
    Clasa MainClass.cs care este punctul de intrare și rulare a aplicației.
        noua clasa MainClass.cs adauga noile functionalitati. 

     Adaugarea codului pe GitHub: https://github.com/mhcrnl/WriteReadObjectCSharp .

Scrierea obiectelor în fișiere text le face vulnerabile pentru a fi citite de oricine le poate deschide. Serializarea lor face acest lucru aproape imposibil, deoarece în acest caz fișierele trebuie deschise cu programul care le-a creat.

Serializarea este procesul de convertire a obiectelor în stream-uri de biți ce vor fi stocați în fișiere.

Aceasta este clasa care trebuie serializata si apoi salvate instantele acesteia:

Contact.cs

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
    }
}


Adaugarea metodei ToString():

 public override string ToString ()  
           {  
                return nume+" "+prenume+" "+telefon;  
           }  



Clasa care se ocupa cu salvarea si stocarea datelor pe disk:

ContactControlv1.cs : - adaugare proprietati Generics.

 using System;  
 using System.IO;  
 using System.Runtime.Serialization.Formatters.Binary;  
 using System.Text;  
 /*  
  * Fila : ContactControlv1.cs  
  *   
  */  
 namespace WriteReadObjects  
 {  
      public class ContactControlv1  
      {  
           public ContactControlv1 ()  
           {  
           }  
           // Scrie obiectele Generics intr-o fila si utilizeaza modul append sau create file   
           public void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)  
           {  
                using (Stream stream = File.Open (filePath, append ? FileMode.Append : FileMode.Create))  
                {  
                     var binaryFormatter = new BinaryFormatter ();  
                     binaryFormatter.Serialize (stream, objectToWrite);  
                }  
           }  
           // Citeste datele din fila si le returneaza   
           public T ReadFromBineryFile<T>( string filePath)  
           {  
                using (Stream stream = File.Open (filePath, FileMode.Open))  
                {  
                     var binaryFormatter = new BinaryFormatter ();  
                     return (T)binaryFormatter.Deserialize (stream);  
                }  
           }  
      }  
 }  


ContactControl.cs

using System;
using System.Collections.Generic;
using System.IO;
/*
 * Fila : ContactControl.cs
 * 
 */
namespace WriteReadObjects
{
    public class ContactControl
    {
        public ContactControl ()
        {
        }

        public void WriteToFile(string file, List<Contact> listaContacte)
        {
            using (Stream stream = File.Open(file, FileMode.Create)) { 
                var bformtter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();
                bformtter.Serialize (stream , listaContacte);
            }
        }

        public List<Contact> ReadFromFile(string file)
        {
            List<Contact> listaContacte;
            using (Stream stream = File.Open(file, FileMode.Open)) {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();
                listaContacte = (List<Contact>)bformatter.Deserialize (stream);
                return listaContacte;
            }

        }
    }
}


MainClass.cs

 using System;  
 using System.Collections.Generic;  
 /*  
  * Fila Program.cs  
  * In aceasta fila are los rularea profgramului   
  *   
  *   
  */  
 namespace WriteReadObjects  
 {  
      class MainClass  
      {  
           public static void Main (string[] args)  
           {  
                Console.WriteLine ("Hello World!");  
                string file = "Contactev1.dat";  
                List<Contact> listaContacte = new List<Contact> ();  
                Contact con = new Contact ("mihai", "Cornel", "0722270796");  
                Contact con1 = new Contact ("Alex", "vasile", "0722 67 89 90");  
                Console.WriteLine (con.ToString ());  
                Console.WriteLine(con1.ToString());  
                listaContacte.Add (con);  
                listaContacte.Add (con1);  
                foreach (Contact conTact in listaContacte) {  
                     Console.WriteLine ("Contacte Citite din lista: " +conTact.ToString ());  
                }  
                Console.WriteLine ("_______________________________________________________");  
                ContactControlv1 cc = new ContactControlv1 ();  
                //cc.WriteToFile (file, listaContacte);  
                //List<Contact> lista = cc.ReadFromFile (file);  
                cc.WriteToBinaryFile<List<Contact>> (file, listaContacte, false);  
                List<Contact> listaCitita=cc.ReadFromBineryFile<List<Contact>> (file);  
                foreach (Contact conObj in listaCitita) {  
                     Console.WriteLine ("Contact citit din fila: " + conObj.ToString());  
                }  
           }  
      }  
 }  



uusing System;
using System.Collections.Generic;
/*
 * Fila Program.cs
 * In aceasta fila are los rularea profgramului 
 * 
 * 
 */
namespace WriteReadObjects
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            Console.WriteLine ("Hello World!");

            List<Contact> listaContacte = new List<Contact> ();
            string file = "Contacte.dat";
            Contact con = new Contact ("mihai", "Cornel", "0722270796");
            listaContacte.Add (con);

            ContactControl cc = new ContactControl ();
            cc.WriteToFile (file, listaContacte);
            List<Contact> lista = cc.ReadFromFile (file);

            foreach (Contact con1 in lista) {
                Console.WriteLine ("Contacte: " + con1.Nume);
            }
        }
    }
}




RESURSE:
http://blog.danskingdom.com/saving-and-loading-a-c-objects-data-to-an-xml-json-or-binary-file/ ;
https://www.techcoil.com/blog/how-to-save-and-load-objects-to-and-from-file-in-c/ 
