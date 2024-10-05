﻿using E_commerceManagementSystem.BLL.DTOs.GeneralResponseDto;
using E_commerceManagementSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceManagementSystem.BLL.Manager.GeneralManager
{
    public class Manager<T> : IManager<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Manager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<GeneralRespons> GetAllAsync()
        {
            var respons = new GeneralRespons();


            var result = await _repository.GetAllAsync();
            if (!(result.Count == 0 || result == null))
            {
                respons.Success = true;
                respons.Model = result;
                respons.Message = $"{nameof(T)}sretrieved successfully";
                return respons;
            }
            else
            {
                respons.Success = false;
                respons.Model = null;
                respons.Message = $" {nameof(T)} not Found successfully";
                return respons;
            }

        }

        public async Task<GeneralRespons> GetByIdAsync(int id)
        {
            var respons =new GeneralRespons();
            var result = await _repository.GetByIdAsync(id);
            if(result!=null)
            {
                respons.Success = true;
                respons.Model = result;
                respons.Message = $"{nameof(T)} retrieved successfully";
                return respons;


            }
            else
            {
                respons.Success = false;
                respons.Model = null;
                respons.Message = $" {nameof(T)} not Found successfully";
                return respons;
            }
        }

        public async Task<GeneralRespons> AddAsync(T entity)
        {
            var response = new GeneralRespons();
            try
            {
               
                await _repository.AddAsync(entity);

                
                response.Success = true;
                response.Message = $"{nameof(entity)} added successfully"; 
                response.Model = entity;
                return response;
            }
            catch (Exception ex)
            {
              
                response.Success = false;
                response.Message = $"Error adding {nameof(entity)}: {ex.Message}"; 
                response.Model = null;
                return response;
            }


        }

        public async Task<GeneralRespons> UpdateAsync(T entity)
        {
            var response = new GeneralRespons();
            try
            {

                await _repository.UpdateAsync(entity);


                response.Success = true;
                response.Message = $"{nameof(entity)} added successfully";
                response.Model = entity;
                return response;
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = $"Error adding {nameof(entity)}: {ex.Message}";
                response.Model = null;
                return response;
            }
        }

        public async Task<GeneralRespons> DeleteAsync(T entity)
        {
            var response = new GeneralRespons();
            try
            {

                await _repository.DeleteAsync(entity);


                response.Success = true;
                response.Message = $"{nameof(entity)} added successfully";
                response.Model = entity;
                return response;
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = $"Error adding {nameof(entity)}: {ex.Message}";
                response.Model = null;
                return response;
            }
        }
    }

}
