﻿#pragma checksum "..\..\DBManage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E67803FE0A74AB4068CAE22C6AF60FFBC08FF58E5233CF66C0D16706A521B459"
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
        
        
        #line 39 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button datab;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button listb;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button usersb;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button processesb;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button scanb;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox sortcb;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sorttb;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox sortcb2;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sorttb2;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button minBT;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\DBManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitBT;
        
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
            
            #line 9 "..\..\DBManage.xaml"
            ((PScnFin.DBManage)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dg = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.datab = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\DBManage.xaml"
            this.datab.Click += new System.Windows.RoutedEventHandler(this.datab_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.listb = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\DBManage.xaml"
            this.listb.Click += new System.Windows.RoutedEventHandler(this.listb_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.usersb = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\DBManage.xaml"
            this.usersb.Click += new System.Windows.RoutedEventHandler(this.usersb_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.processesb = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\DBManage.xaml"
            this.processesb.Click += new System.Windows.RoutedEventHandler(this.processesb_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.scanb = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\DBManage.xaml"
            this.scanb.Click += new System.Windows.RoutedEventHandler(this.scanb_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.sortcb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 52 "..\..\DBManage.xaml"
            this.sortcb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.sortcb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.sorttb = ((System.Windows.Controls.TextBox)(target));
            
            #line 53 "..\..\DBManage.xaml"
            this.sorttb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.sorttb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.sortcb2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.sorttb2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 55 "..\..\DBManage.xaml"
            this.sorttb2.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.sorttb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.minBT = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\DBManage.xaml"
            this.minBT.Click += new System.Windows.RoutedEventHandler(this.minBT_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.exitBT = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\DBManage.xaml"
            this.exitBT.Click += new System.Windows.RoutedEventHandler(this.exitBT_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

