using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    public class TriaMeshGen : IMeshGen
    {
        private TriangleDecompositor decompos;
        private QuadCleverMeshGen meshgen;
        private List<RegMesh2D> mesh;
        private IContour[] contourArray;
        public TriaMeshGen(int nX, int nY)
        {
            this.decompos = new TriangleDecompositor();
            this.meshgen = new QuadCleverMeshGen(nX,nY);
        }
        public List<RegMesh2D> Generate(IContour contour)
        {
            this.mesh = new List<RegMesh2D>();
            contourArray = decompos.decomposed(contour);
            for(int i = 0; i<3;i++)
            {
                mesh.Add(meshgen.Generate(contourArray[i])[0]);              
            }
            return mesh;
        }
    }
}
