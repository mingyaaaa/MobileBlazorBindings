﻿using BlazorDesktop.Elements.Handlers;
using Microsoft.AspNetCore.Components;
using Microsoft.MobileBlazorBindings.Core;
using Microsoft.MobileBlazorBindings.Elements;
using XF = Xamarin.Forms;

namespace BlazorDesktop.Elements
{
    public class WebView : View
    {
        static WebView()
        {
            ElementHandlerRegistry
                .RegisterElementHandler<WebView>(renderer => new WebViewHandler(renderer, new XF.WebView()));
        }

        [Parameter] public XF.WebViewSource Source { get; set; }

        protected override void RenderAttributes(AttributesBuilder builder)
        {
            base.RenderAttributes(builder);

            switch (Source)
            {
                case XF.HtmlWebViewSource htmlWebViewSource:
                    builder.AddAttribute(nameof(XF.HtmlWebViewSource), htmlWebViewSource.Html);
                    break;
                case XF.UrlWebViewSource urlWebViewSource:
                    builder.AddAttribute(nameof(XF.UrlWebViewSource), urlWebViewSource.Url);
                    break;
            }
        }
    }
}
