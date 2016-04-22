using Solvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Geometry;

namespace TestOfSolvers
{
    
    
    /// <summary>
    ///Это класс теста для QuadSimpleMeshGenTest, в котором должны
    ///находиться все модульные тесты QuadSimpleMeshGenTest
    ///</summary>
    [TestClass()]
    public class QuadSimpleMeshGenTest
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
        ///Тест для Конструктор QuadSimpleMeshGen
        ///</summary>
        [TestMethod()]
        public void QuadSimpleMeshGenConstructorTest()
        {
            int nX = 0; // TODO: инициализация подходящего значения
            int nY = 0; // TODO: инициализация подходящего значения
            QuadSimpleMeshGen target = new QuadSimpleMeshGen(nX, nY);
            Assert.Inconclusive("TODO: реализуйте код для проверки целевого объекта");
        }

        /// <summary>
        ///Тест для Generate
        ///</summary>
        [TestMethod()]
        public void GenerateTest()
        {
            int nX = 0; // TODO: инициализация подходящего значения
            int nY = 0; // TODO: инициализация подходящего значения
            QuadSimpleMeshGen target = new QuadSimpleMeshGen(nX, nY); // TODO: инициализация подходящего значения
            Contour contour = null; // TODO: инициализация подходящего значения
            RegMesh2D expected = null; // TODO: инициализация подходящего значения
            RegMesh2D actual;
            actual = target.Generate(contour);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }
    }
}
