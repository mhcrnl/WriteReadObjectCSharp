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
