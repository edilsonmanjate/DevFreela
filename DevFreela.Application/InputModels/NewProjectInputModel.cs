using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
