using MediatR;

namespace TraversalCoreProje.CQRS.Commands.GuideCommands
{
    public class CreateGuideCommand : IRequest<Unit>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
