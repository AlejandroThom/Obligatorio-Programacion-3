namespace Mapper.InterfacesMapper
{
    public interface IMapper<T, U>
    {
        public abstract static T ToDto(U entity);
        public abstract static IEnumerable<T> ToListaDto(IEnumerable<U> entities);
    }
}
