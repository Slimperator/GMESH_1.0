using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestOfGeometry
{
    
    
    /// <summary>
    ///Это класс теста для ContourTest, в котором должны
    ///находиться все модульные тесты ContourTest
    ///</summary>
    [TestClass()]
    public class ContourTest
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
        ///Тест для Конструктор Contour
        ///</summary>
        [TestMethod()]
        public void ContourConstructorTest()
        {
            List<ICurve> curves = new List<ICurve>(); ; // TODO: инициализация подходящего значения
            Contour target = new Contour(curves);
           // Assert.Inconclusive("TODO: реализуйте код для проверки целевого объекта");
        }

        /// <summary>
        ///Тест для Item
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            List<ICurve> curves = new List<ICurve>(); // TODO: инициализация подходящего значения
            curves.Add(new Line(new Point(0, 0), new Point(0, 3)));
            curves.Add(new Line(new Point(0, 0), new Point(1, 6)));
            curves.Add(new Line(new Point(0, 3), new Point(1, 6)));
            Contour target = new Contour(curves); // TODO: инициализация подходящего значения
            int i = 0; // TODO: инициализация подходящего значения
            ICurve expected = curves[i]; // TODO: инициализация подходящего значения
            ICurve actual;
            target[i] = expected;
            actual = target[i];
            Assert.AreEqual(expected, actual);
          
        }

        /// <summary>
        ///Тест для Size
        ///</summary>
        [TestMethod()]
        public void SizeTest()
        {
            List<ICurve> curves = new List<ICurve>(); ; // TODO: инициализация подходящего значения
            Contour target = new Contour(curves); // TODO: инициализация подходящего значения
            int actual;
            actual = target.Size;
           
        }
    }
}
