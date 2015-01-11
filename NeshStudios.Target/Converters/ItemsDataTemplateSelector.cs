using NeshStudios.Target.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NeshStudios.Target.Converters
{
    public class ItemsDataTemplateSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is FilterCriteriaViewModel)
            {
                return element.FindResource("filterCriteriaDataTemplate") as DataTemplate;
            }
            else
            {
                return element.FindResource("filtersDataTemplate") as DataTemplate;
            }
        }
    }
}
