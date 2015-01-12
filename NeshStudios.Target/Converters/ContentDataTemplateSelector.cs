using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NeshStudios.Target.Converters
{
    public class ContentDataTemplateSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is DateTime)
            {
                return element.FindResource("DateTimeDataTemplate") as DataTemplate;
            }
            else if (element != null && item != null && item is bool)
            {
                return element.FindResource("BooleanDataTemplate") as DataTemplate;
            }
            else 
            {
                return element.FindResource("StringDataTemplate") as DataTemplate;
            }
        }
    }
}
