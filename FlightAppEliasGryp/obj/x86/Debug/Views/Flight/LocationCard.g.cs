﻿#pragma checksum "C:\Users\Elias\source\repos\FlightAppEliasGryp\FlightAppEliasGryp\Views\Flight\LocationCard.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C356322B8BA3054171D229A011805161"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlightAppEliasGryp.Views.Flight
{
    partial class LocationCard : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_FlightAppEliasGryp_Views_Flight_AirportCard_Location(global::FlightAppEliasGryp.Views.Flight.AirportCard obj, global::FlightAppEliasGryp.Models.Location value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::FlightAppEliasGryp.Models.Location) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::FlightAppEliasGryp.Models.Location), targetNullValue);
                }
                obj.Location = value;
            }
            public static void Set_FlightAppEliasGryp_Views_Flight_WeatherForecastControl_Location(global::FlightAppEliasGryp.Views.Flight.WeatherForecastControl obj, global::FlightAppEliasGryp.Models.Location value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::FlightAppEliasGryp.Models.Location) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::FlightAppEliasGryp.Models.Location), targetNullValue);
                }
                obj.Location = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class LocationCard_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ILocationCard_Bindings
        {
            private global::FlightAppEliasGryp.Views.Flight.LocationCard dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::FlightAppEliasGryp.Views.Flight.AirportCard obj2;
            private global::FlightAppEliasGryp.Views.Flight.WeatherForecastControl obj3;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2LocationDisabled = false;
            private static bool isobj3LocationDisabled = false;

            public LocationCard_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 17 && columnNumber == 44)
                {
                    isobj2LocationDisabled = true;
                }
                else if (lineNumber == 18 && columnNumber == 55)
                {
                    isobj3LocationDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Views\Flight\LocationCard.xaml line 17
                        this.obj2 = (global::FlightAppEliasGryp.Views.Flight.AirportCard)target;
                        break;
                    case 3: // Views\Flight\LocationCard.xaml line 18
                        this.obj3 = (global::FlightAppEliasGryp.Views.Flight.WeatherForecastControl)target;
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

            // ILocationCard_Bindings

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
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::FlightAppEliasGryp.Views.Flight.LocationCard)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::FlightAppEliasGryp.Views.Flight.LocationCard obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Location(obj.Location, phase);
                    }
                }
            }
            private void Update_Location(global::FlightAppEliasGryp.Models.Location obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\Flight\LocationCard.xaml line 17
                    if (!isobj2LocationDisabled)
                    {
                        XamlBindingSetters.Set_FlightAppEliasGryp_Views_Flight_AirportCard_Location(this.obj2, obj, null);
                    }
                    // Views\Flight\LocationCard.xaml line 18
                    if (!isobj3LocationDisabled)
                    {
                        XamlBindingSetters.Set_FlightAppEliasGryp_Views_Flight_WeatherForecastControl_Location(this.obj3, obj, null);
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
            case 1: // Views\Flight\LocationCard.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.UserControl element1 = (global::Windows.UI.Xaml.Controls.UserControl)target;
                    LocationCard_obj1_Bindings bindings = new LocationCard_obj1_Bindings();
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

