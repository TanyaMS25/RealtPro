﻿#pragma checksum "..\..\..\UI\PagePrintApartment.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D82E4595BD0A54E55CF5BBE82E4B98EDA1D5B6FFCDCCA51B22AF415B1280BF67"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using RealtProWpfApp.UI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace RealtProWpfApp.UI {
    
    
    /// <summary>
    /// PagePrintApartment
    /// </summary>
    public partial class PagePrintApartment : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\UI\PagePrintApartment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboType;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\UI\PagePrintApartment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboRealtor;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\UI\PagePrintApartment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DocumentViewer documentViewer;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\UI\PagePrintApartment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgApart;
        
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
            System.Uri resourceLocater = new System.Uri("/RealtProWpfApp;component/ui/pageprintapartment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\PagePrintApartment.xaml"
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
            this.comboType = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\..\UI\PagePrintApartment.xaml"
            this.comboType.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboType_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.comboRealtor = ((System.Windows.Controls.ComboBox)(target));
            
            #line 26 "..\..\..\UI\PagePrintApartment.xaml"
            this.comboRealtor.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboRealtor_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.documentViewer = ((System.Windows.Controls.DocumentViewer)(target));
            return;
            case 4:
            this.dgApart = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

