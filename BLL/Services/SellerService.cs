﻿using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public  class SellerService
    {
        public static List<SellerDTO> Get()
        {
            var data = DataAccessFactory.SellerData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Seller, SellerDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<SellerDTO>>(data);
            return mapped;
        }

        public static SellerDTO Get(string Sname)
        {
            var data = DataAccessFactory.SellerData().Read(Sname);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Seller, SellerDTO>();

            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SellerDTO>(data);
            return mapped;
        }


        public static Seller Create(SellerDTO seller)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SellerDTO, Seller>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Seller>(seller);
            var res = DataAccessFactory.SellerData().Create(mapped);
            return mapped;
        }

        public static Seller Update(SellerDTO seller)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SellerDTO, Seller>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Seller>(seller);
            var res = DataAccessFactory.SellerData().Create(mapped);
            return mapped;
        }
        public static bool Delete(string Sname)
        {
            return DataAccessFactory.SellerData().Delete(Sname);
        }
    }
}
