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
using System.ComponentModel;

namespace MarketHarmonics {
  public class PointModel :INotifyPropertyChanged{

    DateTime _XAxisValue;
    double _YAxisValue;
    double _Frequency;
    public virtual void OnPropertyChanged( object sender, PropertyChangedEventArgs e ) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if( handler != null )
        handler( sender, e );
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public double Frequency {
      get {
        return _Frequency;
      }
      set {
        if( _Frequency == value )
          return;
        _Frequency = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs("Frequency") );
      }
    }
    public DateTime XAxisValue {
      get {
        return _XAxisValue;
      }
      set {
        if( _XAxisValue == value )
          return;
        _XAxisValue = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "XAxisValue" ) );
      }
    }
    public double YAxisValue {
      get {
        return _YAxisValue;
      }
      set {
        if( _YAxisValue == value )
          return;
        _YAxisValue = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "YAxisValue" ) );
      }
    }
  }
}
