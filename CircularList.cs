using System.Collections.Generic;

class CircularList<T>: IEnumerable<T>, ICollection<T>
{
    class CLNode<U>
    {
        public U data;
        public CLNode<U> next;
    }

    CLNode<T> head = new CLNode<T>();

    public CircularList(params T[] elements)
    {
        CLNode<T> pred = head;
        foreach (var element in elements)
        {
            CLNode<T> node = new CLNode<T>();
            node.data = element;
            pred.next = node;
            pred = node;
        }
        pred.next = head.next;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (CLNode<T> currentNode = head.next; currentNode != null; currentNode = currentNode.next)
            yield return currentNode.data;
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return (System.Collections.IEnumerator) GetEnumerator();
    }

    public void Add(T item)
    {
        throw new System.NotImplementedException();
    }

    public void Clear()
    {
        head.next = null;
    }

    public bool Contains(T item)
    {
        throw new System.NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new System.NotImplementedException();
    }

    public int Count
    {
        get { throw new System.NotImplementedException(); }
    }

    public bool IsReadOnly
    {
        get { throw new System.NotImplementedException(); }
    }

    public bool Remove(T item)
    {
        throw new System.NotImplementedException();
    }
}