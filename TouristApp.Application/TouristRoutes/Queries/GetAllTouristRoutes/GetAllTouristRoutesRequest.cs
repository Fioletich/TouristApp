using MediatR;
using TouristApp.Domain.Models;

namespace TouristApp.Application.TouristRoutes.Queries.GetAllTouristRoutes;

public class GetAllTouristRoutesRequest : IRequest<IEnumerable<TouristRoute>>{ }