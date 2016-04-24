using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestOfGeometry
{
    
    
    /// <summary>
    ///Это класс теста для MorphTest, в котором должны
    ///находиться все модульные тесты MorphTest
    ///</summary>
    [TestClass()]
    public class MorphTest
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
        ///Тест для Конструктор Morph
        ///</summary>
        [TestMethod()]
        public void MorphConstructorTest()
        {
            ICurve a = null; // TODO: инициализация подходящего значения
            ICurve b = null; // TODO: инициализация подходящего значения
            double alpha = 0F; // TODO: инициализация подходящего значения
            Morph target = new Morph(a, b, alpha);

        }

        /// <summary>
        ///Тест для getPoint
        ///</summary>
        [TestMethod()]
        public void getPointTest1()
        {
            ICurve a = new Line(new Point(0, 10), new Point(8, 10)); // TODO: инициализация подходящего значения
            ICurve b = new Line(new Point(0, 2), new Point(10, 4)); // TODO: инициализация подходящего значения
            double alpha = 1F; // TODO: инициализация подходящего значения
            Morph target = new Morph(a, b, alpha); // TODO: инициализация подходящего значения
            double t = 0.5F; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 4.0F; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 10.0F; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);

        }
        [TestMethod()]
        public void getPointTest2()
        {
            ICurve a = new Line(new Point(0, 10), new Point(8, 10)); // TODO: инициализация подходящего значения
            ICurve b = new Line(new Point(0, 2), new Point(10, 4)); // TODO: инициализация подходящего значения
            double alpha = 0F; // TODO: инициализация подходящего значения
            Morph target = new Morph(a, b, alpha); // TODO: инициализация подходящего значения
            double t = 0.5F; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 5.0F; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 3.0F; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);

        }
        [TestMethod()]
        public void getPointTest3()
        {
            ICurve a = new Line(new Point(0, 10), new Point(20, 10)); // TODO: инициализация подходящего значения
            ICurve b = new Line(new Point(0, 10), new Point(10, 0)); // TODO: инициализация подходящего значения
            double alpha = 0.6F; // TODO: инициализация подходящего значения
            Morph target = new Morph(a, b, alpha); // TODO: инициализация подходящего значения
            double t = 0.5F; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 8.0F; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 8.0F; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x, 0.001);
            Assert.AreEqual(yExpected, y, 0.001);

        }
        [TestMethod()]
        public void getPointTest4()
        {
            ICurve a = new Line(new Point(0, 10), new Point(20, 10)); // TODO: инициализация подходящего значения
            ICurve b = new Bezier(new Point(8, 8), new Point(16, 8), new Point(8, 16), new Point(16, 16)); // TODO: инициализация подходящего значения
            double alpha = 0.5F; // TODO: инициализация подходящего значения
            Morph target = new Morph(a, b, alpha); // TODO: инициализация подходящего значения
            double t = 0.5F; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 11.0F; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 11.0F; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x, 0.01);
            Assert.AreEqual(yExpected, y, 0.01);

        }

    }
}
