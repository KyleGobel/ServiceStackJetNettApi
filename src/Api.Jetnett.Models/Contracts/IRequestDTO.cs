using System.Collections.Generic;
using Api.JetNett.Models.Types;

namespace Api.JetNett.Models.Contracts
{
    public interface IRequestDTO<T> where T : class
    {
        IEnumerable<int> Ids { get; set; } 
        T Entity { get; set; }
    }

    public interface IResponseDTO<T> where T : class
    {
        IEnumerable<T> Entities { get; set; }
    }
}