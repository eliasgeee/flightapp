﻿#pragma checksum "C:\Users\Elias\source\repos\FlightAppEliasGryp\FlightAppEliasGryp\Views\ShellPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E1EFF7F2445B5740EE73B596B8828631"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlightAppEliasGryp.Views
{
    partial class ShellPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_Xaml_Interactions_Core_InvokeCommandAction_Command(global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_NavigationView_IsBackEnabled(global::Microsoft.UI.Xaml.Controls.NavigationView obj, global::System.Boolean value)
            {
                obj.IsBackEnabled = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_NavigationView_SelectedItem(global::Microsoft.UI.Xaml.Controls.NavigationView obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.SelectedItem = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_NavigationView_IsPaneVisible(global::Microsoft.UI.Xaml.Controls.NavigationView obj, global::System.Boolean value)
            {
                obj.IsPaneVisible = value;
            }
            public static void Set_Windows_UI_Xaml_UIElement_Visibility(global::Windows.UI.Xaml.UIElement obj, global::Windows.UI.Xaml.Visibility value)
            {
                obj.Visibility = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(global::Windows.UI.Xaml.Controls.Primitives.ButtonBase obj, global::System.Windows.Input.ICommand value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Windows.Input.ICommand) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Windows.Input.ICommand), targetNullValue);
                }
                obj.Command = value;
            }
            public static void Set_FlightAppEliasGryp_Behaviors_NavigationViewHeaderBehavior_DefaultHeader(global::FlightAppEliasGryp.Behaviors.NavigationViewHeaderBehavior obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.DefaultHeader = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class ShellPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IShellPage_Bindings
        {
            private global::FlightAppEliasGryp.Views.ShellPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction obj2;
            private global::Microsoft.UI.Xaml.Controls.NavigationView obj3;
            private global::Microsoft.UI.Xaml.Controls.NavigationViewItem obj4;
            private global::Microsoft.UI.Xaml.Controls.NavigationViewItem obj5;
            private global::Microsoft.UI.Xaml.Controls.NavigationViewItem obj6;
            private global::Microsoft.UI.Xaml.Controls.NavigationViewItem obj7;
            private global::Microsoft.UI.Xaml.Controls.NavigationViewItem obj8;
            private global::Microsoft.UI.Xaml.Controls.NavigationViewItem obj9;
            private global::Microsoft.UI.Xaml.Controls.NavigationViewItem obj10;
            private global::Windows.UI.Xaml.Controls.Button obj11;
            private global::FlightAppEliasGryp.Behaviors.NavigationViewHeaderBehavior obj12;
            private global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction obj13;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2CommandDisabled = false;
            private static bool isobj3IsBackEnabledDisabled = false;
            private static bool isobj3SelectedItemDisabled = false;
            private static bool isobj3IsPaneVisibleDisabled = false;
            private static bool isobj4VisibilityDisabled = false;
            private static bool isobj5VisibilityDisabled = false;
            private static bool isobj6VisibilityDisabled = false;
            private static bool isobj7VisibilityDisabled = false;
            private static bool isobj8VisibilityDisabled = false;
            private static bool isobj9VisibilityDisabled = false;
            private static bool isobj10VisibilityDisabled = false;
            private static bool isobj11CommandDisabled = false;
            private static bool isobj12DefaultHeaderDisabled = false;
            private static bool isobj13CommandDisabled = false;

            private ShellPage_obj1_BindingsTracking bindingsTracking;

            public ShellPage_obj1_Bindings()
            {
                this.bindingsTracking = new ShellPage_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 16 && columnNumber == 37)
                {
                    isobj2CommandDisabled = true;
                }
                else if (lineNumber == 24 && columnNumber == 9)
                {
                    isobj3IsBackEnabledDisabled = true;
                }
                else if (lineNumber == 25 && columnNumber == 9)
                {
                    isobj3SelectedItemDisabled = true;
                }
                else if (lineNumber == 26 && columnNumber == 9)
                {
                    isobj3IsPaneVisibleDisabled = true;
                }
                else if (lineNumber == 37 && columnNumber == 155)
                {
                    isobj4VisibilityDisabled = true;
                }
                else if (lineNumber == 38 && columnNumber == 165)
                {
                    isobj5VisibilityDisabled = true;
                }
                else if (lineNumber == 39 && columnNumber == 161)
                {
                    isobj6VisibilityDisabled = true;
                }
                else if (lineNumber == 40 && columnNumber == 198)
                {
                    isobj7VisibilityDisabled = true;
                }
                else if (lineNumber == 41 && columnNumber == 173)
                {
                    isobj8VisibilityDisabled = true;
                }
                else if (lineNumber == 42 && columnNumber == 169)
                {
                    isobj9VisibilityDisabled = true;
                }
                else if (lineNumber == 43 && columnNumber == 183)
                {
                    isobj10VisibilityDisabled = true;
                }
                else if (lineNumber == 44 && columnNumber == 42)
                {
                    isobj11CommandDisabled = true;
                }
                else if (lineNumber == 48 && columnNumber == 17)
                {
                    isobj12DefaultHeaderDisabled = true;
                }
                else if (lineNumber == 61 && columnNumber == 45)
                {
                    isobj13CommandDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Views\ShellPage.xaml line 16
                        this.obj2 = (global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction)target;
                        break;
                    case 3: // Views\ShellPage.xaml line 21
                        this.obj3 = (global::Microsoft.UI.Xaml.Controls.NavigationView)target;
                        break;
                    case 4: // Views\ShellPage.xaml line 37
                        this.obj4 = (global::Microsoft.UI.Xaml.Controls.NavigationViewItem)target;
                        break;
                    case 5: // Views\ShellPage.xaml line 38
                        this.obj5 = (global::Microsoft.UI.Xaml.Controls.NavigationViewItem)target;
                        break;
                    case 6: // Views\ShellPage.xaml line 39
                        this.obj6 = (global::Microsoft.UI.Xaml.Controls.NavigationViewItem)target;
                        break;
                    case 7: // Views\ShellPage.xaml line 40
                        this.obj7 = (global::Microsoft.UI.Xaml.Controls.NavigationViewItem)target;
                        break;
                    case 8: // Views\ShellPage.xaml line 41
                        this.obj8 = (global::Microsoft.UI.Xaml.Controls.NavigationViewItem)target;
                        break;
                    case 9: // Views\ShellPage.xaml line 42
                        this.obj9 = (global::Microsoft.UI.Xaml.Controls.NavigationViewItem)target;
                        break;
                    case 10: // Views\ShellPage.xaml line 43
                        this.obj10 = (global::Microsoft.UI.Xaml.Controls.NavigationViewItem)target;
                        break;
                    case 11: // Views\ShellPage.xaml line 44
                        this.obj11 = (global::Windows.UI.Xaml.Controls.Button)target;
                        break;
                    case 12: // Views\ShellPage.xaml line 47
                        this.obj12 = (global::FlightAppEliasGryp.Behaviors.NavigationViewHeaderBehavior)target;
                        break;
                    case 13: // Views\ShellPage.xaml line 61
                        this.obj13 = (global::Microsoft.Xaml.Interactions.Core.InvokeCommandAction)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IShellPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::FlightAppEliasGryp.Views.ShellPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::FlightAppEliasGryp.Views.ShellPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
            }
            private void Update_ViewModel(global::FlightAppEliasGryp.ViewModels.ShellViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_LoadedCommand(obj.LoadedCommand, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_IsBackEnabled(obj.IsBackEnabled, phase);
                        this.Update_ViewModel_Selected(obj.Selected, phase);
                        this.Update_ViewModel_IsNavigationVisible(obj.IsNavigationVisible, phase);
                        this.Update_ViewModel_CurrentUser(obj.CurrentUser, phase);
                    }
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_Logout(obj.Logout, phase);
                        this.Update_ViewModel_ItemInvokedCommand(obj.ItemInvokedCommand, phase);
                    }
                }
            }
            private void Update_ViewModel_LoadedCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\ShellPage.xaml line 16
                    if (!isobj2CommandDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_Xaml_Interactions_Core_InvokeCommandAction_Command(this.obj2, obj, null);
                    }
                }
            }
            private void Update_ViewModel_IsBackEnabled(global::System.Boolean obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\ShellPage.xaml line 21
                    if (!isobj3IsBackEnabledDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_NavigationView_IsBackEnabled(this.obj3, obj);
                    }
                }
            }
            private void Update_ViewModel_Selected(global::Microsoft.UI.Xaml.Controls.NavigationViewItem obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel_Selected(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_Selected_Content(obj.Content, phase);
                    }
                }
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\ShellPage.xaml line 21
                    if (!isobj3SelectedItemDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_NavigationView_SelectedItem(this.obj3, obj, null);
                    }
                }
            }
            private void Update_ViewModel_IsNavigationVisible(global::System.Boolean obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\ShellPage.xaml line 21
                    if (!isobj3IsPaneVisibleDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_NavigationView_IsPaneVisible(this.obj3, obj);
                    }
                }
            }
            private void Update_ViewModel_CurrentUser(global::FlightAppEliasGryp.Models.CurrentUser obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel_CurrentUser(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_CurrentUser_IsPassenger(obj.IsPassenger, phase);
                        this.Update_ViewModel_CurrentUser_IsCrewMember(obj.IsCrewMember, phase);
                    }
                }
            }
            private void Update_ViewModel_CurrentUser_IsPassenger(global::System.Boolean obj, int phase)
            {
                if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                {
                    this.Update_ViewModel_CurrentUser_IsPassenger_Cast_IsPassenger_To_Visibility(obj ? global::Windows.UI.Xaml.Visibility.Visible : global::Windows.UI.Xaml.Visibility.Collapsed, phase);
                }
            }
            private void Update_ViewModel_CurrentUser_IsPassenger_Cast_IsPassenger_To_Visibility(global::Windows.UI.Xaml.Visibility obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\ShellPage.xaml line 37
                    if (!isobj4VisibilityDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj4, obj);
                    }
                    // Views\ShellPage.xaml line 39
                    if (!isobj6VisibilityDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj6, obj);
                    }
                    // Views\ShellPage.xaml line 42
                    if (!isobj9VisibilityDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj9, obj);
                    }
                    // Views\ShellPage.xaml line 43
                    if (!isobj10VisibilityDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj10, obj);
                    }
                }
            }
            private void Update_ViewModel_CurrentUser_IsCrewMember(global::System.Boolean obj, int phase)
            {
                if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                {
                    this.Update_ViewModel_CurrentUser_IsCrewMember_Cast_IsCrewMember_To_Visibility(obj ? global::Windows.UI.Xaml.Visibility.Visible : global::Windows.UI.Xaml.Visibility.Collapsed, phase);
                }
            }
            private void Update_ViewModel_CurrentUser_IsCrewMember_Cast_IsCrewMember_To_Visibility(global::Windows.UI.Xaml.Visibility obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\ShellPage.xaml line 38
                    if (!isobj5VisibilityDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj5, obj);
                    }
                    // Views\ShellPage.xaml line 40
                    if (!isobj7VisibilityDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj7, obj);
                    }
                    // Views\ShellPage.xaml line 41
                    if (!isobj8VisibilityDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_UIElement_Visibility(this.obj8, obj);
                    }
                }
            }
            private void Update_ViewModel_Logout(global::System.Windows.Input.ICommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\ShellPage.xaml line 44
                    if (!isobj11CommandDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_ButtonBase_Command(this.obj11, obj, null);
                    }
                }
            }
            private void Update_ViewModel_Selected_Content(global::System.Object obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\ShellPage.xaml line 47
                    if (!isobj12DefaultHeaderDisabled)
                    {
                        XamlBindingSetters.Set_FlightAppEliasGryp_Behaviors_NavigationViewHeaderBehavior_DefaultHeader(this.obj12, obj, null);
                    }
                }
            }
            private void Update_ViewModel_ItemInvokedCommand(global::System.Windows.Input.ICommand obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\ShellPage.xaml line 61
                    if (!isobj13CommandDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_Xaml_Interactions_Core_InvokeCommandAction_Command(this.obj13, obj, null);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class ShellPage_obj1_BindingsTracking
            {
                private global::System.WeakReference<ShellPage_obj1_Bindings> weakRefToBindingObj; 

                public ShellPage_obj1_BindingsTracking(ShellPage_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<ShellPage_obj1_Bindings>(obj);
                }

                public ShellPage_obj1_Bindings TryGetBindingObject()
                {
                    ShellPage_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ViewModel(null);
                    UpdateChildListeners_ViewModel_Selected(null);
                    UpdateChildListeners_ViewModel_CurrentUser(null);
                }

                public void PropertyChanged_ViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ShellPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::FlightAppEliasGryp.ViewModels.ShellViewModel obj = sender as global::FlightAppEliasGryp.ViewModels.ShellViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_ViewModel_IsBackEnabled(obj.IsBackEnabled, DATA_CHANGED);
                                bindings.Update_ViewModel_Selected(obj.Selected, DATA_CHANGED);
                                bindings.Update_ViewModel_IsNavigationVisible(obj.IsNavigationVisible, DATA_CHANGED);
                                bindings.Update_ViewModel_CurrentUser(obj.CurrentUser, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "IsBackEnabled":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_IsBackEnabled(obj.IsBackEnabled, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Selected":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_Selected(obj.Selected, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "IsNavigationVisible":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_IsNavigationVisible(obj.IsNavigationVisible, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "CurrentUser":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_CurrentUser(obj.CurrentUser, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::FlightAppEliasGryp.ViewModels.ShellViewModel cache_ViewModel = null;
                public void UpdateChildListeners_ViewModel(global::FlightAppEliasGryp.ViewModels.ShellViewModel obj)
                {
                    if (obj != cache_ViewModel)
                    {
                        if (cache_ViewModel != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ViewModel).PropertyChanged -= PropertyChanged_ViewModel;
                            cache_ViewModel = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ViewModel;
                        }
                    }
                }
                public void DependencyPropertyChanged_ViewModel_Selected_Content(global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop)
                {
                    ShellPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::Microsoft.UI.Xaml.Controls.NavigationViewItem obj = sender as global::Microsoft.UI.Xaml.Controls.NavigationViewItem;
                        if (obj != null)
                        {
                            bindings.Update_ViewModel_Selected_Content(obj.Content, DATA_CHANGED);
                        }
                    }
                }
                private global::Microsoft.UI.Xaml.Controls.NavigationViewItem cache_ViewModel_Selected = null;
                private long tokenDPC_ViewModel_Selected_Content = 0;
                public void UpdateChildListeners_ViewModel_Selected(global::Microsoft.UI.Xaml.Controls.NavigationViewItem obj)
                {
                    if (obj != cache_ViewModel_Selected)
                    {
                        if (cache_ViewModel_Selected != null)
                        {
                            cache_ViewModel_Selected.UnregisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.ContentControl.ContentProperty, tokenDPC_ViewModel_Selected_Content);
                            cache_ViewModel_Selected = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel_Selected = obj;
                            tokenDPC_ViewModel_Selected_Content = obj.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.ContentControl.ContentProperty, DependencyPropertyChanged_ViewModel_Selected_Content);
                        }
                    }
                }
                public void PropertyChanged_ViewModel_CurrentUser(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    ShellPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::FlightAppEliasGryp.Models.CurrentUser obj = sender as global::FlightAppEliasGryp.Models.CurrentUser;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_ViewModel_CurrentUser_IsPassenger(obj.IsPassenger, DATA_CHANGED);
                                bindings.Update_ViewModel_CurrentUser_IsCrewMember(obj.IsCrewMember, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "IsPassenger":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_CurrentUser_IsPassenger(obj.IsPassenger, DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "IsCrewMember":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_CurrentUser_IsCrewMember(obj.IsCrewMember, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::FlightAppEliasGryp.Models.CurrentUser cache_ViewModel_CurrentUser = null;
                public void UpdateChildListeners_ViewModel_CurrentUser(global::FlightAppEliasGryp.Models.CurrentUser obj)
                {
                    if (obj != cache_ViewModel_CurrentUser)
                    {
                        if (cache_ViewModel_CurrentUser != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ViewModel_CurrentUser).PropertyChanged -= PropertyChanged_ViewModel_CurrentUser;
                            cache_ViewModel_CurrentUser = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel_CurrentUser = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ViewModel_CurrentUser;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 3: // Views\ShellPage.xaml line 21
                {
                    this.navigationView = (global::Microsoft.UI.Xaml.Controls.NavigationView)(target);
                }
                break;
            case 7: // Views\ShellPage.xaml line 40
                {
                    this.OrderManagement = (global::Microsoft.UI.Xaml.Controls.NavigationViewItem)(target);
                }
                break;
            case 15: // Views\ShellPage.xaml line 65
                {
                    this.shellFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Views\ShellPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    ShellPage_obj1_Bindings bindings = new ShellPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

