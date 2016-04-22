using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestOfGeometry
{
    
    
    /// <summary>
    ///Это класс теста для CircleTest, в котором должны
    ///находиться все модульные тесты CircleTest
    ///</summary>
    [TestClass()]
    public class CircleTest
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
        ///Тест для Конструктор Circle
        ///</summary>
        [TestMethod()]
        public void CircleConstructorTest()
        {
            IPoint center = new Point(1, 1); // TODO: инициализация подходящего значения
            double radius = 5.0F; // TODO: инициализация подходящего значения
            Circle target = new Circle(center, radius);
          
        }

        /// <summary>
        ///Тест для getPoint
        ///</summary>
        [TestMethod()]
        public void getPointTest()
        {
            IPoint center = new Point(1, 1); // TODO: инициализация подходящего значения
            double radius = 5; // TODO: инициализация подходящего значения
            Circle target = new Circle(center, radius); // TODO: инициализация подходящего значения
            double t = 0.1; // TODO: инициализация подходящего значения
            double x = 0.0F; // TODO: инициализация подходящего значения
            double xExpected = 5.05; // TODO: инициализация подходящего значения
            double y = 0.0F; // TODO: инициализация подходящего значения
            double yExpected = 3.94; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x, 0.01);
            Assert.AreEqual(yExpected, y, 0.01);
        
        }
    }
}
