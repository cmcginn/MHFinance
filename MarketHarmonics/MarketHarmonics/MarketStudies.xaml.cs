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
  public partial class MarketStudies : UserControl{
    public virtual void OnInitialized( object sender, EventArgs e ) {
      EventHandler handler = Initialized;
      if( handler != null )
        handler( sender, e );
    }
    public event EventHandler Initialized;
    MarketStudiesViewModel _ViewModel = new MarketStudiesViewModel();
    public MarketStudies() {
      DataContext = _ViewModel;
      _ViewModel.AddStudyCommand.Executed += AddStudyCommand_Executed;
      InitializeComponent();
      Initialize();      
    }
    void AddStudyCommand_Executed( object sender, EventArgs e ) {
      _ViewModel.Studies.Add( new MarketStudy() );
    }
    protected virtual void Initialize() {
      //add initial studdy
      var marketStudy = new MarketStudy();
      _ViewModel.Studies.Add( marketStudy );
      OnInitialized( this, EventArgs.Empty );
    }
  }
}
