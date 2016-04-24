using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestOfGeometry
{
    
    
    /// <summary>
    ///Это класс теста для RelocateTest, в котором должны
    ///находиться все модульные тесты RelocateTest
    ///</summary>
    [TestClass()]
    public class RelocateTest
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
        ///Тест для Конструктор Relocate
        ///</summary>
        [TestMethod()]
        public void RelocateConstructorTest()
        {
            ICurve curve = null; // TODO: инициализация подходящего значения
            Point newA = null; // TODO: инициализация подходящего значения
            Point newB = null; // TODO: инициализация подходящего значения
            Relocate target = new Relocate(curve, newA, newB);
          
        }
        using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestOfGeometry
{
    
    
    /// <summary>
    ///Это класс теста для RelocateTest, в котором должны
    ///находиться все модульные тесты RelocateTest
    ///</summary>
    [TestClass()]
    public class RelocateTest
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
        ///Тест для Конструктор Relocate
        ///</summary>
        [TestMethod()]
        public void RelocateConstructorTest()
        {
            ICurve curve = null; // TODO: инициализация подходящего значения
            Point newA = null; // TODO: инициализация подходящего значения
            Point newB = null; // TODO: инициализация подходящего значения
            Relocate target = new Relocate(curve, newA, newB);
          
        }

        /// <summary>
        ///Тест для getPoint
        ///</summary>
        [TestMethod()]
        public void getPointTest()
        {
            ICurve curve = new Line(new Point(2, 1), new Point(3, 4)); // TODO: инициализация подходящего значения
            Point newA = new Point(1, 1); // TODO: инициализация подходящего значения
            Point newB = new Point(2, 4); // TODO: инициализация подходящего значения
            Relocate target = new Relocate(curve, newA, newB); // TODO: инициализация подходящего значения
            double t = 0.5; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = -1.5; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = -0.5; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);
           
        }
    }
}

        /// <summary>
        ///Тест для getPoint
        ///</summary>
        [TestMethod()]
        public void getPointTest()
        {
            ICurve curve = new Line(new Point(2, 1), new Point(3, 4)); // TODO: инициализация подходящего значения
            Point newA = new Point(2, 1); // TODO: инициализация подходящего значения
            Point newB = new Point(3, 4); // TODO: инициализация подходящего значения
            Relocate target = new Relocate(curve, newA, newB); // TODO: инициализация подходящего значения
            double t = 0F; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 2F; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 1F; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);
           
        }
    }
}
