using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ReportSharp.Behaviors
{
    public class DynamicWebViewBehavior : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; set;}
        private WebView AssociatedWebView { get { return AssociatedObject as WebView; } }

        public string HTML
        {
            get { return (string)GetValue(HTMLProperty); }
            set { SetValue(HTMLProperty, value); }
        }

        public static readonly DependencyProperty HTMLProperty =
            DependencyProperty.Register("HTML", typeof(string), typeof(DynamicWebViewBehavior), new PropertyMetadata("", OnHTMLChanged));

        public void Attach(DependencyObject associatedObject)
        {
            if (!(associatedObject is WebView))
                throw new ArgumentException("The associated object must be a WebView");
            AssociatedObject = associatedObject;
        }

        public void Detach() { }

        private static void OnHTMLChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as DynamicWebViewBehavior;
            instance.AssociatedWebView.NavigateToString(e.NewValue?.ToString());
        }
    }
}
