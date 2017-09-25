using System;
using System.Collections.Generic;
using System.Linq;
using People.Models;
using SQLite;

namespace People
{
	public class PersonRepository
	{
		private readonly SQLiteConnection conn;

		public string StatusMessage { get; set; }

		public PersonRepository(string dbPath)
		{
			conn = new SQLiteConnection(dbPath);
			conn.CreateTable<Person>();
		}

		public void AddNewPerson(string name)
		{
		    try
			{
				//basic validation to ensure a name was entered
				if (string.IsNullOrEmpty(name))
					throw new Exception("Valid name required");

				//insert a new person into the Person table
				var result = conn.Insert(new Person { Name = name });
				StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
			}

		}

		public List<Person> GetAllPeople()
		{
			//return a list of people saved to the Person table in the database
			return conn.Table<Person>().ToList();
		}
	}
}