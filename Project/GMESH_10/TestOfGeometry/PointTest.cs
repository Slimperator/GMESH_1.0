using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestOfGeometry
{
    
    
    /// <summary>
    ///Это класс теста для PointTest, в котором должны
    ///находиться все модульные тесты PointTest
    ///</summary>
    [TestClass()]
    public class PointTest
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
        ///Тест для Конструктор Point
        ///</summary>
        [TestMethod()]
        public void PointConstructorTest()
        {
            double x = 0F; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            Point target = new Point(x, y);

        }

        /// <summary>
        ///Тест для X
        ///</summary>
        [TestMethod()]
        public void XTest()
        {
            double x = 5F; // TODO: инициализация подходящего значения
            double y = 8F; // TODO: инициализация подходящего значения
            Point target = new Point(x, y); // TODO: инициализация подходящего значения
            double expected = 5F; // TODO: инициализация подходящего значения
            double actual;
            target.X = expected;
            actual = target.X;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///Тест для Y
        ///</summary>
        [TestMethod()]
        public void YTest()
        {
            double x = 4F; // TODO: инициализация подходящего значения
            double y = 3F; // TODO: инициализация подходящего значения
            Point target = new Point(x, y); // TODO: инициализация подходящего значения
            double expected = 3F; // TODO: инициализация подходящего значения
            double actual;
            target.Y = expected;
            actual = target.Y;
            Assert.AreEqual(expected, actual);
            
        }
    }
}
