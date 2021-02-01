using _20210118_DemoDocumentacio.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProjecteTesting
{
    [TestClass]
    public class VehicleTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Vehicle v = new Vehicle("2342-XXX", 123123112, "Seat", "Leon");
            Assert.AreEqual("2342-XXX", v.Matricula);
            Assert.AreEqual(123123112, v.NumeroBastidor);
            Assert.AreEqual("Seat", v.Marca);
            Assert.AreEqual("Leon", v.Model);
        }


        [TestMethod]
        public void TestConstructorAmbErrors()
        {
            bool testErroni = false;
            try
            {
                Vehicle v = new Vehicle("2342-XXX", 123123112, "Se", "Leon");
                testErroni = true;                
            } catch(Exception e)
            {
                // ok !
            }
            if(testErroni) Assert.Fail("No es valida correctament la marca");


            
            try
            {
                Vehicle v = new Vehicle("2342-XXX", 123123112, null, "Leon");
                testErroni = true;
            }
            catch (Exception e)
            {
                // ok !
            }
            if (testErroni) Assert.Fail("No es valida correctament la marca");

        }
    }
}