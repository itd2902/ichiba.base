using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IChiba.Core.Domain;
using IChiba.Core.Domain.Master;
using IChiba.Core.Infrastructure;
using IChiba.Data;
using LinqToDB;

namespace IChiba.Services.Common
{
    public partial class SPAddressService : ISPAddressService
    {
        #region Constants



        #endregion

        #region Fields

        private readonly IRepository<SPAddress> _spAddressRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<StateProvince> _stateProvinceRepository;
        private readonly IRepository<District> _districtRepository;
        private readonly IRepository<Ward> _wardRepository;

        #endregion

        #region Ctor

        public SPAddressService(
            )
        {
            _spAddressRepository = EngineContext.Current.Resolve<IRepository<SPAddress>>(DataConnectionHelper.ConnectionStringNames.Master);
            _countryRepository = EngineContext.Current.Resolve<IRepository<Country>>(DataConnectionHelper.ConnectionStringNames.Master);
            _stateProvinceRepository = EngineContext.Current.Resolve<IRepository<StateProvince>>(DataConnectionHelper.ConnectionStringNames.Master);
            _districtRepository = EngineContext.Current.Resolve<IRepository<District>>(DataConnectionHelper.ConnectionStringNames.Master);
            _wardRepository = EngineContext.Current.Resolve<IRepository<Ward>>(DataConnectionHelper.ConnectionStringNames.Master);
        }

        #endregion

        #region Methods

        public virtual async Task<IList<SPAddress>> GetByEntity_SelectAsync(EntityType entityType, string entityId)
        {
            var query =
                from x in _spAddressRepository.Table
                join c in _countryRepository.Table on x.CountryId equals c.Id
                join s in _stateProvinceRepository.Table on x.StateProvinceId equals s.Id into xs
                join d in _districtRepository.Table on x.DistrictId equals d.Id into xd
                join w in _wardRepository.Table on x.WardId equals w.Id into xw

                from s in xs.DefaultIfEmpty()
                from d in xd.DefaultIfEmpty()
                from w in xw.DefaultIfEmpty()

                where x.EntityType == (int)entityType && x.EntityId == entityId
                orderby x.Type, x.CreatedOnUtc descending
                select new SPAddress
                {
                    Id = x.Id,
                    Type = x.Type,
                    AddressName = x.AddressName,
                    FullName = x.FullName,
                    Email = x.Email,
                    Company = x.Company,
                    CountryId = x.CountryId,
                    StateProvinceId = x.StateProvinceId,
                    City = x.City,
                    DistrictId = x.DistrictId,
                    WardId = x.WardId,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    ZipPostalCode = x.ZipPostalCode,
                    PhoneNumber = x.PhoneNumber,
                    FaxNumber = x.FaxNumber,
                    IsLocalLanguage = x.IsLocalLanguage,
                    Country = new Country
                    {
                        Id = c.Id,
                        Code = c.Code,
                        Name = c.Name
                    },
                    StateProvince = s ?? new StateProvince
                    {
                        Id = s.Id,
                        Code = s.Code,
                        Name = s.Name
                    },
                    District = d ?? new District
                    {
                        Id = d.Id,
                        Code = d.Code,
                        Name = d.Name
                    },
                    Ward = w ?? new Ward
                    {
                        Id = w.Id,
                        Code = w.Code,
                        Name = w.Name
                    }
                };

            return await query.ToListAsync();
        }

        public async Task<IList<SPAddress>> GetByEntity_SelectAsync(SPAddressSearchModel searchModel)
        {
            var query = QueryBuilder(searchModel.EntityType, searchModel.EntityId, searchModel.Keywords, searchModel.Take);
            return await query.ToListAsync();
        }

        private IQueryable<SPAddress> QueryBuilder(EntityType entityType, string entityId, string keywords, int? take = null)
        {
            var query = from x in _spAddressRepository.Table
                        where x.EntityType == (int)entityType && x.EntityId == entityId
                        select x;
            if (!string.IsNullOrEmpty(keywords))
            {
                query = from x in query
                        where x.FullName.ToLower().Contains(keywords.ToLower())|| x.AddressName.ToLower().Contains(keywords.ToLower())
                        select x;
            }
            if (take != null && take > 0)
            {
                query = query.Take(take.Value);
            }
            query =
                from x in query
                join c in _countryRepository.Table on x.CountryId equals c.Id
                join sta in _stateProvinceRepository.Table on x.StateProvinceId equals sta.Id into staJoin
                join dis in _districtRepository.Table on x.DistrictId equals dis.Id into disJoin
                join wad in _wardRepository.Table on x.WardId equals wad.Id into wadJoin
                from s in staJoin.DefaultIfEmpty()
                from d in disJoin.DefaultIfEmpty()
                from w in wadJoin.DefaultIfEmpty()
                orderby x.Type, x.CreatedOnUtc descending
                select new SPAddress
                {
                    Id = x.Id,
                    Type = x.Type,
                    AddressName = x.AddressName,
                    FullName = x.FullName,
                    Email = x.Email,
                    Company = x.Company,
                    CountryId = x.CountryId,
                    StateProvinceId = x.StateProvinceId,
                    City = x.City,
                    DistrictId = x.DistrictId,
                    WardId = x.WardId,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    ZipPostalCode = x.ZipPostalCode,
                    PhoneNumber = x.PhoneNumber,
                    FaxNumber = x.FaxNumber,
                    IsLocalLanguage = x.IsLocalLanguage,
                    Country = new Country
                    {
                        Id = c.Id,
                        Code = c.Code,
                        Name = c.Name
                    },
                    StateProvince = s ?? new StateProvince
                    {
                        Id = s.Id,
                        Code = s.Code,
                        Name = s.Name
                    },
                    District = d ?? new District
                    {
                        Id = d.Id,
                        Code = d.Code,
                        Name = d.Name
                    },
                    Ward = w ?? new Ward
                    {
                        Id = w.Id,
                        Code = w.Code,
                        Name = w.Name
                    }
                };
            return query;
        }

        #endregion
    }
}
