using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    
    public abstract class Heap<T> where T : IComparable<T>
    {
        HeapArray a;

        public HeapArray A { get { return a; } }
        public Heap(List<T> array)
        {
            a = new HeapArray(array);
            BuildHeap();
        }
        
        protected void BuildHeap()
        {
            for (int i = (int)Math.Ceiling((double)(A.Heapsize / 2) - 1); i >= 0; i--)
            {
                Heapify(i);
            }
        }

        protected void Heapify(int i)
        {
            int l = left(i);
            int r = right(i);
            int largest = 0;

            if (l <= A.Heapsize && Compare(A[l].CompareTo(A[i]), 0))
                largest = l;
            else largest = i;

            if (r <= A.Heapsize && Compare(A[r].CompareTo(A[largest]), 0))
                largest = r;

            if (largest != i)
            {
                swap(largest, i);
                Heapify(largest);
            }

        }

        protected abstract bool Compare(int first, int second);


        public void Heapsort()
        {
            BuildHeap();
            for (int i = A.Length - 1; i >= 0; i--)
            {
                swap(0, i);
                A.Heapsize--;
                Heapify(0);
            }
        }

        /// <summary>
        /// Swaps the specified indexes in the HeapArray a.
        /// </summary>
        /// <param name="A">A.</param>
        /// <param name="index1">The index1.</param>
        /// <param name="index2">The index2.</param>
        protected void swap(int index1, int index2)
        {
            T temp = A[index1];
            A[index1] = A[index2];
            A[index2] = temp;
        }

        /// <summary>
        /// Parent of the node i
        /// </summary>
        /// <param name="i">Index of the child node.</param>
        /// <returns></returns>
        protected int parent(int i)
        {

            return (int)Math.Ceiling((double)i / 2) - 1;
        }

        /// <summary>
        /// The left child of node i
        /// </summary>
        /// <param name="i">Index of the parent node.</param>
        /// <returns></returns>
        protected  int left(int i)
        {
            return 2 * i + 1;
        }

        /// <summary>
        /// The right child of node i
        /// </summary>
        /// <param name="i">Index of the parent node.</param>
        /// <returns></returns>
        protected int right(int i)
        {
            return 2 * i + 2;
        }

        protected T HeapMaxMin()
        {
            return A[0];
        }


        public T this[int index]
        {
            get { return A[index]; }
        }

        /// <summary>
        /// An array with a heapsize, determining what part of the array is a heap
        /// </summary>
        public class HeapArray
        {
            List<T> a;
            int heapsize;

            public List<T> Array { get { return a; } set { a = value; } }
            public int Heapsize { get { return heapsize; } set { heapsize = value; } }

            public int Length { get { return Array.Count; } }
            public HeapArray(List<T> A)
            {
                this.a = A;
                this.heapsize = A.Count -1;
            }

            public T this[int index]
            {
                get { return a[index]; }
                set { a[index] = value; }
            }
        }
    }

    public class MinHeap<T> : Heap<T> where T : IComparable<T>
    {
        public MinHeap(List<T> A) : base(A)
        {

        }
        protected override bool Compare(int first, int second)
        {
            if (first > second)
                return false;
            else return true;
        }
    }

    public class MaxHeap<T> : Heap<T> where T : IComparable<T>

    {
        public MaxHeap(List<T> A) :base(A)
        {

        }

        protected override bool Compare(int first, int second)
        {
            if (first > second)
                return true;
            else return false;
        }
    }


}
