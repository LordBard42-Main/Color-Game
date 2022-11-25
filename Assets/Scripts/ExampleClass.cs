using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ExampleClass
    {
        [SerializeField]
        private int index;

        public ExampleClass(int index)
        {
            this.index = index;
        }

        public int Index { get => index; set => index = value; }

        public int GetIndex()
        {
            return index;
        }
        public void SetIndex(int index)
        {
            this.index = index;
        }
    }
}