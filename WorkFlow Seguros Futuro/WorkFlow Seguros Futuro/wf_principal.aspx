<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_principal.aspx.cs" Inherits="WorkFlow_Seguros_Futuro.wf_principal" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Workflow</title>
    <ext:ResourceManager ID="ResourceManager" runat="server" Theme="Aria" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:Viewport ID="ViewportPrincipal" runat="server">
            <Items>
                <ext:Panel ID="PanelPrincipal" runat="server" Title="Workflow" Icon="BugMagnify" TitleAlign="Center" Layout="FitLayout" Region="North">
                    <Items>
                        <ext:Toolbar ID="Toolbar1" runat="server" EnableOverflow="true">
                            <Items>
                                <ext:SplitButton ID="SplitButton1" runat="server" Text="EMISION" Icon="ApplicationOsxHome">
                                    <Menu>
                                        <ext:Menu ID="Menu1" runat="server">
                                            <Items>
                                                <ext:MenuItem Text="Recepcion Emision" Icon="Applicationviewdetail">
                                                    <DirectEvents>
                                                        <Click OnEvent="CargarButtonPermiso" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                            </Items>
                                            <Items>
                                                <ext:MenuItem Text="Vista de Emision" Icon="Applicationviewdetail">
                                                    <DirectEvents>
                                                        <Click OnEvent="CargarButtonPermiso1" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                            </Items>
                                            <Items>
                                                <ext:MenuItem Text="Seguimiento Emision" Icon="ApplicationFormMagnify">
                                                    <DirectEvents>
                                                        <Click OnEvent="CargarButtonPermiso2" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <ext:MenuItem Text="Reasignar Tareas" Icon="ApplicationFormMagnify">
                                                    <DirectEvents>
                                                        <Click OnEvent="CargarButtonPermiso12" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <ext:MenuItem Text="Firma" Icon="ApplicationFormMagnify">
                                                    <DirectEvents>
                                                        <Click OnEvent="CargarButtonPermiso11" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <ext:MenuItem Text="Enviar ATC" Icon="ApplicationFormMagnify">
                                                    <DirectEvents>
                                                        <Click OnEvent="Button_Click" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <ext:MenuItem Text="Control de Asignacion" Icon="ApplicationFormMagnify">
                                                    <DirectEvents>
                                                        <Click OnEvent="Button_Click" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <ext:MenuItem Text="Ver Expediente" Icon="ApplicationFormMagnify">
                                                    <DirectEvents>
                                                        <Click OnEvent="CargarButtonPermiso31" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>


                                            </Items>
                                        </ext:Menu>
                                    </Menu>
                                </ext:SplitButton>

                                <ext:SplitButton ID="SplitButton4" runat="server" Text="RECLAMOS" Icon="Group">
                                    <Menu>
                                        <ext:Menu ID="Menu4" runat="server">
                                            <Items>
                                                <ext:MenuItem Text="Recepcion de Reclamos" Icon="GroupAdd">
                                                    <DirectEvents>
                                                        <Click OnEvent="CargarButtonPermiso3" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <ext:MenuItem Text="Seguimiento de Reclamos" Icon="GroupKey">
                                                    <DirectEvents>
                                                        <Click OnEvent="CargarButtonPermiso5" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <ext:MenuItem Text="Vista de Reclamos" Icon="GroupGear">
                                                    <DirectEvents>
                                                        <Click OnEvent="CargarButtonPermiso4" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <ext:MenuItem Text="Reasignacion de Reclamo" Icon="ApplicationFormMagnify">
                                                    <DirectEvents>
                                                        <Click OnEvent="CargarButtonPermiso101" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>

                                                <ext:MenuItem Text="Control de Asignacion Reclamos" Icon="ApplicationFormMagnify">
                                                    <DirectEvents>
                                                        <Click OnEvent="Button_Click" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <%--<ext:MenuItem Text="Requisitos" Icon="Applicationviewdetail">
                                                    <DirectEvents>
                                                        <Click OnEvent="Button_Click" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem> --%>
                                            </Items>
                                            <Items>
                                            </Items>
                                        </ext:Menu>
                                    </Menu>
                                </ext:SplitButton>

                                <ext:SplitButton ID="SplitButton5" runat="server" Text="ATENCION AL CLIENTE" Icon="Group">
                                    <Menu>
                                        <ext:Menu ID="Menu8" runat="server">
                                            <Items>
                                                <ext:MenuItem Text="Seguimiento Solicitudes" Icon="GroupAdd">
                                                    <DirectEvents>
                                                        <Click OnEvent="CargarButtonPermiso6" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <ext:MenuItem Text="Recibir Emision" Icon="GroupAdd">
                                                    <DirectEvents>
                                                        <Click OnEvent="Button_Click" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                            </Items>
                                        </ext:Menu>
                                    </Menu>
                                </ext:SplitButton>

                                <ext:SplitButton ID="SplitButton6" runat="server" Text="Monitoreo" Icon="ApplicationEdit">
                                    <Menu>
                                        <ext:Menu ID="Menu9" runat="server">
                                            <Items>
                                                <ext:MenuItem Text="Progreso Emision" Icon="Applicationviewdetail">
                                                    <DirectEvents>
                                                        <Click OnEvent="Button_Click" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <ext:MenuItem Text="Progreso Reclamos" Icon="Applicationviewdetail">
                                                    <DirectEvents>
                                                        <Click OnEvent="Button_Click" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <%--<ext:MenuItem Text="Requisitos" Icon="Applicationviewdetail">
                                                    <DirectEvents>
                                                        <Click OnEvent="Button_Click" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem> --%>
                                            </Items>
                                            <Items>
                                            </Items>
                                        </ext:Menu>
                                    </Menu>
                                </ext:SplitButton>

                                <ext:SplitButton ID="SplitButton2" runat="server" Text="Configuraciones" Icon="ApplicationEdit">
                                    <Menu>
                                        <ext:Menu ID="Menu2" runat="server">
                                            <Items>
                                                <ext:MenuItem Text="Pasos" Icon="Applicationviewdetail">
                                                    <DirectEvents>
                                                        <Click OnEvent="CargarButtonPermiso7" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <ext:MenuItem Text="Requisitos" Icon="Applicationviewdetail">
                                                    <DirectEvents>
                                                        <Click OnEvent="CargarButtonPermiso8" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <ext:MenuItem Text="Perfiles de Usuario" Icon="Applicationviewdetail">
                                                    <DirectEvents>
                                                        <Click OnEvent="CargarButtonPermiso9" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <ext:MenuItem Text="Control de Accesos" Icon="Applicationviewdetail">
                                                    <DirectEvents>
                                                        <Click OnEvent="CargarButtonPermiso25" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                            </Items>
                                            <Items>
                                            </Items>
                                        </ext:Menu>
                                    </Menu>
                                </ext:SplitButton>

                                <%--<ext:Button ID="Button3" runat="server" Text="Mantenedores" Icon="DatabaseConnect">
                                    <Menu>
                                        <ext:Menu ID="Menu5" runat="server">
                                            <Items>
                                                <ext:MenuItem Text="Maestro de Imagenes" Icon="ComputerMagnify">
                                                    <DirectEvents>
                                                      <Click OnEvent="Button_Click" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                                <ext:MenuItem Text="Mantenedor de usuarios" Icon="UserRed">
                                                    <DirectEvents>
                                                       <Click OnEvent="Button_Click" Method="GET">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                            </Items>
                                        </ext:Menu>
                                    </Menu>
                                </ext:Button>--%>
                                <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                <ext:Button ID="ButtonUsuario" runat="server" Icon="UserSuitBlack" StyleSpec="text-transform: uppercase;">
                                    <Menu>
                                        <ext:Menu ID="Menu6" runat="server" Hidden="true">
                                            <Items>
                                                <ext:MenuItem ID="MenuItem6" runat="server" Text="Ayuda" Icon="Help">
                                                    <Menu>
                                                        <ext:Menu ID="Menu7" runat="server">
                                                            <Items>
                                                                <ext:MenuItem ID="MenuItem7" runat="server" Text="Manual (PDF)" Icon="PageWhiteAcrobat">
                                                                </ext:MenuItem>
                                                                <ext:MenuItem ID="MenuItem8" runat="server" Text="Video" Icon="CameraStart" Hidden="true">
                                                                </ext:MenuItem>
                                                            </Items>
                                                        </ext:Menu>
                                                    </Menu>
                                                </ext:MenuItem>
                                                <ext:MenuSeparator ID="MenuSeparator1" runat="server" />
                                                <ext:MenuItem ID="MenuItem9" runat="server" Text="Cerrar Sesión" Icon="UserCross">
                                                    <DirectEvents>
                                                        <Click OnEvent="Button_Click" Method="GET">
                                                            <EventMask ShowMask="true" Msg="Hasta Luego..." MinDelay="1000" />
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:MenuItem>
                                            </Items>
                                        </ext:Menu>
                                    </Menu>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </Items>
                </ext:Panel>
                <ext:Panel ID="PanelMaestro" runat="server" Border="false" Region="Center" Layout="FitLayout" Height="715px">
                    <Loader ID="Loader1" runat="server" Url="../Configurador/configurador.html" Mode="Frame" AutoLoad="true">
                    </Loader>
                </ext:Panel>
                <ext:StatusBar ID="StatusBar1" runat="server" DefaultText="QConsultores Derechos Reservados - 2017  Version 1.0" Region="South">
                    <Items>
                        <ext:ToolbarFill ID="ToolbarFill" runat="server" />
                        <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
                        <ext:ToolbarTextItem ID="clock" runat="server" Text=" " CtCls="x-status-text-panel" />
                    </Items>
                </ext:StatusBar>
            </Items>
        </ext:Viewport>
        <ext:TaskManager ID="TaskManager1" runat="server">
            <Tasks>
                <ext:Task AutoRun="true" Interval="1000">
                    <Listeners>
                        <Update Handler="#{clock}.setText(Ext.Date.format(new Date(), 'g:i:s A'));" />
                    </Listeners>
                </ext:Task>
            </Tasks>
        </ext:TaskManager>
        <ext:Hidden ID="HiddenSesion" runat="server" />
        <ext:Hidden ID="HiddenPermisos" runat="server" />
    </form>
</body>
</html>

