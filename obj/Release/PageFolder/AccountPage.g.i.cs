﻿#pragma checksum "..\..\..\PageFolder\AccountPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BE4FA0FCE5B6E0747265107253E6E80C"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18010
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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


namespace Pigger.PageFolder {
    
    
    /// <summary>
    /// AccountPage
    /// </summary>
    public partial class AccountPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\PageFolder\AccountPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView accountlist;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\PageFolder\AccountPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox inoutType;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\PageFolder\AccountPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox accType;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\PageFolder\AccountPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox year;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\PageFolder\AccountPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox month;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\PageFolder\AccountPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox day;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\PageFolder\AccountPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button filter;
        
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
            System.Uri resourceLocater = new System.Uri("/Pigger;component/pagefolder/accountpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PageFolder\AccountPage.xaml"
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
            this.accountlist = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.inoutType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.accType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.year = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.month = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.day = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.filter = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\PageFolder\AccountPage.xaml"
            this.filter.Click += new System.Windows.RoutedEventHandler(this.filter_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
