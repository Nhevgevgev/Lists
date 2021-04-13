using System;

namespace Lists
{
    public class ArrayList
    {
        private int _length;
        private int[] _array;
        private int _initLength = 10;

        public int Length
        {
            get
            {
                return _length;
            }
            private set
            {
                _length = value >= 0 ? value : 0;
            }
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < Length)
                {
                    return _array[index];
                }

                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Length)
                {
                    _array[index] = value;
                }

                throw new IndexOutOfRangeException();
            }
        }

        public ArrayList()
        {
            Length = 0;
            _array = new int[_initLength];
        }

        public ArrayList(int value)
        {
            Length = 1;
            _array = new int[_initLength];
            _array[0] = value;
        }

        private ArrayList(int[] values)
        {
            Length = values.Length;
            _array = new int[(values.Length * 2)];

            for (int i = 0; i < Length; i++)
            {
                _array[i] = values[i];
            }
        }

        public static ArrayList Create(int[] values)
        {
            if (!(values is null))
            {
                return new ArrayList(values);
            }

            throw new NullReferenceException("Values is null");
        }

        public void Add(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }

            _array[Length++] = value;
        }

        public void AddFirst(int value)
        {
            int index = 0;
            AddByIndex(value, index);
        }

        public void AddByIndex(int value, int index)
        {
            if (index >= 0 && index < Length)
            {
                if (Length == _array.Length)
                {
                    UpSize();
                }

                for (int i = Length; i > index; i--)
                {
                    _array[i] = _array[i - 1];
                }

                _array[index] = value;
                ++Length;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Remove()
        {
            int lastIndex = Length - 1;
            RemoveByIndex(lastIndex);
        }

        public void RemoveFirst()
        {
            RemoveByIndex(index: 0);
        }

        public void RemoveByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                if (index == Length - 1)
                {
                    --Length;
                }
                else
                {
                    for (int i = index; i < Length; i++)
                    {
                        _array[i] = _array[i + 1];
                    }

                    --Length;
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveNElements(int n)
        {
            if (n >= Length)
            {
                _array = new int[_initLength];
                Length = 0;
            }
            else
            {
                Length -= n;
                int[] tempArray = new int[Length];

                for (int i = 0; i < Length; i++)
                {
                    tempArray[i] = _array[i];
                }

                _array = tempArray;
            }
        }

        public void RemoveNElementsFromStart(int n)
        {
            RemoveNElementsByIndex(n, index: 0);
        }

        public void RemoveNElementsByIndex(int n, int index)
        {
            if (index >= 0 && index < Length && n >= 0)
            {
                if (n + index > Length)
                {
                    Length = index;
                }
                else
                {
                    for (int i = index; i < Length; i++)
                    {
                        if (i + n < _array.Length)
                        {
                            _array[i] = _array[i + n];
                        }
                    }

                    Length -= n;
                }

                DownSize();
            }
            else if (n < 0)
            {
                throw new ArgumentException("Incorrect n");
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int RemoveElementByValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    RemoveByIndex(i);

                    return i;
                }
            }

            return -1;
        }

        public int RemoveAllElementsByValue(int value)
        {
            int countRemoveElements = 0;
            int[] tempArray = new int[_array.Length];
            int tempArrayIndex = 0;

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] != value)
                {
                    tempArray[tempArrayIndex] = _array[i];
                    tempArrayIndex++;
                }
                else
                {
                    ++countRemoveElements;
                }
            }

            _array = tempArray;
            Length -= countRemoveElements;
            DownSize();

            return countRemoveElements;
        }

        public int GetIndexbyValue(int value)
        {
            var result = -1;

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public void Reverse()
        {
            for (int i = 0; i < Length / 2; i++)
            {
                Swap(ref _array[i], ref _array[Length - i - 1]);
            }
        }

        public int GetIndexMaxValue()
        {
            int indexOfMaxElement = 0;

            for (int i = 1; i < Length; ++i)
            {
                if (_array[indexOfMaxElement] < _array[i])
                {
                    indexOfMaxElement = i;
                }
            }

            return indexOfMaxElement;
        }

        public int GetIndexMinValue()
        {
            int indexMinValue = 0;

            for (int i = 1; i < Length; ++i)
            {
                if (_array[indexMinValue] > _array[i])
                {
                    indexMinValue = i;
                }
            }

            return indexMinValue;
        }

        public int GetMaxValue()
        {
            return _array[GetIndexMaxValue()];
        }

        public int GetMinValue()
        {
            return _array[GetIndexMinValue()];
        }

        public void AddArrayList(ArrayList list)
        {
            int lastIndex = Length;
            AddArrayListByIndex(list, lastIndex);
        }

        public void AddArrayListToStart(ArrayList list)
        {
            int firstIndex = 0;
            AddArrayListByIndex(list, firstIndex);
        }

        public void AddArrayListByIndex(ArrayList list, int index)
        {
            if (index >= 0 && index <= Length)
            {
                Length += list.Length;

                if (Length >= _array.Length)
                {
                    UpSize();
                }

                int n = list.Length;

                for (int i = Length - 1; i >= index; i--)
                {
                    if (i + n < _array.Length)
                    {
                        _array[i + n] = _array[i];
                    }
                }

                int count = 0;

                for (int i = index; i < Length; i++)
                {
                    if (count < list.Length)
                    {
                        _array[i] = list[count++];
                    }
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Sort(bool isAscending)
        {
            if (_array.Length >= 0)
            {
                var coef = isAscending ? 1 : -1;

                for (int i = 0; i < Length - 1; i++)
                {
                    for (int j = i + 1; j < Length; j++)
                    {
                        if (_array[i].CompareTo(_array[j]) == coef)
                        {
                            Swap(ref _array[i], ref _array[j]);
                        }
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is ArrayList)
            {
                ArrayList list = (ArrayList)obj;
                bool result = true;

                if (Length == list.Length)
                {
                    for (int i = 0; i < Length; i++)
                    {
                        if (!_array[i].Equals(list._array[i]))
                        {
                            result = false;
                        }
                    }
                }
                else
                {
                    result = false;
                }

                return result;
            }

            throw new ArgumentException($"Operator '==' cannot be applied to operands of type 'ArrayList' and '{obj}'");
        }

        public override string ToString()
        {
            string s = string.Empty;

            for (int i = 0; i < Length; i++)
            {
                s += _array[i] + " ";
            }

            return s;
        }

        public override int GetHashCode()
        {
            return _array.GetHashCode();
        }

        private void UpSize()
        {
            int tempLength = (int)(_array.Length * 1.33d + 1);
            int[] tempArray = new int[tempLength];

            for (int i = 0; i < Length; i++)
            {
                tempArray[i] = _array[i];
            }

            _array = tempArray;
        }

        private void DownSize()
        {
            if (Length < _array.Length / 2 + 1)
            {
                int tempLength = (int)(Length * 1.33d + 1);
                int[] tempArray = new int[tempLength];

                for (int i = 0; i < Length; i++)
                {
                    tempArray[i] = _array[i];
                }

                _array = tempArray;
            }
        }

        private void Swap(ref int a, ref int b)
        {
            int tempValue = a;
            a = b;
            b = tempValue;
        }
    }
}