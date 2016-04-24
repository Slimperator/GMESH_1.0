using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestOfGeometry
{


    /// <summary>
    ///Это класс теста для BezierTest, в котором должны
    ///находиться все модульные тесты BezierTest
    ///</summary>
    [TestClass()]
    public class BezierTest
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
        public void getPointTest()
        {
            IPoint P0 = new Point(0, 0); // TODO: инициализация подходящего значения
            IPoint P1 = new Point(1, 0); // TODO: инициализация подходящего значения
            IPoint P2 = new Point(2, 0); // TODO: инициализация подходящего значения
            IPoint P3 = new Point(3, 0); // TODO: инициализация подходящего значения
            Bezier target = new Bezier(P0, P1, P2, P3); // TODO: инициализация подходящего значения
            double t = 0.5; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 1.5; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 0F; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);

        }

        [TestMethod()]
        public void getPointTest1()
        {
            IPoint P0 = new Point(0, 0); // TODO: инициализация подходящего значения
            IPoint P1 = new Point(10, 10); // TODO: инициализация подходящего значения
            IPoint P2 = new Point(2, 1); // TODO: инициализация подходящего значения
            IPoint P3 = new Point(3, 1); // TODO: инициализация подходящего значения
            Bezier target = new Bezier(P0, P1, P2, P3); // TODO: инициализация подходящего значения
            double t = 0.5; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 4.875; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 7.75; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);

        }
        [TestMethod()]
        public void getPointTest2()
        {
            IPoint P0 = new Point(0, 1); // TODO: инициализация подходящего значения
            IPoint P1 = new Point(10, 10); // TODO: инициализация подходящего значения
            IPoint P2 = new Point(2, 10); // TODO: инициализация подходящего значения
            IPoint P3 = new Point(3, 1); // TODO: инициализация подходящего значения
            Bezier target = new Bezier(P0, P1, P2, P3); // TODO: инициализация подходящего значения
            double t = 0.1; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 2.487; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 1; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);

        }
        /// <summary>
        ///Тест для Конструктор Bezier
        ///</summary>
        [TestMethod()]
        public void BezierConstructorTest()
        {
            IPoint P0 = new Point(0, 0);
            IPoint P1 = new Point(0, 0); // TODO: инициализация подходящего значения
            IPoint P2 = new Point(0, 0);
            IPoint P3 = new Point(0, 0);
            Bezier target = new Bezier(P0, P1, P2, P3);

        }
    }
}
