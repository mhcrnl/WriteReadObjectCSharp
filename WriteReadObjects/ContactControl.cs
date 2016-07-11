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

