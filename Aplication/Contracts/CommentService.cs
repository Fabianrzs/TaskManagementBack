using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Aplication.Contracts
{
    public class CommentService : GenericService<Comment>, ICommentService
    {
        public CommentService(ICommentRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(repository, unitOfWork, mapper)
        {
        }
    }
}
