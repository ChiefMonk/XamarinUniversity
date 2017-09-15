using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.Entities;
using SQLite;

namespace People.Data
{
	public sealed class PersonRepository
	{
		// Singleton of the database repository object.
		private static PersonRepository instance;

		public static PersonRepository Instance
		{
			get
			{
				if (instance == null)
					throw new Exception("You must call Initialize before retrieving the singleton for the PersonRepository.");

				return instance;
			}
		}

		public static void Initialize(string filename)
		{
			if (filename == null)
				throw new ArgumentNullException(nameof(filename));

			instance?.Connection.GetConnection().Dispose();

			instance = new PersonRepository(filename);
		}

		public string StatusMessage { get; set; }

		private PersonRepository(string dbPath)
		{
			// TODO: Initialize a new SQLiteConnection
			Connection = new SQLiteAsyncConnection(dbPath);

			// TODO: Create the Person table
			Connection.CreateTableAsync<EntityPerson>().Wait();
		}

		private SQLiteAsyncConnection Connection { get; }

		public async Task AddNewPersonAsync(string name)
		{
			try
			{
				//basic validation to ensure a name was entered
				if (string.IsNullOrEmpty(name))
					throw new Exception("Valid name required");

				var person = new EntityPerson()
				{
					Name = name,
				};

				// TODO: insert a new person into the Person table
				var result = await Connection.InsertAsync(person);

				StatusMessage = $"{result} record(s) added [Name: {name})";
			}
			catch (Exception ex)
			{
				StatusMessage = $"Failed to add {name}. Error: {ex.Message}";
			}
		}

		public async Task<IEnumerable<EntityPerson>> GetAllPeopleAsync()
		{
			try
			{
				// TODO: return the Person table in the database
				return await Connection.Table<EntityPerson>().ToListAsync();

			}
			catch (Exception ex)
			{
				StatusMessage = $"Failed to retrieve data. {ex.Message}";
			}

			return Enumerable.Empty<EntityPerson>();
		}
	}
}
