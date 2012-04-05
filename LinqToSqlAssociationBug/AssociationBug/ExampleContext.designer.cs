﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AssociationBug
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="AMSConsolidated")]
	public partial class ExampleContextDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertViews(Views instance);
    partial void UpdateViews(Views instance);
    partial void DeleteViews(Views instance);
    partial void InsertElements(Elements instance);
    partial void UpdateElements(Elements instance);
    partial void DeleteElements(Elements instance);
    #endregion
		
		public ExampleContextDataContext() : 
				base(global::AssociationBug.Properties.Settings.Default.AMSConsolidatedConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ExampleContextDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExampleContextDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExampleContextDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExampleContextDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Views> Views
		{
			get
			{
				return this.GetTable<Views>();
			}
		}
		
		public System.Data.Linq.Table<Elements> Elements
		{
			get
			{
				return this.GetTable<Elements>();
			}
		}
	}
	
	[Table(Name="dbo.TargetView")]
	public partial class Views : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ViewID;
		
		private int _SomeTypeID;
		
		private System.Guid _SomeValueID;
		
		private EntitySet<Elements> _Elements;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnViewIDChanging(int value);
    partial void OnViewIDChanged();
    partial void OnSomeTypeIDChanging(int value);
    partial void OnSomeTypeIDChanged();
    partial void OnSomeValueIDChanging(System.Guid value);
    partial void OnSomeValueIDChanged();
    #endregion
		
		public Views()
		{
			this._Elements = new EntitySet<Elements>(new Action<Elements>(this.attach_Elements), new Action<Elements>(this.detach_Elements));
			OnCreated();
		}
		
		[Column(Name="TargetViewID", Storage="_ViewID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ViewID
		{
			get
			{
				return this._ViewID;
			}
			set
			{
				if ((this._ViewID != value))
				{
					this.OnViewIDChanging(value);
					this.SendPropertyChanging();
					this._ViewID = value;
					this.SendPropertyChanged("ViewID");
					this.OnViewIDChanged();
				}
			}
		}
		
		[Column(Name="Target_Type_ID", Storage="_SomeTypeID", DbType="Int NOT NULL")]
		public int SomeTypeID
		{
			get
			{
				return this._SomeTypeID;
			}
			set
			{
				if ((this._SomeTypeID != value))
				{
					this.OnSomeTypeIDChanging(value);
					this.SendPropertyChanging();
					this._SomeTypeID = value;
					this.SendPropertyChanged("SomeTypeID");
					this.OnSomeTypeIDChanged();
				}
			}
		}
		
		[Column(Name="Target_GUID", Storage="_SomeValueID", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid SomeValueID
		{
			get
			{
				return this._SomeValueID;
			}
			set
			{
				if ((this._SomeValueID != value))
				{
					this.OnSomeValueIDChanging(value);
					this.SendPropertyChanging();
					this._SomeValueID = value;
					this.SendPropertyChanged("SomeValueID");
					this.OnSomeValueIDChanged();
				}
			}
		}
		
		[Association(Name="Views_Elements", Storage="_Elements", ThisKey="ViewID", OtherKey="ViewID")]
		public EntitySet<Elements> Elements
		{
			get
			{
				return this._Elements;
			}
			set
			{
				this._Elements.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Elements(Elements entity)
		{
			this.SendPropertyChanging();
			entity.Views = this;
		}
		
		private void detach_Elements(Elements entity)
		{
			this.SendPropertyChanging();
			entity.Views = null;
		}
	}
	
	[Table(Name="dbo.Note")]
	public partial class Elements : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ElementID;
		
		private int _ViewID;
		
		private int _SomeValue;
		
		private bool _SomeOtherValue;
		
		private EntityRef<Views> _Views;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnElementIDChanging(int value);
    partial void OnElementIDChanged();
    partial void OnViewIDChanging(int value);
    partial void OnViewIDChanged();
    partial void OnSomeValueChanging(int value);
    partial void OnSomeValueChanged();
    partial void OnSomeOtherValueChanging(bool value);
    partial void OnSomeOtherValueChanged();
    #endregion
		
		public Elements()
		{
			this._Views = default(EntityRef<Views>);
			OnCreated();
		}
		
		[Column(Name="NoteID", Storage="_ElementID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ElementID
		{
			get
			{
				return this._ElementID;
			}
			set
			{
				if ((this._ElementID != value))
				{
					this.OnElementIDChanging(value);
					this.SendPropertyChanging();
					this._ElementID = value;
					this.SendPropertyChanged("ElementID");
					this.OnElementIDChanged();
				}
			}
		}
		
		[Column(Name="TargetViewID", Storage="_ViewID", DbType="Int NOT NULL")]
		public int ViewID
		{
			get
			{
				return this._ViewID;
			}
			set
			{
				if ((this._ViewID != value))
				{
					this.OnViewIDChanging(value);
					this.SendPropertyChanging();
					this._ViewID = value;
					this.SendPropertyChanged("ViewID");
					this.OnViewIDChanged();
				}
			}
		}
		
		[Column(Name="NotePriority", Storage="_SomeValue", DbType="Int NOT NULL")]
		public int SomeValue
		{
			get
			{
				return this._SomeValue;
			}
			set
			{
				if ((this._SomeValue != value))
				{
					this.OnSomeValueChanging(value);
					this.SendPropertyChanging();
					this._SomeValue = value;
					this.SendPropertyChanged("SomeValue");
					this.OnSomeValueChanged();
				}
			}
		}
		
		[Column(Name="NoteActive", Storage="_SomeOtherValue", DbType="Bit NOT NULL")]
		public bool SomeOtherValue
		{
			get
			{
				return this._SomeOtherValue;
			}
			set
			{
				if ((this._SomeOtherValue != value))
				{
					this.OnSomeOtherValueChanging(value);
					this.SendPropertyChanging();
					this._SomeOtherValue = value;
					this.SendPropertyChanged("SomeOtherValue");
					this.OnSomeOtherValueChanged();
				}
			}
		}
		
		[Association(Name="Views_Elements", Storage="_Views", ThisKey="ViewID", OtherKey="ViewID", IsForeignKey=true)]
		public Views Views
		{
			get
			{
				return this._Views.Entity;
			}
			set
			{
				Views previousValue = this._Views.Entity;
				if (((previousValue != value) 
							|| (this._Views.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Views.Entity = null;
						previousValue.Elements.Remove(this);
					}
					this._Views.Entity = value;
					if ((value != null))
					{
						value.Elements.Add(this);
						this._ViewID = value.ViewID;
					}
					else
					{
						this._ViewID = default(int);
					}
					this.SendPropertyChanged("Views");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
