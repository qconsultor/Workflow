
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Ext.Net;
using Ext.Net.Utilities;

namespace WorkFlow_Seguros_Futuro
{
    public partial class wf_principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("login.aspx", true);
            }
            else
            {
                this.HiddenSesion.Text = Session["usuario"].ToString();
                this.ButtonUsuario.Text = Session["usuario"].ToString();
            }

        }

        protected void Button_Click(object sender, DirectEventArgs e)
        {
            switch (((Ext.Net.MenuItem)sender).Text)
            {
                case "Pasos":

                    this.PanelMaestro.LoadContent(new ComponentLoader()
                    {
                        //Url = "MaestroRequisitos.aspx",
                        Url = "wf_maestro_porcentaje.aspx",
                        Mode = LoadMode.Frame,
                        AutoLoad = true,
                        LoadMask = { ShowMask = true, Msg = "Cargando..." }
                    });
                    break;

                case "Enviar ATC":

                    this.PanelMaestro.LoadContent(new ComponentLoader()
                    {
                        //Url = "MaestroRequisitos.aspx",
                        Url = "wf_entrega_p_AC.aspx",
                        Mode = LoadMode.Frame,
                        AutoLoad = true,
                        LoadMask = { ShowMask = true, Msg = "Cargando..." }
                    });
                    break;

                case "Recibir Emision":

                    this.PanelMaestro.LoadContent(new ComponentLoader()
                    {
                        //Url = "MaestroRequisitos.aspx",
                        Url = "wf_recibir_atc.aspx",
                        Mode = LoadMode.Frame,
                        AutoLoad = true,
                        LoadMask = { ShowMask = true, Msg = "Cargando..." }
                    });
                    break;

                case "Requisitos":

                    this.PanelMaestro.LoadContent(new ComponentLoader()
                    {
                        Url = "requisitos.aspx",
                        Mode = LoadMode.Frame,
                        AutoLoad = true,
                        LoadMask = { ShowMask = true, Msg = "Cargando..." }
                    });
                    break;
                case "Recepcion":

                    this.PanelMaestro.LoadContent(new ComponentLoader()
                    {
                        Url = "wf_recepcionserver.aspx",
                        Mode = LoadMode.Frame,
                        AutoLoad = true,
                        LoadMask = { ShowMask = true, Msg = "Cargando..." }
                    });
                    break;

                case "Emision":

                    this.PanelMaestro.LoadContent(new ComponentLoader()
                    {
                        Url = "emision.aspx",
                        Mode = LoadMode.Frame,
                        AutoLoad = true,
                        LoadMask = { ShowMask = true, Msg = "Cargando..." }
                    });
                    break;

                case "Control de Asignacion":

                    this.PanelMaestro.LoadContent(new ComponentLoader()
                    {
                        Url = "gr_asignados_emision.aspx",
                        Mode = LoadMode.Frame,
                        AutoLoad = true,
                        LoadMask = { ShowMask = true, Msg = "Cargando..." }
                    });
                    break;
                case "Control de Asignacion Reclamos":

                    this.PanelMaestro.LoadContent(new ComponentLoader()
                    {
                        Url = "gr_asignados_reclamos.aspx",
                        Mode = LoadMode.Frame,
                        AutoLoad = true,
                        LoadMask = { ShowMask = true, Msg = "Cargando..." }
                    });
                    break;

                case "Reclamos":

                    this.PanelMaestro.LoadContent(new ComponentLoader()
                    {
                        Url = "~/Formularios/wf_reclamos.aspx",
                        Mode = LoadMode.Frame,
                        AutoLoad = true,
                        LoadMask = { ShowMask = true, Msg = "Cargando..." }
                    });
                    break;
                     
                case "Maestro de Imagenes":

                    this.PanelMaestro.LoadContent(new ComponentLoader()
                    {
                        Url = "wf_maestro_imagenes.aspx",
                        Mode = LoadMode.Frame,
                        AutoLoad = true,
                        LoadMask = { ShowMask = true, Msg = "Cargando..." }
                    });
                    break;

                case "Mantenedor de usuarios":

                    this.PanelMaestro.LoadContent(new ComponentLoader()
                    {
                        Url = "agregar_usuarios.aspx",
                        Mode = LoadMode.Frame,
                        AutoLoad = true,
                        LoadMask = { ShowMask = true, Msg = "Cargando..." }
                    });
                    break;

                case "Atencion al Cliente":

                    this.PanelMaestro.LoadContent(new ComponentLoader()
                    {
                        Url = "wf_ate_cliente.aspx",
                        Mode = LoadMode.Frame,
                        AutoLoad = true,
                        LoadMask = { ShowMask = true, Msg = "Cargando..." }
                    });
                    break;

                case "Progreso Emision":

                    this.PanelMaestro.LoadContent(new ComponentLoader()
                    {
                        Url = "progreso.aspx",
                        Mode = LoadMode.Frame,
                        AutoLoad = true,
                        LoadMask = { ShowMask = true, Msg = "Cargando..." }
                    });

                    break;

                case "Progreso Reclamos":

                    this.PanelMaestro.LoadContent(new ComponentLoader()
                    {
                        Url = "progreso_reclamos.aspx",
                        Mode = LoadMode.Frame,
                        AutoLoad = true,
                        LoadMask = { ShowMask = true, Msg = "Cargando..." }
                    });

                    break;

                
                case "Manual (PDF)":

                    this.PanelMaestro.LoadContent(new ComponentLoader()
                    {
                        Url = "Manual/Manual_PDF.html",
                        Mode = LoadMode.Frame,
                        AutoLoad = true,
                        LoadMask = { ShowMask = true, Msg = "Cargando..." }
                    });

                    break;


                default:

                    X.Msg.Alert("Notificación", "Desarrollo no implementado", new MessageBoxButtonsConfig
                    {

                        Ok = new MessageBoxButtonConfig
                        {
                            Text = "Ok"

                        }
                    }).Show();

                    return;



                case "Cerrar Sesión":

                    Response.Redirect("login.aspx");

                    break;



                    X.Msg.Alert("Notificación", "Desarrollo no implementado", new MessageBoxButtonsConfig
                    {

                        Ok = new MessageBoxButtonConfig
                        {
                            Text = "Ok"

                        }
                    }).Show();

                    return;


            }




        }

       

        

        protected void CargarButtonPermiso(object sender, DirectEventArgs e)
        {
            if (!ValidarPermiso(this.HiddenSesion.Text, "RECEPCION EMISION", "RECEPCION EMISION"))
            {

            }
            else
            {
                this.PanelMaestro.LoadContent(new ComponentLoader()
                {

                    Url = "~/Formularios/wf_recepcionserver.aspx",
                    Mode = LoadMode.Frame,
                    AutoLoad = true,
                    LoadMask = { ShowMask = true, Msg = "Procesando..." }

                });
            }

        }
        protected void CargarButtonPermiso1(object sender, DirectEventArgs e)
        {
            if (!ValidarPermiso(this.HiddenSesion.Text, "VISTA DE EMISION", "VISTA DE EMISION"))
            {

            }
            else
            {
                this.PanelMaestro.LoadContent(new ComponentLoader()
                {

                    Url = "emision.aspx",
                    Mode = LoadMode.Frame,
                    AutoLoad = true,
                    LoadMask = { ShowMask = true, Msg = "Procesando..." }

                });
            }

        }
        protected void CargarButtonPermiso2(object sender, DirectEventArgs e)
        {
            if (!ValidarPermiso(this.HiddenSesion.Text, "SEGUIMIENTO EMISION", "SEGUIMIENTO EMISION"))
            {

            }
            else
            {
                this.PanelMaestro.LoadContent(new ComponentLoader()
                {

                    Url = "wf_seguimiento_emision.aspx",
                    Mode = LoadMode.Frame,
                    AutoLoad = true,
                    LoadMask = { ShowMask = true, Msg = "Procesando..." }

                });
            }

        }
        
        protected void CargarButtonPermiso3(object sender, DirectEventArgs e)
        {
            if (!ValidarPermiso(this.HiddenSesion.Text, "RECEPCION DE RECLAMO", "RECEPCION DE RECLAMO"))
            {

            }
            else
            {
                this.PanelMaestro.LoadContent(new ComponentLoader()
                {

                    Url = "~/Formularios/wf_recepcionreclamos.aspx",
                    Mode = LoadMode.Frame,
                    AutoLoad = true,
                    LoadMask = { ShowMask = true, Msg = "Procesando..." }

                });
            }

        }
        protected void CargarButtonPermiso4(object sender, DirectEventArgs e)
        {
            if (!ValidarPermiso(this.HiddenSesion.Text, "VISTA DE RECLAMOS", "VISTA DE RECLAMOS"))
            {

            }
            else
            {
                this.PanelMaestro.LoadContent(new ComponentLoader()
                {

                    Url = "~/Formularios/reclamos.aspx",
                    Mode = LoadMode.Frame,
                    AutoLoad = true,
                    LoadMask = { ShowMask = true, Msg = "Procesando..." }

                });
            }

        }

        protected void CargarButtonPermiso5(object sender, DirectEventArgs e)
        {
            if (!ValidarPermiso(this.HiddenSesion.Text, "SEGUIMIENTO DE RECLA", "SEGUIMIENTO DE RECLA"))
            {

            }
            else
            {
                this.PanelMaestro.LoadContent(new ComponentLoader()
                {

                    Url = "~/Formularios/wf_seguimiento_reclamos.aspx",
                    Mode = LoadMode.Frame,
                    AutoLoad = true,
                    LoadMask = { ShowMask = true, Msg = "Procesando..." }

                });
            }

        }
        protected void CargarButtonPermiso101(object sender, DirectEventArgs e)
        {
            if (!ValidarPermiso(this.HiddenSesion.Text, "SEGUIMIENTO DE RECLA", "SEGUIMIENTO DE RECLA"))
            {

            }
            else
            {
                this.PanelMaestro.LoadContent(new ComponentLoader()
                {

                    Url = "~/Formularios/wf_reasignar_reclamo.aspx",
                    Mode = LoadMode.Frame,
                    AutoLoad = true,
                    LoadMask = { ShowMask = true, Msg = "Procesando..." }

                });
            }

        }

        protected void CargarButtonPermiso6(object sender, DirectEventArgs e)
        {
            if (!ValidarPermiso(this.HiddenSesion.Text, "SEGUIMIENTO DE SOLIC", "SEGUIMIENTO DE SOLIC"))
            {

            }
            else
            {
                this.PanelMaestro.LoadContent(new ComponentLoader()
                {

                    Url = "~/Formularios/wf_atencialalcliente.aspx",
                    Mode = LoadMode.Frame,
                    AutoLoad = true,
                    LoadMask = { ShowMask = true, Msg = "Procesando..." }

                });
            }

        }

        protected void CargarButtonPermiso7(object sender, DirectEventArgs e)
        {
            if (!ValidarPermiso(this.HiddenSesion.Text, "PASOS", "PASOS"))
            {

            }
            else
            {
                this.PanelMaestro.LoadContent(new ComponentLoader()
                {

                    Url = "wf_maestro_porcentaje.aspx",
                    Mode = LoadMode.Frame,
                    AutoLoad = true,
                    LoadMask = { ShowMask = true, Msg = "Procesando..." }

                });
            }

        }

        protected void CargarButtonPermiso8(object sender, DirectEventArgs e)
        {
            if (!ValidarPermiso(this.HiddenSesion.Text, "REQUISITOS", "REQUISITOS"))
            {

            }
            else
            {
                this.PanelMaestro.LoadContent(new ComponentLoader()
                {

                    Url = "requisitos.aspx",
                    Mode = LoadMode.Frame,
                    AutoLoad = true,
                    LoadMask = { ShowMask = true, Msg = "Procesando..." }

                });
            }

        }

        protected void CargarButtonPermiso9(object sender, DirectEventArgs e)
        {
            if (!ValidarPermiso(this.HiddenSesion.Text, "PERFILES DE USUARIO", "PERFILES DE USUARIO"))
            {

            }
            else
            {
                this.PanelMaestro.LoadContent(new ComponentLoader()
                {

                    Url = "wf_perfiles_usuarios.aspx",
                    Mode = LoadMode.Frame,
                    AutoLoad = true,
                    LoadMask = { ShowMask = true, Msg = "Procesando..." }

                });
            }

        }
        protected void CargarButtonPermiso11(object sender, DirectEventArgs e)
        {
            if (!ValidarPermiso(this.HiddenSesion.Text, "FIRMA", "FIRMA"))
            {

            }
            else
            {
                this.PanelMaestro.LoadContent(new ComponentLoader()
                {

                    Url = "firma.aspx",
                    Mode = LoadMode.Frame,
                    AutoLoad = true,
                    LoadMask = { ShowMask = true, Msg = "Procesando..." }

                });
            }

        }
        protected void CargarButtonPermiso12(object sender, DirectEventArgs e)
        {
            if (!ValidarPermiso(this.HiddenSesion.Text, "REASIGNAR TAREA", "REASIGNAR TAREA"))
            {

            }
            else
            {
                this.PanelMaestro.LoadContent(new ComponentLoader()
                {

                    Url = "wf_reasignar_emison.aspx",
                    Mode = LoadMode.Frame,
                    AutoLoad = true,
                    LoadMask = { ShowMask = true, Msg = "Procesando..." }

                });
            }

        }

        protected void CargarButtonPermiso25(object sender, DirectEventArgs e)
        {
            if (!ValidarPermiso(this.HiddenSesion.Text, "Control de Accesos", "Control de Accesos"))
            {

            }
            else
            {
                this.PanelMaestro.LoadContent(new ComponentLoader()
                {

                    Url = "wf_controlAcceso.aspx",
                    Mode = LoadMode.Frame,
                    AutoLoad = true,
                    LoadMask = { ShowMask = true, Msg = "Procesando..." }

                });
            }

        }


        protected void CargarButtonPermiso31(object sender, DirectEventArgs e)
        {
            if (!ValidarPermiso(this.HiddenSesion.Text, "Ver Expediente", "Ver Expediente"))
            {

            }
            else
            {
                this.PanelMaestro.LoadContent(new ComponentLoader()
                {

                    Url = "~/Formularios/PRUEBA_VER_PFG.aspx",
                    Mode = LoadMode.Frame,
                    AutoLoad = true,
                    LoadMask = { ShowMask = true, Msg = "Procesando..." }

                });
            }

        }

        public bool ValidarPermiso(string usuario, string rol, string modulo)
        {
            string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["SIA_ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("select permiso from vw_permisos where usuario=@usuario and rol=@rol and modulo=@modulo", con);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@rol", rol);
            cmd.Parameters.AddWithValue("@modulo", modulo);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.HiddenPermisos.Text = (reader["permiso"].ToString());

            }
            reader.Close();

            if (this.HiddenPermisos.Text == "0")
            {
                X.Msg.Alert("ERROR", "NO TIENE PERMISO PARA ESTA OPERACION, CONTACTE AL ADMINISTRADOR DEL SISTEMA", new MessageBoxButtonsConfig
                {

                    Ok = new MessageBoxButtonConfig
                    {
                        Text = "Ok"

                    }
                }).Show();

                return false;
            }
            if (this.HiddenPermisos.Text == "")
            {
                X.Msg.Alert("ERROR", "NO TIENE PERMISO PARA ESTA OPERACION, CONTACTE AL ADMINISTRADOR DEL SISTEMA", new MessageBoxButtonsConfig
                {

                    Ok = new MessageBoxButtonConfig
                    {
                        Text = "Ok"

                    }
                }).Show();

                return false;
            }
            else
            {
                return true;
            }
        }

    }





}
