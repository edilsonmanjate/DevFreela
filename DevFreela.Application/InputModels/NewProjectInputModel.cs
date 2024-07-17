namespace DevFreela.Application.InputModels
{
    public class NewProjectInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
        public int IdCliente { get; set; }
        public int IdFreelancer { get; set; }

    }
}
