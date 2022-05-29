using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Utilities
{
    public static class MyStoreMapper<TSource, TDestination>
    {
        private static Mapper _myStoreMapper = new Mapper(new MapperConfiguration(
            cfg => cfg.CreateMap<TSource, TDestination>().ReverseMap()));

        public static TDestination Map(TSource source)
        {
            return _myStoreMapper.Map<TDestination>(source);
        }

        public static IEnumerable<TDestination> MapList(List<TSource> source)
        {
            var list = new List<TDestination>();
            source.ForEach(x => { list.Add(Map(x)); });
            return list;
        }
    }
}
