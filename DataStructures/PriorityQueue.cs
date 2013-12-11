using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public abstract class PriorityQueue<T> : Heap<T> where T : IComparable<T>
    {
        public PriorityQueue(T[] A)
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
    }


    public class MinPriorityQueue<T> : PriorityQueue<T> where T : IComparable<T>
    {
        public MinPriorityQueue(T[] A)
            : base(A)
        {

        }
        public override bool Compare(int first, int second)
        {
            if (first > second)
                return false;
            else return true;
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
        public void Insert(T key)
        {
            base.A.Heapsize++;
            A.Array = new T[A.Array + 1];
            A[A.Heapsize] = key;
            DecreaseKey(A.Heapsize - 1, key);
        }
    }


    public class MaxPriorityQueue<T> : PriorityQueue<T> where T : IComparable<T>
    {
        public MaxPriorityQueue(T[] A)
            : base(A)
        {

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
