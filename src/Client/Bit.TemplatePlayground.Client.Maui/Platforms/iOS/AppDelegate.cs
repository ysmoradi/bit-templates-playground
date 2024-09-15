﻿using Foundation;

namespace Bit.TemplatePlayground.Client.Maui.Platforms.iOS;

[Register(nameof(AppDelegate))]
public partial class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
