﻿#pragma checksum "..\..\..\..\View\Channel\SimpleInspectionView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "42F60FEED687D32A6A36C6C99F9E1DC1299D0029F71A9374C977FF292F7541F0"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using BatteryDashBoard.View.Channel;
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


namespace BatteryDashBoard.View.Channel {
    
    
    /// <summary>
    /// SimpleInspectionView
    /// </summary>
    public partial class SimpleInspectionView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\View\Channel\SimpleInspectionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BatteryDashBoard.View.Channel.SimpleInspectionView uc;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\View\Channel\SimpleInspectionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup PopupPause;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\View\Channel\SimpleInspectionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup PopupIsolate;
        
        #line default
        #line hidden
        
        
        #line 208 "..\..\..\..\View\Channel\SimpleInspectionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LV1;
        
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
            System.Uri resourceLocater = new System.Uri("/BatteryDashBoard;component/view/channel/simpleinspectionview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Channel\SimpleInspectionView.xaml"
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
            this.uc = ((BatteryDashBoard.View.Channel.SimpleInspectionView)(target));
            return;
            case 2:
            this.PopupPause = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 3:
            this.PopupIsolate = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 4:
            this.LV1 = ((System.Windows.Controls.ListView)(target));
            
            #line 208 "..\..\..\..\View\Channel\SimpleInspectionView.xaml"
            this.LV1.SizeChanged += new System.Windows.SizeChangedEventHandler(this.LV1_SizeChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

