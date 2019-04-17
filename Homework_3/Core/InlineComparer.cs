using Homework_3.Entities;
using System.Collections.Generic;

namespace Homework_3.Core
{
	public class InlineComparer<T> : IEqualityComparer<T> where T : Barcelona
	{
		public bool Equals(T firstEntity, T secondEntity)
		{
			return firstEntity.Id == secondEntity.Id
				&& firstEntity.Name == secondEntity.Name
				&& firstEntity.ZipCode == secondEntity.ZipCode
				&& firstEntity.SmartLocation == secondEntity.SmartLocation
				&& firstEntity.Country == secondEntity.Country
				&& firstEntity.Latitude == secondEntity.Latitude
				&& firstEntity.Longitude == secondEntity.Longitude;
		}

		public int GetHashCode(T entity)
		{
			int hash = 10;

			hash = hash * 15 + (entity.Id ?? "").GetHashCode();
			hash = hash * 15 + (entity.Name ?? "").GetHashCode();
			hash = hash * 15 + (entity.ZipCode ?? "").GetHashCode();
			hash = hash * 15 + (entity.SmartLocation ?? "").GetHashCode();
			hash = hash * 15 + (entity.Country ?? "").GetHashCode();
			hash = hash * 15 + (entity.Latitude ?? "").GetHashCode();
			hash = hash * 15 + (entity.Longitude ?? "").GetHashCode();

			return hash;
		}
	}
}
