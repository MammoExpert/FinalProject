using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace MammoExpert.PatientServices.PresenterCore
{
    public class ClickBehavior : Behavior<FrameworkElement>
    {
        public bool DoubleClick
        {
            get { return (bool)GetValue(DoubleClickProperty); }
            set { SetValue(DoubleClickProperty, value); }
        }


        public static readonly DependencyProperty DoubleClickProperty = DependencyProperty.RegisterAttached(
            "IsMouseOverAP",
            typeof(bool),
            typeof(ClickBehavior));
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.MouseEnter += AssociatedObject_MouseEnter;
            this.AssociatedObject.MouseLeave += AssociatedObject_MouseLeave;
        }

        void AssociatedObject_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            FrameworkElement el = sender as FrameworkElement;
            SetValue(DoubleClickProperty, false);
        }

        void AssociatedObject_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            FrameworkElement el = sender as FrameworkElement;
            SetValue(DoubleClickProperty, true);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.MouseEnter -= AssociatedObject_MouseEnter;
            this.AssociatedObject.MouseLeave -= AssociatedObject_MouseLeave;
        }

    }

    //public static class ClickBehavior
    //{
    //    public static DependencyProperty RightClickCommandProperty = DependencyProperty.RegisterAttached("RightClick",

    //        typeof(ICommand),

    //        typeof(ClickBehavior),

    //        new FrameworkPropertyMetadata(null, new PropertyChangedCallback(ClickBehavior.RightClickChanged)));

    //    public static readonly DependencyProperty RightClickProperty = DependencyProperty.RegisterAttached("RightClick", typeof(object), typeof(ClickBehavior), new PropertyMetadata(default(object)));


    //    public static void SetRightClick(DependencyObject target, ICommand value)

    //    {

    //        target.SetValue(ClickBehavior.RightClickCommandProperty, value);

    //    }



    //    public static ICommand GetRightClick(DependencyObject target)
    //    {

    //        return (ICommand)target.GetValue(RightClickCommandProperty);

    //    }





    //    private static void RightClickChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)

    //    {

    //        var element = target as UIElement;

    //        if (element != null)

    //        {

    //            // If we're putting in a new command and there wasn't one already

    //            // hook the event

    //            if ((e.NewValue != null) && (e.OldValue == null))

    //            {

    //                element.MouseRightButtonUp += element_MouseRightButtonUp;

    //            }

    //            // If we're clearing the command and it wasn't already null

    //            // unhook the event

    //            else if ((e.NewValue == null) && (e.OldValue != null))

    //            {

    //                element.MouseRightButtonUp -= element_MouseRightButtonUp;

    //            }

    //        }

    //    }



    //    static void element_MouseRightButtonUp(object sender, MouseButtonEventArgs e)

    //    {

    //        var element = (UIElement)sender;

    //        var command = (ICommand)element.GetValue(ClickBehavior.RightClickCommandProperty);

    //        command.Execute(null);

    //    }
    //}
}