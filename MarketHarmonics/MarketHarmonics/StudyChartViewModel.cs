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
  public class StudyChartViewModel:INotifyPropertyChanged {

    ObservableCollection<StudyModel> _StudyModels;
    SimpleCommand _RunStudiesCommand;
    public SimpleCommand RunStudiesCommand {
      get {
        return _RunStudiesCommand;
      }
      set {
        if( _RunStudiesCommand == value )
          return;
        _RunStudiesCommand = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "RunStudiesCommand" ) );
      }
    }
    //public virtual void OnPloted( object sender, EventArgs<StudyModel> e ) {
    //  EventHandler<EventArgs<StudyModel>> handler = Ploted;
    //  if( handler != null )
    //    handler( sender, e );
    //}
    public virtual void OnPropertyChanged( object sender, PropertyChangedEventArgs e ) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if( handler != null )
        handler( sender, e );
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void Initialize() {
      StudyModels = new ObservableCollection<StudyModel>();
      RunStudiesCommand = new SimpleCommand();
      RunStudiesCommand.MayBeExecuted = true;
    }
    public StudyChartViewModel() {
      Initialize();
    }

    //public event EventHandler<EventArgs<StudyModel>> Ploted;
    public void PlotStudyModel( StudyModel data ) {
      //OnPloted( this, new EventArgs<StudyModel>( data ) );
      StudyModels.Add( data );
    }
    public ObservableCollection<StudyModel> StudyModels {
      get {
        return _StudyModels;
      }
      set {
        if( _StudyModels == value )
          return;
        _StudyModels = value;
        OnPropertyChanged( this, new PropertyChangedEventArgs( "StudyModels" ) );
      }
    }
  }
}
