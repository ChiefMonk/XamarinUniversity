using SQLite;

namespace People.Entities
{
	[Table("person")]
	public class EntityPerson : EntityBase
	{
		#region Constructors

		public EntityPerson()
		{			
			Name = null;
		}
		#endregion

		#region Properties
	
		[Column("name"), MaxLength(250), Unique]
		public string Name { get; set; }

		[Ignore]
		public string FullName => $"Cde. {Name}";


		#endregion
	}
}
