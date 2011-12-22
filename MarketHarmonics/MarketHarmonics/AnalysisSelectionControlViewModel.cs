using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;

namespace MarketHarmonics {
  public class AnalysisSelectionControlViewModel:INotifyPropertyChanged {
    public AnalysisSelectionControlViewModel()
    {
      Initialize();
    }
    SimpleCommand _ApplyAnalysisCommand;
    public SimpleCommand ApplyAnalysisCommand {
      get {
        return _ApplyAnalysisCommand;
      }
      private set {
        if( _ApplyAnalysisCommand == value )
          return;
        _ApplyAnalysisCommand = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "ApplyAnalysisCommand" ) );
      }
    }
    List<String> _AvailableIndicators;
    public List<String> AvailableIndicators {
      get {
        return _AvailableIndicators;
      }
      private set {
        if( _AvailableIndicators == value )
          return;
        _AvailableIndicators = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "AvailableIndicators" ) );
      }
    }
    void LoadIndicators() {
      var indicators = new List<string> {
        "Market",
        "SMA 20"
      };
      AvailableIndicators = indicators;
    }
    void Initialize() {
      LoadIndicators();
      ApplyAnalysisCommand = new SimpleCommand();
    }
    public virtual void OnPropertyChanged( object sender, PropertyChangedEventArgs e ) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if( handler != null )
        handler( sender, e );
    }
    public event PropertyChangedEventHandler PropertyChanged;
  }
}
