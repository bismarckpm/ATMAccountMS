using AccountMS.Commons.Dtos.Respose;
using MediatR;

namespace AccountMS.Application.Queries
{
    public class GetAccountQuery : IRequest<GetAccountDto>
    {
        public Guid Id { get; set; }

        public GetAccountQuery(Guid id)
        {
            Id = id;
        }
    }
}
