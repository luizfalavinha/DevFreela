using MediatR;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest<Unit> // Unit (struct sem valor no retorno, unit = empty)
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
        public int IdFreelancer { get; set; }
        public decimal TotalCost { get; set; }
    }
}
