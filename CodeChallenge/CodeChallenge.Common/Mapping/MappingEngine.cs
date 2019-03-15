using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Common.Mapping
{
    public class MappingEngine : IMappingEngine
    {
        private readonly ILogger<MappingEngine> _logger;
        private readonly IMapper _mapper;

        public MappingEngine(IEnumerable<Assembly> assembliesToScan, ILogger<MappingEngine> logger)
        {
            _logger = logger;
            var config = new MapperConfiguration(
                cfg => cfg.AddProfiles(assembliesToScan));
            config.AssertConfigurationIsValid();
            _mapper = config.CreateMapper();
        }

        public TDestiny Map<TSource, TDestiny>(TSource source)
        {
            try
            {
                return _mapper.Map<TDestiny>(source);
            }
            catch (AutoMapperConfigurationException ex)
            {
                _logger.LogError("Cannot map {0} to {1}. Error: {2}", typeof(TSource), typeof(TDestiny), ex.Message);
                throw;
            }
        }

        public TSource Update<TSource, TCopyFrom>(TSource source, TCopyFrom copyFrom)
        {
            try
            {
                return _mapper.Map(copyFrom, source);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError("Cannot map {0} to {1}. Error: {2}", typeof(TSource), typeof(TCopyFrom), ex.Message);
                throw;
            }
        }
    }
}
