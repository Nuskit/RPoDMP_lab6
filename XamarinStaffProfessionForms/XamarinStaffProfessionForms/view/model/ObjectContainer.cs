using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinStaffProfessionForms.view.model
{
    public class ObjectContainer<T>
        where T:class
    {
        public T Container { get; set; }

        public ObjectContainer(T value = null)
        {
            Container = value;
        }
    }
}
