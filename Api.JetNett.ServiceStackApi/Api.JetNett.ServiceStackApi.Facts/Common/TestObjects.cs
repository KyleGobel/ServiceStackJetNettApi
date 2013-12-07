using System.Collections.Generic;
using Api.JetNett.Models.Contracts;

namespace Api.JetNett.ServiceStackApi.Facts.Common
{
    public class TestEntity
    {
        public int Id { get; set; }
    }

    public class TestRequestDTO : IRequestDTO<TestEntity>
    {
        public IEnumerable<int> Ids { get; set; }
        public TestEntity Entity { get; set; }
    }

    public class TestResponseDTO : IResponseDTO<TestEntity>
    {
        public IEnumerable<TestEntity> Entities { get; set; }
    }
}