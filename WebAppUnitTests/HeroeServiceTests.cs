using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business.Tool;
using WebApp.Services;
using WebApp.Models;
using Business.DTO;
using Business.Entity;
using WebApp.Configurations;

namespace WebAppUnitTests
{
    [TestClass]
    public class HeroeServiceTests
    {
        string key = Useful.GetAppSettings("KeyHeader");

        #region Select

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Select funciona segun lo necesitado al enviar parametros vacios
        /// </summary>
        [TestMethod]
        public void HeroeServiceSelectMethodIsEmptyParameters()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceSelect heroeServiceSelect = heroeService.Select(0);
            Assert.IsNotNull(heroeServiceSelect.MessageVO);
            heroeService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Select funciona segun lo necesitado al enviar parametros correctos en donde la entidad no existe
        /// </summary>
        [TestMethod]
        public void HeroeServiceSelectMethodIsCorrectAndNotExist()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);            
            HeroeServiceSelect heroeServiceSelect = heroeService.Select(100);
            Assert.IsNull(heroeServiceSelect.Heroe);
            heroeService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Select funciona segun lo necesitado al enviar parametros correctos en donde la entidad existe
        /// </summary>
        [TestMethod]
        public void HeroeServiceSelectMethodIsCorrect()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);            
            HeroeServiceSelect heroeServiceSelect = heroeService.Select(2);
            Assert.IsNotNull(heroeServiceSelect.Heroe);
            heroeService.Dispose();
        }

        #endregion

        #region Insert

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Insert funciona segun lo necesitado al enviar el objecto nulo
        /// </summary>
        [TestMethod]
        public void HeroeServiceInsertMethodIsNullObject()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);            
            HeroeServiceInsert heroeServiceInsert = heroeService.Insert(null);
            Assert.IsNotNull(heroeServiceInsert.MessageVO);
            heroeService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Insert funciona segun lo necesitado al enviar el objecto con parametros vacios
        /// </summary>
        [TestMethod]
        public void HeroeServiceInsertMethodIsEmptyParametersOfObject()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);            
            HeroeServiceInsert heroeServiceInsert = heroeService.Insert(new HeroeInsertDTO(string.Empty, string.Empty, DateTimeOffset.MinValue, string.Empty, string.Empty));
            Assert.IsNotNull(heroeServiceInsert.MessageVO);
            heroeService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Insert funciona segun lo necesitado al enviar parametros invalidos
        /// </summary>
        [TestMethod]
        public void HeroeServiceInsertMethodIsInvalidParametersOfObject()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceInsert heroeServiceInsert = heroeService.Insert(new HeroeInsertDTO("Test Test Test Test Test Test Test Test Test Test", "Test Test Test Test Test Test Test Test", DateTimeOffset.Now.AddDays(1), Useful.GetPngToBase64String($"{Useful.GetApplicationDirectory()}Contents\\soap-200.png"), "1234asdf"));
            Assert.IsNotNull(heroeServiceInsert.MessageVO);
            heroeService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Insert funciona segun lo necesitado al enviar el objecto con parametros correctos en donde la entidad existe y no se inserta
        /// </summary>
        [TestMethod]
        public void HeroeServiceInsertMethodIsExist()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceInsert heroeServiceInsert = heroeService.Insert(new HeroeInsertDTO("Batman", "DC", new DateTimeOffset(new DateTime(1941, 11, 1)), "El poder más reconocido de Aquaman es la capacidad telepática para comunicarse con la vida marina, la cual puede convocar a grandes distancias.", Useful.GetPngToBase64String($"{Useful.GetApplicationDirectory()}Contents\\soap-200.png")));
            Assert.IsNotNull(heroeServiceInsert.MessageVO);
            heroeService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Insert funciona segun lo necesitado al enviar el objecto con parametros correctos en donde la entidad no existe y se inserta
        /// </summary>
        [TestMethod]
        public void HeroeServiceInsertMethodIsCorrect()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceInsert heroeServiceInsert = heroeService.Insert(new HeroeInsertDTO("Thor", "Marvel", new DateTimeOffset(new DateTime(1962, 8, 1)), "El personaje, que se basa en la deidad nórdica homónima, es el dios del trueno asgardiano poseedor del martillo encantado, Mjolnir, que le otorga capacidad de volar y manipular el clima entre sus otros atributos sobrehumanos, además de concentrar su poder.", Useful.GetPngToBase64String($"{Useful.GetApplicationDirectory()}Contents\\soap-200.png")));
            Assert.IsNotNull(heroeServiceInsert.Heroe);
            heroeService.Dispose();
        }

        #endregion

        #region Update

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Update funciona segun lo necesitado al enviar el objecto nulo
        /// </summary>
        [TestMethod]
        public void HeroeServiceUpdateMethodIsNullObject()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceUpdate heroeServiceUpdate = heroeService.Update(null);
            Assert.IsNotNull(heroeServiceUpdate.MessageVO);
            heroeService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Update funciona segun lo necesitado al enviar el objecto con parametros vacios
        /// </summary>
        [TestMethod]
        public void HeroeServiceUpdateMethodIsEmptyParametersOfObject()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceUpdate heroeServiceUpdate = heroeService.Update(new Heroe(0, string.Empty, string.Empty, DateTimeOffset.MinValue, string.Empty, string.Empty));
            Assert.IsNotNull(heroeServiceUpdate.MessageVO);
            heroeService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Update funciona segun lo necesitado al enviar parametros invalidos
        /// </summary>
        [TestMethod]
        public void HeroeServiceUpdateMethodIsInvalidParametersOfObject()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceUpdate heroeServiceUpdate = heroeService.Update(new Heroe(-1, "Test Test Test Test Test Test Test Test Test Test", "Test Test Test Test Test Test Test Test", DateTimeOffset.Now.AddDays(1), Useful.GetPngToBase64String($"{Useful.GetApplicationDirectory()}Contents\\soap-200.png"), "1234asdf"));
            Assert.IsNotNull(heroeServiceUpdate.MessageVO);
            heroeService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Update funciona segun lo necesitado al enviar el objecto con parametros correctos en donde la entidad no existe y no se actualiza
        /// </summary>
        [TestMethod]
        public void HeroeServiceUpdateMethodIsNotExist()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceUpdate heroeServiceUpdate = heroeService.Update(new Heroe(100, "Superman", "DC", new DateTimeOffset(new DateTime(1938, 6, 1)), "Superman es un hombre alto, musculoso, hombre de raza blanca con ojos azules y pelo negro corto con un rizo. Tiene habilidades sobrehumanas, como una fuerza increíble y una piel impermeable.", Useful.GetPngToBase64String($"{Useful.GetApplicationDirectory()}Contents\\soap-200.png")));
            Assert.IsFalse(heroeServiceUpdate.Update);
            heroeService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Update funciona segun lo necesitado al enviar el objecto con parametros correctos en donde la entidad existe y se actualiza
        /// </summary>
        [TestMethod]
        public void HeroeServiceUpdateMethodIsCorrect()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceUpdate heroeServiceUpdate = heroeService.Update(new Heroe(2, "DC", "Batman", new DateTimeOffset(new DateTime(1941, 11, 1)), "El poder más reconocido de Aquaman es la capacidad telepática para comunicarse con la vida marina, la cual puede convocar a grandes distancias.", Useful.GetPngToBase64String($"{Useful.GetApplicationDirectory()}Contents\\IMG\\batman.png")));
            Assert.IsTrue(heroeServiceUpdate.Update);
            heroeService.Dispose();
        }

        #endregion

        #region Delete

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Delete funciona segun lo necesitado al enviar parametros invalidos
        /// </summary>
        [TestMethod]
        public void HeroeServiceDeleteMethodIsInvalidParameters()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceDelete heroeServiceDelete = heroeService.Delete(0);
            Assert.IsNotNull(heroeServiceDelete.MessageVO);
            heroeService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Delete funciona segun lo necesitado al enviar parametros correctos en donde la entidad no existe
        /// </summary>
        [TestMethod]
        public void HeroeServiceDeleteMethodIsCorrectAndNotExist()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceDelete heroeServiceDelete = heroeService.Delete(100);
            Assert.IsFalse(heroeServiceDelete.Delete);
            heroeService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Delete funciona segun lo necesitado al enviar parametros correctos en donde la entidad existe
        /// </summary>
        [TestMethod]
        public void HeroeServiceDeleteMethodIsCorrect()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceDelete heroeServiceDelete = heroeService.Delete(1);
            Assert.IsTrue(heroeServiceDelete.Delete);
            heroeService.Dispose();
        }

        #endregion

        #region List

        /// <summary>
        /// Verificar que el metodo Services/Heroe/List funciona segun lo necesitado al enviar el objecto nulo
        /// </summary>
        [TestMethod]
        public void HeroeServiceListMethodIsNullObject()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceList heroeServiceList = heroeService.List(null);
            Assert.IsNotNull(heroeServiceList.MessageVO);
            heroeService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/Heroe/List funciona segun lo necesitado al enviar el objecto con parametros invalidos
        /// </summary>
        [TestMethod]
        public void HeroeServiceListMethodIsInvalidParametersOfObject()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceList heroeServiceList = heroeService.List(new HeroeListDTO(0, 0));
            Assert.IsNotNull(heroeServiceList.MessageVO);
            heroeService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo Services/Heroe/List funciona segun lo necesitado al enviar el objecto con parametros correctos
        /// </summary>
        [TestMethod]
        public void HeroeServiceListMethodIsCorrect()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceList heroeServiceList = heroeService.List(new HeroeListDTO(1, 10));
            Assert.IsNotNull(heroeServiceList.Heroes);
            heroeService.Dispose();
        }

        #endregion

        #region TotalRecords

        /// <summary>
        /// Verificar que el metodo Services/Heroe/TotalRecords funciona segun lo necesitado
        /// </summary>
        [TestMethod]
        public void HeroeServiceTotalRecordsMethodIsCorrect()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceTotalRecords heroeServiceTotalRecords = heroeService.TotalRecords();
            Assert.AreNotEqual(heroeServiceTotalRecords.TotalRecords, 0);
            heroeService.Dispose();
        }

        #endregion

        #region Excel

        /// <summary>
        /// Verificar que el metodo Services/Heroe/Excel funciona segun lo necesitado
        /// </summary>
        [TestMethod]
        public void HeroeServiceExcelMethodIsCorrect()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServiceExcel heroeServiceExcel = heroeService.Excel();
            Assert.IsNotNull(heroeServiceExcel.Excel);
            heroeService.Dispose();
        }

        #endregion

        #region PDF

        /// <summary>
        /// Verificar que el metodo Services/Heroe/PDF funciona segun lo necesitado
        /// </summary>
        [TestMethod]
        public void HeroeServicePDFMethodIsCorrect()
        {
            HeroeService heroeService = new HeroeService();
            heroeService.sOAPKeyAuth = new SOAPKeyAuth(key);
            HeroeServicePDF heroeServicePDF = heroeService.PDF();
            Assert.IsNotNull(heroeServicePDF.PDF);
            heroeService.Dispose();
        }

        #endregion

    }
}
