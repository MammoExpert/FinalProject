﻿#pragma checksum "..\..\UcManualInput.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "043ECCA811B6FE24BA9B3A6BCAF89623"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MammoExpert.PatientServices.UI.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MammoExpert.PatientServices.UI.Controls {
    
    
    /// <summary>
    /// UcManualInput
    /// </summary>
    public partial class UcManualInput : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\UcManualInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtLastName;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\UcManualInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtFirstName;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\UcManualInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtMiddleName;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\UcManualInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePickerBirthday;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\UcManualInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton MaleSelection;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\UcManualInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton FemaleSelection;
        
        #line default
        #line hidden
        
        
        #line 301 "..\..\UcManualInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtTelephone;
        
        #line default
        #line hidden
        
        
        #line 319 "..\..\UcManualInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnClearAll;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MammoExpert.PatientServices.UI.Controls;component/ucmanualinput.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UcManualInput.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TxtLastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TxtFirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TxtMiddleName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.DatePickerBirthday = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.MaleSelection = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.FemaleSelection = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.TxtTelephone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.BtnClearAll = ((System.Windows.Controls.Button)(target));
            
            #line 322 "..\..\UcManualInput.xaml"
            this.BtnClearAll.Click += new System.Windows.RoutedEventHandler(this.BtnClearAll_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

