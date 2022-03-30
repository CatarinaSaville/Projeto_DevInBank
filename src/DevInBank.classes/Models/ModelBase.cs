using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.classes.Models
{
    public class ModelBase
    {
        public string Id { get; private set; }

        protected ModelBase() { }

        protected ModelBase(string id) => Id = id;
    }
}
