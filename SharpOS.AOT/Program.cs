// 
// (C) 2006-2007 The SharpOS Project Team (http://www.sharpos.org)
//
// Authors:
//	Mircea-Cristian Racasan <darx_kies@gmx.net>
//
// Licensed under the terms of the GNU GPL License version 2.
//

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using SharpOS;
using SharpOS.AOT.IR;
using SharpOS.AOT.X86;

namespace SharpOS.AOT {
	public class OS {
		static void Main (string[] args) 
		{
			//try
			{
				Engine engine = new Engine ();
				string filename = "SharpOS.Kernel.dll";

				if (args.Length == 1) 
					filename = args [0];

				else if (args.Length > 0) {
					Console.WriteLine ("Usage: SharpOS.AOT.exe [filename]");

					return;
				}

				if (!System.IO.File.Exists (filename)) {
					Console.WriteLine ("File '" + filename + "' was not found.");

					return;
				}

				engine.Run (new Assembly (), filename, "SharpOS.bin");
			}
			//catch (Exception ex)
			{
				//Console.WriteLine("Error: " + ex.Message);
			}
		}
	}
}