﻿using System;
using System.IO;
using PasC.Models;
using PasC.States;

namespace PasC
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				if (args.Length < 1)
				{
					throw new IndexOutOfRangeException();
				}

				if (!File.Exists(args[0]))
				{
					throw new FileNotFoundException();
				}
			}
			catch (IndexOutOfRangeException)
			{
				ConsoleHeader();
				Console.WriteLine("Usage: pasc [source.pc]");
			}
			catch (FileNotFoundException)
			{
				ConsoleHeader();
				Console.WriteLine("[Error]: Invalid source file.");
			}
			catch (Exception e)
			{
				ConsoleHeader();
				Console.WriteLine("[Error]: Fatal unhandled exception: {0}", e);
			}

			if (!File.Exists("pasc_test.pc"))
			{
				Lexer.Set("../../pasc_test.pc");
			}
			else
			{
				Lexer.Set("pasc_test.pc");
			}
		}

		private static void ConsoleHeader()
		{
			Console.WriteLine("pasc (Framework 4.7) 2018.1.1 ALPHA");
			Console.WriteLine("Copyright (C) 2018 Lucas Cota, Carlos Alberto.\n");
		}
	}
}
