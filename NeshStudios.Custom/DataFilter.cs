using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NeshStudios.Custom
{
    [TemplatePart(Name="PART_FilterItems")]
    public class DataFilter : ItemsControl
    {
        static DataFilter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DataFilter), new FrameworkPropertyMetadata(typeof(DataFilter)));
        }
        
        public ICommand AddFilterCommand
        {
            get { return (ICommand)GetValue(AddFilterCommandProperty); }
            set { SetValue(AddFilterCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddFilterCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddFilterCommandProperty =
            DependencyProperty.Register("AddFilterCommand", typeof(ICommand), typeof(DataFilter), new PropertyMetadata(null));

        public override void OnApplyTemplate()
        {
        }

        public Type ObjectType
        {
            get { return (Type)GetValue(ObjectTypeProperty); }
            set { SetValue(ObjectTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ObjectType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ObjectTypeProperty =
            DependencyProperty.Register("ObjectType", typeof(Type), typeof(DataFilter), new PropertyMetadata(null));

        public ICommand RemoveFilterCommand
        {
            get { return (ICommand)GetValue(RemoveFilterCommandProperty); }
            set { SetValue(RemoveFilterCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemoveFilterCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemoveFilterCommandProperty =
            DependencyProperty.Register("RemoveFilterCommand", typeof(ICommand), typeof(DataFilter), new PropertyMetadata(null));

        
        

    }
}
