using AutoMapper;
using Homework_3.Core;
using Homework_3.Entities;
using Homework_3.Helpers;
using System;
using System.Diagnostics;
using System.Linq;

namespace Homework_3
{
	class Program
	{
		private const string barcelona1FileName = "Barcelona1.csv";
		private const string barcelona2FileName = "barcelona2.csv";

		static void Main(string[] args)
		{
			InitializeAutomapper();
			var barcelona1 = FileHelper.ReadFile(barcelona1FileName);
			var barcelona2 = FileHelper.ReadFile(barcelona2FileName);

			Stopwatch stopwatch = Stopwatch.StartNew();
			var union = CustomUnion.Union(barcelona1, barcelona2);
			stopwatch.Stop();
			Console.WriteLine(@"Union. Time elapsed: {0} ms, results {1}", stopwatch.ElapsedMilliseconds, union.Count);

			stopwatch.Start();
			var unionAll = CustomUnion.UnionAll(barcelona1, barcelona2);
			stopwatch.Stop();
			Console.WriteLine(@"UnionAll. Time elapsed: {0} ms, results {1}", stopwatch.ElapsedMilliseconds, unionAll.Count);
		}

		static void InitializeAutomapper()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<string[], Barcelona>()
					.ForMember(dsc => dsc.Id, src => src.MapFrom(s => s[0].Contains('/') ? s[0].Substring(s[0].LastIndexOf('/') + 1) : s[0]))
					.ForMember(dsc => dsc.Name, src => src.MapFrom(s => s[1]))
					.ForMember(dsc => dsc.ZipCode, src => src.MapFrom(s => s[2]))
					.ForMember(dsc => dsc.SmartLocation, src => src.MapFrom(s => s[3]))
					.ForMember(dsc => dsc.Country, src => src.MapFrom(s => s[4]))
					.ForMember(dsc => dsc.Longitude, src => src.MapFrom(s => s[5]))
					.ForMember(dsc => dsc.Latitude, src => src.MapFrom(s => s[6]));
			});
		}
	}
}
