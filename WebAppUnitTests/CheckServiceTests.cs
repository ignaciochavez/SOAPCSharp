using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Services;
using Business.Tool;
using WebApp.Configurations;

namespace WebAppUnitTests
{
    [TestClass]
    public class CheckServiceTests
    {
        string key = Useful.GetAppSettings("KeyHeader");

        /// <summary>
        /// Verificar que el metodo api/check/check funciona correctamente
        /// </summary>
        [TestMethod]
        public void CheckControllerCheckMethodIsCorrect()
        {
            CheckService checkService = new CheckService();
            MessageVO messageVO = checkService.Check();
            Assert.IsNotNull(messageVO);
            checkService.Dispose();
        }

        /// <summary>
        /// Verificar que el metodo api/check/checkauth funciona correctamente
        /// </summary>
        [TestMethod]
        public void CheckControllerCheckAuthMethodIsCorrect()
        {
            CheckService checkService = new CheckService();
            checkService.sOAPKeyAuth = new SOAPKeyAuth(key);
            MessageVO messageVO = checkService.CheckAuth();
            Assert.IsNotNull(messageVO);
            checkService.Dispose();
        }
    }
}
