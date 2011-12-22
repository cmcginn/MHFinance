using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.Charts;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;

namespace MarketHarmonics {
  public partial class StudyChart : UserControl {
    StudyChartViewModel _ViewModel = new StudyChartViewModel();
    

    public virtual void OnInitialized( object sender, EventArgs e ) {
      EventHandler handler = Initialized;
      if( handler != null )
        handler( sender, e );
    }
    public event EventHandler Initialized;
    public StudyChart() {
      DataContext = _ViewModel;
      InitializeComponent();
      Initialize();
    }
    List<MediaElement> _MediaElements = new List<MediaElement>();
    protected virtual void Initialize() {
      _ViewModel.StudyModels.CollectionChanged += StudyModels_CollectionChanged;
      _ViewModel.SoundLoaded += new EventHandler( _ViewModel_SoundLoaded );
      _MediaElements.Add( study1 );
      _MediaElements.Add( study2 );
      _MediaElements.Add( study3 );
      _MediaElements.Add( study4 );
      _MediaElements.Add( study5 );
      OnInitialized( this, EventArgs.Empty );
    }

    void _ViewModel_SoundLoaded( object sender, EventArgs e ) {
      for( int i = 0; i < _ViewModel.SoundWaves.Count; i++ ) {

        _MediaElements.ElementAt( i ).SetSource( _ViewModel.SoundWaves.ElementAt( i ).Source );
        _MediaElements.ElementAt( i ).CurrentStateChanged += StudyChart_CurrentStateChanged;
      } 
    }

    void StudyChart_CurrentStateChanged( object sender, RoutedEventArgs e ) {
      var target = sender as MediaElement;
      if( target.CurrentState == MediaElementState.Paused )
        target.Play();
    }
    void AddSeries( StudyModel data ) {
      
      var series = new LineSeries2D();
      var xyDiagram = chartControl1.Diagram as XYDiagram2D;
      
      series.DataSource = data.PointModels;
      series.ArgumentDataMember = "XAxisValue";
      series.ValueDataMember = "YAxisValue";
      series.ArgumentScaleType = ScaleType.DateTime;
      
      xyDiagram.AxisY.Range.MinValueInternal = _ViewModel.YAxisMinValue;
      xyDiagram.AxisY.Range.MaxValueInternal = _ViewModel.YAxisMaxValue;
      chartControl1.Diagram.Series.Add( series );
      //
    }
    void StudyModels_CollectionChanged( object sender, NotifyCollectionChangedEventArgs e ) {
      if( e.NewItems != null ) {
        var newModel = e.NewItems.OfType<StudyModel>().LastOrDefault();
        if( newModel != null )
          AddSeries( newModel );

      }
    }
  }
}
