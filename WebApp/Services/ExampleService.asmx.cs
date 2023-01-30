using Business.DTO;
using Business.Entity;
using Business.Implementation;
using Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using WebApp.Configurations;
using WebApp.Models;

namespace WebApp.Services
{
    /// <summary>
    /// Descripción breve de ExampleService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ExampleService : System.Web.Services.WebService
    {

        public SOAPKeyAuth sOAPKeyAuth;
        private ContentHTML contentHTML = new ContentHTML();
        private MessageVO messageVO = new MessageVO();

        /// <summary>
        /// Metodo para seleccionar Example
        /// </summary>
        /// <param name="id">Id Example</param>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para seleccionar Example")]
        [SoapHeader("sOAPKeyAuth")]
        public ExampleServiceSelect Select(int id)
        {
            ExampleServiceSelect exampleServiceSelect = new ExampleServiceSelect();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    exampleServiceSelect.MessageVO = messageVO;
                }
                else if (id <= 0)
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "id"));
                    exampleServiceSelect.MessageVO = messageVO;
                }
                else
                {
                    var entity = ExampleImpl.Select(id);
                    exampleServiceSelect.Example = entity;
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                exampleServiceSelect.MessageVO = messageVO;
            }
            return exampleServiceSelect;
        }

        /// <summary>
        /// Metodo para insertar Example
        /// </summary>
        /// <param name="exampleInsertDTO">Modelo ExampleInsertDTO</param>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para insertar Example")]
        [SoapHeader("sOAPKeyAuth")]
        public ExampleServiceInsert Insert(ExampleInsertDTO exampleInsertDTO)
        {
            ExampleServiceInsert exampleServiceInsert = new ExampleServiceInsert();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    exampleServiceInsert.MessageVO = messageVO;
                }
                else if (exampleInsertDTO == null)
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("nullObject").Replace("{0}", "ExampleInsertDTO"));
                    exampleServiceInsert.MessageVO = messageVO;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(exampleInsertDTO.Rut))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Rut"));
                    else if (exampleInsertDTO.Rut.Trim().Length > 12)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Rut").Replace("{1}", "12"));
                    else if (!Useful.ValidateRut(exampleInsertDTO.Rut))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("invalidFormatParameters").Replace("{0}", "Rut"));

                    if (string.IsNullOrWhiteSpace(exampleInsertDTO.Name))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Name"));
                    else if (exampleInsertDTO.Name.Trim().Length > 45)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Name").Replace("{1}", "45"));

                    if (string.IsNullOrWhiteSpace(exampleInsertDTO.LastName))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "LastName"));
                    else if (exampleInsertDTO.LastName.Trim().Length > 45)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "LastName").Replace("{1}", "45"));

                    if (!Useful.ValidateDateTimeOffset(exampleInsertDTO.BirthDate))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParametersNoInitialized").Replace("{0}", "BirthDate"));
                    else if (exampleInsertDTO.BirthDate > DateTimeOffset.Now)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParameterGreaterThanTheCurrentDate").Replace("{0}", "BirthDate"));

                    if (string.IsNullOrWhiteSpace(exampleInsertDTO.Password))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Password"));
                    else if (exampleInsertDTO.Password.Trim().Length > 16)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Password").Replace("{1}", "16"));

                    if (messageVO.Messages.Count() > 0)
                    {
                        messageVO.SetIdTitle(1, contentHTML.GetInnerTextById("requeridTitle"));
                        exampleServiceInsert.MessageVO = messageVO;
                    }
                    else
                    {
                        bool existsEntity = ExampleImpl.ExistsByRut(exampleInsertDTO.Rut.Replace(".", ""));
                        if (existsEntity)
                        {
                            messageVO.SetMessage(2, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("entityExistByParameter").Replace("{0}", "Example").Replace("{1}", "Rut"));
                            exampleServiceInsert.MessageVO = messageVO;
                        }
                        else
                        {
                            var entity = ExampleImpl.Insert(exampleInsertDTO);
                            exampleServiceInsert.Example = entity;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                exampleServiceInsert.MessageVO = messageVO;
            }
            return exampleServiceInsert;
        }

        /// <summary>
        /// Metodo para actualizar Example
        /// </summary>
        /// <param name="example">Modelo Example</param>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para actualizar Example")]
        [SoapHeader("sOAPKeyAuth")]
        public ExampleServiceUpdate Update(Example example)
        {
            ExampleServiceUpdate exampleServiceUpdate = new ExampleServiceUpdate();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    exampleServiceUpdate.MessageVO = messageVO;
                }
                else if (example == null)
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("nullObject").Replace("{0}", "Example"));
                    exampleServiceUpdate.MessageVO = messageVO;
                }
                else
                {
                    if (example.Id <= 0)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "Id"));

                    if (string.IsNullOrWhiteSpace(example.Rut))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Rut"));
                    else if (example.Rut.Trim().Length > 12)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Rut").Replace("{1}", "12"));
                    else if (!Useful.ValidateRut(example.Rut))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("invalidFormatParameters").Replace("{0}", "Rut"));

                    if (string.IsNullOrWhiteSpace(example.Name))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Name"));
                    else if (example.Name.Trim().Length > 45)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Name").Replace("{1}", "45"));

                    if (string.IsNullOrWhiteSpace(example.LastName))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "LastName"));
                    else if (example.LastName.Trim().Length > 45)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "LastName").Replace("{1}", "45"));

                    if (!Useful.ValidateDateTimeOffset(example.BirthDate))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParametersNoInitialized").Replace("{0}", "BirthDate"));
                    else if (example.BirthDate > DateTimeOffset.Now)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParameterGreaterThanTheCurrentDate").Replace("{0}", "BirthDate"));

                    if (string.IsNullOrWhiteSpace(example.Password))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Password"));
                    else if (example.Password.Trim().Length > 16)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Password").Replace("{1}", "16"));

                    if (messageVO.Messages.Count() > 0)
                    {
                        messageVO.SetIdTitle(1, contentHTML.GetInnerTextById("requeridTitle"));
                        exampleServiceUpdate.MessageVO = messageVO;
                    }
                    else
                    {
                        bool existByRutAndNotSameEntity = ExampleImpl.ExistByRutAndNotSameEntity(new ExampleExistByRutAndNotSameEntityDTO() { Id = example.Id, Rut = example.Rut.Replace(".", "") });
                        if (existByRutAndNotSameEntity)
                        {
                            messageVO.SetMessage(2, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("entityExistsByParameterAndIsNotTheSameEntity").Replace("{0}", "Example").Replace("{1}", "Rut").Replace("{2}", "Example"));
                            exampleServiceUpdate.MessageVO = messageVO;
                        }
                        else
                        {
                            var update = ExampleImpl.Update(example);
                            exampleServiceUpdate.Updated = update;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                exampleServiceUpdate.MessageVO = messageVO;
            }
            return exampleServiceUpdate;
        }

        /// <summary>
        /// Metodo para eliminar entidad Example
        /// </summary>
        /// <param name="id">Id Example</param>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para eliminar entidad Example")]
        [SoapHeader("sOAPKeyAuth")]
        public ExampleServiceDelete Delete(int id)
        {
            ExampleServiceDelete exampleServiceDelete = new ExampleServiceDelete();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    exampleServiceDelete.MessageVO = messageVO;
                }
                else if (id <= 0)
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "id"));
                    exampleServiceDelete.MessageVO = messageVO;
                }
                else
                {
                    var delete = ExampleImpl.Delete(id);
                    exampleServiceDelete.Delete = delete;
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                exampleServiceDelete.MessageVO = messageVO;
            }
            return exampleServiceDelete;
        }

        /// <summary>
        /// Metodo para listar Example
        /// </summary>
        /// <param name="exampleListDTO">Objeto</param>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para listar Example")]
        [SoapHeader("sOAPKeyAuth")]
        public ExampleServiceList List(ExampleListDTO exampleListDTO)
        {
            ExampleServiceList exampleServiceList = new ExampleServiceList();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    exampleServiceList.MessageVO = messageVO;
                }
                else if (exampleListDTO == null)
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("nullObject").Replace("{0}", "ExampleListDTO"));
                    exampleServiceList.MessageVO = messageVO;
                }
                else
                {
                    if (exampleListDTO.PageIndex <= 0)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "PageIndex"));

                    if (exampleListDTO.PageSize <= 0)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "PageIndex"));
                    else if (exampleListDTO.PageSize > Useful.GetPageSizeMaximun())
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLength").Replace("{0}", "PageSize").Replace("{1}", Useful.GetPageSizeMaximun().ToString()));

                    if (messageVO.Messages.Count() > 0)
                    {
                        messageVO.SetIdTitle(1, contentHTML.GetInnerTextById("requeridTitle"));
                        exampleServiceList.MessageVO = messageVO;
                    }
                    else
                    {
                        var entitys = ExampleImpl.List(exampleListDTO);
                        exampleServiceList.Examples = entitys;
                    }
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                exampleServiceList.MessageVO = messageVO;
            }
            return exampleServiceList;
        }

        /// <summary>
        /// Metodo para contar registros de entidad Example
        /// </summary>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para contar registros de entidad Example")]
        [SoapHeader("sOAPKeyAuth")]
        public ExampleServiceTotalRecords TotalRecords()
        {
            ExampleServiceTotalRecords exampleServiceTotalRecords = new ExampleServiceTotalRecords();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    exampleServiceTotalRecords.MessageVO = messageVO;
                }
                else
                {
                    var totalRecords = ExampleImpl.TotalRecords();
                    exampleServiceTotalRecords.TotalRecords = totalRecords;
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                exampleServiceTotalRecords.MessageVO = messageVO;
            }
            return exampleServiceTotalRecords;
        }

        /// <summary>
        /// Metodo para retornar Excel
        /// </summary>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para retornar Excel")]
        [SoapHeader("sOAPKeyAuth")]
        public ExampleServiceExcel Excel()
        {
            ExampleServiceExcel exampleServiceExcel = new ExampleServiceExcel();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    exampleServiceExcel.MessageVO = messageVO;
                }
                else
                {
                    var excel = ExampleImpl.Excel();
                    exampleServiceExcel.Excel = excel;
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                exampleServiceExcel.MessageVO = messageVO;
            }
            return exampleServiceExcel;
        }

        /// <summary>
        /// Metodo para retornar PDF
        /// </summary>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para retornar PDF")]
        [SoapHeader("sOAPKeyAuth")]
        public ExampleServicePDF PDF()
        {
            ExampleServicePDF exampleServicePDF = new ExampleServicePDF();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    exampleServicePDF.MessageVO = messageVO;
                }
                else
                {
                    var pdf = ExampleImpl.PDF();
                    exampleServicePDF.PDF = pdf;
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                exampleServicePDF.MessageVO = messageVO;
            }
            return exampleServicePDF;
        }
    }
}
