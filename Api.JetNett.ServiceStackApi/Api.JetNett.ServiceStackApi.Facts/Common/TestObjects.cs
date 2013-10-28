using System.Collections.Generic;
using Api.JetNett.Models.Contracts;

namespace Api.JetNett.ServiceStackApi.Facts.Common
{
    public class TestEntity
    { }

    public class TestRequestDTO : IRequestDTO<TestEntity>
    {
        public int Id { get; set; }
        public TestEntity Entity { get; set; }
    }

    public class TestResponseDTO : IResponseDTO<TestEntity>
    {
        public TestEntity Entity { get; set; }
        public List<TestEntity> Entities { get; set; }
    }
}