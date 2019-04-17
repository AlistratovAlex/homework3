using Homework_3.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Homework_3.Core
{
	public static class CustomUnion
	{
		public static IList<AppartmentResult> UnionAll(IEnumerable<Barcelona> firstEntities, IEnumerable<Barcelona> secondEntities)
		{
			var allFirstEntities = firstEntities.ToList();
			allFirstEntities.AddRange(secondEntities);

			return allFirstEntities
				.Select(ar =>
					new AppartmentResult()
					{
						Name = ar.Name,
						Latitude = ar.Latitude,
						Longitude = ar.Latitude
					})
				.ToList();
		}

		public static IList<AppartmentResult> Union(IEnumerable<Barcelona> firstEntities, IEnumerable<Barcelona> secondEntities)
		{
			return firstEntities.Union(secondEntities, new InlineComparer<Barcelona>()).Select(ar =>
					new AppartmentResult()
					{
						Name = ar.Name,
						Latitude = ar.Latitude,
						Longitude = ar.Latitude
					})
				.ToList();
		}
	}
}
