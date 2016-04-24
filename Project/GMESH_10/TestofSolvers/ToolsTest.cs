using Solvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Geometry;

namespace TestOfSolvers
{
    
    
    /// <summary>
    ///Это класс теста для ToolsTest, в котором должны
    ///находиться все модульные тесты ToolsTest
    ///</summary>
    [TestClass()]
    public class ToolsTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты теста
        // 
        //При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        //ClassInitialize используется для выполнения кода до запуска первого теста в классе
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //TestInitialize используется для выполнения кода перед запуском каждого теста
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //TestCleanup используется для выполнения кода после завершения каждого теста
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Тест для getParam
        ///</summary>
        [TestMethod()]
        public void getParamTest()
        {
            ICurve curve = new Line(new Point(0, 0), new Point(0, 0)); // TODO: инициализация подходящего значения
            double length = 0F; // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = Tools.getParam(curve, length);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для length
        ///</summary>
        [TestMethod()]
        public void lengthTest()
        {
            ICurve curve = new Line(new Point(0, 0), new Point(1, 0)); // TODO: инициализация подходящего значения
            double expected = 1F; // TODO: инициализация подходящего значения
            double actual;
            actual = Tools.length(curve);
            Assert.AreEqual(expected, actual);
            //  Assert.Inconclusive("Проверьте правильность этого метода теста.");

        }
             [TestMethod()]
        public void lengthTest1()
        {
            ICurve curve = new Line(new Point(0, 0), new Point(0, 8)); // TODO: инициализация подходящего значения
            double expected = 8F; // TODO: инициализация подходящего значения
            double actual;
            actual = Tools.length(curve);
            Assert.AreEqual(expected, actual, 0.001);
            //  Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }
    }
}
