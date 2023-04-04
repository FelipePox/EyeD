﻿using AutoMapper;
using EyeD.Application.Interfaces;
using EyeD.Application.ViewModels.Peoples;
using EyeD.Domain.Entities;
using EyeD.Domain.Interfaces;
using EyeD.Domain.ValueObjects;
using EyeD.Infra.Data.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeD.Application.Services
{
    public class PeopleServices : IPeopleServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPeopleRepository _peopleRepository;

        public PeopleServices(IMapper mapper, IUnitOfWork unitOfWork, IPeopleRepository peopleRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _peopleRepository = peopleRepository;
        }

        public async Task<ResponsePeopleViewModel> Create(RequestPeopleViewModel viewModel)
        {
            var people = new People(
                new FullName(viewModel.FirstName, viewModel.SecondName, viewModel.ThirdName),
                new FaceId(viewModel.FaceId),
                new ImageId(viewModel.ImageId),
                new ExternalImageId(viewModel.ExternalImageId),
                new ReferenceDocument(viewModel.ReferenceDocument)
                );

            if (!people.IsValid)
                throw new Exception("Os dados inseridos estão inválidos.");

            var peopleResponse = await _peopleRepository.Insert(people);

            if (await _unitOfWork.SaveChangesAsync() <= 0)
                throw new Exception("Erro ao salvar a Pessoa.");

            return _mapper.Map<ResponsePeopleViewModel>(peopleResponse);
        }

        public async Task<bool> Delete(Guid id)
        {
            var peopleExistente = await _peopleRepository.GetOneWhere(p => p.Id == id);
            if (peopleExistente is null)
                throw new Exception("Pessoa inexistente.");

            await _peopleRepository.Delete(peopleExistente);

            if (await _unitOfWork.SaveChangesAsync() <= 0)
                throw new Exception("Erro ao salvar as alterações em Pessoa.");

            return true;

        }

        public async Task<ResponsePeopleViewModel> Edit(Guid id, RequestPeopleViewModel viewModel)
        {
            var peopleExistente = await _peopleRepository.GetOneWhere(p => p.Id == id);

            if (peopleExistente is null)
                throw new Exception("Pessoa inexistente.");

             peopleExistente.Update(
               new FullName(viewModel.FirstName, viewModel.SecondName, viewModel.ThirdName),
               new FaceId(viewModel.FaceId),
               new ImageId(viewModel.ImageId),
               new ExternalImageId(viewModel.ExternalImageId),
               new ReferenceDocument(viewModel.ReferenceDocument)
               );

            if (!peopleExistente.IsValid)
                throw new Exception("Os dados inseridos estão inválidos.");

            var peopleResponse = await _peopleRepository.Update(peopleExistente);

            if (await _unitOfWork.SaveChangesAsync() <= 0)
                throw new Exception("Erro ao salvar as alterações em Pessoa.");

            return _mapper.Map<ResponsePeopleViewModel>(peopleResponse);
        }

        public async Task<List<ResponsePeopleViewModel>> GetAll()
          => _mapper.Map<List<ResponsePeopleViewModel>>
                (await  _peopleRepository.GetAll());

        public async Task<ResponsePeopleViewModel> GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("Id inválido.");

            var peopleExistente = await _peopleRepository.GetOneWhere(p => p.Id == id);

            if (peopleExistente is null)
                throw new Exception("Pessoa inexistente.");

            return _mapper.Map<ResponsePeopleViewModel>(peopleExistente);

        }
    }
}
