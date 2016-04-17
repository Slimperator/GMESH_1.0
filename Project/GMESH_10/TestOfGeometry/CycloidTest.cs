using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestOfGeometry
{
    
    
    /// <summary>
    ///Это класс теста для CycloidTest, в котором должны
    ///находиться все модульные тесты CycloidTest
    ///</summary>
    [TestClass()]
    public class CycloidTest
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
        ///Тест для Конструктор Cycloid
        ///</summary>
        [TestMethod()]
        public void CycloidConstructorTest()
        {
            IPoint Begin = null; // TODO: инициализация подходящего значения
            IPoint End = null; // TODO: инициализация подходящего значения
            bool Convex = false; // TODO: инициализация подходящего значения
            Cycloid target = new Cycloid(Begin, End, Convex);
            
        }

        /// <summary>
        ///Тест для aboutCurve
        ///</summary>
        [TestMethod()]
        public void aboutCurveTest()
        {
            IPoint Begin = null; // TODO: инициализация подходящего значения
            IPoint End = null; // TODO: инициализация подходящего значения
            bool Convex = false; // TODO: инициализация подходящего значения
            Cycloid target = new Cycloid(Begin, End, Convex); // TODO: инициализация подходящего значения
            string type = string.Empty; // TODO: инициализация подходящего значения
            string typeExpected = string.Empty; // TODO: инициализация подходящего значения
            List<IPoint> Points = null; // TODO: инициализация подходящего значения
            List<IPoint> PointsExpected = null; // TODO: инициализация подходящего значения
            List<string> Special = null; // TODO: инициализация подходящего значения
            List<string> SpecialExpected = null; // TODO: инициализация подходящего значения
            target.aboutCurve(out type, out Points, out Special);
            Assert.AreEqual(typeExpected, type);
            Assert.AreEqual(PointsExpected, Points);
            Assert.AreEqual(SpecialExpected, Special);
            
        }

        /// <summary>
        ///Тест для aglRotate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Geometry.dll")]
        public void aglRotateTest()
        {
            PrivateObject param0 = null; // TODO: инициализация подходящего значения
            Cycloid_Accessor target = new Cycloid_Accessor(param0); // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = target.aglRotate();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Тест для calculationRadius
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Geometry.dll")]
        public void calculationRadiusTest()
        {
            PrivateObject param0 = null; // TODO: инициализация подходящего значения
            Cycloid_Accessor target = new Cycloid_Accessor(param0); // TODO: инициализация подходящего значения
            IPoint Begin = null; // TODO: инициализация подходящего значения
            IPoint End = null; // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = target.calculationRadius(Begin, End);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///Тест для degreeToRadian
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Geometry.dll")]
        public void degreeToRadianTest()
        {
            PrivateObject param0 = null; // TODO: инициализация подходящего значения
            Cycloid_Accessor target = new Cycloid_Accessor(param0); // TODO: инициализация подходящего значения
            double t = 0F; // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = target.degreeToRadian(t);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///Тест для getPoint
        ///</summary>
        [TestMethod()]
        public void getPointTest()
        {
            IPoint Begin = null; // TODO: инициализация подходящего значения
            IPoint End = null; // TODO: инициализация подходящего значения
            bool Convex = false; // TODO: инициализация подходящего значения
            Cycloid target = new Cycloid(Begin, End, Convex); // TODO: инициализация подходящего значения
            double t = 0F; // TODO: инициализация подходящего значения
            double x = 0F; // TODO: инициализация подходящего значения
            double xExpected = 0F; // TODO: инициализация подходящего значения
            double y = 0F; // TODO: инициализация подходящего значения
            double yExpected = 0F; // TODO: инициализация подходящего значения
            target.getPoint(t, out x, out y);
            Assert.AreEqual(xExpected, x);
            Assert.AreEqual(yExpected, y);
            
        }

        /// <summary>
        ///Тест для getX
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Geometry.dll")]
        public void getXTest()
        {
            PrivateObject param0 = null; // TODO: инициализация подходящего значения
            Cycloid_Accessor target = new Cycloid_Accessor(param0); // TODO: инициализация подходящего значения
            double t = 0F; // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = target.getX(t);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///Тест для getY
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Geometry.dll")]
        public void getYTest()
        {
            PrivateObject param0 = null; // TODO: инициализация подходящего значения
            Cycloid_Accessor target = new Cycloid_Accessor(param0); // TODO: инициализация подходящего значения
            double t = 0F; // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = target.getY(t);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///Тест для matrixOfRotate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Geometry.dll")]
        public void matrixOfRotateTest()
        {
            PrivateObject param0 = null; // TODO: инициализация подходящего значения
            Cycloid_Accessor target = new Cycloid_Accessor(param0); // TODO: инициализация подходящего значения
            target.matrixOfRotate();
            
        }

        /// <summary>
        ///Тест для paramToRadian
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Geometry.dll")]
        public void paramToRadianTest()
        {
            PrivateObject param0 = null; // TODO: инициализация подходящего значения
            Cycloid_Accessor target = new Cycloid_Accessor(param0); // TODO: инициализация подходящего значения
            double t = 0F; // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = target.paramToRadian(t);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///Тест для vectorCalculate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Geometry.dll")]
        public void vectorCalculateTest()
        {
            PrivateObject param0 = null; // TODO: инициализация подходящего значения
            Cycloid_Accessor target = new Cycloid_Accessor(param0); // TODO: инициализация подходящего значения
            IPoint expected = null; // TODO: инициализация подходящего значения
            IPoint actual;
            actual = target.vectorCalculate();
            Assert.AreEqual(expected, actual);
                    }
    }
}
