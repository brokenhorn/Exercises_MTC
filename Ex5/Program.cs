using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex5
{
	class Program
	{
		static void Main(string[] args)
		{
			TransformToElephant();
			Console.WriteLine("Муха");

			//... custom application code
			Console.ReadKey();
		}

		static void TransformToElephant()
		{
			Console.WriteLine("Слон");
			Console.SetOut(TextWriter.Null);
		}
	}
}
