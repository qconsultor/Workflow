﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkFlow_Seguros_Futuro
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="SF_WF")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SF_WFConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<wf_seguimiento_95> wf_seguimiento_95
		{
			get
			{
				return this.GetTable<wf_seguimiento_95>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.wf_seguimiento_95")]
	public partial class wf_seguimiento_95
	{
		
		private System.Nullable<System.DateTime> _fecha;
		
		private string _correlativo;
		
		private string _cooperativa;
		
		private string _identificacion;
		
		private string _plan_;
		
		private string _tipodepoliza;
		
		private string _asegurado;
		
		private string _observaciones;
		
		private string _cantidadsolicitudes;
		
		private System.Nullable<System.DateTime> _fecha_destino;
		
		private string _indicador;
		
		private string _indicado;
		
		private string _area;
		
		private System.Nullable<System.DateTime> _ingresado;
		
		private string _codigo_tipo_wf;
		
		private string _tipo_wf;
		
		private System.Nullable<System.DateTime> _f_analisis;
		
		private System.Nullable<System.DateTime> _f_docompleta;
		
		private System.Nullable<System.DateTime> _f_emision;
		
		private System.Nullable<System.DateTime> _f_e_firmas;
		
		private System.Nullable<System.DateTime> _f_r_firmas;
		
		private System.Nullable<System.DateTime> _f_ate_cliente;
		
		private System.Nullable<System.DateTime> _f_reci_atc;
		
		private string _c_atc;
		
		private System.Nullable<System.DateTime> _f_ent_cam;
		
		private System.Nullable<System.DateTime> _f_rec_cliente;
		
		private System.Nullable<decimal> _indica_atc;
		
		private System.Data.Linq.Binary _timestamp_column;
		
		private string _adjunto;
		
		private System.Data.Linq.Binary _imagen;
		
		private string _tsolicitud;
		
		private string _sus_atec;
		
		private string _entrego;
		
		private string _poliza;
		
		private string _tipodoc;
		
		private string _solic;
		
		private string _solicAT;
		
		private System.Nullable<decimal> _cod_coop;
		
		private string _p_codigo;
		
		private string _cod_operacion;
		
		private string _cod_area;
		
		private System.Nullable<decimal> _dias_atec;
		
		private string _Estado;
		
		private System.Nullable<decimal> _Puntos;
		
		private string _asignado;
		
		private System.Nullable<System.DateTime> _en_re_at;
		
		private string _ref_en_re_at;
		
		private System.Nullable<System.DateTime> _f_desti;
		
		private string _estado_indicador;
		
		private string _estado_tiempo;
		
		private System.Nullable<System.DateTime> _f_reci_atec;
		
		private string _descrip_at;
		
		private string _obser_corres;
		
		private string _estado_envio;
		
		private System.Nullable<bool> _generado_mod;
		
		private string _dui;
		
		private string _hora_r;
		
		private string _hora_e;
		
		private string _obser_suspen;
		
		private System.Nullable<System.DateTime> _f_doc_f;
		
		private string _c_atec;
		
		private string _ges_atcl;
		
		private System.Nullable<System.DateTime> _f_gest;
		
		private System.Nullable<System.DateTime> _f_doc_c;
		
		private System.Nullable<System.DateTime> _f_recb_at;
		
		private System.Nullable<System.DateTime> _f_n_resol;
		
		private string _observa_atclie;
		
		private System.Nullable<System.DateTime> _fec_firma;
		
		private System.Nullable<System.DateTime> _f_hallaz;
		
		private System.Nullable<System.DateTime> _f_resolusion;
		
		private System.Nullable<System.DateTime> _f_auditado;
		
		private System.Nullable<System.DateTime> _fec_entr_aten_cli_atec;
		
		private string _requisito;
		
		private string _requisito_cod;
		
		private string _causa;
		
		private string _causa_cod;
		
		private string _planes;
		
		private string _planes_cod;
		
		private string _nplaca;
		
		private System.Nullable<bool> _che_envio;
		
		private System.Nullable<bool> _che_recibido;
		
		public wf_seguimiento_95()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecha", DbType="DateTime", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> fecha
		{
			get
			{
				return this._fecha;
			}
			set
			{
				if ((this._fecha != value))
				{
					this._fecha = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_correlativo", DbType="NVarChar(50)", UpdateCheck=UpdateCheck.Never)]
		public string correlativo
		{
			get
			{
				return this._correlativo;
			}
			set
			{
				if ((this._correlativo != value))
				{
					this._correlativo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cooperativa", DbType="NVarChar(100)", UpdateCheck=UpdateCheck.Never)]
		public string cooperativa
		{
			get
			{
				return this._cooperativa;
			}
			set
			{
				if ((this._cooperativa != value))
				{
					this._cooperativa = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_identificacion", DbType="NVarChar(60)", UpdateCheck=UpdateCheck.Never)]
		public string identificacion
		{
			get
			{
				return this._identificacion;
			}
			set
			{
				if ((this._identificacion != value))
				{
					this._identificacion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_plan_", DbType="NVarChar(140)", UpdateCheck=UpdateCheck.Never)]
		public string plan_
		{
			get
			{
				return this._plan_;
			}
			set
			{
				if ((this._plan_ != value))
				{
					this._plan_ = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tipodepoliza", DbType="NVarChar(83)", UpdateCheck=UpdateCheck.Never)]
		public string tipodepoliza
		{
			get
			{
				return this._tipodepoliza;
			}
			set
			{
				if ((this._tipodepoliza != value))
				{
					this._tipodepoliza = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_asegurado", DbType="Char(254)", UpdateCheck=UpdateCheck.Never)]
		public string asegurado
		{
			get
			{
				return this._asegurado;
			}
			set
			{
				if ((this._asegurado != value))
				{
					this._asegurado = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_observaciones", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string observaciones
		{
			get
			{
				return this._observaciones;
			}
			set
			{
				if ((this._observaciones != value))
				{
					this._observaciones = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cantidadsolicitudes", DbType="NVarChar(30)", UpdateCheck=UpdateCheck.Never)]
		public string cantidadsolicitudes
		{
			get
			{
				return this._cantidadsolicitudes;
			}
			set
			{
				if ((this._cantidadsolicitudes != value))
				{
					this._cantidadsolicitudes = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fecha_destino", DbType="DateTime", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> fecha_destino
		{
			get
			{
				return this._fecha_destino;
			}
			set
			{
				if ((this._fecha_destino != value))
				{
					this._fecha_destino = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indicador", DbType="Char(42)", UpdateCheck=UpdateCheck.Never)]
		public string indicador
		{
			get
			{
				return this._indicador;
			}
			set
			{
				if ((this._indicador != value))
				{
					this._indicador = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indicado", DbType="Char(20)", UpdateCheck=UpdateCheck.Never)]
		public string indicado
		{
			get
			{
				return this._indicado;
			}
			set
			{
				if ((this._indicado != value))
				{
					this._indicado = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_area", DbType="NVarChar(50)", UpdateCheck=UpdateCheck.Never)]
		public string area
		{
			get
			{
				return this._area;
			}
			set
			{
				if ((this._area != value))
				{
					this._area = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ingresado", DbType="DateTime", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> ingresado
		{
			get
			{
				return this._ingresado;
			}
			set
			{
				if ((this._ingresado != value))
				{
					this._ingresado = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codigo_tipo_wf", DbType="NVarChar(50)", UpdateCheck=UpdateCheck.Never)]
		public string codigo_tipo_wf
		{
			get
			{
				return this._codigo_tipo_wf;
			}
			set
			{
				if ((this._codigo_tipo_wf != value))
				{
					this._codigo_tipo_wf = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tipo_wf", DbType="NVarChar(80)", UpdateCheck=UpdateCheck.Never)]
		public string tipo_wf
		{
			get
			{
				return this._tipo_wf;
			}
			set
			{
				if ((this._tipo_wf != value))
				{
					this._tipo_wf = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_analisis", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_analisis
		{
			get
			{
				return this._f_analisis;
			}
			set
			{
				if ((this._f_analisis != value))
				{
					this._f_analisis = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_docompleta", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_docompleta
		{
			get
			{
				return this._f_docompleta;
			}
			set
			{
				if ((this._f_docompleta != value))
				{
					this._f_docompleta = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_emision", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_emision
		{
			get
			{
				return this._f_emision;
			}
			set
			{
				if ((this._f_emision != value))
				{
					this._f_emision = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_e_firmas", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_e_firmas
		{
			get
			{
				return this._f_e_firmas;
			}
			set
			{
				if ((this._f_e_firmas != value))
				{
					this._f_e_firmas = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_r_firmas", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_r_firmas
		{
			get
			{
				return this._f_r_firmas;
			}
			set
			{
				if ((this._f_r_firmas != value))
				{
					this._f_r_firmas = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_ate_cliente", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_ate_cliente
		{
			get
			{
				return this._f_ate_cliente;
			}
			set
			{
				if ((this._f_ate_cliente != value))
				{
					this._f_ate_cliente = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_reci_atc", DbType="DateTime", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_reci_atc
		{
			get
			{
				return this._f_reci_atc;
			}
			set
			{
				if ((this._f_reci_atc != value))
				{
					this._f_reci_atc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_c_atc", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string c_atc
		{
			get
			{
				return this._c_atc;
			}
			set
			{
				if ((this._c_atc != value))
				{
					this._c_atc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_ent_cam", DbType="DateTime", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_ent_cam
		{
			get
			{
				return this._f_ent_cam;
			}
			set
			{
				if ((this._f_ent_cam != value))
				{
					this._f_ent_cam = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_rec_cliente", DbType="DateTime", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_rec_cliente
		{
			get
			{
				return this._f_rec_cliente;
			}
			set
			{
				if ((this._f_rec_cliente != value))
				{
					this._f_rec_cliente = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indica_atc", DbType="Decimal(10,2)", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<decimal> indica_atc
		{
			get
			{
				return this._indica_atc;
			}
			set
			{
				if ((this._indica_atc != value))
				{
					this._indica_atc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_timestamp_column", AutoSync=AutoSync.Always, DbType="rowversion", IsDbGenerated=true, IsVersion=true, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary timestamp_column
		{
			get
			{
				return this._timestamp_column;
			}
			set
			{
				if ((this._timestamp_column != value))
				{
					this._timestamp_column = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_adjunto", DbType="NVarChar(MAX)", UpdateCheck=UpdateCheck.Never)]
		public string adjunto
		{
			get
			{
				return this._adjunto;
			}
			set
			{
				if ((this._adjunto != value))
				{
					this._adjunto = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_imagen", DbType="VarBinary(MAX)", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary imagen
		{
			get
			{
				return this._imagen;
			}
			set
			{
				if ((this._imagen != value))
				{
					this._imagen = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tsolicitud", DbType="NVarChar(20)", UpdateCheck=UpdateCheck.Never)]
		public string tsolicitud
		{
			get
			{
				return this._tsolicitud;
			}
			set
			{
				if ((this._tsolicitud != value))
				{
					this._tsolicitud = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sus_atec", DbType="NChar(15)", UpdateCheck=UpdateCheck.Never)]
		public string sus_atec
		{
			get
			{
				return this._sus_atec;
			}
			set
			{
				if ((this._sus_atec != value))
				{
					this._sus_atec = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_entrego", DbType="Char(50)", UpdateCheck=UpdateCheck.Never)]
		public string entrego
		{
			get
			{
				return this._entrego;
			}
			set
			{
				if ((this._entrego != value))
				{
					this._entrego = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_poliza", DbType="Char(20)", UpdateCheck=UpdateCheck.Never)]
		public string poliza
		{
			get
			{
				return this._poliza;
			}
			set
			{
				if ((this._poliza != value))
				{
					this._poliza = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tipodoc", DbType="Char(20)", UpdateCheck=UpdateCheck.Never)]
		public string tipodoc
		{
			get
			{
				return this._tipodoc;
			}
			set
			{
				if ((this._tipodoc != value))
				{
					this._tipodoc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_solic", DbType="Char(20)", UpdateCheck=UpdateCheck.Never)]
		public string solic
		{
			get
			{
				return this._solic;
			}
			set
			{
				if ((this._solic != value))
				{
					this._solic = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_solicAT", DbType="Char(20)", UpdateCheck=UpdateCheck.Never)]
		public string solicAT
		{
			get
			{
				return this._solicAT;
			}
			set
			{
				if ((this._solicAT != value))
				{
					this._solicAT = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cod_coop", DbType="Decimal(10,0)", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<decimal> cod_coop
		{
			get
			{
				return this._cod_coop;
			}
			set
			{
				if ((this._cod_coop != value))
				{
					this._cod_coop = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_p_codigo", DbType="NChar(10)", UpdateCheck=UpdateCheck.Never)]
		public string p_codigo
		{
			get
			{
				return this._p_codigo;
			}
			set
			{
				if ((this._p_codigo != value))
				{
					this._p_codigo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cod_operacion", DbType="NChar(2)", UpdateCheck=UpdateCheck.Never)]
		public string cod_operacion
		{
			get
			{
				return this._cod_operacion;
			}
			set
			{
				if ((this._cod_operacion != value))
				{
					this._cod_operacion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cod_area", DbType="NChar(2)", UpdateCheck=UpdateCheck.Never)]
		public string cod_area
		{
			get
			{
				return this._cod_area;
			}
			set
			{
				if ((this._cod_area != value))
				{
					this._cod_area = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dias_atec", DbType="Decimal(10,0)", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<decimal> dias_atec
		{
			get
			{
				return this._dias_atec;
			}
			set
			{
				if ((this._dias_atec != value))
				{
					this._dias_atec = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Estado", DbType="NVarChar(50)", UpdateCheck=UpdateCheck.Never)]
		public string Estado
		{
			get
			{
				return this._Estado;
			}
			set
			{
				if ((this._Estado != value))
				{
					this._Estado = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Puntos", DbType="Decimal(18,0)", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<decimal> Puntos
		{
			get
			{
				return this._Puntos;
			}
			set
			{
				if ((this._Puntos != value))
				{
					this._Puntos = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_asignado", DbType="NVarChar(50)", UpdateCheck=UpdateCheck.Never)]
		public string asignado
		{
			get
			{
				return this._asignado;
			}
			set
			{
				if ((this._asignado != value))
				{
					this._asignado = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_en_re_at", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> en_re_at
		{
			get
			{
				return this._en_re_at;
			}
			set
			{
				if ((this._en_re_at != value))
				{
					this._en_re_at = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ref_en_re_at", DbType="NChar(20)", UpdateCheck=UpdateCheck.Never)]
		public string ref_en_re_at
		{
			get
			{
				return this._ref_en_re_at;
			}
			set
			{
				if ((this._ref_en_re_at != value))
				{
					this._ref_en_re_at = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_desti", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_desti
		{
			get
			{
				return this._f_desti;
			}
			set
			{
				if ((this._f_desti != value))
				{
					this._f_desti = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_estado_indicador", DbType="NChar(10)", UpdateCheck=UpdateCheck.Never)]
		public string estado_indicador
		{
			get
			{
				return this._estado_indicador;
			}
			set
			{
				if ((this._estado_indicador != value))
				{
					this._estado_indicador = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_estado_tiempo", DbType="NVarChar(25)", UpdateCheck=UpdateCheck.Never)]
		public string estado_tiempo
		{
			get
			{
				return this._estado_tiempo;
			}
			set
			{
				if ((this._estado_tiempo != value))
				{
					this._estado_tiempo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_reci_atec", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_reci_atec
		{
			get
			{
				return this._f_reci_atec;
			}
			set
			{
				if ((this._f_reci_atec != value))
				{
					this._f_reci_atec = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_descrip_at", DbType="NVarChar(200)", UpdateCheck=UpdateCheck.Never)]
		public string descrip_at
		{
			get
			{
				return this._descrip_at;
			}
			set
			{
				if ((this._descrip_at != value))
				{
					this._descrip_at = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_obser_corres", DbType="NVarChar(200)", UpdateCheck=UpdateCheck.Never)]
		public string obser_corres
		{
			get
			{
				return this._obser_corres;
			}
			set
			{
				if ((this._obser_corres != value))
				{
					this._obser_corres = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_estado_envio", DbType="NVarChar(50)", UpdateCheck=UpdateCheck.Never)]
		public string estado_envio
		{
			get
			{
				return this._estado_envio;
			}
			set
			{
				if ((this._estado_envio != value))
				{
					this._estado_envio = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_generado_mod", DbType="Bit", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<bool> generado_mod
		{
			get
			{
				return this._generado_mod;
			}
			set
			{
				if ((this._generado_mod != value))
				{
					this._generado_mod = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dui", DbType="NVarChar(10)", UpdateCheck=UpdateCheck.Never)]
		public string dui
		{
			get
			{
				return this._dui;
			}
			set
			{
				if ((this._dui != value))
				{
					this._dui = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hora_r", DbType="NVarChar(11)", UpdateCheck=UpdateCheck.Never)]
		public string hora_r
		{
			get
			{
				return this._hora_r;
			}
			set
			{
				if ((this._hora_r != value))
				{
					this._hora_r = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hora_e", DbType="NVarChar(11)", UpdateCheck=UpdateCheck.Never)]
		public string hora_e
		{
			get
			{
				return this._hora_e;
			}
			set
			{
				if ((this._hora_e != value))
				{
					this._hora_e = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_obser_suspen", DbType="NVarChar(MAX)", UpdateCheck=UpdateCheck.Never)]
		public string obser_suspen
		{
			get
			{
				return this._obser_suspen;
			}
			set
			{
				if ((this._obser_suspen != value))
				{
					this._obser_suspen = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_doc_f", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_doc_f
		{
			get
			{
				return this._f_doc_f;
			}
			set
			{
				if ((this._f_doc_f != value))
				{
					this._f_doc_f = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_c_atec", DbType="NVarChar(MAX)", UpdateCheck=UpdateCheck.Never)]
		public string c_atec
		{
			get
			{
				return this._c_atec;
			}
			set
			{
				if ((this._c_atec != value))
				{
					this._c_atec = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ges_atcl", DbType="NVarChar(MAX)", UpdateCheck=UpdateCheck.Never)]
		public string ges_atcl
		{
			get
			{
				return this._ges_atcl;
			}
			set
			{
				if ((this._ges_atcl != value))
				{
					this._ges_atcl = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_gest", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_gest
		{
			get
			{
				return this._f_gest;
			}
			set
			{
				if ((this._f_gest != value))
				{
					this._f_gest = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_doc_c", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_doc_c
		{
			get
			{
				return this._f_doc_c;
			}
			set
			{
				if ((this._f_doc_c != value))
				{
					this._f_doc_c = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_recb_at", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_recb_at
		{
			get
			{
				return this._f_recb_at;
			}
			set
			{
				if ((this._f_recb_at != value))
				{
					this._f_recb_at = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_n_resol", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_n_resol
		{
			get
			{
				return this._f_n_resol;
			}
			set
			{
				if ((this._f_n_resol != value))
				{
					this._f_n_resol = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_observa_atclie", DbType="NVarChar(MAX)", UpdateCheck=UpdateCheck.Never)]
		public string observa_atclie
		{
			get
			{
				return this._observa_atclie;
			}
			set
			{
				if ((this._observa_atclie != value))
				{
					this._observa_atclie = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fec_firma", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> fec_firma
		{
			get
			{
				return this._fec_firma;
			}
			set
			{
				if ((this._fec_firma != value))
				{
					this._fec_firma = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_hallaz", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_hallaz
		{
			get
			{
				return this._f_hallaz;
			}
			set
			{
				if ((this._f_hallaz != value))
				{
					this._f_hallaz = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_resolusion", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_resolusion
		{
			get
			{
				return this._f_resolusion;
			}
			set
			{
				if ((this._f_resolusion != value))
				{
					this._f_resolusion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_f_auditado", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> f_auditado
		{
			get
			{
				return this._f_auditado;
			}
			set
			{
				if ((this._f_auditado != value))
				{
					this._f_auditado = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fec_entr_aten_cli_atec", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> fec_entr_aten_cli_atec
		{
			get
			{
				return this._fec_entr_aten_cli_atec;
			}
			set
			{
				if ((this._fec_entr_aten_cli_atec != value))
				{
					this._fec_entr_aten_cli_atec = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_requisito", DbType="NVarChar(MAX)", UpdateCheck=UpdateCheck.Never)]
		public string requisito
		{
			get
			{
				return this._requisito;
			}
			set
			{
				if ((this._requisito != value))
				{
					this._requisito = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_requisito_cod", DbType="NVarChar(10)", UpdateCheck=UpdateCheck.Never)]
		public string requisito_cod
		{
			get
			{
				return this._requisito_cod;
			}
			set
			{
				if ((this._requisito_cod != value))
				{
					this._requisito_cod = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_causa", DbType="NVarChar(MAX)", UpdateCheck=UpdateCheck.Never)]
		public string causa
		{
			get
			{
				return this._causa;
			}
			set
			{
				if ((this._causa != value))
				{
					this._causa = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_causa_cod", DbType="NVarChar(10)", UpdateCheck=UpdateCheck.Never)]
		public string causa_cod
		{
			get
			{
				return this._causa_cod;
			}
			set
			{
				if ((this._causa_cod != value))
				{
					this._causa_cod = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_planes", DbType="NVarChar(MAX)", UpdateCheck=UpdateCheck.Never)]
		public string planes
		{
			get
			{
				return this._planes;
			}
			set
			{
				if ((this._planes != value))
				{
					this._planes = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_planes_cod", DbType="NVarChar(10)", UpdateCheck=UpdateCheck.Never)]
		public string planes_cod
		{
			get
			{
				return this._planes_cod;
			}
			set
			{
				if ((this._planes_cod != value))
				{
					this._planes_cod = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nplaca", DbType="NChar(20)", UpdateCheck=UpdateCheck.Never)]
		public string nplaca
		{
			get
			{
				return this._nplaca;
			}
			set
			{
				if ((this._nplaca != value))
				{
					this._nplaca = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_che_envio", DbType="Bit", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<bool> che_envio
		{
			get
			{
				return this._che_envio;
			}
			set
			{
				if ((this._che_envio != value))
				{
					this._che_envio = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_che_recibido", DbType="Bit", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<bool> che_recibido
		{
			get
			{
				return this._che_recibido;
			}
			set
			{
				if ((this._che_recibido != value))
				{
					this._che_recibido = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
