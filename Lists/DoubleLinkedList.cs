using System;

namespace Lists
{
    public class DoubleLinkedList
    {
        private DNode _root;
        private DNode _tail;
        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                DNode node = GetNodeByIndex(index);

                return node.Value;
            }
            set
            {
                DNode node = GetNodeByIndex(index);
                node.Value = value;
            }
        }

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public DoubleLinkedList(int value)
        {
            Length = 1;
            _root = new DNode(value);
            _tail = _root;
        }

        private DoubleLinkedList(int[] values)
        {
            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new DNode(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new DNode(values[i]);
                    _tail.Next.Previous = _tail;
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
        }

        public static DoubleLinkedList Create(int[] values)
        {
            if (!(values is null))
            {
                return new DoubleLinkedList(values);
            }

            throw new NullReferenceException("Values is null");
        }

        public void Add(int value)
        {
            if (Length != 0)
            {
                _tail.Next = new DNode(value);
                _tail = _tail.Next;
            }
            else
            {
                _root = new DNode(value);
                _tail = _root;
            }
            Length++;
        }

        public void AddFirst(int value)
        {
            if (Length > 0)
            {
                DNode newRoot = new DNode(value);
                _root.Previous = newRoot;
                newRoot.Next = _root;
                _root = newRoot;
                Length++;
            }
            else
            {
                Length = 1;
                _root = new DNode(value);
                _tail = _root;
            }
        }

        public void AddByIndex(int value, int index)
        {
            if (index >= 0 && index <= Length)
            {
                if (index != 0)
                {
                    DNode current = _root;

                    for (int i = 1; i < index; i++)
                    {
                        current = current.Next;
                    }

                    DNode tmp = new DNode(value);
                    tmp.Next = current.Next;
                    current.Next = tmp;
                    Length++;
                }
                else
                {
                    AddFirst(value);
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove()
        {
            if (Length == 1)
            {
                _root = null;
                _tail = null;
                Length--;
            }
            else if (Length == 0)
            {
                throw new NullReferenceException();
            }
            else
            {
                _tail = _tail.Next;
                Length--;
            }
        }

        public void RemoveFirst()
        {
            if (Length == 1)
            {
                _root = null;
                _tail = null;
                Length--;
            }
            else if (Length == 0)
            {
                throw new NullReferenceException();
            }
            else
            {
                _root = _root.Next;
                Length--;
            }
        }

        public void RemoveByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                if (index != 0)
                {
                    if (Length == 1)
                    {
                        _root = null;
                        _tail = null;
                        Length--;
                    }
                    else
                    {
                        DNode current = _root;

                        for (int i = 1; i < index; i++)
                        {
                            current = current.Next;
                        }

                        current.Next = current.Next.Next;
                        Length--;
                    }
                }
                else
                {
                    RemoveFirst();
                }
            }
            else if (Length == 0)
            {
                throw new NullReferenceException();
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveNElements(int n)//refactor if in less branching
        {
            if (Length == 1 && n <= Length && n > 0)
            {
                _root = null;
                _tail = null;
                Length--;
            }
            else if (Length == 0)
            {
                throw new NullReferenceException();
            }
            else if (n < 0 || n > Length)
            {
                throw new ArgumentException("N is incorrect");
            }
            else if (n == Length && n > 0)
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
            else
            {
                DNode current = _root;

                for (int i = 0; i < n + 1; i++)
                {
                    current = current.Next;
                }

                _tail = current;
                Length -= n;
            }
        }

        public void RemoveNElementsFromStart(int n)
        {
            int index = 0;
            RemoveNElementsByIndex(n, index);
        }

        public void RemoveNElementsByIndex(int n, int index)
        {
            if (index >= 0 && index < Length)
            {
                if (n >= 0 && n <= Length)
                {
                    if (Length == 1)
                    {
                        _root = null;
                        _tail = null;
                        Length--;
                    }
                    else if (Length == n)
                    {
                        _root = null;
                        _tail = null;
                        Length = 0;
                    }
                    else
                    {
                        DNode current1 = _root;
                        DNode current2 = _root;

                        for (int i = 0; i < index - 1; i++)
                        {
                            current1 = current1.Next;
                        }

                        for (int i = 0; i < index + n; i++)
                        {
                            current2 = current2.Next;
                        }

                        if (index == 0)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                current1 = current1.Next;
                            }

                            _root = current1;
                        }
                        else if (current2 is null)
                        {
                            _tail = current1;
                        }
                        else
                        {
                            current1.Next = current2.Next;
                        }

                        Length -= n;
                    }
                }
                else
                {
                    throw new ArgumentException("N is incorrect");
                }
            }
            else if (Length == 0)
            {
                throw new NullReferenceException();
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int RemoveElementByValue(int value)
        {
            if (Length != 0)
            {
                DNode current = _root;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value == value)
                    {
                        RemoveByIndex(i);

                        return i;
                    }

                    current = current.Next;
                }

                return -1;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public int RemoveAllElementsByValue(int value)
        {
            if (Length != 0)
            {
                int countRemoveElements = 0;
                DNode current = _root;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value == value)
                    {
                        RemoveByIndex(i);
                        --i;
                        ++countRemoveElements;
                    }

                    current = current.Next;
                }

                return -1;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public int GetIndexbyValue(int value)
        {
            if (Length != 0)
            {
                DNode current = _root;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value == value)
                    {
                        return i;
                    }

                    current = current.Next;
                }

                return -1;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Reverse()
        {
            if (Length != 0)
            {
                DNode current = _root;
                DNode tmp = _tail;
                int value;
                int count = 0;

                while (count != Length / 2)
                {
                    value = current.Value;
                    current.Value = tmp.Value;
                    tmp.Value = value;

                    current = current.Next;
                    tmp = tmp.Previous;

                    ++count;
                }
            }
            else
            {
                throw new NullReferenceException("Error");
            }
        }

        public int GetIndexMaxValue()
        {
            if (Length != 0)
            {
                DNode current = _root;
                int maxValue = current.Value;
                int indexOfMaxValue = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value > maxValue)
                    {
                        maxValue = current.Value;
                        indexOfMaxValue = i;
                    }

                    current = current.Next;
                }

                return indexOfMaxValue;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public int GetIndexMinValue()
        {
            if (Length != 0)
            {
                DNode current = _root;
                int minValue = current.Value;
                int indexOfMinValue = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value < minValue)
                    {
                        minValue = current.Value;
                        indexOfMinValue = i;
                    }

                    current = current.Next;
                }

                return indexOfMinValue;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public int GetMaxValue()
        {
            if (Length != 0)
            {
                DNode current = _root;
                int maxValue = current.Value;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value > maxValue)
                    {
                        maxValue = current.Value;
                    }

                    current = current.Next;
                }

                return maxValue;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public int GetMinValue()
        {
            if (Length != 0)
            {
                DNode current = _root;
                int minValue = current.Value;

                for (int i = 0; i < Length; i++)
                {
                    if (current.Value < minValue)
                    {
                        minValue = current.Value;
                    }

                    current = current.Next;
                }

                return minValue;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void AddLinkedList(DoubleLinkedList doubleLinkedList)
        {
            if ((!(doubleLinkedList._root is null)) && (!(_root is null)))
            {
                Length += doubleLinkedList.Length;
                DNode tmp = _tail;
                tmp.Next = doubleLinkedList._root;
                _tail = doubleLinkedList._tail;
            }
            else if (_root is null)
            {
                if (doubleLinkedList is null)
                {
                    return;
                }
                else
                {
                    Length += doubleLinkedList.Length;
                    _root = doubleLinkedList._root;
                }
            }
            else
            {
                return;
            }
        }

        public void AddLinkedListToStart(DoubleLinkedList doubleLinkedList)
        {
            if (doubleLinkedList._root is null)
            {
                return;
            }
            else
            {
                Length += doubleLinkedList.Length;
                DNode oldRoot = _root;
                DNode oldTail = doubleLinkedList._tail;
                oldTail.Next = oldRoot;
                _root = doubleLinkedList._root;
            }
        }

        public void AddLinkedListByIndex(DoubleLinkedList doubleLinkedList, int index)
        {
            if (index >= 0 && index < Length)
            {
                if (_root is null || doubleLinkedList._root is null)
                {
                    if (doubleLinkedList._root is null)
                    {
                        return;
                    }
                    else
                    {
                        _root = doubleLinkedList._root;
                        Length += doubleLinkedList.Length;
                    }
                }
                else if (index == 0)
                {
                    AddLinkedListToStart(doubleLinkedList);
                }
                else if (index == Length)
                {
                    AddLinkedList(doubleLinkedList);
                }
                else
                {
                    DNode previous = GetNodeByIndex(index - 1);
                    DNode next = GetNodeByIndex(index);
                    previous.Next = doubleLinkedList._root;
                    doubleLinkedList._tail.Next = next;
                    Length += doubleLinkedList.Length;
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Sort(bool isAscending)
        {
            for (int i = 0; i < Length; i++)
            {
                int max = i;
                var coef = isAscending ? 1 : -1;

                for (int j = i + 1; j < Length; j++)
                {
                    if (GetNodeByIndex(max).Value.CompareTo(GetNodeByIndex(j).Value) == coef)
                    {
                        max = j;
                    }
                }

                int temp = GetNodeByIndex(i).Value;
                GetNodeByIndex(i).Value = GetNodeByIndex(max).Value;
                GetNodeByIndex(max).Value = temp;
            }
        }

        public override string ToString()
        {
            DNode current = _root;
            string s = current.Value + " ";

            if (Length != 0)
            {
                while (!(current.Next is null))
                {
                    current = current.Next;
                    s += current.Value + " ";
                }

                return s;
            }
            else
            {
                return string.Empty;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is DoubleLinkedList)
            {
                DoubleLinkedList list = (DoubleLinkedList)obj;
                DNode currentThis = _root;
                DNode currentList = list._root;
                bool result = true;

                if (Length != list.Length)
                {
                    result = false;
                }
                else if (list.Length == 1)
                {
                    if (currentThis.Value != currentList.Value)
                    {
                        result = false;
                    }
                }
                else if (!((currentThis is null) && (currentList is null)))
                {
                    do
                    {
                        if (currentThis.Value != currentList.Value)
                        {
                            result = false;
                        }

                        currentThis = currentThis.Next;
                        currentList = currentList.Next;
                    }
                    while (!(currentThis.Next is null));
                }

                return result;
            }

            throw new ArgumentException($"Operator '==' cannot be applied to operands of type 'ArrayList' and '{obj}'");
        }

        private DNode GetNodeByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                DNode current;

                if (index < (int)(Length / 2))
                {
                    current = _root;

                    for (int i = 1; i <= index; i++)
                    {
                        current = current.Next;
                    }
                }
                else
                {
                    current = _tail;
                    int indexBack = Length - 1 - index;

                    for (int i = 1; i <= indexBack; ++i)
                    {
                        current = current.Previous;
                    }
                }

                return current;
            }

            throw new IndexOutOfRangeException();
        }
    }
}