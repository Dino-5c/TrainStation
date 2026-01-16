using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Route;
using TrainStation.Domain.Entities;
using TrainStation.Application.Services.Abstractions.Base;
using TrainStation.Repositories.Abstractions;
using TrainStation.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace TrainStation.Application.Services
{
    public class RouteApplicationService(
        IRepository<Route, Guid> routeRepository,
        IRepository<Administrator, Guid> administratorRepository,
        IMapper mapper) : IApplicationService<RouteModel, CreateRouteModel, Guid>
    {
        private readonly ApplicationDbContext Dbcontext;

        /// <summary>
        /// Получение всех моделей
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RouteModel>> GetModelsAsync(CancellationToken cancellationToken = default)
            => (await routeRepository.GetAllAsync(cancellationToken, true))
            .Select(mapper.Map<RouteModel>);

        /// <summary>
        /// Получение маршрута по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RouteModel?> GetModelByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var route = await routeRepository.GetByIdAsync(id, cancellationToken);
            return route is null ? null : mapper.Map<RouteModel>(route);
        }

        /// <summary>
        /// Добавление маршрута
        /// </summary>
        /// <param name="routeInformation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RouteModel?> CreateModelAsync(CreateRouteModel routeInformation, CancellationToken cancellationToken = default)
        {
            var administrator = await administratorRepository.GetByIdAsync(routeInformation.AdministratorId, cancellationToken);
            if (administrator is null)
                return null;

            var route = administrator.CreateRoute(new(routeInformation.RouteName));
            if (route is null)
                return null;

            var updatedAdministrator = await administratorRepository.UpdateAsync(administrator, cancellationToken); // Обновление администратора

            var createdRoute = await routeRepository.AddAsync(route, cancellationToken);
            return createdRoute is null ? null : mapper.Map<RouteModel>(createdRoute);
        }

        /// <summary>
        /// Обновление(изменение) информации, данных о маршруте
        /// </summary>
        /// <param name="routeInformation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> UpdateModelAsync(RouteModel routeInformation, CancellationToken cancellationToken = default)
        {
            var administratorTask = administratorRepository.GetByIdAsync(routeInformation.AdministratorId, cancellationToken);
            if (administratorTask is null)
                return false;
            var administrator = administratorTask.Result;

            var routeTask = routeRepository.GetByIdAsync(routeInformation.Id, cancellationToken);
            if (routeTask is null)
                return false;
            var route = routeTask.Result;

            var editionsRoute = administrator.SetRouteName(route!, new(routeInformation.RouteName));
            if(editionsRoute is null)
                return false;

            return await routeRepository.UpdateAsync(editionsRoute, cancellationToken);
        }

        public async Task<bool> DeleteModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var route = await routeRepository.GetByIdAsync(id, cancellationToken);
            if(route is null)
                return false;

            var administrator = await administratorRepository.GetByIdAsync(route.Administrator.Id, cancellationToken);
            if (administrator == null)
                return false;

            var isRouteClear = administrator.DeleteRoute(route);

            var stations = await Dbcontext.Set<Station>().Where(s => s.Route.Id == route.Id).ToListAsync(cancellationToken); // Удаление всех станций маршрута из базы данных
            Dbcontext.Set<Station>().RemoveRange(stations);
            await Dbcontext.SaveChangesAsync(cancellationToken);

            var updatedAdministrator = await administratorRepository.UpdateAsync(administrator, cancellationToken); // Обновление администратора

            return isRouteClear ? await routeRepository.DeleteAsync(route, cancellationToken) : false;
        }
    }
}
