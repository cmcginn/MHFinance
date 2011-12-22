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

namespace MarketHarmonics {
  public partial class MarketAnalyticsControl : UserControl {
    MarketAnalyticsPresentationModel _ViewModel = new MarketAnalyticsPresentationModel();

    public virtual void OnInitialized( object sender, EventArgs e ) {
      EventHandler handler = Initialized;
      if( handler != null )
        handler( sender, e );
    }
    public event EventHandler Initialized;
    public MarketAnalyticsControl() {
      DataContext = _ViewModel;
      InitializeComponent();
      Initialize();
    }
    protected virtual void Initialize() {
      _ViewModel.StudyChartViewModel = studyChart1.DataContext as StudyChartViewModel;
      _ViewModel.MarketStudiesViewModel = marketStudies1.DataContext as MarketStudiesViewModel;
      OnInitialized( this, EventArgs.Empty );
    }

  }
}
