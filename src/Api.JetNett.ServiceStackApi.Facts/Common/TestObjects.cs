using Api.JetNett.Models.Operations;

namespace Api.JetNett.ServiceStackApi.Facts.Common
{
    public class TestEntity
    {
        public int Id { get; set; }
    }

    public class TestsDTO : IGetRequestDTO
    {
        public TestsDTO(params int[] ids)
        {
            this.Ids = ids;
        }
        public int[] Ids { get; set; }
    }
}