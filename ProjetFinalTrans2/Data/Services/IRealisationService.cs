using ProjetFinalTrans2.Models;
using System.Collections.Generic;

namespace ProjetFinalTrans2.Data.Services
{
    public interface IRealisationService
    {
        IEnumerable<Realisation> GetAll();
        Realisation GetById(int id);
    

    void Add(Realisation realisation);

    void Update(Realisation realisation);

    void Delete(int id);


    }
}
