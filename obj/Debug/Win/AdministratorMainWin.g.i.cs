﻿#pragma checksum "..\..\..\Win\AdministratorMainWin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5356A6967B3ED40E94A81857953A14CC"
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


namespace Pigger {
    
    
    /// <summary>
    /// AdministratorMainWin
    /// </summary>
    public partial class AdministratorMainWin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Win\AdministratorMainWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox userlist;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Win\AdministratorMainWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox username;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Win\AdministratorMainWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwd;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Win\AdministratorMainWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox changepwd;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Win\AdministratorMainWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox realname;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Win\AdministratorMainWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox job;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Win\AdministratorMainWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox group;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Win\AdministratorMainWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button chang;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Win\AdministratorMainWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button save;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Win\AdministratorMainWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delete;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Win\AdministratorMainWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exit;
        
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
            System.Uri resourceLocater = new System.Uri("/Pigger;component/win/administratormainwin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Win\AdministratorMainWin.xaml"
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
            this.userlist = ((System.Windows.Controls.ListBox)(target));
            
            #line 9 "..\..\..\Win\AdministratorMainWin.xaml"
            this.userlist.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.userlist_Selected);
            
            #line default
            #line hidden
            return;
            case 2:
            this.username = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.passwd = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.changepwd = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.realname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.job = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.group = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.chang = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Win\AdministratorMainWin.xaml"
            this.chang.Click += new System.Windows.RoutedEventHandler(this.chang_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.save = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Win\AdministratorMainWin.xaml"
            this.save.Click += new System.Windows.RoutedEventHandler(this.save_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.delete = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\Win\AdministratorMainWin.xaml"
            this.delete.Click += new System.Windows.RoutedEventHandler(this.delete_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.exit = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Win\AdministratorMainWin.xaml"
            this.exit.Click += new System.Windows.RoutedEventHandler(this.exit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
