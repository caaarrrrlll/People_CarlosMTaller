﻿using Microsoft.Extensions.Logging;
using People.Repository;

namespace People
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            string dbPath = FileAccessHelper.GetLocalFilePath("people.db3");
            builder.Services.AddSingleton<PersonRepository>(s => ActivatorUtilities.CreateInstance<PersonRepository>(s, dbPath));
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
