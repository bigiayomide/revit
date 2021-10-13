﻿using AutoMapper;
using Revix.Data.Interfaces;
using Revix.Data.IRepositories;
using Revix.Models;
using Revix.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Revix.Services.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly ICoinMarketCapService _coinMarketCapService;
        private readonly ICryptoListingRepo _crytoListingRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CryptoService(IMapper mapper, IUnitOfWork unitOfWork, ICoinMarketCapService coinMarketCapService,
        ICryptoListingRepo crytoListingRepo)
        {
            _coinMarketCapService = coinMarketCapService;
            _crytoListingRepo = crytoListingRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CryptoListingVM> GetandSaveCryptoData(CryptoListingSortDataVM cryptoListingSort)
        {
            var data = await _coinMarketCapService.GetCryptoRates(cryptoListingSort);
            await SaveCryptoData(data);
            return data;
        }

        public async Task SaveCryptoData(CryptoListingVM cryptoListing)
        {
            var entity = _mapper.Map<List<CryptoListing>>(cryptoListing.Data);
            foreach (var item in entity)
            {
                var getlisting = _crytoListingRepo.List(x => x.Id == item.Id).FirstOrDefault();

                if (getlisting != null && (getlisting.LastUpdated < item.LastUpdated || getlisting.LastUpdatedPrice < item.LastUpdatedPrice))
                {
                    _crytoListingRepo.Update(item);
                }
                else if (getlisting == null)
                    _crytoListingRepo.Add(item);
            }

            await _unitOfWork.CommitAsync();
        }
    }
}
