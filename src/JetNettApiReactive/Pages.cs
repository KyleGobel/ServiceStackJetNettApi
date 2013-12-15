using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using Api.JetNett.Models.Mixins;

namespace JetNettApiReactive
{
    public interface IReactiveRepository<T> where T : class
    {
        IObservable<List<T>> GetAll();
        IObservable<T> GetById(int id);
    }
}