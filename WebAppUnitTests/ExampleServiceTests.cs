using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Services;
using WebApp.Configurations;
using Business.Tool;
using WebApp.Models;
using Business.DTO;
using Business.Entity;

namespace WebAppUnitTests
{
    [TestClass]
    public class ExampleServiceTests
    {
        string key = Useful.GetAppSettings("KeyHeader");

        #region Select

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Select funciona segun lo necesitado al enviar parametros invalidos
        /// </summary>
        [TestMethod]
        public void ExampleServiceSelectMethodIsEmptyParameters()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceSelect exampleServiceSelect = exampleService.Select(0);
            Assert.IsNotNull(exampleServiceSelect.MessageVO);
            exampleService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Select funciona segun lo necesitado al enviar parametros correctos en donde la entidad no existe
        /// </summary>
        [TestMethod]
        public void ExampleServiceSelectMethodIsCorrectAndNotExist()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceSelect exampleServiceSelect = exampleService.Select(100);
            Assert.IsNull(exampleServiceSelect.Example);
            exampleService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Select funciona segun lo necesitado al enviar parametros correctos en donde la entidad existe
        /// </summary>
        [TestMethod]
        public void ExampleServiceSelectMethodIsCorrect()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceSelect exampleServiceSelect = exampleService.Select(1);
            Assert.IsNotNull(exampleServiceSelect.Example);
            exampleService.Dispose();
        }

        #endregion

        #region Insert

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Insert funciona segun lo necesitado al enviar el objeto nulo
        /// </summary>
        [TestMethod]
        public void ExampleServiceInsertMethodIsNullObject()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceInsert exampleServiceInsert = exampleService.Insert(null);
            Assert.IsNotNull(exampleServiceInsert.MessageVO);
            exampleService.Dispose();
        }

        /// <summary>
        /// Verificar que el Services/ExampleService/Insert funciona segun lo necesitado al enviar el objeto con parametros vacios
        /// </summary>
        [TestMethod]
        public void ExampleServiceInsertMethodIsEmptyParametersOfObject()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceInsert exampleServiceInsert = exampleService.Insert(new ExampleInsertDTO(string.Empty, string.Empty, string.Empty, DateTimeOffset.MinValue, false, string.Empty));
            Assert.IsNotNull(exampleServiceInsert.MessageVO);
            exampleService.Dispose();

        }

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Insert funciona segun lo necesitado al enviar el objeto con parametros invalidos
        /// </summary>
        [TestMethod]
        public void ExampleServiceInsertMethodIsInvalidParametersOfObject()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceInsert exampleServiceInsert = exampleService.Insert(new ExampleInsertDTO("12332231123", "Test Test Test Test Test Test Test Test Test Test", "Test Test Test Test Test Test Test Test Test Test", DateTimeOffset.Now.AddDays(1), false, "Test Test Test Test"));
            Assert.IsNotNull(exampleServiceInsert.MessageVO);
            exampleService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Insert funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad existe y no se inserta
        /// </summary>
        [TestMethod]
        public void ExampleServiceInsertMethodIsExist()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceInsert exampleServiceInsert = exampleService.Insert(new ExampleInsertDTO("1-9", "Pedro", "Gutierrez", DateTimeOffset.UtcNow.Date, true, "1234qwer"));
            Assert.IsNotNull(exampleServiceInsert.MessageVO);
            exampleService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Insert funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad no existe y se inserta
        /// </summary>
        [TestMethod]
        public void ExampleServiceInsertMethodIsCorrect()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceInsert exampleServiceInsert = exampleService.Insert(new ExampleInsertDTO("76-0", "Emanuel", "Leiva", DateTimeOffset.UtcNow.Date, true, "4321rewq"));
            Assert.IsNotNull(exampleServiceInsert.Example);
            exampleService.Dispose();
        }

        #endregion

        #region Update

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Update funciona segun lo necesitado al enviar el objeto nulo
        /// </summary>
        [TestMethod]
        public void ExampleServiceUpdateMethodIsNullObject()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceUpdate exampleServiceUpdate = exampleService.Update(null);
            Assert.IsNotNull(exampleServiceUpdate.MessageVO);
            exampleService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Update funciona segun lo necesitado al enviar el objeto con parametros vacios
        /// </summary>
        [TestMethod]
        public void ExampleServiceUpdateMethodIsEmptyParametersOfObject()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceUpdate exampleServiceUpdate = exampleService.Update(new Example(0, string.Empty, string.Empty, string.Empty, DateTimeOffset.MinValue, false, string.Empty));
            Assert.IsNotNull(exampleServiceUpdate.MessageVO);
            exampleService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Update funciona segun lo necesitado al enviar el objeto con parametros invalidos
        /// </summary>
        [TestMethod]
        public void ExampleServiceUpdateMethodIsInvalidParametersOfObject()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceUpdate exampleServiceUpdate = exampleService.Update(new Example(0, "12332231123123", "Test Test Test Test Test Test Test Test Test Test", "Test Test Test Test Test Test Test Test Test Test", DateTimeOffset.Now.AddDays(1), false, "Test Test Test Test"));
            Assert.IsNotNull(exampleServiceUpdate.MessageVO);
            exampleService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Update funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad no existe y no se actualiza
        /// </summary>
        [TestMethod]
        public void ExampleServiceUpdateMethodIsNotExist()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceUpdate exampleServiceUpdate = exampleService.Update(new Example(100, "77-9", "Leonel", "Gonzalez", DateTimeOffset.UtcNow.Date, true, "vcxz9876"));
            Assert.IsFalse(exampleServiceUpdate.Updated);
            exampleService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Update funciona segun lo necesitado al enviar el objeto con parametros correctos en donde la entidad existe y se actualiza
        /// </summary>
        [TestMethod]
        public void ExampleServiceUpdateMethodIsCorrect()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceUpdate exampleServiceUpdate = exampleService.Update(new Example(2, "2-7", "Pedro", "Gutierrez", DateTimeOffset.UtcNow.Date, true, "1234qwer"));
            Assert.IsTrue(exampleServiceUpdate.Updated);
            exampleService.Dispose();
        }

        #endregion

        #region Delete

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Delete funciona segun lo necesitado al enviar parametros invalidos
        /// </summary>
        [TestMethod]
        public void ExampleServiceDeleteMethodIsInvalidParameters()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceDelete exampleServiceDelete = exampleService.Delete(0);
            Assert.IsNotNull(exampleServiceDelete.MessageVO);
            exampleService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Delete funciona segun lo necesitado al enviar parametros correctos en donde la entidad no existe
        /// </summary>
        [TestMethod]
        public void ExampleServiceDeleteMethodIsCorrectAndNotExist()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceDelete exampleServiceDelete = exampleService.Delete(100);
            Assert.IsFalse(exampleServiceDelete.Delete);
            exampleService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Delete funciona segun lo necesitado al enviar parametros correctos en donde la entidad existe
        /// </summary>
        [TestMethod]
        public void ExampleServiceDeleteMethodIsCorrect()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceDelete exampleServiceDelete = exampleService.Delete(1);
            Assert.IsTrue(exampleServiceDelete.Delete);
            exampleService.Dispose();
        }

        #endregion

        #region List

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/List funciona segun lo necesitado al enviar el objeto nulo
        /// </summary>
        [TestMethod]
        public void ExampleServiceListMethodIsNullObject()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceList exampleServiceList = exampleService.List(null);
            Assert.IsNotNull(exampleServiceList.MessageVO);
            exampleService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/List funciona segun lo necesitado al enviar el objeto con parametros invalidos
        /// </summary>
        [TestMethod]
        public void ExampleServiceListMethodIsInvalidParametersOfObject()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceList exampleServiceList = exampleService.List(new ExampleListDTO(0, 0));
            Assert.IsNotNull(exampleServiceList.MessageVO);
            exampleService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/List funciona segun lo necesitado al enviar el objeto con parametros correctos
        /// </summary>
        [TestMethod]
        public void ExampleServiceListMethodIsCorrect()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceList exampleServiceList = exampleService.List(new ExampleListDTO(1, 10));
            Assert.IsNotNull(exampleServiceList.Examples);
            exampleService.Dispose();
        }

        #endregion

        #region TotalRecords

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/TotalRecords funciona segun lo necesitado
        /// </summary>
        [TestMethod]
        public void ExampleServiceTotalRecordsMethodIsCorrect()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceTotalRecords exampleServiceTotalRecords = exampleService.TotalRecords();
            Assert.AreNotEqual(exampleServiceTotalRecords.TotalRecords, 0);
            exampleService.Dispose();
        }

        #endregion

        #region Excel

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/Excel funciona segun lo necesitado
        /// </summary>
        [TestMethod]
        public void ExampleServiceExcelMethodIsCorrect()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServiceExcel exampleServiceExcel = exampleService.Excel();
            Assert.IsNotNull(exampleServiceExcel.Excel);
            exampleService.Dispose();
        }

        #endregion

        #region PDF

        /// <summary>
        /// Verificar que el metodo Services/ExampleService/PDF funciona segun lo necesitado
        /// </summary>
        [TestMethod]
        public void ExampleServicePDFMethodIsCorrect()
        {
            ExampleService exampleService = new ExampleService();
            exampleService.sOAPKeyAuth = new SOAPKeyAuth(key);
            ExampleServicePDF exampleServicePDF = exampleService.PDF();
            Assert.IsNotNull(exampleServicePDF.PDF);
            exampleService.Dispose();
        }

        #endregion
    }
}
