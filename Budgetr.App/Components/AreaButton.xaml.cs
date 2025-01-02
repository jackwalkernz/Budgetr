using System.Windows;
using System.Windows.Controls;

namespace Budgetr.App.Components
{
    /// <summary>
    /// Interaction logic for AreaButton.xaml
    /// </summary>
    public partial class AreaButton : UserControl
    {
        public static readonly DependencyProperty AreaNameProperty = DependencyProperty.Register("AreaName", typeof(string), typeof(AreaButton), new PropertyMetadata(string.Empty));
        public static readonly RoutedEvent ButtonClickEvent = EventManager.RegisterRoutedEvent("ButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AreaButton));
        public string AreaName
        {
            get
            {
                return (string)GetValue(AreaNameProperty);
            }
            set
            {
                SetValue(AreaNameProperty, value);
            }
        }

        public event RoutedEventHandler ButtonClick
        {
            add { AddHandler(ButtonClickEvent, value); }
            remove { RemoveHandler(ButtonClickEvent, value); }
        }

        public AreaButton()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ButtonClickEvent));
        }
    }
}
