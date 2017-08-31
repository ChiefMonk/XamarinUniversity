using Android.App;
using System;
using Android.Runtime;
using System.Collections.Generic;
using System.Linq;
using GreatQuotes.Data;

namespace GreatQuotes
{
	[Application(Icon="@drawable/icon", Label="@string/app_name")]
	public class App : Application
	{
        private SimpleContainer _ioContainer;

        public App(IntPtr h, JniHandleOwnership jho) : base(h, jho)
		{
		}

		public override void OnCreate()
		{
			base.OnCreate();

		    if (_ioContainer == null)
		        _ioContainer = new SimpleContainer();

		    _ioContainer.Register<IQuoteLoader, QuoteLoader>();
		    _ioContainer.Create<QuoteManager>();
            ServiceLocator.Instance.Add<ITextToSpeech, TextToSpeechService>();
        }

		public static void Save()
		{
			QuoteManager.Instance.Save();
		}
	}
}

