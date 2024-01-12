using Avalonia.Android;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaScope2.Android
{
    public interface INativeDemoControl
    {
        /// <param name="isSecond">Used to specify which control should be displayed as a demo</param>
        /// <param name="parent"></param>
        /// <param name="createDefault"></param>
        IPlatformHandle CreateControl(bool isSecond, IPlatformHandle parent, Func<IPlatformHandle> createDefault);
    }

    public class EmbedSampleAndroid : INativeDemoControl
    {
        public IPlatformHandle CreateControl(bool isSecond, IPlatformHandle parent, Func<IPlatformHandle> createDefault)
        {
            var parentContext = (parent as AndroidViewControlHandle)?.View.Context
                ?? global::Android.App.Application.Context;

            if (isSecond)
            {
                var webView = new global::Android.Webkit.WebView(parentContext);
                webView.LoadUrl("https://www.android.com/");

                return new AndroidViewControlHandle(webView);
            }
            else
            {
                var button = new global::Android.Widget.Button(parentContext) { Text = "Hello world" };
                var clickCount = 0;
                button.Click += (sender, args) =>
                {
                    clickCount++;
                    button.Text = $"Click count {clickCount}";
                };

                return new AndroidViewControlHandle(button);
            }
        }
    }
}
