using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using NeshStudios.Custom.Model;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NeshStudios.Custom
{
    [TemplatePart(Name = "PART_LogicalOperators")]
    [TemplatePart(Name = "PART_PropertyNames")]
    [TemplatePart(Name = "PART_Operators")]
    [TemplatePart(Name = "PART_SearchText")]
    [TemplatePart(Name = "PART_RemoveButton")]
    public class FilterControl : Control
    {
        static FilterControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FilterControl), new FrameworkPropertyMetadata(typeof(FilterControl)));
        }

        public LogicalOperator LogicalOperator
        {
            get { return (LogicalOperator)GetValue(LogicalOperatorProperty); }
            set { SetValue(LogicalOperatorProperty, value); }
        }

        public static readonly DependencyProperty LogicalOperatorProperty =
            DependencyProperty.Register("LogicalOperator", typeof(LogicalOperator), typeof(FilterControl), new PropertyMetadata(LogicalOperator.AND));

        public string PropertyName
        {
            get { return (string)GetValue(PropertyNameProperty); }
            set { SetValue(PropertyNameProperty, value); }
        }

        public static readonly DependencyProperty PropertyNameProperty =
            DependencyProperty.Register("PropertyName", typeof(string), typeof(FilterControl), new PropertyMetadata(null));

        public Operator Operator
        {
            get { return (Operator)GetValue(OperatorProperty); }
            set { SetValue(OperatorProperty, value); }
        }

        public static readonly DependencyProperty OperatorProperty =
            DependencyProperty.Register("Operator", typeof(Operator), typeof(FilterControl), new PropertyMetadata(Operator.isGreaterThan));

        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }

        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register("SearchText", typeof(string), typeof(FilterControl), new PropertyMetadata(null));




        public Type ObjectType
        {
            get { return (Type)GetValue(ObjectTypeProperty); }
            set { SetValue(ObjectTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ObjectType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ObjectTypeProperty =
            DependencyProperty.Register("ObjectType", typeof(Type), typeof(FilterControl)
            , new FrameworkPropertyMetadata((s,e)=>
                {
                    var control = (FilterControl)s;
                    control.OnObjectTypeChanged();
                }));

        public void OnObjectTypeChanged()
        {
            var propertyNamesControl = GetTemplateChild("PART_PropertyNames");

            if (propertyNamesControl != null)
            {
                var list = new ObservableCollection<string>(this.ObjectType.GetProperties().Select(x => x.Name));
                ((ItemsControl)propertyNamesControl).ItemsSource = list;
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var logicalOperatorsControl = GetTemplateChild("PART_LogicalOperators");

            if ( logicalOperatorsControl != null)
            {
                var list = new ObservableCollection<LogicalOperator>() { LogicalOperator.AND, LogicalOperator.OR };
                ((ItemsControl)logicalOperatorsControl).ItemsSource = list;
            }

            var operatorsControl = GetTemplateChild("PART_Operators");

            if (operatorsControl != null)
            {
                var enumList = Enum.GetValues(typeof(Operator));
                var list = new ObservableCollection<Operator>();
                foreach (var item in enumList)
                {
                    list.Add((Operator)item);
                }

                ((ItemsControl)operatorsControl).ItemsSource = list;
            }
        }        
    }
}
