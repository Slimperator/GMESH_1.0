using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestOfGeometry
{
    
    
    /// <summary>
    ///Это класс теста для RegMesh2DTest, в котором должны
    ///находиться все модульные тесты RegMesh2DTest
    ///</summary>
    [TestClass()]
    public class RegMesh2DTest
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
        ///Тест для Конструктор RegMesh2D
        ///</summary>
        [TestMethod()]
        public void RegMesh2DConstructorTest()
        {
            int cols = 0; // TODO: инициализация подходящего значения
            int rows = 0; // TODO: инициализация подходящего значения
            RegMesh2D target = new RegMesh2D(cols, rows);
            Assert.Inconclusive("TODO: реализуйте код для проверки целевого объекта");
        }

        /// <summary>
        ///Тест для Конструктор RegMesh2D
        ///</summary>
        [TestMethod()]
        public void RegMesh2DConstructorTest1()
        {
            IPoint[,] mesh = null; // TODO: инициализация подходящего значения
            int cols = 0; // TODO: инициализация подходящего значения
            int rows = 0; // TODO: инициализация подходящего значения
            RegMesh2D target = new RegMesh2D(mesh, cols, rows);
            Assert.Inconclusive("TODO: реализуйте код для проверки целевого объекта");
        }

        /// <summary>
        ///Тест для Item
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            int cols = 0; // TODO: инициализация подходящего значения
            int rows = 0; // TODO: инициализация подходящего значения
            RegMesh2D target = new RegMesh2D(cols, rows); // TODO: инициализация подходящего значения
            int i = 0; // TODO: инициализация подходящего значения
            int j = 0; // TODO: инициализация подходящего значения
            IPoint expected = null; // TODO: инициализация подходящего значения
            IPoint actual;
            target[i, j] = expected;
            actual = target[i, j];
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для X
        ///</summary>
        [TestMethod()]
        public void XTest()
        {
            int cols = 0; // TODO: инициализация подходящего значения
            int rows = 0; // TODO: инициализация подходящего значения
            RegMesh2D target = new RegMesh2D(cols, rows); // TODO: инициализация подходящего значения
            int actual;
            actual = target.X;
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }

        /// <summary>
        ///Тест для Y
        ///</summary>
        [TestMethod()]
        public void YTest()
        {
            int cols = 0; // TODO: инициализация подходящего значения
            int rows = 0; // TODO: инициализация подходящего значения
            RegMesh2D target = new RegMesh2D(cols, rows); // TODO: инициализация подходящего значения
            int actual;
            actual = target.Y;
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }
    }
}
