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
  public partial class MarketAnalytics : UserControl {
    MarketAnalyticsViewModel viewModel = new MarketAnalyticsViewModel();
    public MarketAnalytics() {
      //DataContext = viewModel;
      //viewModel.AddStudyCommand.Executed += AddStudyCommand_Executed;
      InitializeComponent();
     // this.MarketStudies.Items.Add( new MarketStudy() );
    }

    void AddStudyCommand_Executed( object sender, EventArgs e ) {
     // this.MarketStudies.Items.Add( new MarketStudy() );
    }
  }
}
