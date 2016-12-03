﻿using System;
using ATPR.Utils;
using ATPRNER;

namespace ATPR
{
	/// <summary>
	/// Strategy class that generates the dictionary from the NER result.
	/// </summary>
	public class GenerateDictionaryStrategy : AbstractExecStrategy
	{
		public GenerateDictionaryStrategy(Options options) : base(options)
		{
		}

		/// <summary>
		/// Generates the dictionary of entities found.
		/// </summary>
		/// <param name="options">Options.</param>
		public override void Run()
		{
			if (options.Verbose)
				Console.Error.WriteLine("Dictionary generation command");


			if (!NERLangUtils.CheckLangFiles (options.Language)) {
				Console.Error.WriteLine ("Language files not found.Exiting...");
				return;
			}

			string xml = NER.GenerateEntitiesToString(options.InputFile,options.Language);
			string csv = CSVUtils.RemoveDuplicates(CSVUtils.EntitiesToCsv(xml, options.Separator));

			WriteResult(csv);
		}
	}
}
