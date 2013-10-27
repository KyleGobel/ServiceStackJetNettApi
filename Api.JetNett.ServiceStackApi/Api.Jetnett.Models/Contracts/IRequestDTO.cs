using System.Collections.Generic;

namespace Api.JetNett.Models.Contracts
{
    public interface IRequestDTO<T> where T : class
    {
        int Id { get; set; }
        T Entity { get; set; }
    }

    public interface IResponseDTO<T> where T : class
    {
        T Entity { get; set; }
        List<T> Entities { get; set; }
    }
}