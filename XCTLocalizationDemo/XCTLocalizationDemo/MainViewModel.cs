﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using XCTLocalizationDemo.Resx;

namespace XCTLocalizationDemo
{
    public class MainViewModel : ObservableObject
    {
        List<(Func<string> name, string value)> languageMapping { get; } = new()
        {
            (() => AppResources.System, null),
            (() => AppResources.English, "en"),
            (() => AppResources.Ukrainian, "uk"),
        };

        public LocalizedString Version { get; } = new(() => string.Format(AppResources.Version, AppInfo.VersionString));

        public ICommand ChangeLanguageCommand { get; }

        public MainViewModel()
        {
            ChangeLanguageCommand = new AsyncCommand(ChangeLanguage);
        }

        async Task ChangeLanguage()
        {
            string selectedName = await Application.Current.MainPage.DisplayActionSheet(
                AppResources.ChangeLanguage,
                null, null,
                languageMapping.Select(m => m.name()).ToArray());
            if (selectedName == null)
            {
                return;
            }

            string selectedValue = languageMapping.Single(m => m.name() == selectedName).value;
            LocalizationResourceManager.Current.CurrentCulture = selectedValue == null ? CultureInfo.CurrentCulture : new CultureInfo(selectedValue);
        }
    }
}
