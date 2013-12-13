using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DataStructures.Tests
{
    [TestClass()]
    public class HeapTests
    {
        MaxPriorityQueue<int> maxheap;
        MinPriorityQueue<int> minheap;

        [TestInitialize()]
        public void Init()
        {

        }

        [TestMethod()]
        public void HeapsortTest()
        {
            List<int> A = new List<int>(){ 1, 6, 3, 4, 7, 2, 5, 8, 9, 2 };
            List<int> B = new List<int>(){ 1, 2, 2, 3, 4, 5, 6, 7, 8, 9 };

            maxheap = new MaxPriorityQueue<int>(A);
            maxheap.Heapsort();
            bool a = Enumerable.SequenceEqual(A, B);
            Assert.AreEqual(a, true);
        }

        [TestMethod()]
        public void BuildMaxHeapTest()
        {
            List<int> A = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            maxheap = new MaxPriorityQueue<int>(A);
            

            Assert.AreEqual(A[0], 9);
            Assert.AreEqual(A[1], 8);
            Assert.AreEqual(A[2], 7);
            Assert.AreEqual(A[3], 4);
            Assert.AreEqual(A[4], 5);
            Assert.AreEqual(A[5], 6);
            Assert.AreEqual(A[6], 3);
            Assert.AreEqual(A[7], 2);
            Assert.AreEqual(A[8], 1);
        }

        
        [TestMethod()]
        public void BuildMinHeapTest()
        {
            List<int> A = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            minheap = new MinPriorityQueue<int>(A);


            Assert.AreEqual(A[0], 1);
            Assert.AreEqual(A[1], 2);
            Assert.AreEqual(A[2], 3);
            Assert.AreEqual(A[3], 4);
            Assert.AreEqual(A[4], 5);
            Assert.AreEqual(A[5], 6);
            Assert.AreEqual(A[6], 7);
            Assert.AreEqual(A[7], 8);
            Assert.AreEqual(A[8], 9);
        }

        #region protected methods
        //Cannot be tested while the methods are protected
        /*
        [TestMethod()]
        public void MaxHeapifyTest2()
        {
            List<int> A = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            maxheap = new MaxPriorityQueue<int>(A);


            Assert.AreEqual(A[0], 1);
            Assert.AreEqual(A[1], 5);
            Assert.AreEqual(A[2], 3);
            Assert.AreEqual(A[3], 4);
            Assert.AreEqual(A[4], 2);
            Assert.AreEqual(A[5], 6);
            Assert.AreEqual(A[6], 7);
            Assert.AreEqual(A[7], 8);
            Assert.AreEqual(A[8], 9);
        }

        [TestMethod()]
        public void MaxHeapifyTest()
        {
            List<int> A = new List<int>() { 1, 2, 3, 4, 5 };


            maxheap = new MaxPriorityQueue<int>(A);

            PrivateObject accessor = new PrivateObject(maxheap);
            int k = (int)accessor.Invoke("Heapify", 0);
            

            Assert.AreEqual(A[0], 3);
            Assert.AreEqual(A[1], 2);
            Assert.AreEqual(A[2], 1);
            Assert.AreEqual(A[3], 4);
            Assert.AreEqual(A[4], 5);
        }

        [TestMethod()]
        public void swapTest()
        {
            List<int> A = new List<int>() { 1, 2, 3, 4, 5 };

            maxheap = new MaxPriorityQueue<int>(A);

            PrivateObject accessor = new PrivateObject(maxheap);
            int k = (int)accessor.Invoke("swap", 0,4);
            
            Assert.AreEqual(A[0], 5);
            Assert.AreEqual(A[1], 2);
            Assert.AreEqual(A[2], 3);
            Assert.AreEqual(A[3], 4);
            Assert.AreEqual(A[4], 1);
        }

        [TestMethod()]
        public void swapTest2()
        {
            List<int> A = new List<int>() { 1, 2, 3, 4, 5 };
            maxheap = new MaxPriorityQueue<int>(A);

            PrivateObject accessor = new PrivateObject(maxheap);
            int k = (int)accessor.Invoke("swap", 4,0);
            
            Assert.AreEqual(A[0], 5);
            Assert.AreEqual(A[1], 2);
            Assert.AreEqual(A[2], 3);
            Assert.AreEqual(A[3], 4);
            Assert.AreEqual(A[4], 1);
        }

        [TestMethod()]
        public void swapTest3()
        {
            List<int> A = new List<int>() { 1, 2, 3, 4, 5 };
            maxheap = new MaxPriorityQueue<int>(A);

            PrivateObject accessor = new PrivateObject(maxheap);
            int k = (int)accessor.Invoke("swap", 3,2);

            Assert.AreEqual(A[0], 1);
            Assert.AreEqual(A[1], 2);
            Assert.AreEqual(A[2], 4);
            Assert.AreEqual(A[3], 3);
            Assert.AreEqual(A[4], 5);
        }
        */
        #endregion

        [TestMethod()]
        public void HeapExtractTest()
        {
            List<int> A = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            maxheap = new MaxPriorityQueue<int>(A);

            int k = maxheap.HeapExtract();

            Assert.AreEqual(k, 9);
        }

        [TestMethod()]
        public void HeapExtractTest2()
        {
            List<int> A = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            maxheap = new MaxPriorityQueue<int>(A);


            int k1 = maxheap.HeapExtract();
            int k2 = maxheap.HeapExtract();
            int k3 = maxheap.HeapExtract();
            int k4 = maxheap.HeapExtract();
            int k5 = maxheap.HeapExtract();
            int k6 = maxheap.HeapExtract();
            int k7 = maxheap.HeapExtract();
            int k8 = maxheap.HeapExtract();
            int k9 = maxheap.HeapExtract();

            Assert.AreEqual(k1, 9);
            Assert.AreEqual(k2, 8);
            Assert.AreEqual(k3, 7);
            Assert.AreEqual(k4, 6);
            Assert.AreEqual(k5, 5);
            Assert.AreEqual(k6, 4);
            Assert.AreEqual(k7, 3);
            Assert.AreEqual(k8, 2);
            Assert.AreEqual(k9, 1);

        }

        [TestMethod()]
        public void IncreaseKeyTest()
        {
            List<int> A = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            minheap = new MinPriorityQueue<int>(A);

            minheap.DecreaseKey(8, 0);

            Assert.AreEqual(minheap[0], 0);
            Assert.AreEqual(minheap[1], 1);
            Assert.AreEqual(minheap[2], 3);
            Assert.AreEqual(minheap[3], 2);
            Assert.AreEqual(minheap[4], 5);
            Assert.AreEqual(minheap[5], 6);
            Assert.AreEqual(minheap[6], 7);
            Assert.AreEqual(minheap[7], 8);
            Assert.AreEqual(minheap[8], 4);

        }
        [TestMethod()]
        public void DecreaseKeyTest()
        {
            List<int> A = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            maxheap = new MaxPriorityQueue<int>(A);

            maxheap.IncreaseKey(8, 10);

            Assert.AreEqual(maxheap[0], 10);
            Assert.AreEqual(maxheap[1], 9);
            Assert.AreEqual(maxheap[2], 7);
            Assert.AreEqual(maxheap[3], 8);
            Assert.AreEqual(maxheap[4], 5);
            Assert.AreEqual(maxheap[5], 6);
            Assert.AreEqual(maxheap[6], 3);
            Assert.AreEqual(maxheap[7], 2);
            Assert.AreEqual(maxheap[8], 4);
        }

        [TestMethod()]
        public void ParentTestIndex8()
        {
            List<int> A = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            minheap = new MinPriorityQueue<int>(A);
            PrivateObject accessor = new PrivateObject(minheap);
            int k = (int)accessor.Invoke("parent", 8);

            Assert.AreEqual(k, 3);
        }

        [TestMethod()]
        public void ParentTestIndex3()
        {
            List<int> A = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            minheap = new MinPriorityQueue<int>(A);
            PrivateObject accessor = new PrivateObject(minheap);
            int k = (int)accessor.Invoke("parent", 3);

            Assert.AreEqual(k, 1);
        }
        [TestMethod()]
        public void ParentTestIndex1()
        {
            List<int> A = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            minheap = new MinPriorityQueue<int>(A);
            PrivateObject accessor = new PrivateObject(minheap);
            int k = (int)accessor.Invoke("parent", 1);

            Assert.AreEqual(k, 0);
        }

        [TestMethod()]
        public void ParentTestIndex6()
        {
            List<int> A = new List<int>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            minheap = new MinPriorityQueue<int>(A);
            PrivateObject accessor = new PrivateObject(minheap);
            int k = (int)accessor.Invoke("parent", 6);

            Assert.AreEqual(k, 2);
        }


        [TestMethod()]
        public void InsertTest()
        {
            List<int> A = new List<int>() { 1 };

            minheap = new MinPriorityQueue<int>(A);
            minheap.Insert(2);

            Assert.AreEqual(A[0], 1);
            Assert.AreEqual(A[1], 2);
        }

        [TestMethod()]
        public void InsertTest2()
        {
            List<int> A = new List<int>() { 1 ,2,3,4};

            minheap = new MinPriorityQueue<int>(A);
            minheap.Insert(2);

            Assert.AreEqual(A[0], 1);
            Assert.AreEqual(A[1], 2);
            Assert.AreEqual(A[2], 3);
            Assert.AreEqual(A[3], 4);
            Assert.AreEqual(A[4], 2);
        }

        [TestMethod()]
        public void InsertTestMax()
        {
            List<int> A = new List<int>() { 1 };

            maxheap = new MaxPriorityQueue<int>(A);
            maxheap.Insert(2);

            Assert.AreEqual(A[0], 2);
            Assert.AreEqual(A[1], 1);
        }

        [TestMethod()]
        public void InsertTestMax2()
        {
            List<int> A = new List<int>() { 4,3,2,1 };

            maxheap = new MaxPriorityQueue<int>(A);
            maxheap.Insert(2);

            Assert.AreEqual(A[0], 4);
            Assert.AreEqual(A[1], 3);
            Assert.AreEqual(A[2], 2);
            Assert.AreEqual(A[3], 1);
            Assert.AreEqual(A[4], 2);
        }
        [TestMethod()]
        public void InsertTestMax3()
        {
            List<int> A = new List<int>() { 4, 3, 2, 1 };

            maxheap = new MaxPriorityQueue<int>(A);
            maxheap.Insert(0);

            Assert.AreEqual(A[0], 4);
            Assert.AreEqual(A[1], 3);
            Assert.AreEqual(A[2], 2);
            Assert.AreEqual(A[3], 1);
            Assert.AreEqual(A[4], 0);
        }
        [TestMethod()]
        public void InsertTestMax4()
        {
            List<int> A = new List<int>() { 4, 3, 2, 1 };

            maxheap = new MaxPriorityQueue<int>(A);
            maxheap.Insert(5);
            maxheap.Insert(3);

            Assert.AreEqual(A[0], 5);
            Assert.AreEqual(A[1], 4);
            Assert.AreEqual(A[2], 3);
            Assert.AreEqual(A[3], 1);
            Assert.AreEqual(A[4], 3);
            Assert.AreEqual(A[5], 2);
        }
    }
}
