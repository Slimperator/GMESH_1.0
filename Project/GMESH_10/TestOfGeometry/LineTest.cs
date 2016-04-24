using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestOfGeometry
{
    
    
    /// <summary>
    ///Это класс теста для LineTest, в котором должны
    ///находиться все модульные тесты LineTest
    ///</summary>
    [TestClass()]
    public class LineTest
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
        ///Тест для getPoint
        ///</summary>
        [TestMethod()]
        public void getPointTest1()
        {
            IPoint L1 = new Point(0, 0); // TODO: инициализация подходящего значения
            IPoint L2 = new Point(1, 1); // TODO: инициализация подходящего значения
            Line target = new Line(L1, L2); // TODO: инициализация подходящего значения
            double t = 0F; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 0; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 0; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);
         
        }
        [TestMethod()]
        public void getPointTest2()
        {
            IPoint L1 = new Point(0, 0); // TODO: инициализация подходящего значения
            IPoint L2 = new Point(2, 1); // TODO: инициализация подходящего значения
            Line target = new Line(L1, L2); // TODO: инициализация подходящего значения
            double t = 1F; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 2; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 1; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);

        }
        [TestMethod()]
        public void getPointTest3()
        {
            IPoint L1 = new Point(0, 0); // TODO: инициализация подходящего значения
            IPoint L2 = new Point(20, 10); // TODO: инициализация подходящего значения
            Line target = new Line(L1, L2); // TODO: инициализация подходящего значения
            double t = 0.5F; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 10.0; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 5.0; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);

        }
        [TestMethod()]
        public void getPointTest4()
        {
            IPoint L1 = new Point(10, 30); // TODO: инициализация подходящего значения
            IPoint L2 = new Point(20, 10); // TODO: инициализация подходящего значения
            Line target = new Line(L1, L2); // TODO: инициализация подходящего значения
            double t = 0.1F; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 11.0; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 28.0; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x, 0.001);
            Assert.AreEqual(yExpected, y, 0.001);

        }

        /// <summary>
        ///Тест для Конструктор Line
        ///</summary>
        [TestMethod()]
        public void LineConstructorTest()
        {
            IPoint L1 = new Point(0, 0); // TODO: инициализация подходящего значения
            IPoint L2 = new Point(0, 0); // TODO: инициализация подходящего значения
            Line target = new Line(L1, L2);
     
        }
    }
}
