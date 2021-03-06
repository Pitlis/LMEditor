﻿#pragma checksum "..\..\RecipeEditor.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F613DA2B5D209DC43AFCD935DD7A4F11"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
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


namespace EditItems {
    
    
    /// <summary>
    /// RecipeEditor
    /// </summary>
    public partial class RecipeEditor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\RecipeEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListRecipes;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\RecipeEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox recipName;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\RecipeEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox recipDescr;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\RecipeEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox recipPrice;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\RecipeEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listReagents;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\RecipeEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listResults;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\RecipeEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtO;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\RecipeEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLevel;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\RecipeEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTime;
        
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
            System.Uri resourceLocater = new System.Uri("/EditItems;component/recipeeditor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RecipeEditor.xaml"
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
            this.ListRecipes = ((System.Windows.Controls.ListView)(target));
            
            #line 14 "..\..\RecipeEditor.xaml"
            this.ListRecipes.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListRecipe_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 21 "..\..\RecipeEditor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnCreate);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 22 "..\..\RecipeEditor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSave);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 23 "..\..\RecipeEditor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnRemove);
            
            #line default
            #line hidden
            return;
            case 5:
            this.recipName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.recipDescr = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.recipPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.listReagents = ((System.Windows.Controls.ListView)(target));
            
            #line 31 "..\..\RecipeEditor.xaml"
            this.listReagents.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListReagents_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.listResults = ((System.Windows.Controls.ListView)(target));
            
            #line 39 "..\..\RecipeEditor.xaml"
            this.listResults.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListReagents_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 48 "..\..\RecipeEditor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnAddItem);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 49 "..\..\RecipeEditor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDeleteItem);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 50 "..\..\RecipeEditor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnAddItemResult);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 51 "..\..\RecipeEditor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDeleteItemResult);
            
            #line default
            #line hidden
            return;
            case 14:
            this.txtO = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.txtLevel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.txtTime = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

