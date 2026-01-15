using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStation.Application.Models.Station;
using TrainStation.Domain.Entities;
using TrainStation.Repositories.Abstractions;
using TrainStation.ValueObjects;
using TrainStation.Application.Services.Abstractions.Base;

namespace TrainStation.Application.Services
{
    public class StationApplicationService(
        IRepository<Station, Guid> stationRepository, IRepository<Administrator, Guid> administratorRepository,
        IRepository<Route, Guid> routeRepository, IRepository<Tariffes, Guid> tariffZoneRepository, IMapper mapper) : IApplicationService<StationModel, CreateStationModel, Guid>
    {
        /// <summary>
        /// Получение всех моделей
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<StationModel>> GetModelsAsync(CancellationToken cancellationToken = default)
            => (await stationRepository.GetAllAsync(cancellationToken, true))
            .Select(mapper.Map<StationModel>);

        /// <summary>
        /// Получение модели станции
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<StationModel?> GetModelByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var station = await stationRepository.GetByIdAsync(id, cancellationToken);
            return station is null ? null : mapper.Map<StationModel>(station);
        }

        /// <summary>
        /// Добавление станции
        /// </summary>
        /// <param name="stationInformation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<StationModel?> CreateModelAsync(CreateStationModel stationInformation, CancellationToken cancellationToken = default)
        {
            var routeById = routeRepository.GetByIdAsync(stationInformation.RouteId, cancellationToken);
            if (routeById is null)
                return null;

            var route = routeById.Result;

            var tariffZoneById = tariffZoneRepository.GetByIdAsync(stationInformation.TariffZoneId, cancellationToken);
            if (tariffZoneById is null)
                return null;

            var tariffZone = tariffZoneById.Result;

            var administratorById = administratorRepository.GetByIdAsync(route.Administrator.Id, cancellationToken);
            if (administratorById is null)
                return null;

            var administrator = administratorById.Result;

            var station = administrator.CreateStation(new StationName(stationInformation.StationName), route, tariffZone);

            if (station is null)
                return null;


            // route = mapper.Map<RouteModel>(route);
            var updatedRoute = await routeRepository.UpdateAsync(route, cancellationToken); // Нужно обновление маршрута, если станция добавлена в коллекцию маршрута?

            var createdStation = await stationRepository.AddAsync(station, cancellationToken);
            return createdStation is null ? null : mapper.Map<StationModel>(createdStation);
        }

        /// <summary>
        /// Обновление значений станции
        /// </summary>
        /// <param name="stationInformation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> UpdateModelAsync(StationModel stationInformation, CancellationToken cancellationToken = default)
        {
            var routeById = routeRepository.GetByIdAsync(stationInformation.RouteId, cancellationToken);
            if (routeById is null)
                return false;

            var route = routeById.Result;

            var tariffZoneById = tariffZoneRepository.GetByIdAsync(stationInformation.TariffZoneId, cancellationToken);
            if (tariffZoneById is null)
                return false;

            var tariffZone = tariffZoneById.Result;

            var administratorById = administratorRepository.GetByIdAsync(route.Administrator.Id, cancellationToken);
            if (administratorById is null)
                return false;

            var administrator = administratorById.Result;

            var stationById = stationRepository.GetByIdAsync(stationInformation.Id, cancellationToken);
            if (stationById is null)
                return false;

            var station = stationById.Result;

            var editStation = administrator.RedactStation(
                station!,
                new StationName(stationInformation.StationName),
                (Domain.Enums.StationStatus)stationInformation.StationStatus,
                tariffZone,
                route);

            if (editStation is null)
                return false;

            return await stationRepository.UpdateAsync(editStation, cancellationToken);
        }

        /// <summary>
        /// Удаление модели станции
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> DeleteModelAsync(Guid id, CancellationToken cancellationToken = default)
        {

            var stationById = stationRepository.GetByIdAsync(id, cancellationToken);
            if (stationById is null)
                return false;

            var station = stationById.Result;

            var routeById = routeRepository.GetByIdAsync(station.Route.Id, cancellationToken);
            if (routeById is null)
                return false;

            var route = routeById.Result;

            var administratorById = administratorRepository.GetByIdAsync(route.Administrator.Id, cancellationToken);
            if (administratorById is null)
                return false;

            var administrator = administratorById.Result;

            var isStationClear = administrator.DeleteStation(station, route);
            var updatedRoute = await routeRepository.UpdateAsync(route, cancellationToken); // Нужно обновление маршрута, если станция добавлена в коллекцию маршрута?

            // Если получилось удалить станцию из списка, удаляем из Базы Данных её тоже
            return isStationClear ? await stationRepository.DeleteAsync(station, cancellationToken) : false;



        }
    }
}
