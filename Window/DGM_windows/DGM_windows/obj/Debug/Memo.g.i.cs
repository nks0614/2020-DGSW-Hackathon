﻿#pragma checksum "..\..\Memo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A313641DC6E505F0C9AA17AC9161D39291386072F6BEEA1092A11E6527E6BF91"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using DGM_windows;
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


namespace DGM_windows {
    
    
    /// <summary>
    /// Memo
    /// </summary>
    public partial class Memo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\Memo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label id;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Memo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SaveDescription;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Memo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker SaveDate;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Memo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle SaveButton;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Memo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SaveButtonText;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Memo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle DeleteButton;
        
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
            System.Uri resourceLocater = new System.Uri("/DGM_windows;component/memo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Memo.xaml"
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
            
            #line 13 "..\..\Memo.xaml"
            ((DGM_windows.Memo)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Memo_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.id = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.SaveDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.SaveDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.SaveButton = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 35 "..\..\Memo.xaml"
            this.SaveButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.SaveButton_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SaveButtonText = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.DeleteButton = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 39 "..\..\Memo.xaml"
            this.DeleteButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.DeleteButton_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

