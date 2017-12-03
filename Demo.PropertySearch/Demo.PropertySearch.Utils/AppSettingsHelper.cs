using System;
using System.ComponentModel;
using System.Configuration;
using System.Linq;

namespace Demo.PropertySearch.Utils
{
    public static class AppSettingsHelper
    {
        public static TConfig CreateFromAppConfig<TConfig>() where TConfig : class, new()
        {
            var config = new TConfig();

            // filter the configuration properties by existing application settings in web/app.config
            var properties = config.GetType().GetPropertiesOf()
                .Join
                (
                    ConfigurationManager.AppSettings.AllKeys,
                    prop => prop.Name,
                    appSettingKey => appSettingKey,
                    (info, key) => info, StringComparer.InvariantCultureIgnoreCase
                );

            // map the configuration properties value from the application settings in web/app.config
            foreach (var property in properties)
            {
                var appSetting = ConfigurationManager.AppSettings[property.Name];

                var typeConverter = TypeDescriptor.GetConverter(property.PropertyType);

                var value = typeConverter.ConvertFrom(appSetting);

                property.SetValue(config, value);
            }

            return config;
        }
    }
}
