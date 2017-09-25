using SQLite;

namespace People.Entities
{
	public abstract class EntityBase
	{
		#region Constructors

		protected EntityBase()
		{
			Id = 0;
		}
		#endregion

		#region Properties
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		#endregion
	}
}
