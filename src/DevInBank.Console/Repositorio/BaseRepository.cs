using DevInBank.classes.Models;
using DevInBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.Console.Repositorio
{
    public class BaseRepository<T>: IBaseRepository<T> where T: ModelBase
    {
        public IList<T> Elementos { get; set; }

        public BaseRepository() => Elementos = new List<T>();

        public void AdicionarElemento(T elemento) => Elementos.Add(elemento);

        public void ApagarElemento(string id) => Elementos.Remove(RetornarElemento(id));

        public T RetornarElemento(string id) =>
                Elementos.FirstOrDefault(ele => ele.Id == id)
                ?? throw new Exception($"Elemento com id {id} não existe");
    }
}
