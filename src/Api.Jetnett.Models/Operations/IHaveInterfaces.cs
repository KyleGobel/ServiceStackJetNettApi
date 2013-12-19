namespace Api.JetNett.Models.Operations
{
    /// <summary>
    /// Base Contracts to use with the Basic Service
    /// </summary>
    public interface IHaveId
    {
        int Id { get; set; }
    }
    public interface IHaveManyIds
    {
        int[] Ids { get; set; }
    }

    public interface IHaveEntity<TModel> where TModel : class
    {
        TModel Entity { get; set; }
    }
}