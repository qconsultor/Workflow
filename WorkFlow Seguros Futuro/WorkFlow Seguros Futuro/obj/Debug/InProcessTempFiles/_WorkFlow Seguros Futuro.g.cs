//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XamlStaticHelperNamespace {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamlBuildTask", "4.0.0.0")]
    internal class _XamlStaticHelper {
        
        private static System.WeakReference schemaContextField;
        
        private static System.Collections.Generic.IList<System.Reflection.Assembly> assemblyListField;
        
        internal static System.Xaml.XamlSchemaContext SchemaContext {
            get {
                System.Xaml.XamlSchemaContext xsc = null;
                if ((schemaContextField != null)) {
                    xsc = ((System.Xaml.XamlSchemaContext)(schemaContextField.Target));
                    if ((xsc != null)) {
                        return xsc;
                    }
                }
                if ((AssemblyList.Count > 0)) {
                    xsc = new System.Xaml.XamlSchemaContext(AssemblyList);
                }
                else {
                    xsc = new System.Xaml.XamlSchemaContext();
                }
                schemaContextField = new System.WeakReference(xsc);
                return xsc;
            }
        }
        
        internal static System.Collections.Generic.IList<System.Reflection.Assembly> AssemblyList {
            get {
                if ((assemblyListField == null)) {
                    assemblyListField = LoadAssemblies();
                }
                return assemblyListField;
            }
        }
        
        private static System.Collections.Generic.IList<System.Reflection.Assembly> LoadAssemblies() {
            System.Collections.Generic.IList<System.Reflection.Assembly> assemblyList = new System.Collections.Generic.List<System.Reflection.Assembly>();
            assemblyList.Add(Load("Microsoft.CSharp, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a" +
                        "3a"));
            assemblyList.Add(Load("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("PresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e" +
                        "35"));
            assemblyList.Add(Load("PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856a" +
                        "d364e35"));
            assemblyList.Add(Load("System.Activities, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364" +
                        "e35"));
            assemblyList.Add(Load("System.Activities.Presentation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=" +
                        "31bf3856ad364e35"));
            assemblyList.Add(Load("System.ComponentModel.DataAnnotations, Version=4.0.0.0, Culture=neutral, PublicKe" +
                        "yToken=31bf3856ad364e35"));
            assemblyList.Add(Load("System.Configuration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11" +
                        "d50a3a"));
            assemblyList.Add(Load("System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System.Data.DataSetExtensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b" +
                        "77a5c561934e089"));
            assemblyList.Add(Load("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" +
                        ""));
            assemblyList.Add(Load("System.EnterpriseServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5" +
                        "f7f11d50a3a"));
            assemblyList.Add(Load("System.ServiceModel.Activities, Version=4.0.0.0, Culture=neutral, PublicKeyToken=" +
                        "31bf3856ad364e35"));
            assemblyList.Add(Load("System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c56193" +
                        "4e089"));
            assemblyList.Add(Load("System.Web.ApplicationServices, Version=4.0.0.0, Culture=neutral, PublicKeyToken=" +
                        "31bf3856ad364e35"));
            assemblyList.Add(Load("System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"));
            assemblyList.Add(Load("System.Web.DynamicData, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856" +
                        "ad364e35"));
            assemblyList.Add(Load("System.Web.Entity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e" +
                        "089"));
            assemblyList.Add(Load("System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856a" +
                        "d364e35"));
            assemblyList.Add(Load("System.Web.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d" +
                        "50a3a"));
            assemblyList.Add(Load("System.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e08" +
                        "9"));
            assemblyList.Add(Load("WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"));
            assemblyList.Add(Load("Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=31bf3856ad364" +
                        "e35"));
            assemblyList.Add(Load("AspNet.ScriptManager.jQuery, Version=1.7.1.0, Culture=neutral, PublicKeyToken=nul" +
                        "l"));
            assemblyList.Add(Load("AspNet.ScriptManager.jQuery.UI.Combined, Version=1.8.20.0, Culture=neutral, Publi" +
                        "cKeyToken=null"));
            assemblyList.Add(Load("DotNetOpenAuth.AspNet, Version=4.0.0.0, Culture=neutral, PublicKeyToken=2780ccd10" +
                        "d57b246"));
            assemblyList.Add(Load("DotNetOpenAuth.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=2780ccd10d5" +
                        "7b246"));
            assemblyList.Add(Load("DotNetOpenAuth.OAuth.Consumer, Version=4.0.0.0, Culture=neutral, PublicKeyToken=2" +
                        "780ccd10d57b246"));
            assemblyList.Add(Load("DotNetOpenAuth.OAuth, Version=4.0.0.0, Culture=neutral, PublicKeyToken=2780ccd10d" +
                        "57b246"));
            assemblyList.Add(Load("DotNetOpenAuth.OpenId, Version=4.0.0.0, Culture=neutral, PublicKeyToken=2780ccd10" +
                        "d57b246"));
            assemblyList.Add(Load("DotNetOpenAuth.OpenId.RelyingParty, Version=4.0.0.0, Culture=neutral, PublicKeyTo" +
                        "ken=2780ccd10d57b246"));
            assemblyList.Add(Load("EntityFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e08" +
                        "9"));
            assemblyList.Add(Load("Ext.Net, Version=4.0.0.0, Culture=neutral, PublicKeyToken=2e12ce3d0176cd87"));
            assemblyList.Add(Load("Ext.Net.Utilities, Version=2.5.0.0, Culture=neutral, PublicKeyToken=2c34ac34702a3" +
                        "c23"));
            assemblyList.Add(Load("Microsoft.AspNet.Membership.OpenAuth, Version=1.0.0.0, Culture=neutral, PublicKey" +
                        "Token=31bf3856ad364e35"));
            assemblyList.Add(Load("Microsoft.AspNet.Web.Optimization.WebForms, Version=1.0.0.0, Culture=neutral, Pub" +
                        "licKeyToken=31bf3856ad364e35"));
            assemblyList.Add(Load("Microsoft.ScriptManager.MSAjax, Version=4.5.6.0, Culture=neutral, PublicKeyToken=" +
                        "31bf3856ad364e35"));
            assemblyList.Add(Load("Microsoft.ScriptManager.WebForms, Version=4.5.6.0, Culture=neutral, PublicKeyToke" +
                        "n=31bf3856ad364e35"));
            assemblyList.Add(Load("Microsoft.Web.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31" +
                        "bf3856ad364e35"));
            assemblyList.Add(Load("Newtonsoft.Json, Version=8.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aee" +
                        "d"));
            assemblyList.Add(Load("System.Web.Optimization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf385" +
                        "6ad364e35"));
            assemblyList.Add(Load("System.Web.Providers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad" +
                        "364e35"));
            assemblyList.Add(Load("Transformer.NET, Version=2.1.1.22883, Culture=neutral, PublicKeyToken=e274d618e7c" +
                        "603a7"));
            assemblyList.Add(Load("WebActivatorEx, Version=2.0.0.0, Culture=neutral, PublicKeyToken=7b26dc2a43f6a0d4" +
                        ""));
            assemblyList.Add(Load("WebGrease, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"));
            assemblyList.Add(System.Reflection.Assembly.GetExecutingAssembly());
            return assemblyList;
        }
        
        private static System.Reflection.Assembly Load(string assemblyNameVal) {
            System.Reflection.AssemblyName assemblyName = new System.Reflection.AssemblyName(assemblyNameVal);
            byte[] publicKeyToken = assemblyName.GetPublicKeyToken();
            System.Reflection.Assembly asm = null;
            try {
                asm = System.Reflection.Assembly.Load(assemblyName.FullName);
            }
            catch (System.Exception ) {
                System.Reflection.AssemblyName shortName = new System.Reflection.AssemblyName(assemblyName.Name);
                if ((publicKeyToken != null)) {
                    shortName.SetPublicKeyToken(publicKeyToken);
                }
                asm = System.Reflection.Assembly.Load(shortName);
            }
            return asm;
        }
    }
}
