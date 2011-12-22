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
using System.Linq;
using System.Collections.Generic;

namespace MarketHarmonics {
  public class SimpleCommand:ICommand {
    public SimpleCommand() {
      bool _MayBeExecuted = false;
    }
    public virtual void OnCanExecuteChanged( object sender, EventArgs e ) {
      EventHandler handler = CanExecuteChanged;
      if( handler != null )
        handler( sender, e );
    }
    public virtual void OnExecuted( object sender, EventArgs e ) {
      EventHandler handler = Executed;
      if( handler != null )
        handler( sender, e );
    }
    public event EventHandler Executed;
    public bool CanExecute( object parameter ) {
      return _MayBeExecuted;
    }
    public event EventHandler CanExecuteChanged;
    public void Execute( object parameter ) {
      OnExecuted( this, EventArgs.Empty );
    }
    bool _MayBeExecuted;
    public bool MayBeExecuted {
      get { return _MayBeExecuted; }
      set 
      {
        if( _MayBeExecuted == value )
          return;
        _MayBeExecuted = value;
        OnCanExecuteChanged( this, EventArgs.Empty );
        
      }
    }
  }    
}

 

