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
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using MarketSynth.Services;
using System.ServiceModel.DomainServices.Client;
using System.Collections.ObjectModel;

namespace MarketHarmonics {
  public class MarketStudiesViewModel:INotifyPropertyChanged {

    SimpleCommand _AddStudyCommand;
    public SimpleCommand AddStudyCommand {
      get {
        return _AddStudyCommand;
      }
      set {
        if( _AddStudyCommand == value )
          return;
        _AddStudyCommand = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "AddStudyCommand" ) );
      }
    }

    public MarketStudiesViewModel() {
      Initialize();
    }
    ObservableCollection<MarketStudy> _Studies;

    public virtual void OnPropertyChanged( object sender, PropertyChangedEventArgs e ) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if( handler != null )
        handler( sender, e );
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public ObservableCollection<MarketStudy> Studies {
      get {
        return _Studies;
      }
      set {
        if( _Studies == value )
          return;
        _Studies = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs("Studies") );
      }
    }
    protected virtual void Initialize() {
      Studies = new ObservableCollection<MarketStudy>();
      _AddStudyCommand = new SimpleCommand { MayBeExecuted = true };
    }
  }
}
