using Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using WebApp.Configurations;

namespace WebApp.Services
{
    /// <summary>
    /// Descripción breve de CheckService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class CheckService : System.Web.Services.WebService
    {
        public SOAPKeyAuth sOAPKeyAuth = new SOAPKeyAuth();
        private ContentHTML contentHTML = new ContentHTML();
        private MessageVO messageVO = new MessageVO();

        /// <summary>
        /// Metodo para verificar conectividad al servicio
        /// </summary>
        /// <returns>MessageVO</returns>
        [WebMethod(Description = "Metodo para verificar conectividad al servicio")]
        public MessageVO Check()
        {
            try
            {
                if (contentHTML.IsLoadDocumentHTML())
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("checkTitle"), contentHTML.GetInnerTextById("correctCheckMessage"));
                }
                else
                {
                    messageVO.SetMessage(0, "Verificacion de API", "Servicio no responde correctamente, funcionalidad no se ha ejecutado segun lo esperado");
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
            }
            return messageVO;
        }

        /// <summary>
        /// Metodo para verificar funcionalidad de autenticacion
        /// </summary>
        /// <returns>MessageVO</returns>
        [WebMethod(Description = "Metodo para verificar funcionalidad de autenticacion")]
        [SoapHeader("sOAPKeyAuth")]
        public MessageVO CheckAuth()
        {
            try
            {
                if (!sOAPKeyAuth.IsAuthorized())
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                }
                else
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("checkTitle"), contentHTML.GetInnerTextById("correctCheckMessage"));
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
            }
            return messageVO;
        }
    }
}
