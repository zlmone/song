using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.WinForm.Common
{
    public class Validation
    {
        private List<BaseValidateItem> items = new List<BaseValidateItem>();

        public void Add(BaseValidateItem item) {
            this.items.Add(item);
        }
        public void RemoveAt(int index) {
            if (items.Count > index)
            {
                this.items[index].ClearError();
                this.items.RemoveAt(index);
            }
        }
        public void Clear() {
            for (int i = 0; i < this.items.Count; i++)
            {
                this.RemoveAt(i); i--;
            }
        }
        public void ClearError() {
            for (int i = 0; i < this.items.Count; i++)
            {
                this.items[i].ClearError();
            }
        }
        public bool IsValid()
        {
            bool result = true;

            foreach (BaseValidateItem item in items)
            {
                if (!item.Check())
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
