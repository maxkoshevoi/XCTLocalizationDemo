# XCTLocalizationDemo
App localization demo using Xamarin.CommunityToolkit

See video for more info: https://www.youtube.com/watch?v=wyKKa09z9VQ <br />
Great extension to manage resx-based resources: https://marketplace.visualstudio.com/items?itemName=TomEnglert.ResXManager

## How to use XCT localization?

1. In `App.xaml.cs` 
- Initialize `LocalizationResourceManager` with your resouce manager and optionally initial culture;
- Subscribe to `PropertyChanged` to ensure that culture for `AppResources` is updated when `LocalizationResourceManager.Current.CurrentCulture` is updated.

```cs
LocalizationResourceManager.Current.PropertyChanged += (_, _) => AppResources.Culture = LocalizationResourceManager.Current.CurrentCulture;
LocalizationResourceManager.Current.Init(AppResources.ResourceManager, initialCulture);
```

2. For static strings that use `xct:Translate`. 

```xaml
<ContentPage Title="{xct:Translate AppName}">
```

3. For dynamily generated strings use `LocalizedString` (currently in preview). 

```cs
public LocalizedString AppVersion { get; } = new(() => string.Format(AppResources.Version, AppInfo.VersionString));
```
```xaml
<Label Text="{Binding AppVersion.Localized}"/>
```

4. That's it. Now just do this when you need to change current culture:

```cs
LocalizationResourceManager.Current.CurrrentCulture = newCulture;
```

And after that every resource string in the program will be automatically updated.
