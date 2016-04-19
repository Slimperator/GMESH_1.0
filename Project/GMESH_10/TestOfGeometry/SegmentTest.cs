using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestOfGeometry
{
    
    
    /// <summary>
    ///Это класс теста для SegmentTest, в котором должны
    ///находиться все модульные тесты SegmentTest
    ///</summary>
    [TestClass()]
    public class SegmentTest
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
        ///Тест для St
        ///</summary>
        [TestMethod()]
        public void StTest()
        {
            IPoint st = new Point(0, 0); // TODO: инициализация подходящего значения
            IPoint fin = new Point(0, 0); // TODO: инициализация подходящего значения
            Segment target = new Segment(st, fin); // TODO: инициализация подходящего значения
            IPoint expected = null; // TODO: инициализация подходящего значения
            IPoint actual;
            target.St = expected;
            actual = target.St;
            Assert.AreEqual(expected, actual);
           
        }

        /// <summary>
        ///Тест для Fin
        ///</summary>
        [TestMethod()]
        public void FinTest()
        {
            IPoint st = new Point(0, 0); // TODO: инициализация подходящего значения
            IPoint fin = new Point(0, 0); // TODO: инициализация подходящего значения
            Segment target = new Segment(st, fin); // TODO: инициализация подходящего значения
            IPoint expected = null; // TODO: инициализация подходящего значения
            IPoint actual;
            target.Fin = expected;
            actual = target.Fin;
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///Тест для getPoint
        ///</summary>
        [TestMethod()]
        public void getPointTest0()
        {
            IPoint st = new Point(0, 0); // TODO: инициализация подходящего значения
            IPoint fin = new Point(0, 0); // TODO: инициализация подходящего значения
            Segment target = new Segment(st, fin); // TODO: инициализация подходящего значения
            double t = 0F; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 0F; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 0F; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);

        }
        [TestMethod()]
        public void getPointTest1()
        {
            IPoint st = new Point(0, 0); // TODO: инициализация подходящего значения
            IPoint fin = new Point(1, 1); // TODO: инициализация подходящего значения
            Line target = new Line(st, fin); // TODO: инициализация подходящего значения
            double t = 0F; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 1; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 1; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);

        }
        [TestMethod()]
        public void getPointTest2()
        {
            IPoint st = new Point(0, 0); // TODO: инициализация подходящего значения
            IPoint fin = new Point(2, 1); // TODO: инициализация подходящего значения
            Line target = new Line(st, fin); // TODO: инициализация подходящего значения
            double t = 1F; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 2; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 1; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);

        }

        /// <summary>
        ///Тест для Конструктор Segment
        ///</summary>
        [TestMethod()]
        public void SegmentConstructorTest()
        {
            IPoint st = new Point(0, 0); // TODO: инициализация подходящего значения
            IPoint fin = new Point(0, 0); // TODO: инициализация подходящего значения
            Segment target = new Segment(st, fin);

        }
    }
}
