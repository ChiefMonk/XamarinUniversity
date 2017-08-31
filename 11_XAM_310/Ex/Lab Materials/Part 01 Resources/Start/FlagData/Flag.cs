using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FlagData
{
    /// <summary>
    /// This model object represents a single flag
    /// </summary>
    public class Flag
    {	    
	    private string _country;
	    private string _imageUrl;
	    private DateTime _dateAdopted;
	    private bool _includesShield;
	    private string _description;
	    private Uri _moreInformationUrl;

		public event PropertyChangedEventHandler PropertyChanged;

	    /// <summary>
	    /// Name of the country that this flag belongs to
	    /// </summary>
	    public string Country
	    {
		    get => _country;
		    set => ChangePropertyValue(ref _country, value);
	    }
        /// <summary>
        /// Image URL for the flag (from resources)
        /// </summary>
        public string ImageUrl
        {
	        get => _imageUrl;
	        set => ChangePropertyValue(ref _imageUrl, value);
        }
		/// <summary>
		/// The date this flag was adopted
		/// </summary>
		public DateTime DateAdopted
		{
			get => _dateAdopted;
			set => ChangePropertyValue(ref _dateAdopted, value);
		}
		/// <summary>
		/// Whether the flag includes an image/shield as part of the design
		/// </summary>
		public bool IncludesShield
		{
			get => _includesShield;
			set => ChangePropertyValue(ref _includesShield, value);
		}
		/// <summary>
		/// Some trivia or commentary about the flag
		/// </summary>
		public string Description
		{
			get => _description;
			set => ChangePropertyValue(ref _description, value);
		}
		/// <summary>
		/// A URL for more information
		/// </summary>
		public Uri MoreInformationUrl
		{
			get => _moreInformationUrl;
			set => ChangePropertyValue(ref _moreInformationUrl, value);
		}

		private bool ChangePropertyValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
	    {
		    if (!Equals(field, value))
		    {
			    field = value;
			    RaisePropertyChanged(propertyName);
			    return true;
		    }
		    return false;
	    }

		private void RaisePropertyChanged([CallerMemberName] string propertyName ="")
	    {
		    if(PropertyChanged != null)
			    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));

		}
    }
}
