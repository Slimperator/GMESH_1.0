using Solvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Geometry;
using System.Collections.Generic;

namespace TestOfSolvers
{
    
    
    /// <summary>
    ///Это класс теста для QuadCleverMeshGenTest, в котором должны
    ///находиться все модульные тесты QuadCleverMeshGenTest
    ///</summary>
    [TestClass()]
    public class QuadCleverMeshGenTest
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
        ///Тест для Конструктор QuadCleverMeshGen
        ///</summary>
        [TestMethod()]
        public void QuadCleverMeshGenConstructorTest()
        {
            int nX = 0; // TODO: инициализация подходящего значения
            int nY = 0; // TODO: инициализация подходящего значения
            QuadCleverMeshGen target = new QuadCleverMeshGen(nX, nY);
           
        }

        /// <summary>
        ///Тест для Generate
        ///</summary>
        [TestMethod()]
        public void GenerateTest()
        {
            ICurve curve1 = new Line(new Point(0,0),new Point(1,0) );
            ICurve curve2 = new Line(new Point (1, 0), new Point(1,1));
            ICurve curve3 = new Line(new Point(1, 1), new Point(0, 1));
            ICurve curve4 = new Line(new Point(0,1), new Point(0,0));
            List<ICurve> curves = new List<ICurve>();
            curves.Add(curve1);
            curves.Add(curve2);
            curves.Add(curve3);
            curves.Add(curve4);


            int nX = 1; // TODO: инициализация подходящего значения
            int nY = 1; // TODO: инициализация подходящего значения
            QuadCleverMeshGen target = new QuadCleverMeshGen(nX, nY); // TODO: инициализация подходящего значения
            IContour contour = new Contour(curves); ; // TODO: инициализация подходящего значения
            //List<RegMesh2D> expected = new List<RegMesh2D>(new Point(0,0),new Point(1,0),new Point(1,1),new Point(0,1)); // TODO: инициализация подходящего значения
             List<RegMesh2D> mesh  = new List<RegMesh2D>();
             IPoint[,] Points = new Point[2,2];
             Points[0, 0] = new Point(0, 0);
             Points[0, 1] = new Point(1, 0);
             Points[1, 0] = new Point(1, 1);
             Points[1, 1] = new Point(0, 1);
             mesh.Add(new RegMesh2D(Points,2,2));
            List<RegMesh2D> actual;
            actual = target.Generate(contour);
          CollectionAssert.AreEqual(mesh, actual);

        }

        /// <summary>
        ///Тест для createVectorOfParam
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Solvers.exe")]
        public void createVectorOfParamTest()
        {
            PrivateObject param0 = null; // TODO: инициализация подходящего значения
            QuadCleverMeshGen_Accessor target = new QuadCleverMeshGen_Accessor(param0); // TODO: инициализация подходящего значения
            ICurve contour5 = new Line(new Point(0, 0), new Point(10, 0));
            double[] cur = new double[11]{0,1,2,3,4,5,6,7,8,9,10} ; 
            target.createVectorOfParam();
           
        }

        /// <summary>
        ///Тест для fillMesh
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Solvers.exe")]
        public void fillMeshTest()
        {
            PrivateObject param0 = null; // TODO: инициализация подходящего значения
            QuadCleverMeshGen_Accessor target = new QuadCleverMeshGen_Accessor(param0); // TODO: инициализация подходящего значения
            target.fillMesh();
            
        }

        /// <summary>
        ///Тест для getSizeOfPart
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Solvers.exe")]
        public void getSizeOfPartTest()
        {
            PrivateObject param0 = null; // TODO: инициализация подходящего значения
            QuadCleverMeshGen_Accessor target = new QuadCleverMeshGen_Accessor(param0);// TODO: инициализация подходящего значения
            ICurve contour5 = new Line(new Point(1, 2), new Point(3, 4));
            double hX = 0.01;
            double lenghtOfCurve = Tools.length(contour5)*hX; // TODO: инициализация подходящего значения
            double expected = 0.02; // TODO: инициализация подходящего значения
            double actual;
            actual = target.getSizeOfPart(lenghtOfCurve);
            Assert.AreEqual(expected, actual,0.01);
           
        }
    }
}
