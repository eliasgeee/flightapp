﻿#pragma checksum "C:\Users\Elias\source\repos\FlightAppEliasGryp\FlightAppEliasGryp\Views\PassengerItem.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "008E8A261969885BBB0CBD8AC75B2AB4"
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
    partial class PassengerItem : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_FrameworkElement_Tag(global::Windows.UI.Xaml.FrameworkElement obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.Tag = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class PassengerItem_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IPassengerItem_Bindings
        {
            private global::FlightAppEliasGryp.Views.PassengerItem dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.StackPanel obj2;
            private global::Windows.UI.Xaml.Controls.TextBlock obj3;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2TagDisabled = false;
            private static bool isobj3TextDisabled = false;

            private PassengerItem_obj1_BindingsTracking bindingsTracking;

            public PassengerItem_obj1_Bindings()
            {
                this.bindingsTracking = new PassengerItem_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 24 && columnNumber == 26)
                {
                    isobj2TagDisabled = true;
                }
                else if (lineNumber == 25 && columnNumber == 24)
                {
                    isobj3TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Views\PassengerItem.xaml line 23
                        this.obj2 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                        break;
                    case 3: // Views\PassengerItem.xaml line 25
                        this.obj3 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
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

            // IPassengerItem_Bindings

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
                    this.dataRoot = (global::FlightAppEliasGryp.Views.PassengerItem)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            private delegate void InvokeFunctionDelegate(int phase);
            private global::System.Collections.Generic.Dictionary<string, InvokeFunctionDelegate> PendingFunctionBindings = new global::System.Collections.Generic.Dictionary<string, InvokeFunctionDelegate>();

            private void Invoke_Seat_Passenger_M_GetFullName_757602046(int phase)
            {
                global::System.String result = this.dataRoot.Seat.Passenger.GetFullName();
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\PassengerItem.xaml line 25
                    if (!isobj3TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj3, result, null);
                    }
                }
            }

            private void CompleteUpdate(int phase)
            {
                var functions = this.PendingFunctionBindings;
                this.PendingFunctionBindings = new global::System.Collections.Generic.Dictionary<string, InvokeFunctionDelegate>();
                foreach (var function in functions.Values)
                {
                    function.Invoke(phase);
                }
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::FlightAppEliasGryp.Views.PassengerItem obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_Seat(obj.Seat, phase);
                    }
                }
                else
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.UpdateFallback_Seat(phase);
                    }
                }
                this.CompleteUpdate(phase);
            }
            private void Update_Seat(global::FlightAppEliasGryp.Models.Seat obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_Seat(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_Seat_Passenger(obj.Passenger, phase);
                    }
                }
                else
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.UpdateFallback_Seat_Passenger(phase);
                    }
                }
            }
            private void Update_Seat_Passenger(global::FlightAppEliasGryp.Models.Passenger obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_Seat_Passenger(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_Seat_Passenger_M_GetFullName_757602046(phase);
                    }
                }
                else
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.UpdateFallback_Seat_Passenger_M_GetFullName_757602046(phase);
                    }
                }
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\PassengerItem.xaml line 23
                    if (!isobj2TagDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_FrameworkElement_Tag(this.obj2, obj, null);
                    }
                }
            }
            private void Update_Seat_Passenger_M_GetFullName_757602046(int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    if (!isobj3TextDisabled)
                    {
                        this.PendingFunctionBindings["Seat_Passenger_M_GetFullName_757602046"] = new InvokeFunctionDelegate(this.Invoke_Seat_Passenger_M_GetFullName_757602046); 
                    }
                }
            }

            private void UpdateFallback_Seat(int phase)
            {
                this.UpdateFallback_Seat_Passenger(phase);
            }

            private void UpdateFallback_Seat_Passenger(int phase)
            {
                this.UpdateFallback_Seat_Passenger_M_GetFullName_757602046(phase);
            }

            private void UpdateFallback_Seat_Passenger_M_GetFullName_757602046(int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\PassengerItem.xaml line 25
                    if (!isobj3TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj3, "Empty seat", null);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class PassengerItem_obj1_BindingsTracking
            {
                private global::System.WeakReference<PassengerItem_obj1_Bindings> weakRefToBindingObj; 

                public PassengerItem_obj1_BindingsTracking(PassengerItem_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<PassengerItem_obj1_Bindings>(obj);
                }

                public PassengerItem_obj1_Bindings TryGetBindingObject()
                {
                    PassengerItem_obj1_Bindings bindingObject = null;
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
                    UpdateChildListeners_Seat(null);
                    UpdateChildListeners_Seat_Passenger(null);
                }

                public void PropertyChanged_Seat(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    PassengerItem_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::FlightAppEliasGryp.Models.Seat obj = sender as global::FlightAppEliasGryp.Models.Seat;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_Seat_Passenger(obj.Passenger, DATA_CHANGED);
                            }
                            else
                            {
                                bindings.UpdateFallback_Seat_Passenger(DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "Passenger":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_Seat_Passenger(obj.Passenger, DATA_CHANGED);
                                    }
                                    else
                                    {
                                        bindings.UpdateFallback_Seat_Passenger(DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                        bindings.CompleteUpdate(DATA_CHANGED);
                    }
                }
                private global::FlightAppEliasGryp.Models.Seat cache_Seat = null;
                public void UpdateChildListeners_Seat(global::FlightAppEliasGryp.Models.Seat obj)
                {
                    if (obj != cache_Seat)
                    {
                        if (cache_Seat != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_Seat).PropertyChanged -= PropertyChanged_Seat;
                            cache_Seat = null;
                        }
                        if (obj != null)
                        {
                            cache_Seat = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_Seat;
                        }
                    }
                }
                public void PropertyChanged_Seat_Passenger(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    PassengerItem_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::FlightAppEliasGryp.Models.Passenger obj = sender as global::FlightAppEliasGryp.Models.Passenger;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_Seat_Passenger_M_GetFullName_757602046(DATA_CHANGED);
                            }
                            else
                            {
                                bindings.UpdateFallback_Seat_Passenger_M_GetFullName_757602046(DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "GetFullName":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_Seat_Passenger_M_GetFullName_757602046(DATA_CHANGED);
                                    }
                                    else
                                    {
                                        bindings.UpdateFallback_Seat_Passenger_M_GetFullName_757602046(DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                        bindings.CompleteUpdate(DATA_CHANGED);
                    }
                }
                private global::FlightAppEliasGryp.Models.Passenger cache_Seat_Passenger = null;
                public void UpdateChildListeners_Seat_Passenger(global::FlightAppEliasGryp.Models.Passenger obj)
                {
                    if (obj != cache_Seat_Passenger)
                    {
                        if (cache_Seat_Passenger != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_Seat_Passenger).PropertyChanged -= PropertyChanged_Seat_Passenger;
                            cache_Seat_Passenger = null;
                        }
                        if (obj != null)
                        {
                            cache_Seat_Passenger = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_Seat_Passenger;
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
            case 2: // Views\PassengerItem.xaml line 23
                {
                    this.PassengerNameContainer = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3: // Views\PassengerItem.xaml line 25
                {
                    this.Passenger_Text = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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
            case 1: // Views\PassengerItem.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.UserControl element1 = (global::Windows.UI.Xaml.Controls.UserControl)target;
                    PassengerItem_obj1_Bindings bindings = new PassengerItem_obj1_Bindings();
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

