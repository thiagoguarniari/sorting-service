namespace CrossCutting.CustomException
{
    public class OrdererException : Exception
    {
        public OrdererException()
            : base("Erro ao ordenar a lista de livros") { }
    }
}