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
  public class StudyModel :INotifyPropertyChanged{
    string _Indicator;
    string _StudyName;

    ObservableCollection<PointModel> _PointModels;
    public virtual void OnStudyDataLoaded( object sender, EventArgs e ) {
      EventHandler handler = StudyDataLoaded;
      if( handler != null )
        handler( sender, e );
    }
    public virtual void OnPropertyChanged( object sender, PropertyChangedEventArgs e ) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if( handler != null )
        handler( sender, e );
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public string Indicator {
      get {
        return _Indicator;
      }
      set {
        if( _Indicator == value )
          return;
        _Indicator = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "Indicator" ) );
      }
    }
    public ObservableCollection<PointModel> PointModels {
      get {
        return _PointModels;
      }
      set {
        if( _PointModels == value )
          return;
        _PointModels = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "PointModels" ) );
      }
    }
    public string StudyName {
      get {
        return _StudyName;
      }
      set {
        if( _StudyName == value )
          return;
        _StudyName = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "StudyName" ) );
      }
    }

    #region Data Access
    public event EventHandler StudyDataLoaded;

    protected void OnDataLoaded( LoadOperation<PointData> operation ) {
      PointModels = new ObservableCollection<PointModel>( operation.Entities.Select( x => new PointModel { XAxisValue = x.Date, YAxisValue = x.Point, Frequency=x.Frequency } ) );
      OnStudyDataLoaded( this, EventArgs.Empty );
    }

    public void LoadStudyData() {
      var ctx = new MarketSynthDomainContext();
      var query = ctx.GetPointDataQuery( _Indicator, _StudyName );
      ctx.Load( query, OnDataLoaded, ctx );
    }
    #endregion
  }
}
