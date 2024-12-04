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

namespace WpfApp7.Chapter08
{
    /// <summary>
    /// Interaction logic for LineChartControl.xaml
    /// </summary>
    public partial class LineChartControl : UserControl
    {
        public LineChartControl()
        {
            InitializeComponent();
            this.DataContext = this;

            this.ControlChartStyle =new ChartStyleLineChartControl(this);
            this.ControlDataCollection = new DataCollectionLineChartControl(this);
            this.ControlDataSeries = new DataSeriesLineChartControl();

        }

        public ChartStyleLineChartControl ControlChartStyle { get; set; }

        public DataCollectionLineChartControl ControlDataCollection { get; set; }

        public DataSeriesLineChartControl ControlDataSeries { get; set; }


        public static DependencyProperty XminProperty =
DependencyProperty.Register(
"Xmin", typeof(double), typeof(LineChartControl),
new FrameworkPropertyMetadata(0.0,
new PropertyChangedCallback(OnDoubleChanged)));
        public double Xmin
        {
            get { return (double)GetValue(XminProperty); }
            set { SetValue(XminProperty, value); }
        }
        public static DependencyProperty XmaxProperty =
        DependencyProperty.Register(
        "Xmax", typeof(double), typeof(LineChartControl),
        new FrameworkPropertyMetadata(1.0,
        new PropertyChangedCallback(OnDoubleChanged)));
        public double Xmax
        {
            get { return (double)GetValue(XmaxProperty); }
            set { SetValue(XmaxProperty, value); }
        }
        public static DependencyProperty YminProperty =
        DependencyProperty.Register(
        "Ymin", typeof(double), typeof(LineChartControl),
        new FrameworkPropertyMetadata(0.0,
        new PropertyChangedCallback(OnDoubleChanged)));
        public double Ymin
        {
            get { return (double)GetValue(YminProperty); }
            set { SetValue(YminProperty, value); }
        }
        public static DependencyProperty YmaxProperty =
        DependencyProperty.Register(
        "Ymax", typeof(double), typeof(LineChartControl),
        new FrameworkPropertyMetadata(1.0,
        new PropertyChangedCallback(OnDoubleChanged)));
        public double Ymax
        {
            get { return (double)GetValue(YmaxProperty); }
            set { SetValue(YmaxProperty, value); }
        }
        public static DependencyProperty XTickProperty =
        DependencyProperty.Register(
        "XTick", typeof(double), typeof(LineChartControl),
        new FrameworkPropertyMetadata(0.5,
        new PropertyChangedCallback(OnDoubleChanged)));

        public double XTick
        {
            get { return (double)GetValue(XTickProperty); }
            set { SetValue(XTickProperty, value); }
        }
        public static DependencyProperty YTickProperty =
        DependencyProperty.Register(
        "YTick", typeof(double), typeof(LineChartControl),
        new FrameworkPropertyMetadata(0.5,
        new PropertyChangedCallback(OnDoubleChanged)));
        public double YTick
        {
            get { return (double)GetValue(YTickProperty); }
            set { SetValue(YTickProperty, value); }
        }
        public static DependencyProperty TitleProperty =
        DependencyProperty.Register(
        "Title", typeof(string), typeof(LineChartControl),
        new FrameworkPropertyMetadata("My Chart",
        new PropertyChangedCallback(OnStringChanged)));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static DependencyProperty XLabelProperty =
        DependencyProperty.Register(
        "XLabel", typeof(string), typeof(LineChartControl),
        new FrameworkPropertyMetadata("X Axis",
        new PropertyChangedCallback(OnStringChanged)));
        public string XLabel
        {
            get { return (string)GetValue(XLabelProperty); }
            set { SetValue(XLabelProperty, value); }
        }
        public static DependencyProperty YLabelProperty = DependencyProperty.Register(
"YLabel", typeof(string), typeof(LineChartControl),
new FrameworkPropertyMetadata("Y Axis",
new PropertyChangedCallback(OnStringChanged)));
        public string YLabel
        {
            get { return (string)GetValue(YLabelProperty); }
            set { SetValue(YLabelProperty, value); }
        }
        public static DependencyProperty IsXGridProperty =
        DependencyProperty.Register(
        "IsXGrid", typeof(bool), typeof(LineChartControl),
        new FrameworkPropertyMetadata(true,
        new PropertyChangedCallback(OnBoolChanged)));
        public bool IsXGrid
        {
            get { return (bool)GetValue(IsXGridProperty); }
            set { SetValue(IsXGridProperty, value); }
        }
        public static DependencyProperty IsYGridProperty =
        DependencyProperty.Register(
        "IsYGrid", typeof(bool), typeof(LineChartControl),
        new FrameworkPropertyMetadata(true,
        new PropertyChangedCallback(OnBoolChanged)));
        public bool IsYGrid
        {
            get { return (bool)GetValue(IsYGridProperty); }
            set { SetValue(IsYGridProperty, value); }
        }
        public static DependencyProperty GridlineColorProperty
        = DependencyProperty.Register(
        "GridlineColor", typeof(Brush),
        typeof(LineChartControl),
        new FrameworkPropertyMetadata(Brushes.Gray,
        new PropertyChangedCallback(OnColorChanged)));
        public Brush GridlineColor
        {
            get
            {
                return (Brush)GetValue(
            GridlineColorProperty);
            }
            set { SetValue(GridlineColorProperty, value); }
        }
        public static DependencyProperty
        GridlinePatternProperty =
        DependencyProperty.Register(
        "GridLinePattern", typeof(
        ChartStyleLineChartControl.GridlinePatternEnum),
                typeof(LineChartControl),
                        new FrameworkPropertyMetadata(
                        ChartStyleLineChartControl.GridlinePatternEnum.Solid,
                        new PropertyChangedCallback(
                        OnGridlinePatternChanged)));
        public ChartStyleLineChartControl.GridlinePatternEnum GridlinePattern
        {
            get
            {
                return (ChartStyleLineChartControl.
            GridlinePatternEnum)GetValue(
            GridlinePatternProperty);
            }
            set { SetValue(GridlinePatternProperty, value); }
        }
        private static void OnGridlinePatternChanged(
        DependencyObject sender,
        DependencyPropertyChangedEventArgs e)
        {
            LineChartControl lcc = (LineChartControl)sender;
            lcc.GridlinePattern = (ChartStyleLineChartControl.
            GridlinePatternEnum)e.NewValue;
        }
        private static void OnColorChanged(DependencyObject
        sender, DependencyPropertyChangedEventArgs e)
        {
            LineChartControl lcc = (LineChartControl)sender;
            lcc.GridlineColor = (Brush)e.NewValue;
        }

        private static void OnDoubleChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            LineChartControl lcc = (LineChartControl)sender;
            if (e.Property == XminProperty)
                lcc.Xmin = (double)e.NewValue;
            else if (e.Property == XmaxProperty)
                lcc.Xmax = (double)e.NewValue;
            else if (e.Property == YminProperty)
                lcc.Ymin = (double)e.NewValue;
            else if (e.Property == YmaxProperty)
                lcc.Ymax = (double)e.NewValue;
            else if (e.Property == XTickProperty)
                lcc.XTick = (double)e.NewValue;
            else if (e.Property == YTickProperty)
                lcc.YTick = (double)e.NewValue;
        }
        private static void OnStringChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            LineChartControl lcc = (LineChartControl)sender;
            if (e.Property == TitleProperty)
            {
                lcc.Title = (string)e.NewValue;
            }
            else if (e.Property == XLabelProperty)
            {
                lcc.XLabel = (string)e.NewValue;
            }
            else if (e.Property == YLabelProperty)
            {
                lcc.YLabel = (string)e.NewValue;
            }
        }
        private static void OnBoolChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            LineChartControl lcc = (LineChartControl)sender;
            if (e.Property == IsXGridProperty)
                lcc.IsXGrid = (bool)e.NewValue;
            else if (e.Property == IsYGridProperty)
                lcc.IsYGrid = (bool)e.NewValue;
        }
    }
}
