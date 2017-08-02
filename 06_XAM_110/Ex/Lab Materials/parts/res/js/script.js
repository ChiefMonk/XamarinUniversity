(function() {
    // Used to determine if a particular platform has already been chosen
    var platformPicker = (function () {
        var getQuerystringValue = function (name, url) {
            if (!url) {
                url = window.location.href;
            }
            name = name.replace(/[\[\]]/g, "\\$&");
            var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return '';
            return decodeURIComponent(results[2].replace(/\+/g, " "));
        };
        var windowsPlatformValue = "win";
        var macOsPlatformValue = "mac";
        var platformKey = "platform";
        var currentPlatform = function () {
            return getQuerystringValue("platform");
        };
        var isWindowsPicked = function () {
            return (currentPlatform() === windowsPlatformValue);
        };
        var isMacOSPicked = function () {
            return (currentPlatform() === macOsPlatformValue);
        };
        var getPlatformUrl = function (platform) {
            return window.location.pathname + "?platform=" + platform;
        }
        var macOsPlatformUrl = getPlatformUrl(macOsPlatformValue);
        var windowsPlatformUrl = getPlatformUrl(windowsPlatformValue);
        return {
            currentPlatform: currentPlatform,
            isMacOSPicked: isMacOSPicked,
            isWindowsPicked: isWindowsPicked,
            macOsPlatformUrl: macOsPlatformUrl,
            windowsPlatformUrl: windowsPlatformUrl
        };
    })();

	// This method is used to color alternating rows in a table when the
	// class "alternate-rows" is applied.
	function altRows(className) {
		var table = document.getElementsByClassName(className);

		for (i = 0; i < table.length; i++) {
			var rows = table[i].getElementsByTagName("tr"); 
			for (r = 0; r < rows.length; r++) {          
				if (r % 2 == 0) {
					rows[r].className = "evenrowcolor";
				} else {
					rows[r].className = "oddrowcolor";
				}      
			}
		}
	}

	window.onload=function() {
		altRows("alternate-rows")
    prettyPrint()
    var title = $('#page-title')
    if (title.length)
      title.html(document.title)

    var header = $('header[role=course-title]')
    if (header.length)
      header.html(document.title)
	}

   /////////////////////
   // IDE selection
   ////////////////////
    var $ideSelector = $('#ide-selector');

    $ideSelector.bind('recalc', function(e, newValue) {
        var value;

        if (newValue == undefined) {
             value = "xs";
        } else {
            value = newValue;
        }

        $(this).find('a').removeClass('active');
        $(this).find('a[data-name="' + value + '"]').addClass('active');

        $('#main ide, main .ide').hide();
        $('#main ide[name="' + value + '"], #main .ide.' + value).show();
    });

    if ($ideSelector.length > 0) {
        $ideSelector.trigger('recalc');
    }

    $ideSelector.on('click', 'a', function(e) {
        var ideValue = $(this).attr('data-name');
        var newUrl;

        e.preventDefault();
        if (!ideValue) { return; }

        // Trigger requested platform switch.
        $ideSelector.trigger('recalc', ideValue);
        // Maintain platform choice for reload/back/forward, when possible.
        if (history && history.pushState) {
            if (ideValue === "xs") {
                newUrl = platformPicker.macOsPlatformUrl;
            }
            else {
                newUrl = platformPicker.windowsPlatformUrl;
            }
            history.pushState({}, '', newUrl);
        }
    });

    // Go to the requested platform on first load.
    if (platformPicker.isMacOSPicked()) {
        $ideSelector.trigger("recalc", "xs");
    }
    else if (platformPicker.isWindowsPicked()) {
        $ideSelector.trigger("recalc", "vs");
    }
})();

// This is used to show/hide code blocks
function toggleCode(btn, id) {
   var e = document.getElementById(id);
   if(e.style.display == 'block') {
      e.style.display = 'none';
      btn.innerHTML = "Show Code";
   }
   else {
      e.style.display = 'block';
      btn.innerHTML = "Hide Code";
   }
}

// This is used to show/hide text blocks
function toggleBlock(btn, id, showText, hideText) {
   var e = document.getElementById(id);
   if(e.style.display == 'block') {
      e.style.display = 'none';
      btn.innerHTML = showText;
   }
   else {
      e.style.display = 'block';
      btn.innerHTML = hideText;
   }
}

