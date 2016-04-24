using Solvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Geometry;

namespace TestOfSolvers
{
    
    
    /// <summary>
    ///Это класс теста для ArithmMeanGradeTest, в котором должны
    ///находиться все модульные тесты ArithmMeanGradeTest
    ///</summary>
    [TestClass()]
    public class ArithmMeanGradeTest
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
        ///Тест для Конструктор ArithmMeanGrade
        ///</summary>
        [TestMethod()]
        public void ArithmMeanGradeConstructorTest()
        {
            ArithmMeanGrade target = new ArithmMeanGrade();
            Assert.Inconclusive("TODO: реализуйте код для проверки целевого объекта");
        }

        /// <summary>
        ///Тест для Calculate
        ///</summary>
        [TestMethod()]
        public void CalculateTest()
        {
            ArithmMeanGrade target = new ArithmMeanGrade(); // TODO: инициализация подходящего значения
            RegMesh2D mesh = null; // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = target.Calculate(mesh);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для CalculateSquare
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Solvers.exe")]
        public void CalculateSquareTest()
        {
            ArithmMeanGrade_Accessor target = new ArithmMeanGrade_Accessor(); // TODO: инициализация подходящего значения
            IPoint p1 = null; // TODO: инициализация подходящего значения
            IPoint p2 = null; // TODO: инициализация подходящего значения
            IPoint p3 = null; // TODO: инициализация подходящего значения
            IPoint p4 = null; // TODO: инициализация подходящего значения
            double expected = 0F; // TODO: инициализация подходящего значения
            double actual;
            actual = target.CalculateSquare(p1, p2, p3, p4);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }
    }
}
