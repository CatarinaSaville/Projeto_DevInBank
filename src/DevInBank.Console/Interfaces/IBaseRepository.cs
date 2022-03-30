using DevInBank.classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.Interfaces
{
    public interface IBaseRepository<T> where T : ModelBase
    {
        public void AdicionarElemento(T elemento);

        public void ApagarElemento(string id);

        public T RetornarElemento(string id);
    }
}
