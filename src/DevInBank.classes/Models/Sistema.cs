
public class Sistema
{
    private DateTime _dataSistema = DateTime.Now;
    public DateTime DataSistema { get { return _dataSistema; } }
    //public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

    public void AlterarDataSistem(DateTime novaData)
    {
        // TODO: aplicar multa nos inadimplentes
        _dataSistema = novaData;
    }
}

