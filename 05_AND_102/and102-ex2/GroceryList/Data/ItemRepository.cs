using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Java.Util;

namespace GroceryList.Data
{
	public class ItemRepository
	{
		private static readonly Lazy<ItemRepository> _instance = new Lazy<ItemRepository>(()=> new ItemRepository());
		public static ItemRepository Instance => _instance.Value;

		private readonly IList<ModelItem> _itemCollection;
		#region Constructors

		private ItemRepository()
		{
			_itemCollection = new List<ModelItem>();
		}
		#endregion

		public ObservableCollection<ModelItem> ItemCollection => new ObservableCollection<ModelItem>(_itemCollection);

		public void AddItem(ModelItem item)
		{
			_itemCollection.Add(item);
		}

		public async Task AddItemAsync(ModelItem item)
		{
			await Task.Run(() => AddItem(item));
		}
	}
}