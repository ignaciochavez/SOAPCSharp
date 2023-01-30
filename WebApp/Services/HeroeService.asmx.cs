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
    /// Descripción breve de HeroeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class HeroeService : System.Web.Services.WebService
    {
        public SOAPKeyAuth sOAPKeyAuth;
        private ContentHTML contentHTML = new ContentHTML();
        private MessageVO messageVO = new MessageVO();

        /// <summary>
        /// Metodo para seleccionar Heroe
        /// </summary>
        /// <param name="id">Id Heroe</param>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para seleccionar Heroe")]
        [SoapHeader("sOAPKeyAuth")]
        public HeroeServiceSelect Select(int id)
        {
            HeroeServiceSelect heroeServiceSelect = new HeroeServiceSelect();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    heroeServiceSelect.MessageVO = messageVO;
                }
                else if (id <= 0)
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "id"));
                    heroeServiceSelect.MessageVO = messageVO;
                }
                else
                {
                    var entity = HeroeImpl.Select(id);
                    heroeServiceSelect.Heroe = entity;
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                heroeServiceSelect.MessageVO = messageVO;
            }
            return heroeServiceSelect;
        }

        /// <summary>
        /// Metodo para insertar Heroe
        /// </summary>
        /// <param name="heroeInsertDTO">Modelo HeroeInsertDTO</param>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para insertar Heroe")]
        [SoapHeader("sOAPKeyAuth")]
        public HeroeServiceInsert Insert(HeroeInsertDTO heroeInsertDTO)
        {
            HeroeServiceInsert heroeServiceInsert = new HeroeServiceInsert();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    heroeServiceInsert.MessageVO = messageVO;
                }
                else if (heroeInsertDTO == null)
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("nullObject").Replace("{0}", "HeroeInsertDTO"));
                    heroeServiceInsert.MessageVO = messageVO;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(heroeInsertDTO.Name))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Name"));
                    else if (heroeInsertDTO.Name.Trim().Length > 45)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Name").Replace("{1}", "45"));

                    if (string.IsNullOrWhiteSpace(heroeInsertDTO.Home))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Home"));
                    else if (heroeInsertDTO.Home.Trim().Length > 35)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Home").Replace("{1}", "35"));

                    if (!Useful.ValidateDateTimeOffset(heroeInsertDTO.Appearance))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParametersNoInitialized").Replace("{0}", "Appearance"));
                    else if (heroeInsertDTO.Appearance > DateTimeOffset.Now)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParameterGreaterThanTheCurrentDate").Replace("{0}", "Appearance"));

                    if (string.IsNullOrWhiteSpace(heroeInsertDTO.Description))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Description"));
                    else if (heroeInsertDTO.Description.Trim().Length > 450)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Description").Replace("{1}", "450"));

                    if (string.IsNullOrWhiteSpace(heroeInsertDTO.ImgBase64String))
                    {
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "ImgBase64String"));
                    }
                    else if (!Useful.ValidateBase64String(Useful.ReplaceConventionImageFromBase64String(heroeInsertDTO.ImgBase64String)))
                    {
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("invalidFormatParameters").Replace("{0}", "ImgBase64String"));
                    }
                    else
                    {

                        string[] arrayImgBase64String = heroeInsertDTO.ImgBase64String.Split(',');
                        if (!Useful.ValidateIsImageBase64String(arrayImgBase64String[0]))
                            messageVO.Messages.Add(contentHTML.GetInnerTextById("formatMustBe").Replace("{0}", "ImgBase64String").Replace("{1}", "bmp, emf, exif, gif, icon, jpeg, jpg, png, tiff o wmf"));

                    }

                    if (messageVO.Messages.Count() > 0)
                    {
                        messageVO.SetIdTitle(1, contentHTML.GetInnerTextById("requeridTitle"));
                        heroeServiceInsert.MessageVO = messageVO;
                    }
                    else
                    {
                        bool existsEntity = HeroeImpl.ExistByName(heroeInsertDTO.Name);
                        if (existsEntity)
                        {
                            messageVO.SetMessage(2, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("entityExistByParameter").Replace("{0}", "Heroe").Replace("{1}", "Name"));
                            heroeServiceInsert.MessageVO = messageVO;
                        }
                        else
                        {
                            var entity = HeroeImpl.Insert(heroeInsertDTO);
                            heroeServiceInsert.Heroe = entity;
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                heroeServiceInsert.MessageVO = messageVO;
            }
            return heroeServiceInsert;
        }

        /// <summary>
        /// Metodo para actualizar Heroe
        /// </summary>
        /// <param name="heroe">Modelo Heroe</param>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para actualizar Heroe")]
        [SoapHeader("sOAPKeyAuth")]
        public HeroeServiceUpdate Update(Heroe heroe)
        {
            HeroeServiceUpdate heroeServiceUpdate = new HeroeServiceUpdate();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    heroeServiceUpdate.MessageVO = messageVO;
                }   
                else if (heroe == null)
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("nullObject").Replace("{0}", "Heroe"));
                    heroeServiceUpdate.MessageVO = messageVO;
                }
                else
                {
                    if (heroe.Id <= 0)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "Id"));

                    if (string.IsNullOrWhiteSpace(heroe.Name))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Name"));
                    else if (heroe.Name.Trim().Length > 45)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Name").Replace("{1}", "45"));

                    if (string.IsNullOrWhiteSpace(heroe.Home))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Home"));
                    else if (heroe.Home.Trim().Length > 35)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Home").Replace("{1}", "35"));

                    if (!Useful.ValidateDateTimeOffset(heroe.Appearance))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParametersNoInitialized").Replace("{0}", "Appearance"));
                    else if (heroe.Appearance > DateTimeOffset.Now)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParameterGreaterThanTheCurrentDate").Replace("{0}", "Appearance"));

                    if (string.IsNullOrWhiteSpace(heroe.Description))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Description"));
                    else if (heroe.Description.Trim().Length > 450)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Description").Replace("{1}", "450"));

                    if (string.IsNullOrWhiteSpace(heroe.ImgBase64String))
                    {
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "ImgBase64String"));
                    }
                    else if (!Useful.ValidateBase64String(Useful.ReplaceConventionImageFromBase64String(heroe.ImgBase64String)))
                    {
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("invalidFormatParameters").Replace("{0}", "ImgBase64String"));
                    }
                    else
                    {

                        string[] arrayImgBase64String = heroe.ImgBase64String.Split(',');
                        if (!Useful.ValidateIsImageBase64String(arrayImgBase64String[0]))
                            messageVO.Messages.Add(contentHTML.GetInnerTextById("formatMustBe").Replace("{0}", "ImgBase64String").Replace("{1}", "bmp, emf, exif, gif, icon, jpeg, jpg, png, tiff o wmf"));

                    }

                    if (messageVO.Messages.Count() > 0)
                    {
                        messageVO.SetIdTitle(1, contentHTML.GetInnerTextById("requeridTitle"));
                        heroeServiceUpdate.MessageVO = messageVO;
                    }
                    else
                    {
                        bool existByNameAndNotSameEntity = HeroeImpl.ExistByNameAndNotSameEntity(new HeroeExistByNameAndNotSameEntityDTO() { Id = heroe.Id, Name = heroe.Name });
                        if (existByNameAndNotSameEntity)
                        {
                            messageVO.SetMessage(2, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("entityExistsByParameterAndIsNotTheSameEntity").Replace("{0}", "Heroe").Replace("{1}", "Name").Replace("{2}", "Heroe"));
                            heroeServiceUpdate.MessageVO = messageVO;
                        }
                        else
                        {
                            var update = HeroeImpl.Update(heroe);
                            heroeServiceUpdate.Update = update;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                heroeServiceUpdate.MessageVO = messageVO;
            }
            return heroeServiceUpdate;
        }

        /// <summary>
        /// Metodo para eliminar entidad Heroe
        /// </summary>
        /// <param name="id">Id Heroe</param>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para eliminar entidad Heroe")]
        [SoapHeader("sOAPKeyAuth")]
        public HeroeServiceDelete Delete(int id)
        {
            HeroeServiceDelete heroeServiceDelete = new HeroeServiceDelete();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    heroeServiceDelete.MessageVO = messageVO;
                }
                else if (id <= 0)
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "id"));
                    heroeServiceDelete.MessageVO = messageVO;
                }
                else
                {
                    var delete = HeroeImpl.Delete(id);
                    heroeServiceDelete.Delete = delete;
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                heroeServiceDelete.MessageVO = messageVO;
            }
            return heroeServiceDelete;
        }

        /// <summary>
        /// Metodo para listar Heroe
        /// </summary>
        /// <param name="heroeListDTO">Modelo HeroeListDTO</param>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para listar Heroe")]
        [SoapHeader("sOAPKeyAuth")]
        public HeroeServiceList List(HeroeListDTO heroeListDTO)
        {
            HeroeServiceList heroeServiceList = new HeroeServiceList();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    heroeServiceList.MessageVO = messageVO;
                }
                else if (heroeListDTO == null)
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("nullObject").Replace("{0}", "HeroeListDTO"));
                    heroeServiceList.MessageVO = messageVO;
                }
                else
                {
                    if (heroeListDTO.PageIndex <= 0)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "PageIndex"));

                    if (heroeListDTO.PageSize <= 0)
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "PageSize"));
                    else if (heroeListDTO.PageSize > Useful.GetPageSizeMaximun())
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLength").Replace("{0}", "PageSize").Replace("{1}", Useful.GetPageSizeMaximun().ToString()));

                    if (messageVO.Messages.Count() > 0)
                    {
                        messageVO.SetIdTitle(1, contentHTML.GetInnerTextById("requeridTitle"));
                        heroeServiceList.MessageVO = messageVO;
                    }
                    else
                    {
                        var entitys = HeroeImpl.List(heroeListDTO);
                        heroeServiceList.Heroes = entitys;
                    }
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                heroeServiceList.MessageVO = messageVO;
            }
            return heroeServiceList;
        }

        /// <summary>
        /// Metodo para contar registros de entidad Heroe
        /// </summary>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para contar registros de entidad Heroe")]
        [SoapHeader("sOAPKeyAuth")]
        public HeroeServiceTotalRecords TotalRecords()
        {
            HeroeServiceTotalRecords heroeServiceTotalRecords = new HeroeServiceTotalRecords();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    heroeServiceTotalRecords.MessageVO = messageVO;
                }
                else
                {
                    var totalRecords = HeroeImpl.TotalRecords();
                    heroeServiceTotalRecords.TotalRecordss = totalRecords;
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                heroeServiceTotalRecords.MessageVO = messageVO;
            }
            return heroeServiceTotalRecords;
        }

        /// <summary>
        /// Metodo para retornar Excel
        /// </summary>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para retornar Excel")]
        [SoapHeader("sOAPKeyAuth")]
        public HeroeServiceExcel Excel()
        {
            HeroeServiceExcel heroeServiceExcel = new HeroeServiceExcel();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    heroeServiceExcel.MessageVO = messageVO;
                }
                else
                {
                    var excel = HeroeImpl.Excel();
                    heroeServiceExcel.Excel = excel;
                }                
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                heroeServiceExcel.MessageVO = messageVO;
            }
            return heroeServiceExcel;
        }

        /// <summary>
        ///  Metodo para retornar PDF
        /// </summary>
        /// <returns>Retorna el objeto</returns>
        [WebMethod(Description = "Metodo para retornar PDF")]
        [SoapHeader("sOAPKeyAuth")]
        public HeroeServicePDF PDF()
        {
            HeroeServicePDF heroeServicePDF = new HeroeServicePDF();
            try
            {
                if (sOAPKeyAuth == null || (sOAPKeyAuth != null && !sOAPKeyAuth.IsAuthorized()))
                {
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("notAuthorizedTitle"), contentHTML.GetInnerTextById("notAuthorized"));
                    heroeServicePDF.MessageVO = messageVO;
                }
                else
                {
                    var pdf = HeroeImpl.PDF();
                    heroeServicePDF.PDF = pdf;
                }                
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                heroeServicePDF.MessageVO = messageVO;
            }
            return heroeServicePDF;
        }
    }
}
