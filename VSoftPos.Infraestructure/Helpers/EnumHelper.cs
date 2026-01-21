using Pos.Core.Attributos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Pos.Infraestructure.Helpers
{
    public static class EnumHelper
    {
        public static T? GetAttributeOfType<T>(this Enum enumValue) where T : Attribute
        {
            var type = enumValue.GetType();
            // Use GetField to get the field info for the enum value
            var memInfo = type.GetField(enumValue.ToString(), BindingFlags.Public | BindingFlags.Static);

            if (memInfo is null)
                return null;

            // Retrieve the custom attributes of type T
            var attributes = memInfo.GetCustomAttributes<T>(false);
            return attributes.FirstOrDefault();
        }

        public static string GetDisplayDescription(this Enum value)
        {
            if (value is null)
                return string.Empty;

            // Get the DisplayAttribute
            var attribute = value.GetAttributeOfType<DisplayAttribute>();

            // Return the DisplayAttribute name if it exists, otherwise return the enum's string representation
            return attribute?.Description ?? value.ToString();

        }

        public static MenuAttribute? GetMenuAttribute(this Enum value)
        {
            var type = value.GetType();
            if (type == null)
                return null;

            FieldInfo? field = type.GetField(value.ToString());
            if (field == null)
                return null;

            MenuAttribute[] customAttributes = (MenuAttribute[])field.GetCustomAttributes(typeof(MenuAttribute), false);
            if (customAttributes.Length == 0)
                return null;

            return customAttributes[0];
        }

        public static string GetDescripcion(this Enum value)
        {
            var type = value.GetType();
            if (type == null)
                return string.Empty;

            FieldInfo? field = type.GetField(value.ToString());
            if (field == null)
                return string.Empty;

            DescriptionAttribute[] customAttribute = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return customAttribute.Length > 0 ? customAttribute[0].Description : value.ToString();
        }
    }
}
