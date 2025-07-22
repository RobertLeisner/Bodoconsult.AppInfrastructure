namespace Bodoconsult.App.Wpf.Services
{
    /// <summary>
    /// Keeps information about language resource file used by diffrent modules
    /// </summary>
    public class LanguageResourceService
    {

        private static readonly Dictionary<string, string> Data = new Dictionary<string, string>();


        /// <summary>
        /// Register a language resource file for a language and a module
        /// </summary>
        /// <param name="language"></param>
        /// <param name="moduleName"></param>
        /// <param name="path"></param>
        public static void RegisterLanguageResourceFile(string language, string moduleName, string path)
        {
            var key = language + moduleName;
            if (Data.ContainsKey(key)) return;
            Data.Add(key, path);
        }


        /// <summary>
        /// Get a resource from the store for a language and a module
        /// </summary>
        /// <param name="language">requested language</param>
        /// <param name="moduleName">requested module name</param>
        /// <param name="resourceKey">requested resource key</param>
        public static string FindResource(string language, string moduleName, string resourceKey)
        {

            if (string.IsNullOrEmpty(moduleName)) return "LanguageResourceService: moduleName may not be null!";

            var key = language + moduleName;
            return !Data.ContainsKey(key) ? $"LanguageResourceService: register resource file first! {language}, {moduleName}, {resourceKey}"
                : 
                ResourceFinderService.FindResource<string>(Data[key], resourceKey);
        }
    }
}
