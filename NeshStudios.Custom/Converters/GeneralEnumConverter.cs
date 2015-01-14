using NeshStudios.Custom.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NeshStudios.Custom.Converters
{
    internal static class EnumCache<T> 
        where T : struct, IConvertible
    {
        private static Dictionary<int, Tuple<T, string>> collectionCache;

        public static Dictionary<int, Tuple<T, string>> CollectionCache
        {
            get
            {
                if (collectionCache == null)
                {
                    collectionCache = CreateCache();
                }
                return collectionCache;
            }
        }

        private static Dictionary<int, Tuple<T, string>> CreateCache()
        {
            Dictionary<int, Tuple<T, string>> collectionCache = new Dictionary<int, Tuple<T, string>>();

            var fields = typeof(T).GetFields().Where(x => x.IsLiteral);

            foreach (var field in fields)
            {
                var intValue = (int)field.GetValue(null);
                var displayText = ((DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false))[0].Description;
                T operatorEnum = (T)(object)field.GetValue(null);
                var tuple = Tuple.Create(operatorEnum, displayText);
                collectionCache.Add(intValue, tuple);
            }
            return collectionCache;
        }
    }

    public class OperatorEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //this is a hack, binding is unbinding to text i think???
            if ( value is string)
            {
                value = Operator.Contains;
            }

            return EnumCache<Operator>.CollectionCache[(int)value].Item2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var displayText = (String)value;
            var key = EnumCache<Operator>.CollectionCache.Single(x => x.Value.Item2 == displayText).Key;
            return (object)EnumCache<Operator>.CollectionCache[key].Item1;
        }
    }

    public class LogicalOperatorEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //this is a hack, binding is unbinding to text i think???
            if (value is string)
            {
                value = LogicalOperator.Where;
            }

            return EnumCache<LogicalOperator>.CollectionCache[(int)value].Item2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var displayText = (String)value;
            var key = EnumCache<LogicalOperator>.CollectionCache.Single(x => x.Value.Item2 == displayText).Key;
            return (object)EnumCache<LogicalOperator>.CollectionCache[key].Item1;
        }
    }
}
