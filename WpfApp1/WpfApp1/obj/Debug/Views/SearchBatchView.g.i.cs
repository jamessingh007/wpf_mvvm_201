﻿#pragma checksum "..\..\..\Views\SearchBatchView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42D082F13D6F46011202371F230FFB802D304C3E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApp1.Views;


namespace WpfApp1.Views {
    
    
    /// <summary>
    /// SearchBatchView
    /// </summary>
    public partial class SearchBatchView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\Views\SearchBatchView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblsearchKeyword;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Views\SearchBatchView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtsearchkeyword;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Views\SearchBatchView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Views\SearchBatchView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblBatchResults;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Views\SearchBatchView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView BatchListView;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Views\SearchBatchView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridView grdBatch;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Views\SearchBatchView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\SearchBatchView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\SearchBatchView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblParticpantResults;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\SearchBatchView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ParticipantsListView;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views\SearchBatchView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridView grdParticpant;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Views\SearchBatchView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddParticipant;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/views/searchbatchview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\SearchBatchView.xaml"
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
            this.lblsearchKeyword = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.txtsearchkeyword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.lblBatchResults = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.BatchListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.grdBatch = ((System.Windows.Controls.GridView)(target));
            return;
            case 7:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.lblParticpantResults = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.ParticipantsListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 11:
            this.grdParticpant = ((System.Windows.Controls.GridView)(target));
            return;
            case 12:
            this.btnAddParticipant = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

