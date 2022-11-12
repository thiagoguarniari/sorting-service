namespace CrossCutting.CustomException
{
    public class SorterException : Exception
    {
        public SorterException()
            : base("Erro ao ordenar a lista de livros") { }
    }
}