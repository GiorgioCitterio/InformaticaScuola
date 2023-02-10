using Microsoft.Extensions.Logging;

namespace _13_PersistenzaDati
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

#if DEBUG
		builder.Logging.AddDebug();
#endif
            string dbPath = FileAccessHelper.GetFileLocalPath("Dati.db3"); //prendo percorso del db
            builder.Services.AddSingleton<PersonRepository>(s => 
            ActivatorUtilities.CreateInstance<PersonRepository>(s, dbPath));
            //fa un'iniezione delle dipendenze
            return builder.Build();
        }
    }
}