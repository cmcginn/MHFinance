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

namespace MarketHarmonics {
  public class EventArgs<T>:EventArgs {
    T _Value;
    public EventArgs( T arg ) {
      Value = arg;
    }
    public T Value {
      get {
        return _Value;
      }
      set {
        _Value = value;
      }
    }
  }
}
