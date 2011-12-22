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
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MarketSynth.Services;
using System.ServiceModel.DomainServices.Client;
namespace MarketHarmonics {
  public class MarketStudyViewModel : INotifyPropertyChanged {
    public MarketStudyViewModel() {     
      Initialize();
    }
    StudyModel _StudyModel;
    List<string> _StudyNames;
  

    public StudyModel StudyModel {
      get {
        return _StudyModel;
      }
      set {
        if( _StudyModel == value )
          return;
        _StudyModel = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "StudyModel" ) );
      }
    }
    public List<string> StudyNames {
      get {
        return _StudyNames;
      }
      set {
        if( _StudyNames == value )
          return;
        _StudyNames = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "AvailableStudies" ) );
      }
    }


    public virtual void OnPropertyChanged( object sender, PropertyChangedEventArgs e ) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if( handler != null )
        handler( sender, e );
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void Initialize()
    {
      StudyModel = new StudyModel();
      StudyNames = new List<string> { "Open Price", "Close Price" };
    }
  }
}