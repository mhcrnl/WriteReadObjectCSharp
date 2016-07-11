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

