using Solvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Geometry;

namespace TestOfSolvers
{
    
    
    /// <summary>
    ///Это класс теста для TriaMeshGenTest, в котором должны
    ///находиться все модульные тесты TriaMeshGenTest
    ///</summary>
    [TestClass()]
    public class TriaMeshGenTest
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
        ///Тест для Конструктор TriaMeshGen
        ///</summary>
        [TestMethod()]
        public void TriaMeshGenConstructorTest()
        {
            TriaMeshGen target = new TriaMeshGen();
            Assert.Inconclusive("TODO: реализуйте код для проверки целевого объекта");
        }

        /// <summary>
        ///Тест для Generate
        ///</summary>
        [TestMethod()]
        public void GenerateTest()
        {
            TriaMeshGen target = new TriaMeshGen(); // TODO: инициализация подходящего значения
            Contour contour = null; // TODO: инициализация подходящего значения
            RegMesh2D expected = null; // TODO: инициализация подходящего значения
            RegMesh2D actual;
            actual = target.Generate(contour);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }
    }
}
