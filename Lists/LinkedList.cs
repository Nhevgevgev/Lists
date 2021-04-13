using System;

namespace Lists
{
    public class LinkedList
    {
        private Node _root;
        private Node _tail;
        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                Node node = GetNodeByIndex(index);

                return node.Value;
            }
            set
            {
                Node node = GetNodeByIndex(index);
                node.Value = value;
            }
        }

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        private LinkedList(int[] values)
        {
            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
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

        public static LinkedList Create(int[] values)
        {
            if (!(values is null))
            {
                return new LinkedList(values);
            }

            throw new NullReferenceException("Values is null");
        }

        public void Add(int value)
        {
            if (Length != 0)
            {
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
            else
            {
                _root = new Node(value);
                _tail = _root;
            }

            Length++;
        }

        public void AddFirst(int value)
        {
            Node tmp = new Node(value);
            tmp.Next = _root;
            _root = tmp;
            Length++;
        }

        public void AddByIndex(int value, int index)
        {
            if (index >= 0 && index <= Length)
            {
                if (index != 0)
                {
                    Node current = _root;

                    for (int i = 1; i < index; i++)
                    {
                        current = current.Next;
                    }

                    Node tmp = new Node(value);
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
                        Node current = _root;

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

        public void RemoveNElements(int n)
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
            else if (n < 0 || n > Length)
            {
                throw new ArgumentException("N is incorrect");
            }
            else if (n == Length)
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
            else
            {
                Node current = _root;

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
            RemoveNElementsByIndex(n, 0);
        }

        public void RemoveNElementsByIndex(int n, int index)
        {
            if (index >= 0 && index < Length)
            {
                if (n < 0 || n > Length)
                {
                    throw new ArgumentException("N is incorrect");
                }
                else
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
                        Node current1 = _root;
                        Node current2 = _root;

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
                Node current = _root;

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
                Node current = _root;

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

                return countRemoveElements;
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
                Node current = _root;

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
                Node prev = null;
                Node current = _root;

                while (!(current is null))
                {
                    Node next = current.Next;
                    current.Next = prev;
                    prev = current;
                    current = next;
                }

                _tail = _root;
                _root = prev;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public int GetIndexMaxValue()
        {
            if (Length != 0)
            {
                Node current = _root;
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
                Node current = _root;
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
                Node current = _root;
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
                Node current = _root;
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

        public void AddLinkedList(LinkedList linkedList)
        {
            if ((!(linkedList._root is null)) && (!(_root is null)))
            {
                Length += linkedList.Length;
                Node tmp = _tail;
                tmp.Next = linkedList._root;
                _tail = linkedList._tail;
            }
            else if (_root is null)
            {
                if (linkedList is null)
                {
                    return;
                }
                else
                {
                    Length += linkedList.Length;
                    _root = linkedList._root;
                }
            }
            else
            {
                return;
            }
        }

        public void AddLinkedListToStart(LinkedList linkedList)
        {
            if (linkedList._root is null)
            {
                return;
            }
            else if (this is null)
            {
                Length += linkedList.Length;
                _root = linkedList._root;
            }
            else
            {
                Length += linkedList.Length;
                Node oldRoot = _root;
                Node oldTail = linkedList._tail;
                oldTail.Next = oldRoot;
                _root = linkedList._root;
            }
        }

        public void AddLinkedListByIndex(LinkedList linkedList, int index)
        {
            if (index >= 0 && index < Length)
            {
                if (_root is null || linkedList._root is null)
                {
                    if (linkedList._root is null)
                    {
                        return;
                    }
                    else
                    {
                        _root = linkedList._root;
                        Length += linkedList.Length;
                    }
                }
                else if (index == 0)
                {
                    AddLinkedListToStart(linkedList);
                }
                else if (index == Length)
                {
                    AddLinkedList(linkedList);
                }
                else
                {
                    Node previous = GetNodeByIndex(index - 1);
                    Node next = GetNodeByIndex(index);
                    previous.Next = linkedList._root;
                    linkedList._tail.Next = next;
                    Length += linkedList.Length;
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
            Node current = _root;
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
            if (obj is LinkedList)
            {
                LinkedList list = (LinkedList)obj;
                Node currentThis = _root;
                Node currentList = list._root;
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

        private Node GetNodeByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                Node current = _root;

                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                return current;
            }

            throw new IndexOutOfRangeException();
        }
    }
}