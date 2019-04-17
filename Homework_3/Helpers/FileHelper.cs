using AutoMapper;
using Homework_3.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Homework_3.Helpers
{
	public static class FileHelper
	{
		private const int _columnCount = 7;

		public static List<Barcelona> ReadFile(string fileName)
		{
			var lines = File.ReadAllLines(fileName).Skip(1).Select(x => x);

			var entities = new List<Barcelona>();
			foreach (var input in lines)
			{
				MatchCollection matches = Regex.Matches(
					input,
					@"^(?:(?:\s*""(?<value>[^""]*)""\s*|(?<value>[^,]*)),)*?(?:\s*""(?>value>[^""]*)""\s*|(?<value>[^,]*))$",
					RegexOptions.Multiline);

				foreach (Match row in matches)
				{
					var capturesCount = row.Groups["value"].Captures.Count;
					if (capturesCount == 7)
					{
						string[] values = new string[capturesCount];
						for (int i = 0; i < capturesCount; i++)
						{
							values[i] = row.Groups["value"].Captures[i].Value;
						}

						entities.Add(Mapper.Map<string[], Barcelona>(values));
					}
				}
			}

			return entities;
		}
	}
}
