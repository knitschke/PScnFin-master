﻿#pragma checksum "..\..\DBManage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CF46F7D45420D57EBC3483CE083D0D4FC28235613BA89BD6C57494E44FA04056"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using PScnFin;
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


namespace PScnFin {
    
    
    /// <summary>
    /// DBManage
    /// </summary>
    public partial class DBManage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button datab;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button listb;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button usersb;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button processesb;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button scanb;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox sortcb;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sorttb;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox sortcb2;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sorttb2;
        
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
            System.Uri resourceLocater = new System.Uri("/PScnFin;component/dbmanage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DBManage.xaml"
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
            this.dg = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.datab = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\DBManage.xaml"
            this.datab.Click += new System.Windows.RoutedEventHandler(this.datab_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.listb = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\DBManage.xaml"
            this.listb.Click += new System.Windows.RoutedEventHandler(this.listb_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.usersb = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\DBManage.xaml"
            this.usersb.Click += new System.Windows.RoutedEventHandler(this.usersb_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.processesb = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\DBManage.xaml"
            this.processesb.Click += new System.Windows.RoutedEventHandler(this.processesb_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.scanb = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\DBManage.xaml"
            this.scanb.Click += new System.Windows.RoutedEventHandler(this.scanb_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.sortcb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\DBManage.xaml"
            this.sortcb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.sortcb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.sorttb = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\DBManage.xaml"
            this.sorttb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.sorttb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.sortcb2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.sorttb2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\DBManage.xaml"
            this.sorttb2.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.sorttb_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

