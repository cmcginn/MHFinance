﻿#pragma checksum "C:\Projects\Prototypes\MarketHarmonics\MarketHarmonics\AnalysisSelectionControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0319EDDB490287B28DB3A1CDB5260722"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MarketHarmonics;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace MarketHarmonics {
    
    
    public partial class AnalysisSelectionControl : System.Windows.Controls.UserControl {
        
        internal MarketHarmonics.AnalysisSelectionControlViewModel ViewModel;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock LabelInstrument;
        
        internal System.Windows.Controls.TextBox Instrument;
        
        internal System.Windows.Controls.TextBlock LabelIndicator;
        
        internal System.Windows.Controls.ComboBox Indicator;
        
        internal System.Windows.Controls.Button ButtonApplyIndicator;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/MarketHarmonics;component/AnalysisSelectionControl.xaml", System.UriKind.Relative));
            this.ViewModel = ((MarketHarmonics.AnalysisSelectionControlViewModel)(this.FindName("ViewModel")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.LabelInstrument = ((System.Windows.Controls.TextBlock)(this.FindName("LabelInstrument")));
            this.Instrument = ((System.Windows.Controls.TextBox)(this.FindName("Instrument")));
            this.LabelIndicator = ((System.Windows.Controls.TextBlock)(this.FindName("LabelIndicator")));
            this.Indicator = ((System.Windows.Controls.ComboBox)(this.FindName("Indicator")));
            this.ButtonApplyIndicator = ((System.Windows.Controls.Button)(this.FindName("ButtonApplyIndicator")));
        }
    }
}

