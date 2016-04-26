using Solvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Geometry;
using System.Collections.Generic;

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
            int nX = 3; // TODO: инициализация подходящего значения
            int nY = 3; // TODO: инициализация подходящего значения
            QuadSimpleMeshGen target = new QuadSimpleMeshGen(nX, nY); // TODO: инициализация подходящего значения
            List<ICurve> curves = new List<ICurve>();
            curves.Add(new Line(new Point(0, 0), new Point(0, 9)));
            curves.Add(new Line(new Point(0, 9), new Point(9, 9)));
            curves.Add(new Line(new Point(9, 9), new Point(9, 0)));
            curves.Add(new Line(new Point(9, 9), new Point(0, 0)));
            Contour contour = new Contour(curves); // TODO: инициализация подходящего значени
            IPoint[,] mesh = new Point[4, 4];
            mesh[0, 0] = new Point(0, 0);
            mesh[0, 1] = new Point(3, 0);
            mesh[0, 2] = new Point(6, 0);
            mesh[0, 3] = new Point(9, 0);
            mesh[1, 0] = new Point(0, 3);
            mesh[1, 1] = new Point(3, 3);
            mesh[1, 2] = new Point(6, 3);
            mesh[1, 3] = new Point(9, 3);
            mesh[2, 0] = new Point(0, 6);
            mesh[2, 1] = new Point(3, 6);
            mesh[2, 2] = new Point(6, 6);
            mesh[2, 3] = new Point(9, 6);
            mesh[3, 0] = new Point(0, 9);
            mesh[3, 1] = new Point(3, 9);
            mesh[3, 2] = new Point(6, 9);
            mesh[3, 3] = new Point(9, 9);
            RegMesh2D expected = new RegMesh2D(mesh, nY, nX); // TODO: инициализация подходящего значения
            
            List<RegMesh2D> actual;
            actual = target.Generate(contour);
           
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Проверьте правильность этого метода теста.");
        }
    }
}
