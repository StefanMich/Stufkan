using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public abstract class PriorityQueue<T> : Heap<T> where T : IComparable<T>
    {
        public PriorityQueue(List<T> A)
            : base(A)
        {

        }
        public T HeapExtract()
        {
            if (A.Heapsize < 0)
                throw new ArgumentException("Heap is empty");

            T max = A[0];
            A[0] = A[A.Heapsize];
            A.Heapsize--;
            Heapify(0);
            return max;
        }

        public override bool Compare(int first, int second)
        {
            if (first > second)
                return false;
            else return true;
        }

        protected Action<int, T> xCreaseKey;

        public void Insert(T key)
        {
            base.A.Heapsize++;
            A.Array.Add(key);
            xCreaseKey(A.Heapsize, key);
        }
    }


    public class MinPriorityQueue<T> : PriorityQueue<T> where T : IComparable<T>
    {
        public MinPriorityQueue(List<T> A)
            : base(A)
        {
            base.xCreaseKey = DecreaseKey;
        }
      

        public T HeapMinimum()
        {
            return this.HeapMaxMin();
        }

        public void DecreaseKey(int index, T key)
        {
            if (key.CompareTo(A[index]) > 0)
                throw new ArgumentException("new key is bigger than the current key");

            A.Array[index] = key;

            while (index > 0 && A[base.parent(index)].CompareTo(A[index]) > 0)
            {
                swap(index, base.parent(index));
                index = parent(index);
            }
        }

    }

    public class MaxPriorityQueue<T> : PriorityQueue<T> where T : IComparable<T>
    {
        public MaxPriorityQueue(List<T> A)
            : base(A)
        {
            base.xCreaseKey = IncreaseKey;
        }

        public override bool Compare(int first, int second)
        {
            if (first > second)
                return true;
            else return false;
        }

        public T HeapMaximum()
        {
            return this.HeapMaxMin();
        }

        public void IncreaseKey(int index, T key)
        {
            if (key.CompareTo(A[index]) < 0)
                throw new ArgumentException("new key is smaller than the current key");

            A.Array[index] = key;

            while (index > 0 && A[base.parent(index)].CompareTo(A[index]) < 0)
            {
                swap(index, base.parent(index));
                index = parent(index);
            }
        }


    }


}
