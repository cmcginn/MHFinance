

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LightSwitchApplication
{
    #region Entities
    
    /// <summary>
    /// No Modeled Description Available
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "10.0.0.0")]
    public sealed partial class Indicator : global::Microsoft.LightSwitch.Framework.Base.EntityObject<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass>
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new instance of the Indicator entity.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "10.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public Indicator()
            : this(null)
        {
        }
    
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "10.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public Indicator(global::Microsoft.LightSwitch.Framework.EntitySet<global::LightSwitchApplication.Indicator> entitySet)
            : base(entitySet)
        {
            global::LightSwitchApplication.Indicator.DetailsClass.Initialize(this);
        }
    
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Indicator_Created();
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Indicator_AllowSaveWithErrors(ref bool result);
    
        #endregion
    
        #region Private Properties
        
        /// <summary>
        /// Gets the Application object for this application.  The Application object provides access to active screens, methods to open screens and access to the current user.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "10.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::Microsoft.LightSwitch.IApplication<global::LightSwitchApplication.DataWorkspace> Application
        {
            get
            {
                return global::LightSwitchApplication.Application.Current;
            }
        }
        
        /// <summary>
        /// Gets the containing data workspace.  The data workspace provides access to all data sources in the application.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "10.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private global::LightSwitchApplication.DataWorkspace DataWorkspace
        {
            get
            {
                return (global::LightSwitchApplication.DataWorkspace)this.Details.EntitySet.Details.DataService.Details.DataWorkspace;
            }
        }
        
        #endregion
    
        #region Public Properties
    
        /// <summary>
        /// No Modeled Description Available
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "10.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Guid Id
        {
            get
            {
                return global::LightSwitchApplication.Indicator.DetailsClass.GetValue(this, global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties.Id);
            }
            set
            {
                global::LightSwitchApplication.Indicator.DetailsClass.SetValue(this, global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties.Id, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Id_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Id_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Id_Changed();

        /// <summary>
        /// No Modeled Description Available
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "10.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public string Name
        {
            get
            {
                return global::LightSwitchApplication.Indicator.DetailsClass.GetValue(this, global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties.Name);
            }
            set
            {
                global::LightSwitchApplication.Indicator.DetailsClass.SetValue(this, global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties.Name, value);
            }
        }
        
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Name_IsReadOnly(ref bool result);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Name_Validate(global::Microsoft.LightSwitch.EntityValidationResultsBuilder results);
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        partial void Name_Changed();

        #endregion
    
        #region Details Class
    
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "10.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public sealed class DetailsClass : global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<
                global::LightSwitchApplication.Indicator,
                global::LightSwitchApplication.Indicator.DetailsClass,
                global::LightSwitchApplication.Indicator.DetailsClass.IImplementation,
                global::LightSwitchApplication.Indicator.DetailsClass.PropertySet,
                global::Microsoft.LightSwitch.Details.Framework.EntityCommandSet<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass>,
                global::Microsoft.LightSwitch.Details.Framework.EntityMethodSet<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass>>
        {
    
            static DetailsClass()
            {
                var initializeEntry = global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties.Id;
            }
    
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass>.Entry
                __IndicatorEntry = new global::Microsoft.LightSwitch.Details.Framework.Base.EntityDetails<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass>.Entry(
                    global::LightSwitchApplication.Indicator.DetailsClass.__Indicator_CreateNew,
                    global::LightSwitchApplication.Indicator.DetailsClass.__Indicator_Created,
                    global::LightSwitchApplication.Indicator.DetailsClass.__Indicator_AllowSaveWithErrors);
            private static global::LightSwitchApplication.Indicator __Indicator_CreateNew(global::Microsoft.LightSwitch.Framework.EntitySet<global::LightSwitchApplication.Indicator> es)
            {
                return new global::LightSwitchApplication.Indicator(es);
            }
            private static void __Indicator_Created(global::LightSwitchApplication.Indicator e)
            {
                e.Indicator_Created();
            }
            private static bool __Indicator_AllowSaveWithErrors(global::LightSwitchApplication.Indicator e)
            {
                bool result = false;
                e.Indicator_AllowSaveWithErrors(ref result);
                return result;
            }
    
            public DetailsClass() : base()
            {
            }
    
            public new global::Microsoft.LightSwitch.Details.Framework.EntityCommandSet<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass> Commands
            {
                get
                {
                    return base.Commands;
                }
            }
    
            public new global::Microsoft.LightSwitch.Details.Framework.EntityMethodSet<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass> Methods
            {
                get
                {
                    return base.Methods;
                }
            }
    
            public new global::LightSwitchApplication.Indicator.DetailsClass.PropertySet Properties
            {
                get
                {
                    return base.Properties;
                }
            }
    
            [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "10.0.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public sealed class PropertySet : global::Microsoft.LightSwitch.Details.Framework.Base.EntityPropertySet<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass>
            {
    
                public PropertySet() : base()
                {
                }
    
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass, global::System.Guid> Id
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties.Id) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass, global::System.Guid>;
                    }
                }
                
                public global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass, string> Name
                {
                    get
                    {
                        return base.GetItem(global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties.Name) as global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass, string>;
                    }
                }
                
            }
    
            #pragma warning disable 109
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
            public interface IImplementation : global::Microsoft.LightSwitch.Internal.IEntityImplementation
            {
                new global::System.Guid Id { get; set; }
                new string Name { get; set; }
            }
            #pragma warning restore 109
    
            [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "10.0.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal class PropertySetProperties
            {
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass, global::System.Guid>.Entry
                    Id = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass, global::System.Guid>.Entry(
                        "Id",
                        global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties._Id_Stub,
                        global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties._Id_ComputeIsReadOnly,
                        global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties._Id_Validate,
                        global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties._Id_GetImplementationValue,
                        global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties._Id_SetImplementationValue,
                        global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties._Id_OnValueChanged);
                private static void _Id_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.Indicator.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass, global::System.Guid>.Data> c, global::LightSwitchApplication.Indicator.DetailsClass d, object sf)
                {
                    c(d, ref d._Id, sf);
                }
                private static bool _Id_ComputeIsReadOnly(global::LightSwitchApplication.Indicator e)
                {
                    bool result = false;
                    e.Id_IsReadOnly(ref result);
                    return result;
                }
                private static void _Id_Validate(global::LightSwitchApplication.Indicator e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.Id_Validate(r);
                }
                private static global::System.Guid _Id_GetImplementationValue(global::LightSwitchApplication.Indicator.DetailsClass d)
                {
                    return d.ImplementationEntity.Id;
                }
                private static void _Id_SetImplementationValue(global::LightSwitchApplication.Indicator.DetailsClass d, global::System.Guid v)
                {
                    d.ImplementationEntity.Id = v;
                }
                private static void _Id_OnValueChanged(global::LightSwitchApplication.Indicator e)
                {
                    e.Id_Changed();
                }
    
                [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass, string>.Entry
                    Name = new global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass, string>.Entry(
                        "Name",
                        global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties._Name_Stub,
                        global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties._Name_ComputeIsReadOnly,
                        global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties._Name_Validate,
                        global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties._Name_GetImplementationValue,
                        global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties._Name_SetImplementationValue,
                        global::LightSwitchApplication.Indicator.DetailsClass.PropertySetProperties._Name_OnValueChanged);
                private static void _Name_Stub(global::Microsoft.LightSwitch.Details.Framework.Base.DetailsCallback<global::LightSwitchApplication.Indicator.DetailsClass, global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass, string>.Data> c, global::LightSwitchApplication.Indicator.DetailsClass d, object sf)
                {
                    c(d, ref d._Name, sf);
                }
                private static bool _Name_ComputeIsReadOnly(global::LightSwitchApplication.Indicator e)
                {
                    bool result = false;
                    e.Name_IsReadOnly(ref result);
                    return result;
                }
                private static void _Name_Validate(global::LightSwitchApplication.Indicator e, global::Microsoft.LightSwitch.EntityValidationResultsBuilder r)
                {
                    e.Name_Validate(r);
                }
                private static string _Name_GetImplementationValue(global::LightSwitchApplication.Indicator.DetailsClass d)
                {
                    return d.ImplementationEntity.Name;
                }
                private static void _Name_SetImplementationValue(global::LightSwitchApplication.Indicator.DetailsClass d, string v)
                {
                    d.ImplementationEntity.Name = v;
                }
                private static void _Name_OnValueChanged(global::LightSwitchApplication.Indicator e)
                {
                    e.Name_Changed();
                }
    
            }
    
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass, global::System.Guid>.Data _Id;
            
            [global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
            private global::Microsoft.LightSwitch.Details.Framework.EntityStorageProperty<global::LightSwitchApplication.Indicator, global::LightSwitchApplication.Indicator.DetailsClass, string>.Data _Name;
            
        }
    
        #endregion
    }
    
    #endregion
}
