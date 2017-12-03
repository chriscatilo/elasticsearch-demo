using Demo.PropertySearch.Utils;
using System;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Demo.PropertySearch.Specs.Utils
{
    public static class TableExtensions
    {
        public static TModel To<TModel>(this Table table) where TModel : class, new()
        {
            var model = new TModel();

            var properties = model.GetType().GetPropertiesOf().ToArray();

            properties.ToList().ForEach(SetPropertyValueFromTable(table, model));

            return model;
        }

        private static Action<PropertyInfo> SetPropertyValueFromTable<TModel>(Table table, TModel model)
        {
            return property =>
            {
                var value = table.Rows.SingleOrDefault(r => r[0] == property.Name)?[1];

                var @type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                var safeValue = (value == null) ? null : Convert.ChangeType(value, @type);
                
                property.SetValue(model, safeValue);
            };
        }
    }
}
